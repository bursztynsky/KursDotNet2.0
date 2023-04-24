using _14_FirstAppWithDb.Models;
using System.Data.SqlClient;

namespace _14_FirstAppWithDb
{
    internal class DataService
    {
        public List<Car> Cars { get; set; } = new List<Car>();

        private readonly string _dbFilePath = "data\\cars.txt";

        private readonly string _dbConnectionString = "Server=localhost;Database=firstAppWithDb;User Id=sa;Password=12345Abc;";

        public void LoadDataFromDb()
        {
            var allCars = new List<Car>();

            using var connection = new SqlConnection(_dbConnectionString);

            var command = new SqlCommand("select * from Cars", connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var car = new Car()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Model = reader.GetString(2),
                    Year = reader.GetInt32(3),
                };

                allCars.Add(car);
            }

            Cars = allCars;
        }

        public Car GetCarFromRow(DataGridViewRow row)
        {
            var result = int.TryParse(row.Cells["CarId"].Value.ToString(), out var id);

            if (result == false)
            {
                MessageBox.Show("ERROR");

                return null;
            }

            if (id <= 0)
            {
                MessageBox.Show("ERROR");

                return null;
            }

            // LINQ -> to biblioteka ktora dodaje nam zajebiscie wygodne metody do korzytsania na
            // tablicach i kolekcjach
            // Mozemy chociazby znalezc metode First oraz FirstOrDefault

            // First() -> znajduje pierwszy obiekt spelniajacy regule ktora przekazuje jako argument
            // UWAGA: First WALI BLEDEM jesli nie znajdzie nic pasujacego
            //var car = Cars.First(car => car.Id == id);

            // FirstOrDefault() -> znajduje pierwszy obiekt spelniajacy regule ktora przekazuje jako argument
            // UWAGA: Nie wali bledem ale zwraca null jesli nie znalazl danej pozycji
            var car = Cars.FirstOrDefault(car => car.Id == id);

            if (car == null)
            {
                MessageBox.Show("CAR IS NULL");

                return null;
            }

            return car;
        }
    }
}
