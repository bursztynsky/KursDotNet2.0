using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Strumienie
{
    internal static class FilesService
    {
        public static List<Car> allCars = new();

        public static void Zadanie1()
        {
            Console.ResetColor();
            // Zadanie 1: odczytaj wszystkie linie z pliku Cars.txt i wyswietl w konsoli

            Console.WriteLine("-- Zadanie 1 --");

            // aby polaczyc sie do pliku musimy otworzyc strumien
            using var fileStream = new FileStream("cars.txt", FileMode.Open);
            using var fileReader = new StreamReader(fileStream);

            // UWAGA: w linni 18 bede mial blad System.IO.FileNotFoundException bo nie ma pliku cars.txt tam gdzie kompiluje sie nam
            // aplikacja

            // To dlatego ze przekompilowany program laduje w folderze bin\Debu\netX\

            // Rozwiazanie to w VisualStudio kliknac lewym przyciskiem na plik cars.txt i w Properties
            // zmienic pozycje "Copy to Output Directory" zmieniam z wartosci "Do not copy" na "Copy always"

            // dla sprawdzenia czy wszystko dziala wyswietlmy pierwsza linie tekstu z pliku
            //var firstLine = fileReader.ReadLine();
            //Console.WriteLine("First line: " + firstLine);

            // Wyswietlamy wszystko co jest w pliku linia po linnii

            // Dwa sposoby:

            // 1 sposob: ReadToEnd()
            //var allLines = fileReader.ReadToEnd();
            //Console.WriteLine(allLines);

            // 2 sposob (WAZNIEJSZY) to z uzyciem petli:
            var lineNumber = 1;

            while (fileReader.EndOfStream == false)
            {
                var line = fileReader.ReadLine();
                Console.WriteLine("Line " + lineNumber + " : " + line);

                lineNumber++;
            }

            // NAJWAZNIEJSZE - zamknac strumienie na koniec uzycia!
            //fileReader.Dispose();
            //fileStream.Dispose();

            // teraz skoro przenioslem kod do metody i mam strumienie otwierane w konkretnej metodzie
            // to moge dodac do strumieni using i on zamknie mi strumienie na koniec dzialania w linii 63

            Console.ResetColor();
        }

        public static void Zadanie2_oraz_Zadanie3()
        {
            Console.ResetColor();
            Console.WriteLine("-- ZADANIE 2 --");

            // W TYM ZADANIU skorzystam z using w wersji w ktorej wskazuje przez jaki czas ma on pilnowac strumienie
            // i zamknie je wtedy kiedy bym chcial

            // Zadanie 2: Odczytaj dane z pliku cars.txt i sprawdz czy dane sa w poprawnym formacie Marka;Model;Rok i jesli nie
            // to wyswietl odpowiedni komunikat
            using (var fileStream2 = new FileStream("cars.txt", FileMode.Open))
            using (var fileReader2 = new StreamReader(fileStream2))
            {
                var lineNumber = 1;

                while (fileReader2.EndOfStream == false)
                {
                    var line = fileReader2.ReadLine();

                    if (line == null)
                    {
                        Console.WriteLine("The line " + lineNumber + " is empty!");
                        lineNumber++;
                        continue;
                    }

                    var variables = line.Split(';');

                    // jesli teorytcznie dane sa prawidlowo podane to bedziemy mieli 3 wartosci podzielone dwoma srednikami
                    // wiec variables.Length powinno wynosic 3
                    if (variables.Length != 3)
                    {
                        Console.WriteLine("The line " + lineNumber + " has not 3 values");
                        lineNumber++;
                        continue;
                    }

                    // tutaj zakladam ze ilosc danych jest ok, wiec czas na walidacje kazdego z nich
                    // MARKA
                    var brand = variables[0];

                    // sprawdzamy czy nie jest pusty
                    if (string.IsNullOrWhiteSpace(brand))
                    {
                        Console.WriteLine("The line " + lineNumber + " brand is empty!");
                        lineNumber++;
                        continue;
                    }

                    // BRAND
                    var model = variables[1];

                    // sprawdzamy czy nie jest pusty
                    if (string.IsNullOrWhiteSpace(model))
                    {
                        Console.WriteLine("The line " + lineNumber + " model is empty!");
                        lineNumber++;
                        continue;
                    }

                    // YEAR
                    var year = variables[2];

                    // sprawdzamy czy nie jest pusty
                    if (string.IsNullOrWhiteSpace(year))
                    {
                        Console.WriteLine("The line " + lineNumber + " year is empty!");
                        lineNumber++;
                        continue;
                    }

                    var parseResult = int.TryParse(year, out var parsedYear);

                    if (parseResult == false)
                    {
                        Console.WriteLine("The line " + lineNumber + " year is not a number!");
                        lineNumber++;
                        continue;
                    }

                    Console.WriteLine("In line " + lineNumber + " there is a car: Brand=" + brand + " Model=" + model + " Year=" + year);

                    lineNumber++;
                }
            }

            Console.WriteLine("-- ZADANIE 3 --");

            // ZADANIE 3: Zrob to samo co w 2 ale korzystajac z klas i metod itd (tzw. refactoring)
            // W RAMACH ZADANIA 4 DODAJE LISTE:
            using var fileStream3 = new FileStream("cars.txt", FileMode.Open);
            using var fileReader3 = new StreamReader(fileStream3);

            var lineNumber2 = 1;

            while (fileReader3.EndOfStream == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var line = fileReader3.ReadLine();

                try
                {
                    var car = new Car(line, lineNumber2);

                    Console.WriteLine(car);

                    // W RAMACH ZADANIA 4 DODAJE DO LISTY SAMOCHOD
                    allCars.Add(car);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

                lineNumber2++;
            }

            Console.ResetColor();
        }

        public static void Zadanie4()
        {
            Console.ResetColor();
            Console.WriteLine("-- ZADANIE 4 --");

            // ZADANIE 4: Korzystajac z samochodow stworzonych w zadaniu 3, zapisz nowy plik finalCars.txt wlasnie z tymi poprawnie
            // utworzonymi samochodami
            using var fileStream4 = new FileStream("finalCars.txt", FileMode.Create);
            using var fileWriter4 = new StreamWriter(fileStream4);
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var car in allCars)
            {
                Console.WriteLine("Saving car: " + car);
                fileWriter4.WriteLine(car);
            }

            Console.WriteLine("Cars saved successfully");

            Console.ResetColor();
        }
    }
}
