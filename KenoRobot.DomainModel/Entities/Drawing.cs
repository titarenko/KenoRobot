using System;

namespace KenoRobot.DomainModel.Entities
{
    public class Drawing
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public char Engine { get; set; }

        public byte BallsComplect { get; set; }

        public byte[] Balls { get; set; }
    }
}