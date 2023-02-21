namespace _09_AplikacjaDlaKolekcji
{
    internal class CarService
    {
        private readonly DataService _dataService;

        public List<Car> Cars { get; set; } = new List<Car>();

        public CarService()
        {
            _dataService = new DataService();

            Cars = _dataService.GetCarsFromFile();
        }

        public void SaveData()
        {
            _dataService.SaveCarsToFile(Cars);
        }

        public void Add()
        {
            var success = false;
            var newCar = new Car();

            while (!success)
            {
                Console.WriteLine("Provide a name of the new car:");

                var providedValue = Console.ReadLine();

                newCar.Id = BiggestId() + 1;

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

            // Walidacja czy nie istnieje juz samochod o takim ID
            if (Cars.Exists(car => car.Id == newCar.Id))
            {
                throw new Exception($"Car with Id '{newCar.Id}' already exists!");
            }

            Cars.Add(newCar);
        }

        public void Show()
        {
            Console.WriteLine("Cars list:");
            foreach (var car in Cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public void Delete()
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

                    var carToRemove = Cars.Find(x => x.Id == carId);

                    // Moze byc sytuacja ze w liscie samochodow nie ma tego co szukam wiec carToRemove bedzie null
                    // (bo Find zwraca null jesli nie znajdzie)
                    // Robie wiec warunek sprawdzajacy czy carToRemove jest null i jesli tak to wyswietlam odpowiednie info
                    if (carToRemove == null)
                        throw new Exception($"There is not car with provided id {carId}");

                    Cars.Remove(carToRemove);

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

        public void Edit()
        {
            var success = false;

            var carToEditName = string.Empty;

            Car carToEdit = new Car();

            // -- ETAP1: Wyciagniecie od uzytkownika obiekt do edycji
            while (!success)
            {
                Console.WriteLine("Provide car ID to edit:");

                var providedValue = Console.ReadLine();

                try
                {
                    carToEdit = GetCar(providedValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    continue;
                }

                success = true;
            }

            // ETAP2: Pobranie od uzytkownika operacji jaka chce wykonac przy edycji
            success = false;
            var editOperationType = EditOperationType.ChangeName;

            while (!success)
            {
                Console.WriteLine("Type [N] for editing the name of the car.\nType [M] for editing the Model.\nType [B] for editing the both values.");

                var providedValue = Console.ReadLine();

                switch (providedValue.ToUpper())
                {
                    case "N":
                        editOperationType = EditOperationType.ChangeName;
                        break;
                    case "M":
                        editOperationType = EditOperationType.ChangeModel;
                        break;
                    case "B":
                        editOperationType = EditOperationType.ChangeBoth;
                        break;
                    default:
                        continue;
                }

                success = true;
            }

            // -- ETAP3: Wykonujemy operacje edycji
            if (editOperationType == EditOperationType.ChangeName)
            {
                ChangeName(carToEdit);
            }
            else if (editOperationType == EditOperationType.ChangeModel)
            {
                ChangeModel(carToEdit);
            }
            else if (editOperationType == EditOperationType.ChangeBoth)
            {
                ChangeBoth(carToEdit);
            }
        }

        private void ChangeName(Car car)
        {
            var success = false;

            while (!success)
            {
                Console.WriteLine("Provide the new name:");

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

                // ZMIENIAMY NAZWE
                car.Name = providedValue;

                success = true;
            }
        }
        private void ChangeModel(Car car)
        {
            var success = false;

            while (!success)
            {
                Console.WriteLine("Provide the new model name:");

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

                // ZMIENIAMY MODEL
                car.Model = providedValue;

                success = true;
            }
        }
        private void ChangeBoth(Car car)
        {
            ChangeName(car);
            ChangeModel(car);
        }
        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("The name can't me empty!");
        }
        private Car GetCar(string providedValue)
        {
            // sprawdzamy czy podana wartosc nie jest pustym stringiem
            if (string.IsNullOrWhiteSpace(providedValue))
                throw new Exception("The name can't me empty!");

            // sprawdzamy czy podana wartosc to liczba calkowita
            var parseResult = int.TryParse(providedValue, out var carId);

            if (!parseResult)
                throw new Exception("Provided value is not a number");

            // bierzemy referencje do samochodu jaki chcemy edytowac oraz zwracamy ta referencje
            var carResult = Cars.Find(car => car.Id == carId);

            if (carResult == null)
                throw new Exception("There is no car with id: " + carId);

            return carResult;
        }
        private int BiggestId()
        {
            if (Cars.Count == 0)
                return 0;

            var result = Cars.First();

            if (result == null)
                return 0;

            if (Cars.Count == 1)
                return result.Id;

            foreach (var car in Cars)
            {
                if (car.Id != result.Id && car.Id > result.Id)
                    result = car;
            }

            return result.Id;
        }
    }
}