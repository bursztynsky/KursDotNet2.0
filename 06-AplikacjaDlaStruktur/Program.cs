﻿// ------------------------------
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
    // Edycja polega na wyszukaniu kota po jego imieniu i po znalezeniu umozliwiamy edycje imienia kota oraz
    // lub wlascicela
    // KROKI:
    // 1. Potrzebujemy zweryfikowac czy podano prawidlowe imie kota
    // 2. Jesli nie - zmuszczamy do podania imienia az bedzie ok
    // 3. Jesli mamy imie kota i wiemy ze istnieje w tablicy to wyciagamy sobie tego kota i pokazujemy w konsoli
    // 4. Pytamy uzytkownika czy chce zmienic imie lub imie wlasciciela
    // 5. Umozliwia zmiane (weryfikujac podane dane np. sprawdzjac czy taki kot juz istnieje)
    // 6. Po poprawnej zmianie wyswietlamy odpowiedni komunikat

    var success = false;

    //var catToEditName = ""; // to jest to samo co ponizej
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
    var catToEdit = new Cat();

    while (!success)
    {
        foreach (var existingCat in cats)
            if (string.Equals(existingCat.Name, catToEditName, StringComparison.OrdinalIgnoreCase))
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

    if (editOperationType == EditOperationType.ChangeName)
    {
        ChangeName(catToEdit);
    }
    else if (editOperationType == EditOperationType.ChangeOwner)
    {
        ChangeOwner(catToEdit);
    }
    else if (editOperationType == EditOperationType.ChangeBoth)
    {
        var editedCat = ChangeName(catToEdit);
        ChangeOwner(editedCat);
    }
}

// Ta metoda zmienia imie kota w tablicy ORAZ zwraca obiekt tego edytowanego kota
// (bym wiedzial jakie jest jego nowe imie)
Cat ChangeName(Cat cat)
{
    var success = false;
    var editedCat = new Cat();

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

        // Taka edycja kota NIE ZADZIALA w przypadku typu struct
        // zmienna cat, ktora jest przekazywana do metody to inna zmienna w innej komorce pamieci
        // niz ten kot oryginalny jaki jest w mojej tablicy kotow (taka jest specyfika typow wartosciowych)
        // BO TYPY WARTOSCIOWE PRZEKAZYWANE DO FUNCKJI SA NOWA KOPIA TEGO CO PRZEKAZUJEMY
        // i nie wiedza gdzie w pamieci lezy ten oryginal
        //cat.Name = providedValue;

        // Musimy wiec zrobic tak:
        // 1. Idziemy do tablicy i przechodzimy po niej (z indeksami czyli for) az znajdziemy kota
        //    ktory ma to samo imie to ten kot ktorego edytujemy (ale nie jego nowe imie tylko stare)
        // 2. Edytujemy bezposrednio w tablicy ten element po indeksie czyli zmieniamy mu imie lub ownera lub oba
        for (int i = 0; i < cats.Length; i++)
        {
            if (string.Equals(cats[i].Name, cat.Name, StringComparison.OrdinalIgnoreCase))
            {
                // edytuje imie kota w tablicy by zapisac mu to nowe imie
                cats[i].Name = providedValue;

                // ustawiam ta zmienna jaka zwroce czyli kota PO EDYCJI
                editedCat = cats[i];

                break; // wychodze z for bo wiem, ze nie ma po co isc dalej w array bo nie ma wiecej kotow
                // o takim imieniu
            }
        }

        Console.WriteLine("You have changes the name successfully!");

        success = true;
    }

    return editedCat;
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

        for (int i = 0; i < cats.Length; i++)
        {
            if (string.Equals(cats[i].Name, cat.Name, StringComparison.OrdinalIgnoreCase))
            {
                cats[i].Owner = providedValue;

                break;
            }
        }

        Console.WriteLine("You have changed the Owner successfully!");

        success = true;
    }
}