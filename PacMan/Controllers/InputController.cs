using PacMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Controllers
{
    internal class InputController
    {
        public Controls GetControl()
        {
            Controls control = Controls.None;
            //HACK: Изменить на if
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                control = ParseFromKeyToControl(key.Key);
            }

            return control;
        }
        private Controls ParseFromKeyToControl(ConsoleKey key)
        {
            Controls control;

            switch (key)
            {
                case ConsoleKey.W:
                    control = Controls.Up; 
                    break;
                case ConsoleKey.A:
                    control = Controls.Left; 
                    break;
                case ConsoleKey.D:
                    control = Controls.Right; 
                    break;
                case ConsoleKey.S:
                    control = Controls.Down; 
                    break;
                case ConsoleKey.P:
                    control = Controls.Pause; 
                    break;
                case ConsoleKey.Escape:
                    control = Controls.Exit;
                    break;
                case ConsoleKey.Enter:
                    control = Controls.Restart; 
                    break;
                default:
                    control = Controls.None;
                    break;
            }

            return control;
        }
    }
}
