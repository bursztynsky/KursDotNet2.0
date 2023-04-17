using _14_FirstAppWithDb.Models;
using System.Data.SqlClient;

namespace _14_FirstAppWithDb
{
    internal class DataService
    {
        public List<Car> Cars { get; set; } = new List<Car>();

        private readonly string _dbFilePath = "data\\cars.txt";

        private readonly string _dbConnectionString = "Server=localhost;Database=firstAppWithDb;User Id=sa;Password=12345Abc;";

        public List<Car> GetAllFromDb()
        {
            using var connection = new SqlConnection(_dbConnectionString);

            var command = new SqlCommand("select * from Cars", connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                MessageBox.Show(string.Format("{0}, {1}, {2}, {3}", reader[0], reader[1], reader[2], reader[3]));
            }

            return new List<Car>();
        }

        /// <summary>
        /// This method will return new cars from provided file and 
        /// </summary>
        public void GetCarsFromFile(string fileName)
        {
            try
            {
                var newCars = GetNewCars(fileName);

                // sprawdzamy czy nowy samochod juz nie istnieje
                foreach (var car in newCars)
                {
                    //if(CheckIfCarExists(car) == false)
                    if (!CheckIfCarExists(car))
                    {
                        Cars.Add(car);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveCarsToFile()
        {
            var convertedCars = new List<string>();

            foreach (var car in Cars)
            {
                convertedCars.Add(car.ToString());
            }


            File.WriteAllLines(_dbFilePath, convertedCars);
        }

        /// <summary>
        /// This method will take cars from db and save it in the service
        /// </summary>
        public void InitData()
        {
            Cars = GetFromDb();
        }

        /// <summary>
        /// This method will return a list of cars from provided cars, there will be no ids!
        /// </summary>
        private List<Car> GetNewCars(string fileName)
        {
            var result = new List<Car>();

            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var data = line.Split(';');
                Console.WriteLine(string.Join(" ", data));

                if (data.Length != 3)
                    continue;

                var convertResult = int.TryParse(data[2], out int year);

                if (convertResult == false)
                    continue;

                if (year < 1800)
                    continue;

                var name = data[0];
                var model = data[1];

                var car = new Car(name, model, year);

                result.Add(car);
            }

            return result;
        }

        /// <summary>
        /// This method will return a list of cars from file database
        /// </summary>
        public List<Car> GetFromDb()
        {
            CreateDbFileIsNotExists();

            var result = new List<Car>();

            var lines = File.ReadAllLines(_dbFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var data = line.Split(';');
                Console.WriteLine(string.Join(" ", data));

                if (data.Length != 4)
                    continue;

                // sprawdzam czy id da sie przekonwertowac
                var convertResult = int.TryParse(data[0], out int id);

                if (convertResult == false)
                    continue;

                // sprawdzam czy rok da sie przekonwertowac
                convertResult = int.TryParse(data[3], out int year);

                if (convertResult == false)
                    continue;

                // sprawdzam czy rok jest odpowiedni
                if (year < 1800)
                    continue;

                var name = data[1];
                var model = data[2];

                var car = new Car(name, model, year);

                result.Add(car);
            }

            return result;
        }

        /// <summary>
        /// This method will create a db file if deosn't exist
        /// </summary>
        private void CreateDbFileIsNotExists()
        {
            // sprawdzamy czy istnieje directory (sciezka) do pliku
            // jesli nie = tworzymy folder 'data'
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            if (!File.Exists(_dbFilePath))
            {
                var stream = File.Create(_dbFilePath);
                stream.Dispose();
            }
        }

        /// <summary>
        /// This method will return a list of cars that we want to create if there is no cars available
        /// </summary>
        private List<Car> SeedCars()
        {
            // Seed data czyli tzw. zasianie danymi
            // Tzn. ze dla testow dodamy sobie juz jakies wartosci jesli zadne nie istnieja
            return new List<Car>()
                {
                    new Car("Toyota", "Yaris", 2001),
                    new Car("Audi", "Q7", 2021),
                    new Car("Nissan", "Primera", 2000),
                    new Car("Fiat", "Panda", 1997),
                };
        }


        private bool CheckIfCarExists(Car car)
        {
            foreach (var existingCar in Cars)
            {
                // zapobiegamy dodaniu samochodu z takim samym id
                if (existingCar.Id == car.Id)
                    return true;

                // sprawdzamy czy istnieje juz samochod z taka sama nazwa, modelem i rokiem
                if (existingCar.Name == car.Name && existingCar.Model == car.Model && existingCar.Year == car.Year)
                    return true;
            }

            return false;
        }
    }
}
