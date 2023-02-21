namespace _09_AplikacjaDlaKolekcji
{
    internal class DataService
    {
        public List<Car> GetCarsFromFile()
        {
            var fileName = "data\\cars.txt";

            var cars = new List<Car>();

            var lines = File.ReadAllLines(fileName);

            // Mamy juz lines ktore sa tablica samochodow ale w formie string czyli dane1;dane2;dane3
            // Musimy wiec wyciagnac te dane i stworzyc klasy Car na ich podstawie
            foreach (var line in lines)
            {
                // sprawdzamy czy linia nie jest pusta
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var data = line.Split(';');
                Console.WriteLine(string.Join(" ", data));

                // sprawdzamy czy w linijce tekstu sa 3 dane, lub wiecej/mniej
                if (data.Length != 3)
                    continue;

                var convertResult = int.TryParse(data[0], out int id);

                // sprawdzamy czy udalo sie przekonwertowac
                if (convertResult == false)
                    continue;

                // sprawdzamy czy id nie jest mniejszy od 1
                if (id < 1)
                    continue;

                var name = data[1];
                var model = data[2];
                var car = new Car(id, name, model);

                cars.Add(car);
            }

            return cars;
        }

        public void SaveCarsToFile(List<Car> cars)
        {
            var fileName = "data\\cars.txt";

            var convertedCars = new List<string>();

            foreach (var car in cars)
            {
                convertedCars.Add(car.ToString());
            }

            // sprawdzamy czy istnieje directory (sciezka) do pliku
            // jesli nie = tworzymy folder 'data'
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            File.WriteAllLines(fileName, convertedCars);
        }
    }
}
