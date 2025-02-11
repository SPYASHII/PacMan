using PacMan.Entities;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Assets
{
    //TODO: Сделать отдельный класс модели с цветом модели
    internal static class EntitiesModels
    {
        private static readonly char _wall = 'X';
        private static readonly char _empty = ' ';
        private static readonly char _point = '*';
        private static readonly char _exit = 'T';
        private static readonly char _enemy = 'E';
        private static readonly char _player = 'P';

        public static char GetModel(IEntity entity)
        {
            var type = entity.GetType();
            char model;

            if (type == typeof(Wall))
                model = _wall;
            else if (type == typeof(Enemy))
                model = _enemy;
            else if (type == typeof(Player))
                model = _player;
            else if (type == typeof(Exit))
                model = _exit;
            else if (type == typeof(Point))
                model = _point;
            else
                model = _empty;

            return model;
        }
    }
}
