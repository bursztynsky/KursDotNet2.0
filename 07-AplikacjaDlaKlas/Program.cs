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

Console.WriteLine("Hello in the vet-application (using class instead of structure)!");

while (!shutDown)
{
    Console.WriteLine("\nList of possible operations:");
    Console.WriteLine("Type [A] for adding the new cat");
    Console.WriteLine("Type [D] for delete the cat");
    Console.WriteLine("Type [S] for showing all cats");
    Console.WriteLine("Type [E] for editing the cat");

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

void ValidateToEdit(string providedValue)
{
    if (string.IsNullOrWhiteSpace(providedValue))
        throw new Exception("The name can't me empty!");

    var catExists = false;

    foreach (var existingCat in cats)
        if (string.Equals(existingCat.Name, providedValue, StringComparison.OrdinalIgnoreCase))
            catExists = true;

    if (!catExists)
        throw new Exception("There is no cat with provided name!");
}

void EditCat()
{
    var success = false;

    var catToEditName = string.Empty;

    // -- ETAP1: Wyciagniecie od uzytkownika imienia kota do edycji
    while (!success)
    {
        Console.WriteLine("Provide a name of the cat to edit:");

        var providedValue = Console.ReadLine();

        try
        {
            ValidateToEdit(providedValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            continue;
        }

        catToEditName = providedValue;

        success = true;
    }

    // -- ETAP2: Pobieranie kota po jego imieniu
    success = false;

    // Kiedy robie nowa zmienna z klasa w srodku (uzywam slowa new)
    // to pod spodem dzieje sie to:
    // 1. Tworzone jest w nowej komorce pamieci miejsce na nowa zmienna
    // 2. Kiedy tworze pusta klase (nie przekazuje zadnych danych jak np. imie) to w miejscu w tej komorce pamieci
    // tworzony jest obiekt Cat z domyslnymi wartosciami
    var catToEdit = new Cat();

    while (!success)
    {
        foreach (var existingCat in cats)
            if (string.Equals(existingCat.Name, catToEditName, StringComparison.OrdinalIgnoreCase))
                // KLUCZOWA LINIA
                // Tutaj jest sytuacja ze do zmiennej ktora posiada wartosc typu class Cat przypisuje inna
                // wartosc typu class Car
                // W PRZECIWIENSTWIE do struktur w miejscu w pamieci gdzie lezy zmienna catToEdit
                // nie tworzymy nowego kota o takich samych wartosciach ALE mowimy mu, ze
                // ma on teraz wskazywac na adres w pamieci gdzie lezy znaleziony kot 'existingCat'
                // i od teraz zmienna 'catToEdit' posiada REFERENCJE do kota w tablicy ktorego sobie znalezlismy
                catToEdit = existingCat;

        success = true;
    }

    // ETAP3: Pobranie od uzytkownika operacji jaka chce wykonac przy edycji
    success = false;
    var editOperationType = EditOperationType.ChangeName;

    while (!success)
    {
        Console.WriteLine("Type [N] for editing the name of the Cat.\nType [O] for editing the Owner.\nType [B] for editing the both values.");

        var providedValue = Console.ReadLine();

        switch (providedValue.ToUpper())
        {
            case "N":
                editOperationType = EditOperationType.ChangeName;
                break;
            case "O":
                editOperationType = EditOperationType.ChangeOwner;
                break;
            case "B":
                editOperationType = EditOperationType.ChangeBoth;
                break;
            default:
                continue;
        }

        success = true;
    }

    // -- ETAP4: Wykonujemy operacje edycji

    Console.WriteLine("Kot przed edycja ma imie: " + catToEdit.Name);

    if (editOperationType == EditOperationType.ChangeName)
    {
        // do metody przekazuje zmienna catToEdit
        // catToEdit wskazuje na komurke w pamieci gdzie mam REFERENCJE do kota w tablicy
        // W srodku metody tworzy sie nowa zmienna o nazwie 'cat' i do niej KOPIUJE REFERENCJE do kota z tablicy
        ChangeName(catToEdit);
        Console.WriteLine("Kot po edycji ma imie: " + catToEdit.Name);
    }
    else if (editOperationType == EditOperationType.ChangeOwner)
    {
        ChangeOwner(catToEdit);
    }
    else if (editOperationType == EditOperationType.ChangeBoth)
    {
        ChangeName(catToEdit);
        ChangeOwner(catToEdit);
    }
}

void ChangeName(Cat cat)
{
    var success = false;

    while (!success)
    {
        Console.WriteLine("Type the new cat name:");
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

        // DZIEKI TEMU ze jest to klasa to moge bezposrednio zmienic imie .Name na cos nowego
        // i za wartosc bedzie zapisana w kocie z tablicy
        // BO DO ZMIENNYCH PRZYPISALEM REFERENCJE DO TEGO KOTA Z TABLICY
        cat.Name = providedValue;

        Console.WriteLine("You have changes the name successfully!");

        success = true;
    }
}

void ChangeOwner(Cat cat)
{
    var success = false;

    while (!success)
    {
        Console.WriteLine("Type the new Owner name:");
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

        cat.Owner = providedValue;

        Console.WriteLine("You have changed the Owner successfully!");

        success = true;
    }
}