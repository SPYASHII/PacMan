using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Structures
{
    internal struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool isSet { get; private set; } = false;

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
            isSet = true;
        }
    }
}
