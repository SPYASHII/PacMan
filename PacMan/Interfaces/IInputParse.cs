﻿using PacMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    internal interface IInputParse
    {
        public Controls ParseFromKeyToControl(ConsoleKey key);
    }
}
