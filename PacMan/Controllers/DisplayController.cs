using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Services;
using PacMan.Assets;
using System.Security.Cryptography.X509Certificates;

namespace PacMan.Controllers
{
    //Контроллер визуала
    internal class DisplayController
    {
        private IDisplayService _displayService;

        public DisplayController(IDisplayService displayService)
        {
            _displayService = displayService;
        }

        public void DisplayAllMap(IEntity[,] map)
        {
            Console.Clear();

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
        public void DisplayWinScenario()
        {
            var builder = new StringBuilder();

            builder.AppendLine("You have won!");
            builder.AppendLine();
            builder.AppendLine("Press Enter to restart");

            _displayService.Clear();
            _displayService.DisplayMessage(builder.ToString());
        }
    }
}
