// ------------------------
// Tematyka aplikacji:
// - Klasy
// - Kolekcje
// - Strumienie
// - Zapis / odczyt plikow
// - Serializacja
//-------------------------
// Aplikacja ktora pozwala zarzadzac samochodami w firmie z wykorzystaniem:
// 1. Klas
// 2. Kolekcji generycznych
// 3. Zapisywaniem wynikow do i z pliku .txt
// ------------------------

// SERIALIZACJA -> proces przekonstruowania danych z programu do miejsca jego przetrzymywania (np. plik .txt,
// .json, .xml, bazy danych SQL i NO-SQL)
// DESERIALIZACJA -> odwrocenie procesu serializacji (czyli wczytanie danych DO aplikajci z zewnatrz)

using _09_AplikacjaDlaKolekcji;

var shutDown = false;

var carService = new CarService();

Console.WriteLine("Hello in the car-application!");

while (!shutDown)
{
    Console.WriteLine("\nList of possible operations:");
    Console.WriteLine("Type [A] for adding the new car");
    Console.WriteLine("Type [D] for delete the car");
    Console.WriteLine("Type [S] for showing all cars");
    Console.WriteLine("Type [E] for editing the car");
    Console.WriteLine("Type [EXIT] for closing the app");

    var providedValue = Console.ReadLine();

    switch (providedValue.ToUpper())
    {
        case "A":
            carService.Add();
            break;
        case "S":
            carService.Show();
            break;
        case "D":
            carService.Delete();
            break;
        case "E":
            carService.Edit();
            break;
        case "ADD":
            Info.Binary();
            break;
        case "EXIT":
            shutDown = true;
            break;
        default:
            Console.WriteLine("You've provided the wrong operation!");
            break;
    }
}

carService.SaveData();

Console.WriteLine("Closing the application...");