using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Struktury
{
    internal struct Worker
    {
        // Tworzymy obiekt Worker ktory ma id (nieedytowalne), name (edytowalne publiczne) i age (edytowalne
        // ale kontrolujemy by liczba nie byla mniejsza niz 0)

        private int _id;
        public string Name;
        private int _age;

        // robimy getter dla id
        public int GetId()
        {
            // tutaj moge stworzyc kod ktory np. sprawdza czy id istnieje
            // i jesli nie istnieje to je tworzy a potem zwraca

            return _id;
        }

        // robimy setter dla id
        public void SetId(int id)
        {
            if (id > 0)
            {
                _id = id;
            }
            else
            {
                Console.WriteLine("Nie mozesz podac id mniejszego od 0");
            }
        }

        public int GetAge()
        {
            return _age;
        }

        // robimy setter dla id
        public void SetAge(int age)
        {
            if (age > 0)
            {
                _age = age;
            }
            else
            {
                Console.WriteLine("Nie mozesz podac wieku mniejszego od 0");
            }

            //ZmniejszWiek();
            //Console.WriteLine("Po zmianach masz wiek " + GetAge());
        }

        public void ZmniejszWiek()
        {
            _age -= 10;
        }
    }
}
