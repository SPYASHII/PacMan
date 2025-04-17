using PacMan.Entities;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Handlers
{
    internal class CollisionHandler
    {
        private List<IEntity> _entitiesChanged;
        private event EventHandler? _gameOver;
        private event EventHandler? _levelPassed;
        public CollisionHandler(
            List<IEntity> entitiesChanged,
            EventHandler onGameOver,
            EventHandler onLevelPassed) : this(entitiesChanged)
        {
            _gameOver = onGameOver;
            _levelPassed = onLevelPassed;
        }
        public CollisionHandler(List<IEntity> entitiesChanged)
        {
            _entitiesChanged = entitiesChanged;
        }

        public event EventHandler GameOver
        {
            add => _gameOver += value;
            remove => _gameOver -= value;
        }
        public event EventHandler LevelPassed
        {
            add => _levelPassed += value;
            remove => _levelPassed -= value;
        }

        //Логика взаимодействия между сущностями при движении,
        //возращаемое значение - сигнал двигатся сущности или нет
        public bool CollideWithLogic(IEntity iniciator, IEntity colidedWith)
        {
            bool move = false;

            if (iniciator is Player player)
                move = PlayerCollide(player, colidedWith);
            else if (iniciator is Enemy enemy)
                move = EnemyCollide(enemy, colidedWith);

            return move;
        }
        private bool EnemyCollide(Enemy enemy, IEntity colidedWith)
        {
            bool move = false;

            if (colidedWith is Wall)
            {
                enemy.ChangeDirection();
            }
            else if (colidedWith is Player)
            {
                _gameOver?.Invoke(this, new EventArgs());
            }
            else if (colidedWith is Enemy)
            {
                //do nothing
            }
            else
            {
                //POINT AND EMPTY SPACE
                //swap
                SecondTakePlaceOfFirst(enemy, colidedWith);

                move = true;
            }

            if (move)
                _entitiesChanged.Add(enemy);

            return move;
        }
        private bool PlayerCollide(Player player, IEntity colidedWith)
        {
            bool move = false;

            if (colidedWith is Point)
            {
                //TODO: POINTS/SCORE
                //delete point and add to score
                //set empty space on spot before
                SecondTakePlaceOfFirst(player, new EmptySpace());

                move = true;
            }
            else if (colidedWith is Wall)
            {
                //do nothing
            }
            else if (colidedWith is Enemy)
            {
                _gameOver?.Invoke(this, new EventArgs());
            }
            else if (colidedWith is Exit)
            {
                //some logic
                _levelPassed?.Invoke(this, new EventArgs());
            }
            else
            {
                //EMPTY SPACE
                SecondTakePlaceOfFirst(player, colidedWith);

                move = true;
            }

            if (move)
                _entitiesChanged.Add(player);

            return move;
        }
        //Метод для задания второй сущности координат первой + добавление в список измененных сущностей
        private void SecondTakePlaceOfFirst(IEntity first, IEntity second)
        {
            second.SetCoordinates(first.Coordinates.X, first.Coordinates.Y);
            _entitiesChanged.Add(second);
        }
    }
}
