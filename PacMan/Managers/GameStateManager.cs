using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Managers
{
    internal class GameStateManager
    {
        public bool Pause { get; private set; }
        public bool Exit { get; private set; }
        public bool Win { get; private set; }

        public GameStateManager()
        {
            SetDefaultState();
        }
        public void SetDefaultState()
        {
            Pause = false;
            Exit = false;
            Win = false;
        }
        public void SwitchPause()
        {
            Pause = !Pause;
        }
        public void SetExit()
        {
            Exit = true;
        }
        public void SetWin()
        {
            Win = true;
        }
        
    }
}
