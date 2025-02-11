using PacMan.Entities;
using PacMan.Interfaces;
using PacMan.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Controllers
{
    //Контроллер для управления уровнем/уровнями
    internal class LevelController
    {
        private MapsStorage _mapStorage;

        private Level _currentLevel;

        private int _curLevelNumber;
        private readonly int _numberOfLevels;
        public LevelController()
        {
            _mapStorage = MapsStorage.GetInstance();
            _numberOfLevels = _mapStorage.GetMapsCount();

            SetLevel(0);
        }
        public void ResetLevel()
        {
            SetLevel(_curLevelNumber);
        }
        public bool NextLevel()
        {
            return SetLevel(_curLevelNumber + 1);
        }
        public void FirstLevel()
        {
            SetLevel(0);
        }
        private bool SetLevel(int number)
        {
            bool success = number < _numberOfLevels;

            if (success)
            {
                _currentLevel = new Level(_mapStorage.GetMap(number));
                _curLevelNumber = number;
            }

            return success;
        }
        public Level GetCurrentLevel()
        {
            return _currentLevel;
        }

        //Вставить сущность в карту
        public void InsertEntity(IEntity entity)
        {
            var cords = entity.Coordinates;

            _currentLevel.Map[cords.Y, cords.X] = entity;
        }
        public void InsertEntities(List<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                InsertEntity(entity);
            }
        }
    }
}
