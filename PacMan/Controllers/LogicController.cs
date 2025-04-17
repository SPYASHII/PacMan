using PacMan.Entities;
using PacMan.Enums;
using PacMan.Handlers;
using PacMan.Interfaces;
using PacMan.Managers;
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
        private LevelController _levelController;
        private DisplayController _displayController;

        private MovementLogicService _movementLogic;

        private CollisionHandler _collisionHandler;
        private ControlsHandler _controlsHandler;

        private GameStateManager _gameStateManager;

        public LogicController(GameStateManager gameStateManager)
        {
            IDisplayService displayService = new DisplayService();

            _displayController = new DisplayController(displayService);
            _levelController = new LevelController();

            _collisionHandler = new CollisionHandler(_entitiesChanged);

            _collisionHandler.GameOver += OnExit;
            _collisionHandler.LevelPassed += OnLevelPassed;

            _controlsHandler = new ControlsHandler(OnExit, OnRestart, OnPause);

            _gameStateManager = gameStateManager;
        }

        //Лист существ которых нужно отобразить(которые подверглись изменениям)
        private List<IEntity> _entitiesChanged = new List<IEntity>();

        private bool _levelPassed = false;
        //alpha test 1       
        //Первоначальная настройка логики при новом уровне
        public void Setup()
        {
            _gameStateManager.SetDefaultState();

            _levelPassed = false;

            SetCoordinatesForEntities();

            var level = _levelController.GetCurrentLevel();

            _movementLogic = new MovementLogicService(level, _collisionHandler.CollideWithLogic);

            _displayController.DisplayAllMap(level.Map);
        }
        //Логика каждой "итерации" игры
        public void ProcessLogic(Controls input)
        {
            _controlsHandler.HandleControls(input, _levelController.GetCurrentLevel().Player);

            if (!_gameStateManager.Pause && !_gameStateManager.Win)
            {
                _entitiesChanged.Clear();

                _movementLogic.PlayerMoveLogic();
                _movementLogic.EnemyMoveLogic();

                if (!_gameStateManager.Win)
                {
                    //Обработка изменненных сущностей
                    _levelController.InsertEntities(_entitiesChanged); //Фактическое помещение на карту уровня
                    _displayController.DisplayEntities(_entitiesChanged); //Отображение

                    if (_levelPassed)
                    {
                        LevelLogic();
                    }
                }
            }
            if(_gameStateManager.Win)
            {
                _displayController.DisplayWinScenario();
            }
        }
        private void LevelLogic()
        {
            bool isNextLevel = _levelController.NextLevel();

            if (isNextLevel)
                Setup();
            else
                _gameStateManager.SetWin();
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
        private void OnExit(object? sender, EventArgs e)
        {
            _gameStateManager.SetExit();
        }
        private void OnLevelPassed(object? sender, EventArgs e)
        {
            _levelPassed = true;
        }
        private void OnRestart(object? sender, EventArgs e)
        {
            Restart();
        }
        private void Restart()
        {
            _levelController.FirstLevel();
            Setup();
        }
        private void OnPause(object? sender, EventArgs e)
        {
            _gameStateManager.SwitchPause();
        }
    }
}
