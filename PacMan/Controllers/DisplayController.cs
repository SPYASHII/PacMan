using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Services;
using PacMan.Assets;

namespace PacMan.Controllers
{
    internal class DisplayController
    {
        private DisplayService _displayService = new DisplayService();
        public void DisplayAllMap(IEntity[,] map)
        {
            foreach (var entity in map)
            {
                DisplayEntity(entity);
            }    
        }
        public void DisplayEntities(List<IEntity> entities)
        {
            foreach(var entity in entities)
            {
                DisplayEntity(entity);
            }
        }
        public void DisplayEntity(IEntity entity)
        {
            char model = EntitiesModels.GetModel(entity);

            _displayService.DisplayAt(entity.Coordinates, model);
        }
        public void DisplayWin()
        {
            Console.Clear();
            Console.WriteLine("You have won!");
        }
    }
}
