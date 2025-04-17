using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Assets
{
    internal class Model
    {
        public readonly string name;

        public readonly char[,] model;

        public Model(string name, char[,] model)
        {
            this.name = name;
            this.model = model;
        }

    }
}
