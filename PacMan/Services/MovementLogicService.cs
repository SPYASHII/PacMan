using PacMan.Delegates;
using PacMan.Entities;
using PacMan.Enums;
using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Services
{
    internal class MovementLogicService
    {
        private Level Level { get; set; }
        public Collide CollideLogic { get; set; }
        public MovementLogicService(Level level, Collide collideLogic)
        {
            Level = level;
            CollideLogic = collideLogic;
        }
        //TODO: доделать логику передвижения
        //Посмотреть в тетрадь!
        public void ChangeLevel(Level level)
        {
            Level = level;
        }

        public void PlayerMoveLogic()
        {
            var player = Level.Player;

            TryChangePlayerDirection();

            MoveLogic(player);
        }
        public void EnemyMoveLogic()
        {
            var enemies = Level.Enemies;

            foreach (var enemy in enemies)
            {
                MoveLogic(enemy);
            }
        }
        private void MoveLogic(IMoveble moveble)
        {
            IEntity entity = GetEntityFromDirection(moveble.Direction, moveble.Coordinates);

            bool move = CollideLogic(moveble, entity);

            if (move)
                moveble.Move(Constants.movementStep);
        }
        private IEntity GetEntityFromDirection(Directions dir, Coordinates coords)
        {
            switch (dir)
            {
                case Directions.Up:
                    coords.Y--;
                    break;
                case Directions.Down:
                    coords.Y++;
                    break;
                case Directions.Left:
                    coords.X--;
                    break;
                case Directions.Right:
                    coords.X++;
                    break;
                default:
                    break;
            }

            return Level.Map[coords.Y, coords.X];
        }
        private void TryChangePlayerDirection()
        {
            IEntity entity;
            var player = Level.Player;

            if (player.NextDirection != Directions.None)
            {
                entity = GetEntityFromDirection(player.NextDirection, player.Coordinates);

                if (entity.GetType() != typeof(Wall))
                    player.Direction = player.NextDirection;
            }
        }

    }
}
