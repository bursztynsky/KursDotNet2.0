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
            var min = 2;
            var max = 6;

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

        public void RenameFolders()
        {
            var success = false;

            while (!success)
            {
                Console.WriteLine("Choose if you want to add a prefix or suffix: \n[1] - prefix\n[2] - suffix");

                var value = Console.ReadLine();

                var isPrefix = false;

                switch (value)
                {
                    case "1":
                        isPrefix = true;
                        break;
                    case "2":
                        isPrefix = false;
                        break;
                    default:
                        Console.WriteLine("You've provided a wrong value");
                        continue;
                }

                var name = isPrefix ? "prefix" : "suffix";
                Console.WriteLine($"Provide a {name}:");

                var newFolderName = Console.ReadLine();

                // zbieramy foldery w naszym folderze
                var directories = Directory.GetDirectories(_pathToDirectory);

                // tworzymy nowe foldery
                var newFolders = new List<string>();

                var idx = 1;
                foreach (var folder in directories)
                {
                    // tworzymy nowy folder
                    var newFullFolderName = isPrefix == true
                        ? $"{newFolderName}{idx}"
                        : $"{idx}{newFolderName}";

                    var newFolderPath = $"{_pathToDirectory}\\{newFullFolderName}";

                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                    }

                    idx++;
                }

                foreach(var folder in directories)
                {
                    // zbieramy pliki ze starego folderu i przenosimy do nowego
                    Directory.Move(folder, newFolderPath);
                }

                success = true;
            }
        }
    }
}
