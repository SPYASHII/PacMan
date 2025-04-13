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
        private int _directionSwitch; //Переменная для смены направления например: Вверх/Вниз

        //Ссылок - 0, удалить?
        public Enemy() { }
        //Уже не подходит //поправка: Подходит?
        //Вердикт: подходит :D
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
        //HACK: По сути идентичный с классом Player,
        //может лучше сделать IMoveble абстрактным классом и реализовать в нём Move?
        //Будет ли это считаться плохой практикой??
        private static readonly Dictionary<Directions, Action<Enemy, int>> _moveActions = new()
        {
            { Directions.Left, (p,s) => p.SetCoordinates(p.Coordinates.X - s, p.Coordinates.Y)},
            { Directions.Right, (p,s) => p.SetCoordinates(p.Coordinates.X + s, p.Coordinates.Y)},
            { Directions.Up, (p,s) => p.SetCoordinates(p.Coordinates.X, p.Coordinates.Y - s)},
            { Directions.Down, (p,s) => p.SetCoordinates(p.Coordinates.X, p.Coordinates.Y + s)}
        };

        public void Move(int step)
        {
            if (_moveActions.TryGetValue(Direction, out var action))
            {
                action(this, step);
            }
        }
        public void SetDirectionX()
        {
            Direction = Directions.Right;

            _directionSwitch = 0;
            _directions[0] = Directions.Right;
            _directions[1] = Directions.Left;
        }
        public void SetDirectionY()
        {
            Direction = Directions.Down;

            _directionSwitch = 0;
            _directions[0] = Directions.Down;
            _directions[1] = Directions.Up;
        }
        public void ChangeDirection()
        {
            if (_directionSwitch + 1 == _directions.Length)
                _directionSwitch = 0;
            else
                _directionSwitch++;

            Direction = _directions[_directionSwitch];
        }
        public void SetCoordinates(int x, int y)
        {
            Coordinates = new Coordinates(x, y);
        }
    }
}
