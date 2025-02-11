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
    //Очень интересный класс, вроде и нужный а вроде и спорный
    //Пришлось использовать делегат ведь действия класса тесно связаны с тем что находиться в LogicController
    //Если не использовать делегат то будет нагромождение в LogicController
    //Хмммм
    internal class MovementLogicService
    {
        private Level Level { get; set; }
        public Collide CollideLogic { get; set; }
        public MovementLogicService(Level level, Collide collideLogic)
        {
            Level = level;
            CollideLogic = collideLogic;
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
            //Получает сущность с места куда планируется сделать шаг
            IEntity entity = GetEntityFromDirection(moveble.Direction, moveble.Coordinates);

            //Отправляет на обработку логике, получает сигнал двигаться/не двигаться
            bool move = CollideLogic(moveble, entity); 

            if (move)
                moveble.Move(Constants.movementStep);
        }
        //Получение сущности с места куда планируется сделать шаг
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
        //Менять ли фактическое направление на то которое задаёт пользователь
        private void TryChangePlayerDirection()
        {
            IEntity entity;
            var player = Level.Player;

            if (player.NextDirection != Directions.None)
            {
                entity = GetEntityFromDirection(player.NextDirection, player.Coordinates);

                //При условии что в том направлении не стена - менять
                if (entity.GetType() != typeof(Wall))
                    player.Direction = player.NextDirection;
            }
        }

    }
}
