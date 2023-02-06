// ------------------------
// Aplikacja ktora pozwala zarzadzac samochodami w firmie z wykorzystaniem:
// 1. Klas
// 2. Kolekcji generycznych
// 3. Zapisywaniem wynikow do i z pliku .txt
// ------------------------

// SERIALIZACJA -> proces przekonstruowania danych z programu do miejsca jego przetrzymywania (np. plik .txt,
// .json, .xml, bazy danych SQL i NO-SQL)
// DESERIALIZACJA -> odwrocenie procesu serializacji (czyli wczytanie danych DO aplikajci z zewnatrz)

// TODO: Skonczyc Edit oraz zerobic serializacje do pliku .txt i z pliku .txt

using _09_AplikacjaDlaKolekcji;

var shutDown = false;

var allCars = new List<Car>();

Console.WriteLine("Hello in the car-application!");

while (!shutDown)
{
    Console.WriteLine("\nList of possible operations:");
    Console.WriteLine("Type [A] for adding the new car");
    Console.WriteLine("Type [D] for delete the car");
    Console.WriteLine("Type [S] for showing all cars");
    Console.WriteLine("Type [E] for editing the car");

    var providedValue = Console.ReadLine();

    switch (providedValue.ToUpper())
    {
        case "A":
            Add();
            break;
        case "S":
            Show();
            break;
        case "D":
            Delete();
            break;
        //case "E":
        //    Edit();
        //    break;
        default:
            Console.WriteLine("You've provided the wrong operation!");
            break;
    }

}

Console.WriteLine("Closing the application...");

void Add()
{
    var success = false;
    var newCar = new Car();

    while (!success)
    {
        Console.WriteLine("Provide a name of the new car:");

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

        newCar.Name = providedValue;

        Console.WriteLine("Provide a model name of the new car:");

        providedValue = Console.ReadLine();

        try
        {
            Validate(providedValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            continue;
        }

        newCar.Model = providedValue;

        success = true;
    }

    allCars.Add(newCar);
}

//// Metoda bedzie:
//// 1. sprawdzac czy podane imie nie jest puste
void Validate(string name)
{
    if (string.IsNullOrWhiteSpace(name))
        throw new Exception("The name can't me empty!");
}

void Show()
{
    Console.WriteLine("Cars list:");
    foreach (var car in allCars)
    {
        // Poniewaz klasy domyslnie jak psorubjemy wyswietlic w WriteLine wyswietlaja nazwe swojej klasy
        // to zrobimy specjalna metode, ktora powie aplikacji, to ma wyswietlic
        // jesli parsujemy Car na string
        //Console.WriteLine($"Name: {car.Name}, Owner: {car.Owner}");
        Console.WriteLine(car.ToString());
    }
}

void Delete()
{
    var success = false;

    while (!success)
    {
        Console.WriteLine("Provide an ID of the new car that you want to remove:");

        var providedValue = Console.ReadLine();

        try
        {
            Validate(providedValue);

            var carId = int.Parse(providedValue);

            // Posiadajac carId musze znalezc w mojej liscie odpowiedni Car
            // zapisac sobie referencje do tego Car w np. nowe zmiennej 'carToRemove'
            // I na koniec przekazac ta refenrecje do wbudowane metody Remov() z klasy List<T>

            var carToRemove = allCars.Find(x => x.Id == carId);

            // Moze byc sytuacja ze w liscie samochodow nie ma tego co szukam wiec carToRemove bedzie null
            // (bo Find zwraca null jesli nie znajdzie)
            // Robie wiec warunek sprawdzajacy czy carToRemove jest null i jesli tak to wyswietlam odpowiednie info
            if (carToRemove == null)
                throw new Exception($"There is not car with provided id {carId}");

            allCars.Remove(carToRemove);

            Console.WriteLine("You've removed car successfully!");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("You've provided a wrong number!");

            continue;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            continue;
        }

        success = true;
    }
}

//void ValidateToEdit(string providedValue)
//{
//    if (string.IsNullOrWhiteSpace(providedValue))
//        throw new Exception("The name can't me empty!");

//    var carExists = false;

//    foreach (var existingcar in cars)
//        if (string.Equals(existingcar.Name, providedValue, StringComparison.OrdinalIgnoreCase))
//            carExists = true;

//    if (!carExists)
//        throw new Exception("There is no car with provided name!");
//}

//void Editcar()
//{
//    // Edycja polega na wyszukaniu kota po jego imieniu i po znalezeniu umozliwiamy edycje imienia kota oraz
//    // lub wlascicela
//    // KROKI:
//    // 1. Potrzebujemy zweryfikowac czy podano prawidlowe imie kota
//    // 2. Jesli nie - zmuszczamy do podania imienia az bedzie ok
//    // 3. Jesli mamy imie kota i wiemy ze istnieje w tablicy to wyciagamy sobie tego kota i pokazujemy w konsoli
//    // 4. Pytamy uzytkownika czy chce zmienic imie lub imie wlasciciela
//    // 5. Umozliwia zmiane (weryfikujac podane dane np. sprawdzjac czy taki kot juz istnieje)
//    // 6. Po poprawnej zmianie wyswietlamy odpowiedni komunikat

//    var success = false;

//    //var carToEditName = ""; // to jest to samo co ponizej
//    var carToEditName = string.Empty;

//    // -- ETAP1: Wyciagniecie od uzytkownika imienia kota do edycji
//    while (!success)
//    {
//        Console.WriteLine("Provide a name of the car to edit:");

//        var providedValue = Console.ReadLine();

//        try
//        {
//            ValidateToEdit(providedValue);
//        }
//        carch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);

//            continue;
//        }

//        carToEditName = providedValue;

//        success = true;
//    }

//    // -- ETAP2: Pobieranie kota po jego imieniu
//    success = false;
//    var carToEdit = new car();

//    while (!success)
//    {
//        foreach (var existingcar in cars)
//            if (string.Equals(existingcar.Name, carToEditName, StringComparison.OrdinalIgnoreCase))
//                carToEdit = existingcar;

//        success = true;
//    }

//    // ETAP3: Pobranie od uzytkownika operacji jaka chce wykonac przy edycji
//    success = false;
//    var editOperationType = EditOperationType.ChangeName;

//    while (!success)
//    {
//        Console.WriteLine("Type [N] for editing the name of the car.\nType [O] for editing the Owner.\nType [B] for editing the both values.");

//        var providedValue = Console.ReadLine();

//        switch (providedValue.ToUpper())
//        {
//            case "N":
//                editOperationType = EditOperationType.ChangeName;
//                break;
//            case "O":
//                editOperationType = EditOperationType.ChangeOwner;
//                break;
//            case "B":
//                editOperationType = EditOperationType.ChangeBoth;
//                break;
//            default:
//                continue;
//        }

//        success = true;
//    }

//    // -- ETAP4: Wykonujemy operacje edycji

//    if (editOperationType == EditOperationType.ChangeName)
//    {
//        ChangeName(carToEdit);
//    }
//    else if (editOperationType == EditOperationType.ChangeOwner)
//    {
//        ChangeOwner(carToEdit);
//    }
//    else if (editOperationType == EditOperationType.ChangeBoth)
//    {
//        var editedcar = ChangeName(carToEdit);
//        ChangeOwner(editedcar);
//    }
//}