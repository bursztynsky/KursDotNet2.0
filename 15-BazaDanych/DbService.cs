using System.Data.SqlClient;

namespace _15_BazaDanych
{
    internal class DbService
    {
        private string _connectionString = "Server=.\\;Initial Catalog=app1;User ID=sa;Password=12345Abc;MultipleActiveResultSets=True;TrustServerCertificate=True";
        private SqlConnection _connection;

        public DbService()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public void AddUser(User user)
        {
            // WERYFIKACJa czy uzytkownik o tkaim email juz nie istnieje
            var allUsers = GetAllUsersFromDb();

            _connection.Open();

            // LINQ -> biblioteka ktora udostepnia nam metody takie jak First, FirstOrDefault, Where, Select itd...
            // First -> przyjmuje funkcje na podstawie ktorej szuka pozycji w kolekcji, jesli nie ma zwraca blad!
            // FirstOrDefault -> przyjmuje funkcje na podstawie ktorej szuka pozycji w kolekcji, jesli nie ma zwraca null (default wartosc dla klasy)
            var existingUser = allUsers.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
                Console.WriteLine("UZYTKOWNIK O TAKIM MAILU JUZ ISTNIEJE!");
                return;
            }

            var arg1 = new SqlParameter("arg1", user.Name);
            var arg2 = new SqlParameter("arg2", user.Surname);
            var arg3 = new SqlParameter("arg3", user.Email);

            using var selectUsers = new SqlCommand("insert into Users values(@arg1, @arg2, @arg3)", _connection);
            selectUsers.Parameters.Add(arg1);
            selectUsers.Parameters.Add(arg2);
            selectUsers.Parameters.Add(arg3);

            selectUsers.ExecuteNonQuery();

            _connection.Close();
        }

        public void DeleteUser(int id)
        {
            // WERYFIKACJA czy uzytkownik jakiego chcemy usunac istnieje
            var allUsers = GetAllUsersFromDb();

            var existingUser = allUsers.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
            {
                Console.WriteLine("UZYTKOWNIK O TAKIM ID NIE ISTNIEJE!");
                return;
            }

            _connection.Open();

            using var selectUsers = new SqlCommand($"delete from Users where id = {id}", _connection);

            selectUsers.ExecuteNonQuery();

            _connection.Close();
        }

        public void EditUser(User user)
        {
            // WERYFIKACJA czy uzytkownik jakiego chcemy edytowac istnieje
            var allUsers = GetAllUsersFromDb();

            var existingUser = allUsers.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser == null)
            {
                Console.WriteLine("UZYTKOWNIK O TAKIM ID NIE ISTNIEJE!");
                return;
            }

            _connection.Open();

            using var selectUsers = new SqlCommand(@$"
update Users set
[name] = '{user.Name}'
,[surname] = '{user.Surname}'
,[email] = '{user.Email}'
where id = '{user.Id}'
", _connection);

            selectUsers.ExecuteNonQuery();

            _connection.Close();
        }

        public List<User> GetAllUsersFromDb()
        {
            _connection.Open();

            var result = new List<User>();
            using var selectUsers = new SqlCommand("select * from Users", _connection);

            var reader = selectUsers.ExecuteReader();

            while (reader.Read())
            {
                var user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                result.Add(user);
            }

            _connection.Close();

            return result;
        }
    }
}
