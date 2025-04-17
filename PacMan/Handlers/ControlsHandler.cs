using PacMan.Controllers;
using PacMan.Entities;
using PacMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Handlers
{
    internal class ControlsHandler
    {
        public event EventHandler Exit;
        public event EventHandler Restart;
        public event EventHandler Pause;

        public ControlsHandler(EventHandler exit, EventHandler restart, EventHandler pause)
        {
            Exit += exit;
            Restart += restart;
            Pause += pause;
        }
        //Обработка нажатий на клавиатуру
        public void HandleControls(Controls input, Player player)
        {
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
                    Exit(this, new EventArgs());
                    break;
                case Controls.Restart:
                    Restart(this, new EventArgs());
                    break;
                case Controls.Pause:
                    Pause(this, new EventArgs());
                    break;
                default:
                    break;
            }
        }
    }
}
