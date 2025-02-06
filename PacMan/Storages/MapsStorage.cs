using PacMan.Assets;
using PacMan.Instruments;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Enums;

namespace PacMan.Storages
{
    internal class MapsStorage
    {
        private List<IEntity[,]> _maps = new List<IEntity[,]>();
        private MapBuilder _mapBuilder = new MapBuilder();
        private static MapsStorage _instance;

        private MapsStorage()
        {
            IEntity[,] map1 = _mapBuilder.BuildMap(Maps.Map1);
            IEntity[,] map2 = _mapBuilder.BuildMap(Maps.Map2);

            _maps.Add(map1);
            _maps.Add(map2);
        }

        public static MapsStorage GetInstance()
        {
            if (_instance == null)
                _instance = new MapsStorage();
            return _instance;
        }
        public IEntity[,] GetMap(int  mapNumber)
        {
            IEntity[,] map = (IEntity[,])_maps[mapNumber].Clone();
            return map;
        }
        public int GetMapsCount()
        {
            return _maps.Count;
        }

        //private IEntity[,] CreateMap1()
        //{
        //    IEntity[,] map = new IEntity[10, 10];

        //    map.CreateMapBorders();
        //    map.CreateFromToX(2, 1, 2, new Wall());
        //    map.CreateFromToX(4, 1, 2, new Wall());
        //    map.CreateFromToX(7, 1, 2, new Wall());

        //    map.CreateFromToX(7, 5, 6, new Wall());

        //    map.CreateFromToY(4, 3, 8, new Wall());
        //    map.CreateFromToY(5, 1, 1, new Wall());

        //    map.CreateFromToY(6, 2, 5, new Wall());

        //    map.CreateAt(2, 7, new Wall());
        //    map.CreateAt(4, 7, new Wall());
        //    map.CreateAt(5, 7, new Wall());

        //    map.CreateAt(1, 6, new Player());

        //    map.CreateAt(1, 8, new Enemy(Direction.Down));
        //    map.CreateAt(8, 5, new Enemy(Direction.Right));
        //    map.CreateAt(3, 1, new Enemy(Direction.Right));
        //    map.CreateAt(5, 2, new Enemy(Direction.Right));


        //    map.CreateAt(8, 1, new Exit());

        //    map.FillWithPoints();

        //    return map;
        //}
    }
}
