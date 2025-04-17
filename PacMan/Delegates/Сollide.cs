using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Delegates
{
    //Делегат для передачи метода-логики обработки взаимодействия сущностей (Усложнение?)
    internal delegate bool Collide(IEntity entity, IEntity entity1);
}
