using PacMan.Assets;
using PacMan.Controllers;
using PacMan.Enums;
using PacMan.Interfaces;
using PacMan.Managers;
using PacMan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Game
    {
        private InputController _inputController;
        private LogicController _logicController;
        private GameStateManager _gameStateManager;
        public Game()
        {
            IInputParse inputParser = new InputParserService();

            _gameStateManager = new GameStateManager();

            _inputController = InputController.Init(inputParser);
            _logicController = new LogicController(_gameStateManager);
        }
        public void Start()
        {
            Console.CursorVisible = false;

            _logicController.Setup();
            GameLoop();
        }
        private void GameLoop()
        {
            while (!_gameStateManager.Exit)
            {
                Controls control;
                if (_gameStateManager.Win)
                    control = _inputController.GetControl();
                else
                    control = _inputController.GetControlOnAvailable();

                Thread.Sleep(250);

                _logicController.ProcessLogic(control);
            }
        }
    }
}
