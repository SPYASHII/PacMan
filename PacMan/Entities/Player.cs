using PacMan.Enums;
using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    internal class Player : IMoveble
    {
        public Coordinates Coordinates { get; private set; }
        public Directions Direction { get; set; }
        public Directions NextDirection { get; set; }
        public void Move(int step)
        {
            switch (Direction)
            {
                case Directions.Left:
                    SetCoordinates(Coordinates.X - step, Coordinates.Y);
                    break;
                case Directions.Right:
                    SetCoordinates(Coordinates.X + step, Coordinates.Y);
                    break;
                case Directions.Up:
                    SetCoordinates(Coordinates.X, Coordinates.Y - step);
                    break;
                case Directions.Down:
                    SetCoordinates(Coordinates.X, Coordinates.Y + step);
                    break;
                default:
                    break;
            }
        }
        public void SetCoordinates(int x, int y)
        {
            Coordinates = new Coordinates(x, y);
        }
    }
}
