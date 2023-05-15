// Najprostszym sposobem na korzystanie z bazy danych z poziomu aplikacji jest polaczenie za pomoca
// SqlConnection oraz wysylanie zapytan SQL korzystajac z klasy SqlCommand

// to jest string z adresem do serwera sql, nazwa bazy danych oraz userem jakim sie logujemy
// server name jesli jest .\\ lub localhost tzn. ze szukamy serwera na twoim kompie
using _15_BazaDanych;

var dbService = new DbService();

while (true)
{
    var shutDown = false;
    Console.WriteLine("Podaj komende:");
    Console.WriteLine("[S] -> wyswietl uzytkownikow");
    Console.WriteLine("[A] -> dodaj uzytkownika");
    Console.WriteLine("[U] -> edytuj uzytkownika");
    Console.WriteLine("[D] -> usun uzytkownika");
    Console.WriteLine("[E] -> exit");

    var comm = Console.ReadLine();

    switch (comm.ToUpper())
    {
        case "S":
            ShowAllUsers();
            break;
        case "A":
            Add();
            break;
        case "U":
            Update();
            break;
        case "D":
            Delete();
            break;
        case "E":
            shutDown = true;
            break;
    }

    if (shutDown)
    {
        break;
    }
}

Console.WriteLine("Closing app...");

void ShowAllUsers()
{
    var allUsers = dbService.GetAllUsersFromDb();

    foreach (var user in allUsers)
    {
        Console.WriteLine(user.GetUserInfo());
    }
}

void Add()
{
    Console.WriteLine("Podaj imie");
    var name = Console.ReadLine();

    Console.WriteLine("Podaj nazwisko");
    var surname = Console.ReadLine();

    Console.WriteLine("Podaj email");
    var email = Console.ReadLine();

    var user = new User(name, surname, email);

    dbService.AddUser(user);
}

void Update()
{
    Console.WriteLine("Podaj id");
    var stringId = Console.ReadLine();

    var parseResult = int.TryParse(stringId, out var id);

    if (parseResult == false)
    {
        // obslugujemy blad...
    }

    Console.WriteLine("Podaj imie");
    var name = Console.ReadLine();

    Console.WriteLine("Podaj nazwisko");
    var surname = Console.ReadLine();

    Console.WriteLine("Podaj email");
    var email = Console.ReadLine();

    var user = new User(id, name, surname, email);

    dbService.EditUser(user);
}

void Delete()
{
    Console.WriteLine("Podaj id");
    var stringId = Console.ReadLine();

    var parseResult = int.TryParse(stringId, out var id);

    if (parseResult == false)
    {
        // obslugujemy blad...
    }

    dbService.DeleteUser(id);
}