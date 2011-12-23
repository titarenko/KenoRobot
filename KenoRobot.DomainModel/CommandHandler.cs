﻿using System;
using System.IO;
using System.Net;
using Cqrsnes.Infrastructure;
using Ionic.Zip;
using System.Linq;
using KenoRobot.DomainModel.Commands;
using KenoRobot.DomainModel.Entities;

namespace KenoRobot.DomainModel
{
    public class CommandHandler : 
        ICommandHandler<PollServer>,
        ICommandHandler<AddDrawing>
    {
        private readonly IBus bus;
        private readonly IAggregateRootRepository repository;

        private readonly Guid historyId = new Guid("00715f58f09c4e4ca9c401edbd7c559d");

        public CommandHandler(IBus bus, IAggregateRootRepository repository)
        {
            this.bus = bus;
            this.repository = repository;
        }

        public void Handle(PollServer command)
        {
            using (var client = new WebClient())
            using (var stream = new MemoryStream(
                client.DownloadData("http://www.lottery.com.ua/main/keno_csv.zip")))
            using (var file = new ZipInputStream(stream))
            using (var reader = new StreamReader(file.GetNextEntry().OpenReader()))
            {
                // skip first line with headers
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var tokens = line.Split(',');
                    bus.Send(new AddDrawing
                        {
                            Drawing = new Drawing
                                {
                                    Number = int.Parse(tokens[0]),
                                    Date = DateTime.Parse(tokens[1]),
                                    Engine = tokens[2][0],
                                    BallsComplect = byte.Parse(tokens[3]),
                                    Balls = tokens.Skip(4).Select(byte.Parse).ToArray()
                                }
                        });
                }
            }
        }

        public void Handle(AddDrawing command)
        {
            var history = repository.GetById<History>(historyId);
            history.AddDrawing(command.Drawing);
            repository.Save(history);
        }
    }
}