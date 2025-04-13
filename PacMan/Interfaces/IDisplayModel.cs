using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    internal interface IDisplayModel
    {
        void DisplayAt(Coordinates cords, char model);
    }
}
