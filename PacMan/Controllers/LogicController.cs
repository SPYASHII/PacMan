using PacMan.Entities;
using PacMan.Enums;
using PacMan.Interfaces;
using PacMan.Services;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Controllers
{
    //Контроллер Логики, по факту является самым главным
    internal class LogicController
    {
        private LevelController _levelController = new LevelController();
        private DisplayController _displayController = new DisplayController();
        private MovementLogicService _movementLogic;

        //Лист существ которых нужно отобразить(которые подверглись изменениям)
        private List<IEntity> _entitiesChanged = new List<IEntity>();

        public bool win = false;
        public bool exit = false;
        private bool _levelPassed = false;
        //alpha test 1       
        //Первоначальная настройка логики при новом уровне
        public void Setup()
        {
            _levelPassed = false;

            SetCoordinatesForEntities();

            var level = _levelController.GetCurrentLevel();

            _movementLogic = new MovementLogicService(level, CollideWithLogic);

            _displayController.DisplayAllMap(level.Map);
        }
        //Логика каждой "итерации" игры
        public void ProcessLogic(Controls input)
        {
            _entitiesChanged.Clear();

            HandleControls(input);

            _movementLogic.PlayerMoveLogic();
            _movementLogic.EnemyMoveLogic();

            if (!exit)
            {
                //Обработка изменненных сущностей
                _levelController.InsertEntities(_entitiesChanged); //Фактическое помещение на карту уровня
                _displayController.DisplayEntities(_entitiesChanged); //Отображение

                if (_levelPassed)
                {
                    LevelLogic();
                }

                if(win)
                {
                    _displayController.DisplayWin();
                    Console.ReadKey();
                    win = false;
                }
            }
        }
        private void LevelLogic()
        {
            bool isNextLevel = _levelController.NextLevel();

            if(isNextLevel)
                Setup();
            else
                win = true;
        }
        //Обработка нажатий на клавиатуру
        private void HandleControls(Controls input)
        {
            var player = _levelController.GetCurrentLevel().Player;

            switch (input)
            {
                case Controls.Up:
                    player.NextDirection = Directions.Up;
                    break;
                case Controls.Down:
                    player.NextDirection = Directions.Down;
                    break;
                case Controls.Left:
                    player.NextDirection = Directions.Left;
                    break;
                case Controls.Right:
                    player.NextDirection = Directions.Right;
                    break;
                case Controls.Exit:
                    exit = true;
                    break;
                case Controls.Restart:
                    _levelController.FirstLevel();
                    Setup();
                    break;
            }
        }
        //Установить координаты всем сущностям на карте
        private void SetCoordinatesForEntities()
        {
            var level = _levelController.GetCurrentLevel();

            for (int i = 0; i < level.LengthY; i++)
            {
                for (int j = 0; j < level.LengthX; j++)
                {
                    level.Map[i, j].SetCoordinates(j, i);
                }
            }
        }
        //Логика взаимодействия между сущностями при движении,
        //возращаемое значение - сигнал двигатся сущности или нет
        private bool CollideWithLogic(IEntity iniciator, IEntity colidedWith)
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
                exit = true;
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
                exit = true;
            }
            else if (colidedWith is Exit)
            {
                //some logic
                _levelPassed = true;
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
