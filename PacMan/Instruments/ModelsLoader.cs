using PacMan.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Instruments
{
    internal class ModelsLoader
    {
        public Model[] LoadModelsFromDir(string dirPath)
        {
            var dir = new DirectoryInfo(dirPath);

            var modelFiles = dir.GetFiles();

            Model[] models;

            models = LoadModels(modelFiles);

            return models;
        }
        private Model[] LoadModels(FileInfo[] modelFiles)
        {
            List<Model> models = new List<Model>();

            foreach (var file in modelFiles)
            {
                models.Add(LoadModel(file));
            }

            return models.ToArray();
        }
        private Model LoadModel(FileInfo file)
        {
            int size = GameSettings.ModelSize;

            char[,] modelChars = new char[size, size];

            try
            {
                using (TextReader reader = new StreamReader(file.FullName))
                {
                    for (int i = 0; i < size; i++)
                    {
                        //считывание модельки с файла строками
                        string line = reader.ReadLine();

                        Console.WriteLine(line.Length);

                        //переписывание строки в массив модельки
                        for (int j = 0; j < size; j++)
                        {
                            modelChars[i, j] = line[j];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(LoadModel)}");
                Console.WriteLine(file.Name);
                Console.WriteLine(ex.Message);

                Environment.Exit(0);
            }

            //Имя файла должно быть именем типа(иначе привязка к типу не сработает)

            string name = file.Name.Replace(file.Extension, "");

            Model model = new Model(name, modelChars);

            return model;
        }
    }
}
