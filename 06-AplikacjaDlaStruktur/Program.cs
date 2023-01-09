// ------------------------------
// Stworz aplikacje, ktora umozliwi tworzenie listy zwierzat
// czyt. dodawanie i usuwanie zwierzat oraz edycja istniejacych
// *aplikacja nie zapisuje danych w np. bazie, wiec wszystko to co wprowadzimy do aplikacji
// zniknie w momencie jej wylaczenia
// ------------------------------

// DEBUGOWANIE SKROTY KLAWIATUROWE:
// 1. F5 -> continue, czyli idz do nastepnego breakpoint (jesli nie ma nastepnego, to kod wykonuje sie dalej bez zatrzymywania
// 2. F10 -> move next, tzn ze przesuwamy sie o linjke w dol (oczywiscie pomija puste linie)
// 3. F11 -> step into, tzn wchodzimy w wywolywana metode i sie zatrzymujemy w pierwszej jej linijce kodu
// 4. Ctrl + Shift + F9 -> usuwa wszystkie breakpoint

// WAZNY SKROT:
// Ctrl + F12 -> jak najedziesz kursorem na nazwe metody i klikniesz F12 to przekieruje Cie do kodu tej metody

using _06_AplikacjaDlaStruktur;

var shutDown = false;
var cats = new Cat[] {
    new()
    {
        Name = "Kitek",
        Owner = "Jacek",
    },
    new()
    {
        Name = "Bialas",
        Owner = "Dominik",
    },
    new()
    {
        Name = "Puszek",
        Owner = "Monika",
    },
};

Console.WriteLine("Hello in the vet-application!");

while (!shutDown)
{
    Console.WriteLine("\nList of possible operations:");
    Console.WriteLine("Type [A] for adding the new cat");
    Console.WriteLine("Type [D] for delete the cat");
    Console.WriteLine("Type [S] for showing all cats");

    var providedValue = Console.ReadLine();

    switch (providedValue.ToUpper())
    {
        case "A":
            AddCat();
            break;
        case "S":
            ShowCats();
            break;
        case "D":
            DeleteCat();
            break;
        case "E":
            // TODO: edycja kotow
            EditCat();
            break;
        default:
            Console.WriteLine("You've provided the wrong operation!");
            break;
    }

}

Console.WriteLine("Closing the application...");

void AddCat()
{
    var success = false;
    var newCat = new Cat();

    while (!success)
    {
        Console.WriteLine("Provide a name of the new cat:");

        var providedValue = Console.ReadLine();

        try
        {
            Validate(providedValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            continue;
        }

        newCat.Name = providedValue;

        Console.WriteLine("Provide an Owner name of the new cat:");

        providedValue = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(providedValue))
        {
            continue;
        }

        newCat.Owner = providedValue;

        Console.WriteLine($"Addind the new cat to the system (Name: {newCat.Name}, Owner: {newCat.Owner})");

        success = true;
    }

    // tutaj juz wiem ze stworzono poprawnie kota i moge go dodac do tablicy
    AddToList(newCat);
}

// Metoda bedzie:
// 1. sprawdzac czy podane imie nie jest puste
// 2. sprawdzac czy istnieje kot o podanym imieniu w tablicy
void Validate(string name)
{
    if (string.IsNullOrWhiteSpace(name))
        throw new Exception("The name can't me empty!");

    foreach (var cat in cats)
        if (string.Equals(cat.Name, name, StringComparison.OrdinalIgnoreCase))
            throw new Exception($"There is already a cat with name '{name}'");
}

void AddToList(Cat cat)
{
    Console.WriteLine("Adding the new cat...");
    var newArray = new Cat[cats.Length + 1];

    var idx = 0;

    foreach (var existingCat in cats)
    {
        newArray[idx] = existingCat;

        idx++;
    }

    newArray[cats.Length] = cat;

    cats = newArray;
}

void ShowCats()
{
    Console.WriteLine("Cats list:");
    foreach (var cat in cats)
    {
        Console.WriteLine($"Name: {cat.Name}, Owner: {cat.Owner}");
    }
}

void RemoveFromList(string name)
{
    // Sprawdzmy czy tablica kotow nie jest pusta
    if (cats.Length < 1)
    {
        Console.WriteLine("There is no cats in the list!");

        return; // metoda przerywa sie w tej linii kiedy nie ma zadnego kota
    }

    #region Opcjolany kod weryfikujacy czy istnieje kot
    // UWAGA:
    // Moglibysmy najpierw przejsc element po elemencie i sprawdzic czy kot istnieje
    // To jest bartdzo praktyka I NAGMINNIE BEDZIEMY TEGO UZYWAC W KOLEKCJACH
    // Niestety tutaj mamy tablice i tak czy siak bede musial przejsc po jej wsyzsktich elementach
    // wiec lepiej jest przejsc po nich raz (i najzywej nie uzyc nowej tablicy bo nie znaleziono kota o taki imieniu)
    // niz przechodzic dwa razy po takiej tablicy np. mamy 1 milion kotow, wiec przjedziemy po 2 milionach zamiast po jednym

    var existsProvidedCat = false;
    foreach (var existingCat in cats)
    {
        if (string.Equals(existingCat.Name, name, StringComparison.OrdinalIgnoreCase))
        {
            existsProvidedCat = true;
        }
    }

    if (!existsProvidedCat)
    {
        Console.WriteLine("There is no cat with this name!");

        return;
    }
    #endregion

    var newArray = new Cat[cats.Length - 1];
    var idx = 0;

    foreach (var existingCat in cats)
    {
        if (!string.Equals(existingCat.Name, name, StringComparison.OrdinalIgnoreCase))
        {
            newArray[idx] = existingCat;

            idx++;
        }

    }

    // Jesli udalo mi sie znalezc podanego kota to
    // 1. Wyswietlam odpowiedni komunikat
    // 2. Nadpisuje moja talbice kotow nowa tablica bez tego kota
    if (existsProvidedCat)
    {
        cats = newArray;

        Console.WriteLine("Removed successfully!");
    }
    else
    {
        Console.WriteLine($"There is not cat with the name '{name}'");
    }

    #region Kod ciekawostka jak to zrobic szybciej wbudowana metoda FindAll()
    // Skorzystamy z metody Array.FindAll()
    // Zwraca ona nowa tablice z elemntami spelniajacymi podany warunek
    // Tzn. Mozemy to zrobic tak, ze zwrocimy sobie nowa tablicy bez kota o podanym imieniu,
    // dzieki czemu skrocimy proces 'usuwania' kota z tablicy

    //cats = Array
    //    //             tutaj mamy warunek ktory mowi CZY kopiowac wartosc czy nie
    //    //             korzystamy tutaj z lambda expression inaczej nazywane anonimowa funkcja
    //    //             co to znaczy? To jest po prostu metoda jak kazda inna np. DeleteDat() ale nie ma swojej nazwy
    //    // Budowa lambda expression:
    //    //  zmiennaBedacaElementemPoElemencieSprawdzanymWTablicy => tutajMamLinjkeKoduKtoraZwracaTrueLubFalse
    //    .FindAll(cats, cat => !string.Equals(cat.Name, name, StringComparison.OrdinalIgnoreCase))
    //    // Musze jeszcze na koniec odpalic metode ToArray() -> o tym przy interfejsach
    //    .ToArray();
    #endregion
}

void DeleteCat()
{
    var success = false;

    while (!success)
    {
        Console.WriteLine("Provide a name of the new cat that you want to remove:");

        var providedValue = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(providedValue))
        {
            Console.WriteLine("The name can't me empty!");

            continue;
        }

        success = true;

        RemoveFromList(providedValue);
    }
}

void EditCat()
{
    // TODO: skoncz metode
}