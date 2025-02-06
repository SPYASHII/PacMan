using PacMan.Entities;
using PacMan.Interfaces;
using PacMan.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Enums;

namespace PacMan.Instruments
{
    internal class MapBuilder
    {
        public IEntity[,] BuildMap(MapBlueprint blueprint)
        {
            IEntity[,] map = new IEntity[blueprint.LengthY,blueprint.LengthX];

            FillMap(map, blueprint.Map);

            return map;
        }
        private void FillMap(IEntity[,] map, string[] mapPrint)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                string current = mapPrint[i];
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    IEntity entity = SelectEntity(current[j]);

                    CreateAt(map, i, j, entity);
                }
            }
        }
        private IEntity SelectEntity(char entityChar)
        {
            IEntity entity;
            switch (entityChar)
            {
                case 'X':
                    entity = new Wall();
                    break;
                case '*':
                    entity = new Point();
                    break;
                case 'P':
                    entity = new Player();
                    break;
                case '0':
                    entity = new Enemy(Directions.Up); //Нормально ли настраивать Enemy прямо в MapBuilder при создании?
                    break;
                case '1':
                    entity = new Enemy(Directions.Left);
                    break;
                case 'T':
                    entity = new Exit();
                    break;
                default:
                    entity = new EmptySpace();
                    break;
            }
            return entity;
        }

        //private void FillWithPoints(IEntity[,] map)
        //{
        //    for(int i = 0;  i < map.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < map.GetLength(1); j++)
        //        {
        //            if (map[i, j] == null)
        //                map.CreateAt(i, j, new Point());
        //        }
        //    }
        //}
        //private void CreateMapBorders(IEntity[,] map)
        //{
        //    map.CreateFromToX(0, 0, map.GetLength(1) - 1, new Wall());
        //    map.CreateFromToX(map.GetLength(0) - 1, 0, map.GetLength(1) - 1, new Wall());

        //    map.CreateFromToY(0, 0, map.GetLength(0) - 1, new Wall());
        //    map.CreateFromToY(map.GetLength(1) - 1, 0, map.GetLength(0) - 1, new Wall());
        //}
        //private void CreateFromToY(IEntity[,] map, int x, int y, int y1, IEntity entity)
        //{
        //    int start = y < y1 ? y : y1;
        //    int end = y == start ? y1 : y;

        //    for(int i = start; i <= end; i++)
        //    {
        //        map.CreateAt(i, x, entity);
        //    }
        //}
        //private void CreateFromToX(IEntity[,] map, int y, int x, int x1, IEntity entity)
        //{
        //    int start = x < x1 ? x : x1;
        //    int end = x == start ? x1 : x;

        //    for (int i = start; i <= end; i++)
        //    {
        //        map.CreateAt(y, i, entity);
        //    }
        //}
        private void CreateAt(IEntity[,] map, int y, int x, IEntity entity)
        {
            map[y, x] = entity;
        }
    }
}
