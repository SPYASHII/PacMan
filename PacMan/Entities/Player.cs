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

        private static readonly Dictionary<Directions, Action<Player, int>> _moveActions = new()
        {
            { Directions.Left, (p,s) => p.SetCoordinates(p.Coordinates.X - s, p.Coordinates.Y)},
            { Directions.Right, (p,s) => p.SetCoordinates(p.Coordinates.X + s, p.Coordinates.Y)},
            { Directions.Up, (p,s) => p.SetCoordinates(p.Coordinates.X, p.Coordinates.Y - s)},
            { Directions.Down, (p,s) => p.SetCoordinates(p.Coordinates.X, p.Coordinates.Y + s)}
        };
        public void Move(int step)
        {
            if(_moveActions.TryGetValue(Direction, out var action))
            {
                action(this, step);
            }
        }
        public void SetCoordinates(int x, int y)
        {
            Coordinates = new Coordinates(x, y);
        }
    }
}
