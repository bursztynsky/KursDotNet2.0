using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_PlikiFolderyStrumienie
{
    public class FilesService
    {
        // readonly -> powoduje, ze zmienna moze miec ustawiona wartosc TYLKO w konstruktorze LUB przy inicie tzn. ze wygladaloby tak: private readonly string _pathToDirectory = "test";
        private readonly string _pathToDirectory;

        public FilesService(string pathToDirectory)
        {
            _pathToDirectory = pathToDirectory;
        }

        public void ShowDirectories()
        {
            var directories = Directory.GetDirectories(_pathToDirectory);

            foreach (var dir in directories)
            {
                Console.WriteLine(dir);
            }
        }

        public void ShowFiles()
        {
            var files = Directory.GetFiles(_pathToDirectory);

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

        public void ShowAll()
        {
            ShowDirectories();
            ShowFiles();
        }

        public void DeleteAll()
        {
            Directory.Delete(_pathToDirectory, true);
        }

        public void GenerateRandomValues()
        {
            var min = 10;
            var max = 15;

            var random = new Random();

            var numberOfDirectories = random.Next(min, max);

            Console.WriteLine("Generating " + numberOfDirectories + " directories...");

            var folderName = "generatedFolder";
            var fileName = "generatedFile";
            var fileExtension = ".txt";

            for (int i = 1; i <= numberOfDirectories; i++)
            {
                // tworze folder o nazwie np. generatedFolder1, generatedFolder2 itd.
                // $ przed string nazywa sie interpolacja z ang. string interpolation
                var newDirectory = $"{_pathToDirectory}\\{folderName}{i}";

                if (!Directory.Exists(newDirectory))
                {
                    Directory.CreateDirectory(newDirectory);
                }

                // jesli wylosuje liczbe podzielna przez 2 to beda w srodku generowane pliki
                var shouldBeEmpty = random.Next(0, 50) % 2 == 0;

                if (shouldBeEmpty)
                {
                    var numberOfFiles = random.Next(min, max);

                    Console.WriteLine("Generating " + numberOfFiles + " files...");

                    for (int j = 1; j <= numberOfFiles; j++)
                    {
                        //File.Create("newDirectory" + "\\" + fileName + j + fileExtension); // to jest rowniez ok wiec jak wolicie
                        var newFileName = $"{newDirectory}\\{fileName}{j}{fileExtension}";

                        if (!File.Exists(newFileName))
                        {
                            File.Create(newFileName);
                        }
                    }
                }
            }
        }
    }
}
