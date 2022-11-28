// --------------------------------------------------------
//                     TYP ZNAKOWY - CHAR
// --------------------------------------------------------

// Char to typ wartosciowy, ktory przetrzymuje tylko jedna litere
// Wartosci typu char ZAWSZe zapisujemy w '', a nie ""
// NIE MOZECIE wpisac w '' wiecej niz jedna litere, bo bedzie blad

// tworze char i wpisuje mu litere
// char ch1 = "A"; // tu mam blad, ze nie moge wpisac do char typu string BO zawsze w "" wpisywany jest string
char ch1 = 'a';

Console.WriteLine(ch1);

// Char zapisywany jest domyslnie w UTF-16 -> https://pl.wikipedia.org/wiki/UTF-16

// Char ZAWSze zajmuje 2 byte
Console.WriteLine(sizeof(char));


// Char ma wbudowane kilka metod ktore moga byc przydatne
// char.ToUpper(zmiennaTypuChar) -> zmienia dany znak na duzy
Console.WriteLine(char.ToUpper(ch1));

// char.IsUpper(zmiennaTypuChar) -> true jest upper, false jesli nie
Console.WriteLine(char.IsUpper(ch1));

// char.ToLower(zmiennaTypuChar) -> zmienia dany znak na mały
Console.WriteLine(char.ToLower('A'));

// char.IsLower(zmiennaTypuChar) -> true jesli nie jest upper, false jesli jest
Console.WriteLine(char.IsLower(ch1));

// przyklad trzymania wiecej niz jednej wartosci char
char[] charTab1 = new char[] {
    'D',
    'U',
    'P',
    'A',
};

for (int idx = 0; idx < charTab1.Length; idx++)
{
    Console.Write(charTab1[idx]);
}
Console.Write('\n');
Console.WriteLine("----------");

// --------------------------------------------------
//                  STRING
// --------------------------------------------------
// To jest typ REFERENCYJNY
// W C++ string to tak naprawde tablica charow
// C++ JEST ZUPELNIE NIE ZWIAZANY Z C# TO ZA ZALEZNOSC NIE ISTNIEJE
// 
// C# string to NIE JEST tablica charow

// String to po prostu typ ktory moze przetrzymywac 0 lub wiecej znakow
// Pusty string to po prostu ""
// String posiada zawsze tez info co do WhiteSpace czyli bialych znakow np. endline, tabulacja, spacja itd
// string x = " " -> to mamy string o dlugosci 1, bo ma jeden znak

// UWAGA -> KAZDY OBIEKT W C# posiada wbudowana metode ToString()
// Wszystkie typy wartosciowe maja metode ToString
// Console.Write i Console.WriteLine przyjmuje jako argumenty TYLKO warotsc typu string
// DLACZEGO WIEC JAK WPISZE INT TO NIE MA BLEDU?
// W tym przypadku .NET widzi, ze typ docelowy jest string i wie, ze kazdy obiekt ma metode ToString()
// i ja odpala NIEJAWNIE

// tworzenie string:
string str1 = ""; // pusty string
string str2 = null; // string bez zadnej wartosci, czyli NULL

// null -> to kluczowa znak w C#, ktora oznacza, ze brakuje warotsci!
// typy wartosciowe NIGDY nie moga byc null, one zawsze maja wartosc, wiec stad na nazwa!
// czyli nie moge zrobic: int x = null, bo bedzie blad!
// typy refrencyjne MOGA BYC null, moge im nadac ta wartosc!

Console.WriteLine("string zainicjowany pusta wartoscia: " + str1);
Console.WriteLine("string zainicjowany nullem: " + str2);
Console.Write("Czy obie te zmienne maja ta sama wartosc? ");
Console.Write(str1 == str2);
Console.Write("\n");

// NULL NIE JEST WARTOSCIA!!!
// Null to brak wartosci, wiec zawsze w programach musimy zwracac na to uwage
// czy przypadkiem zmienna zawierajaca typ referencyjny nie jest null

// CZEMU?
Console.WriteLine("Dlugosc zmiennej str1:" + str1.Length);
// Console.WriteLine("Dlugosc zmiennej str2:"+str2.Length); // mamy blad, bo jesli zmienna
// wskazuje null, to nie moge uzyc niczego, co w sobie zawiera po . 

// W srodku string znajduje sie ukryta tablica charow, ktora pozwala nam na dostanie sie do kazdego
// znaku z osobna
// ALE NIE JEST TABLICA! on tylko ja posiada w srodku jako taki dodatek
string str3 = "Ala ma kota";
Console.WriteLine(str3[0]);
Console.WriteLine(str3[4]);
Console.WriteLine(str3[7]);

for (int idx = 0; idx < str3.Length; idx++)
{
    Console.Write(str3[idx]);
}
Console.Write('\n');
// ---------
// FOREACH
// ---------
// Petla foreach to zminimalizowana wersja petli for
// w foreach NIE DA SIE odniesc do indeksu, wiec 
// to nam mowi, ze foreach moze przechodzic tylko po konkretnych zbiorach danych
// a same te zbiory nie musza posiadac indeksow
// Indeksy posiadaja tablice
// a np. obiekty ktore ich nie posiadaja, a sa zbiorem, to kolekcje
// 
// foreach (typZmiennej nazwaZmiennej in kolekcja) {
//
//}
//

foreach (char value in str3)
{
    Console.Write(value);
}

Console.Write('\n');


// Sposoby laczenia stringow

// Za pomoca +
// PLUS-> szybko piszesz
// MINUS-> malo czytelne w kodzie
string str4 = "Ala";
string str5 = " ma kota";
string str6 = str4 + str5;

Console.WriteLine(str6);
Console.WriteLine("Jakie zdanie 1." + " " + "Jakies zdanie 2.");

// Interpolacja
// Do string przed "" mozemy dodac jakis znak kluczowy
// W tym przypadku $ znaczy interpolacje
// Interpolacja pozwala nam na wpisanie w stringu klamer {} i podanie czegokolwiek w srodku,
// a pozniej on to zamienia w string

Console.WriteLine("Moja waga wynosi {100} {10000} {'A'} kg");
Console.WriteLine($"Moja waga wynosi {100} {10000} {'A'} {"dupa"} {true} {10 == 100} kg");


// Metody z klasy string

// string.Join() -> łaczy ze soba wartosci, z czego mozesz dodac separator jako pierwszy argument
// UWAGA - zawsze pierwszy argumentt o jest spearator, wiec jesli ma go nie byc to daj pusty ""
int[] oceny = new int[] {
    1 ,4 ,2 ,4 ,6
};

Console.WriteLine(string.Join("", oceny));
Console.WriteLine(string.Join(string.Empty, oceny));
Console.WriteLine(string.Join(String.Empty, oceny));
Console.WriteLine(string.Join("; ", oceny));
Console.WriteLine(string.Join("; ", oceny));

// BTW -> string.Empty to jest TO SAMO, co pusty cudzyslow ""

// string.Format() -> to metoda ktora byla protoplasta interpolacji w C#
// Pozwala na podanie string w srodku ktorego podajesz {liczba}
// nastepnie kazdy kolejny argument to jest wartosc ktora ma podstawiac pod te {liczba}
string str7 = "Moja waga wynosi {0} {0} {1} {2} kg";
Console.WriteLine(string.Format(str7, 50, 100, 150));