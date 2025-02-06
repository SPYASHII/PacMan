using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Services
{
    internal class DisplayService
    {
        public void DisplayAt(Coordinates cords, char model)
        {
            Console.SetCursorPosition(cords.X, cords.Y);
            Console.Write(model);
        }
        public void DeleteAt(Coordinates cords)
        {
            DisplayAt(cords, ' ');
        }
    }
}
