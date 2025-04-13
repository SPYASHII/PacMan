using PacMan.Enums;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Controllers
{
    //Контроллер ввода
    internal class InputController
    {
        private IInputParse inputParser;

        public InputController(IInputParse inputParser)
        {
            this.inputParser = inputParser;
        }
        public Controls GetControl()
        {
            Controls control = Controls.None;
            
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                control = inputParser.ParseFromKeyToControl(key.Key);
            }

            return control;
        }
    }
}
