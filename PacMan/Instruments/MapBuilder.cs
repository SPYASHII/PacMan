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
    //Строитель карты, на входе принимает чертёж карты, выдаёт массив с обьектами который
    //по факту является картой
    internal class MapBuilder
    {
        public IEntity[,] BuildMap(MapBlueprint blueprint)
        {
            //Не уверен нужны ли параметры длины, ведь можно использовать длину строки и массива :/
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
        //Метод для интерпритации чертежа в обьекты
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
        private void CreateAt(IEntity[,] map, int y, int x, IEntity entity)
        {
            map[y, x] = entity;
        }
    }
}
