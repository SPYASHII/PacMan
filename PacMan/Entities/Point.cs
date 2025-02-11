using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    //TODO: Мб добавить сюда свойство кол-ва получаемых очков
    //Наверно лучше кол-во получаемых очков добавить в константы
    internal class Point : IEntity
    {
        public Coordinates Coordinates { get; private set; }
        public void SetCoordinates(int x, int y)
        {
            Coordinates = new Coordinates(x, y);
        }
    }
}
