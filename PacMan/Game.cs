using PacMan.Assets;
using PacMan.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class Game
    {
        private InputController _inputController = new InputController();
        private LogicController _logicController = new LogicController();
        public void Start()
        {
            Console.CursorVisible = false;

            _logicController.Setup();
            GameLoop();
        }
        private void GameLoop()
        {
            while (!_logicController.exit)
            {
                var control = _inputController.GetControl();

                Thread.Sleep(250);

                _logicController.ProcessLogic(control);
            }
        }
    }
}
