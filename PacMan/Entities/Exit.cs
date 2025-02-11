using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    internal class Exit : IEntity
    {
        public Coordinates Coordinates { get; private set; }
        public void SetCoordinates(int x, int y)
        {
            if (!Coordinates.isSet) //позиция не изменяется ни при каких условиях
                Coordinates = new Coordinates(x, y);
        }
    }
}
