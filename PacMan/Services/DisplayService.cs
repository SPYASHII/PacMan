using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Services
{
    //Сервис для отображения, по факту используеться только один метод
    //Нужен ли он вообще, или я усложняю??
    internal class DisplayService
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
    }
}
