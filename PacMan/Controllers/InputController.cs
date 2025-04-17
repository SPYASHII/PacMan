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

        private static InputController _instance;
        //private InputController() { }
        private InputController(IInputParse inputParser)
        {
            this.inputParser = inputParser;
        }

        public static InputController Init(IInputParse inputParser)
        {
            if(_instance == null)
                _instance = new InputController(inputParser);

            return _instance;
        }
        public static InputController? GetInstance(out bool notNull)
        {
            if(_instance == null)
                notNull = false;
            else
                notNull = true;

                return _instance;
        }

        public Controls GetControlOnAvailable()
        {
            Controls control = Controls.None;
            
            if (Console.KeyAvailable)
            {
                control = GetControl();
            }

            return control;
        }
        public Controls GetControl()
        {
            var key = Console.ReadKey(true);

            var control = inputParser.ParseFromKeyToControl(key.Key);

            return control;
        }
    }
}
