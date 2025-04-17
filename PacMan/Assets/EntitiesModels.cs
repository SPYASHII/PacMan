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
    internal class EntitiesModels
    {
        //private static readonly char _wall = 'X';
        //private static readonly char _empty = ' ';
        //private static readonly char _point = '*';
        //private static readonly char _exit = 'T';
        //private static readonly char _enemy = 'E';
        //private static readonly char _player = 'P';

        private readonly Model[] _models;

        private static EntitiesModels? _instance;
        private EntitiesModels(Model[] models)
        {
            _models = models;
        }
        public static EntitiesModels Init(Model[] models)
        {
            _instance ??= new EntitiesModels(models);

            return _instance;
        }
        public static EntitiesModels? GetInstance(out bool notNull)
        {
            if(_instance == null)
                notNull = false;
            else
                notNull = true;

                return _instance;
        }
        public Model GetModel(IEntity entity)
        {
            var type = entity.GetType();
            Model model;

            model = _models.FirstOrDefault(k => k.name == type.Name);

            model ??= _models.First(k => k.name == nameof(EmptySpace));

            return model;
        }
        //public static char GetModel(IEntity entity)
        //{
        //    var type = entity.GetType();
        //    char model;

        //    if (type == typeof(Wall))
        //        model = _wall;
        //    else if (type == typeof(Enemy))
        //        model = _enemy;
        //    else if (type == typeof(Player))
        //        model = _player;
        //    else if (type == typeof(Exit))
        //        model = _exit;
        //    else if (type == typeof(Point))
        //        model = _point;
        //    else
        //        model = _empty;

        //    return model;
        //}
    }
}
