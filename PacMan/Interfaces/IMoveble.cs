using PacMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    //Moveble не может быть не Entity ведь так?
    internal interface IMoveble : IEntity
    {
        Directions Direction { get; set; }
        void Move(int step);
    }
}
