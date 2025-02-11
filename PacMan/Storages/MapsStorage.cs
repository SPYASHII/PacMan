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
    //Синглтон для хранения карт в неизменном виде, после сборки их строителем
    internal class MapsStorage
    {
        private List<IEntity[,]> _maps = new List<IEntity[,]>();
        private MapBuilder _mapBuilder = new MapBuilder();
        private static MapsStorage _instance;

        private MapsStorage()
        {
            IEntity[,] map1 = _mapBuilder.BuildMap(Maps.Map1); //Мб сделать yield return в классе Maps?
            IEntity[,] map2 = _mapBuilder.BuildMap(Maps.Map2); //Чтобы не нагромождать этот класс ручным кодом

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
    }
}
