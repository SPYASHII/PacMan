using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    internal interface IEntity
    {
        Coordinates Coordinates { get; }
        public void SetCoordinates(int x, int y);
    }
}
