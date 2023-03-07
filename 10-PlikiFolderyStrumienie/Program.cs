//--------------------
// OPIS:
// - aplikacja prosi uzytkownika o podanie sciezki do folderu
// - aplikacja umozliwia usuwanie wszystkie w danej sciezce
// - aplikacja umozliwia generowanie testowych plikow i folderow w danej sciezce
// - aplikacja umozliwia wyswietlenie wszystkich plikow i folderow i podfolderow i wszystkiego co jest w danej sciezce
// - aplikacja umozliwia zmiane prefix i sufix dla wszystkich plikow w podanej sciezce
//--------------------

using _10_PlikiFolderyStrumienie;

var shutDown = false;
var directoryPath = "";

Console.WriteLine("Hello in the 'directories and folders' program!");

while (!shutDown)
{
    // Umozliwiamy uzytownikowi podanie sciezki do folderu w ktorym chcemy wykonywac operacje
    // Co musimy zrobic:
    // - odebrac sciezke od usera
    // - sprawdzic czy nie jest pusta
    // - sprawdzic czy istnieje a jesli nie, to ja utworzyc

    Console.WriteLine("Please provide the path to directory:");

    //directoryPath = Console.ReadLine();
    // W ramach testowania ustawie na sztywno ze path to: C:\Users\tom\Desktop\TEST_PROGRAMU
    directoryPath = "C:\\Users\\tom\\Desktop\\TEST_PROGRAMU";

    // ustawiam shutDown na true by wyjsc z tego while bo mam juz sciezke do folderu
    shutDown = true;
}

var service = new FilesService(directoryPath);

// ustawiam shutDown na true by wejsc do nastepnego while
shutDown = false;

while (!shutDown)
{
    if (string.IsNullOrWhiteSpace(directoryPath))
    {
        Console.WriteLine("You have provided an empty value!");
        continue;
    }

    if (!Directory.Exists(directoryPath))
    {
        // jesli nie ma tkaiej sciezki, to tworzymy
        Directory.CreateDirectory(directoryPath);
    }


    Console.WriteLine("\nList of possible operations:");
    Console.WriteLine("Type [1] Show all files and directories in the path");
    Console.WriteLine("Type [2] Remove all files and directories in the path");
    Console.WriteLine("Type [3] Generates random files and directories in the path");
    Console.WriteLine("Type [4] Rename all folders");
    Console.WriteLine("Type [EXIT] for closing the app");

    var operation = Console.ReadLine();

    // ReadLine moze zwrocic null, (jak wpiszemy ^Z czyli Ctrl+Z) wiec musimy sprawdzic czy nim nie jest by nie dostac bledu
    //if (operation == null)
    //{
    //    Console.WriteLine("Don't user Ctrl+Z!");
    //    continue;
    //}

    // Drugim rozwiazaniem jest dodanie do zmiennej (przed .) znaku ?
    // Korzystanie z '?.' powoduje, ze program wie, ze to co jest przed . MOZE byc nullem, wiec sam sobie w srodku
    // korzysta z takiego 'try-catch' czyli nie walnie nam bledem!
    // TZN. ze jesli operation jest null i ja odpale linie 'operation.ToUpper()' to bede mial NullReferenceException
    // a jesli uzyje 'operation?.ToUpper()' to bledu nie bedzie i zwroci nam znowu wartosc null

    switch (operation?.ToUpper())
    {
        case "1":
            service.ShowAll();
            break;
        case "2":
            service.DeleteAll();
            break;
        case "3":
            service.GenerateRandomValues();
            break;
        case "4":
            service.RenameFolders();
            break;
        case "EXIT":
            shutDown = true;
            break;
        default:
            Console.WriteLine("You've provided the wrong operation!");
            break;
    }
}

//carService.SaveData();

Console.WriteLine("Closing the application...");