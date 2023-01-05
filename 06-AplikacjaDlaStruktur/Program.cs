// ------------------------------
// Stworz aplikacje, ktora umozliwi tworzenie listy zwierzat
// czyt. dodawanie i usuwanie zwierzat oraz edycja istniejacych
// *aplikacja nie zapisuje danych w np. bazie, wiec wszystko to co wprowadzimy do aplikacji
// zniknie w momencie jej wylaczenia
// ------------------------------

using _06_AplikacjaDlaStruktur;
using static System.Runtime.InteropServices.JavaScript.JSType;

var shutDown = false;
var cats = new Cat[] {
    new()
    {
        Name = "Puszek",
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

        if (string.IsNullOrWhiteSpace(providedValue))
        {
            continue; // continue -> pwooduje, ze kod ponizej sie nie wykona i znowu zaczynam od linni 44
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
    Console.WriteLine("Removing the cat...");

    var newArray = new Cat[cats.Length - 1];
    var idx = 0;
    var success = false;

    foreach (var existingCat in cats)
    {
        if (existingCat.Name.ToUpper() != name.ToUpper())
        {
            newArray[idx] = existingCat;

            idx++;
        }
        else
        {
            success = true;

            break;
        }
    }

    if (!success)
    {
        Console.WriteLine("There was a problem with removing the cat of the name: " + name);

        return;
    }

    cats = newArray;
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
            continue;
        }

        success = true;

        RemoveFromList(providedValue);
    }
}