using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Enums;
using PacMan.Interfaces;

namespace PacMan.Services
{
    internal class InputParserService : IInputParse
    {
        private static readonly Dictionary<ConsoleKey, Controls> _keyMappings = new()
        {
            {ConsoleKey.W, Controls.Up },
            {ConsoleKey.A, Controls.Left },
            {ConsoleKey.S, Controls.Down },
            {ConsoleKey.D, Controls.Right },
            {ConsoleKey.P, Controls.Pause },
            {ConsoleKey.Escape, Controls.Exit },
            {ConsoleKey.Enter, Controls.Restart },

        };

        public Controls ParseFromKeyToControl(ConsoleKey key) =>
            _keyMappings.TryGetValue(key, out var control) ? control : Controls.None;
    }
}
