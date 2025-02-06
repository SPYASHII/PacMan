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
    internal class Enemy : IMoveble
    {
        public Coordinates Coordinates { get; private set; }
        public Directions Direction { get; set; }
        private Directions[] _directions = new Directions[2];
        private int _currentDir;

        public Enemy() { }
        //Уже не подходит //поправка: Подходит?
        public Enemy(Directions direction)
        {
            Direction = direction;

            if(Direction == Directions.Left || Direction == Directions.Right)
            {
                SetDirectionX();
            }
            else
            {
                SetDirectionY();
            }
        }

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
        public void SetDirectionX()
        {
            Direction = Directions.Right;

            _currentDir = 0;
            _directions[0] = Directions.Right;
            _directions[1] = Directions.Left;
        }
        public void SetDirectionY()
        {
            Direction = Directions.Down;

            _currentDir = 0;
            _directions[0] = Directions.Down;
            _directions[1] = Directions.Up;
        }
        public void ChangeDirection()
        {
            if (_currentDir + 1 == _directions.Length)
                _currentDir = 0;
            else
                _currentDir++;

            Direction = _directions[_currentDir];
        }
        public void SetCoordinates(int x, int y)
        {
            Coordinates = new Coordinates(x, y);
        }
    }
}
