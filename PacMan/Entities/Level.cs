using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Entities
{
    internal class Level
    {
        public int LengthX { get; private set; }
        public int LengthY { get; private set; }

        //Нужно для быстрого доступа к движушимся сущностям
        public Player Player { get; private set; }
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

        public IEntity[,] Map {  get; private set; }
        public Level(IEntity[,] map)
        {
            Map = map;
            LengthX = map.GetLength(1);
            LengthY = map.GetLength(0);

            FindPlayerAndEnemies();
        }

        private void FindPlayerAndEnemies()
        {
            foreach (var item in Map)
            {
                if (item.GetType() == typeof(Enemy))
                    Enemies.Add((Enemy)item);
                else if (item.GetType() == typeof(Player))
                    Player = (Player)item;
            }
        }
    }
}
