using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _05_Struktury
{
    internal struct Cat
    {
        // w C# zamiast robic prywatne pola i do nich oddzielne gettery i settery
        // mozemy skorzystac z Wlasciwosci (Property)
        // W momencie jak tworze property to gdy kompiluje kod to kompilator SAM
        // generuje pod spodem gettery i settery
        // PLUS:
        // - nie musze tworzyc oddzielnie metod get i set
        // - property jest uzywane identycznie tak samo jak pole czyli kiedy ustawiam
        // nowa wartosc dla property to robie to tak jakby to bylo pole a nie odpalam metode SetName()

        // prop + Tab (dwa razy) -> generuje property
        // WAZNE -> JESLI PROPERTY JEST PUBLIC TO ZAWSZE PISZ Z DUZEJ LITERY (PascalCase)
        public string Name { get; set; }

        // ten kawalek kodu zostanie zamieniony na cos takiego:
        //private string _name;

        //public void SetName(string name)
        //{
        //    _name = name;
        //}

        //public string GetName()
        //{
        //    return _name;
        //}


        // OCZYWISCIE w property mozemy powiedziec JAK wyglada getter i setter
        private string _owner;

        public string Owner
        {
            get
            {
                Console.WriteLine("Czytam imie kota...");
                return _owner;
            }
            set
            {
                Console.WriteLine("Probuje ustawic Wlasciciela na wartosc: " + value);
                _owner = value;
            }
            // w set mozemy uzyc slowa 'value' ktore przedstawia wartosc jaka ktos probuje przypisac do zmiennej
        }
    }
}
