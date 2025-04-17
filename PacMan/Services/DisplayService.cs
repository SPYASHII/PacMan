using PacMan.Assets;
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
        public void DisplayAt(Coordinates cords, Model model)
        {
            int x = cords.X, y = cords.Y;

            if (x != 0)
                x *= GameSettings.ModelSize;
            if (y != 0)
                y *= GameSettings.ModelSize;

            Console.SetCursorPosition(x + GameSettings.DisplayModifierX, y + GameSettings.DisplayModifierY);
            DisplayModel(model);
        }
        private void DisplayModel(Model model)
        {
            int size = GameSettings.ModelSize;

            (int x, int y) cursorPos = Console.GetCursorPosition();

            char[,] modelChars = model.model;

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    char c = modelChars[i, j];

                    Console.Write(c);
                }
                cursorPos.y++;

                Console.SetCursorPosition(cursorPos.x, cursorPos.y);
            }
        }
        ////HACK: Под удаление
        //public void DeleteAt(Coordinates cords)
        //{
        //    DisplayAt(cords, ' ');
        //}
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
