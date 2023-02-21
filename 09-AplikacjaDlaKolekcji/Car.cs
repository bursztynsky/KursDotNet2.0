using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_AplikacjaDlaKolekcji
{
    internal class Car
    {
        // UWAGA - implementujemy w Car to, ze gdy tworzymy nowy samochod, to generujemy mu odpowienie ID
        // Spelniac bedzie to, ze ID bedzie unikatowe (jedno na caly system dla samochodow)
        // Samo sie bedzie uzupelniac

        // Jak to zrobic?
        // Potrzebujemy jakies pole ktore by zapisywalo jakie id ostatnio zostalo utworzone
        // To pole MUSI wspoldzielic swoja wartosc ze wszystkimi innymi samochodami (czyli instancjami klasy Car)
        // zeby kazdy mogl w kazdej chwili to podejrzec (ustawiajac nowe Id) oraz zmienic na to, ktore wlasnie 
        // zostalo wygenerowane

        // Do tego celu wykorzystamy pole statyczne oznaczane slowem 'static'

        // Static mozemy dodac do:
        // 1. Klasy -> wtedy dana klasa nie moze miec instancji tzn. nie uzyjemy przy niej slowa 'new', nie ma wiec
        // ona konstruktora ORAZ wszystkie jej pola i metody w srodku MUSZA byc oznaczone 'static'
        // 2. Pola / Wlasciwosci -> wtedy dane pole/wlasciwosc wspoldzili wartosc ze wszystkimi instancjami klasy i moze
        // byc przez nie modyfikana
        // 3. Metoda -> wtedy dana metoda jest wsplodzielona i moze byc wykorzystana nawet bez tworzenia instancji klasy
        //public static int LastId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }

        public Car()
        {
        }

        public Car(int id, string name, string model)
        {
            Id = id;
            Name = name;
            Model = model;
        }

        // Object posiada metode ToString ktora dla klas zwraca jej nazwe
        // Aby poprawic dzialanie metody ToString na cos co my chcemy wyswietlic
        // musze nadpisac metode ToString
        // NADPISANIE (Override) -> metoda istnieje w klasie matka (tutaj Object) ALE chce jej pokazac, ze w Car chce
        // by jej dzialanie zostalo zmienione

        // aby nadpisac metode musimy uzyc slowa override
        // w Object mamy tylko 3 klasy do nadpisania m.in. ToString
        public override string ToString()
        {
            // Kiedy korzystamy z override mozemy uzyc tez slowa 'base'
            // Base odnosi sie do klasy MATKA i pozwala nam z niej odpalic jakas metode
            // Dzieki temu moge np. wywolujac moja nadpisana metode ToString wyswietlic
            // sobie na konsoli najpierw to, co by zwrocila domyslna metoda ToString z object
            //Console.WriteLine(base.ToString());

            //return $"Id:{Id} Name:{Name} Model:{Model}";
            // plij CSV: linijka po linijce zapisywane sa dane, zas oddzielone sa one srednikiem
            // PS: pierwsza lunia to nazwy kolumn
            // np.
            // Id;Name;Model
            // 1;Toyota;Yaris
            // 2;Audi;Q7
            //return $"Id:{Id} Name:{Name} Model:{Model}";
            return $"{Id};{Name};{Model}";
        }
    }
}
