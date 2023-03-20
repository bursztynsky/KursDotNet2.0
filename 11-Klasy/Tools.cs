using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Klasy
{
    internal static class Tools
    {
        public static void PrintValues(Worker worker)
        {
            //Console.WriteLine(worker.Name + " " + worker.Surname);
            PrintNameAndSurname(worker);

            Console.WriteLine("Salary:" + worker.Salary);
        }

        public static void PrintValues(Client client)
        {
            //Console.WriteLine(client.Name + " " + client.Surname);
            PrintNameAndSurname(client);

            Console.WriteLine("Address: " + client.Address);
        }

        private static void PrintNameAndSurname(Human human)
        {
            Console.WriteLine(human.Name + " " + human.Surname);
        }
    }
}
