using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Services
{
    internal class DisplayService : IDisplayService
    {
        public void DisplayAt(Coordinates cords, char model)
        {
            Console.SetCursorPosition(cords.X + Constants.DisplayModifierX, cords.Y + Constants.DisplayModifierY);
            Console.Write(model);
        }
        //HACK: Под удаление
        public void DeleteAt(Coordinates cords)
        {
            DisplayAt(cords, ' ');
        }
        public void DisplayWin()
        {
            Console.Clear();
            Console.WriteLine("You have won!");
        }
    }
}
