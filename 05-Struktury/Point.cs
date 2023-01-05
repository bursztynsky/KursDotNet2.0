// UWAGA: poniewaz plik Program.cs jest specjalnych plikiem uruchomieniowych aplikacji
// i posiada on teraz uproszczona wersje ktora pozwala nam nie widzie tych slow jak
// 'namespace', 'internal', 'using'

// using -> to slowo kluczowe ktore importuje klasy z innych plikow
// domyslnie importowane sa zawsze te klasy:
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

// namespace -> to slowo kluczowe ktorym okreslam GDZIE w JAKIM FOLDERZE
// znajduje sie plik .cs
// ZAZWYCZAJ namespace to po NazwaProjektu_Foler1_Folder2
// namespace mozemy zapisac z lub bez nawiasow {}
// jesli dajemy {} to wszystko co jest w pliku .cs musi byc w srodku tych nawiasow
// namespace mozemy tez zapisac bez {} ale dajemy na koncu ;

// NIE  MUSIMY ich recznie dodawac do pliku .cs, one sa wsze doklejane wszedzie przez
// kompilator

namespace _05_Struktury;

// Sruktura ma slowo kluczowe struct
struct Point
{
    // kiedy cos jest Public to piszemy PascalCase czyli kazde slowo z duzej litery!

    // to ponizej to jest POLE (field)
    public int X;
    public int Y;

    // Robimy konstruktor
    // KONSTRUKTOR ZAWSZE MUSI BYC PUBLIC
    // Taki pusty konstruktor, (przez pusty mam na mysli ze ja nic nie dodalem w nawiasy {}),
    // nazywa sie domyslnym konstruktorem
    // Od najnowszych wersji .NET nie trzeba pisac domyslnego konsruktora recznie
    // ale kiedys trzeba bylo bo walilo bledami ze klasa lub struct nie ma konstruktora domyslneg
    // przez co nie umie utworzyc miejsca w pamieci ble ble

    // KAZDY konsturktor, nawet domyslny, ustawia poczatkowo wszystkie pola danej sturktury
    // na wartosci domyslne (dla int to jest 0)
    public Point()
    {
    }

    // Konstruktorow moze byc wiele, ale musza sie roznic ilosci argumentow LUB ich typem
    // ale nie moge dac oddzielnie Point(int x) i Point(int y) bo nie roznia sie ANI TYPEM
    // ANI ILOSCIA
    public Point(int x)
    {
        X = x;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Ta metoda zwroci odleglosc miedzy punktem tym na ktorym wywoluje metoda
    // oraz tym ktory przekazuje w ()
    public double GetDistance(Point point)
    {
        return Math.Sqrt(
            Math.Pow(point.X - X, 2) +
            Math.Pow(point.Y - Y, 2)
            );
    }

    public void Print()
    {
        Console.WriteLine("Moj punkt ma: X=" + X + " Y=" + Y);
    }
}