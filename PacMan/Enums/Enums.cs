using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Enums
{
    //Перечисление для управления игрой
    //TODO: Реализовать паузу
    internal enum Controls
    {
        None = 0, Left, Right, Up, Down, Pause, Exit, Restart
    }
    //Перечисление для направлений движения
    internal enum Directions
    {
        None = 0, Left, Right, Up, Down,
    }
}
