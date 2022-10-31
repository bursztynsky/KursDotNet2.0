// ------------------------------------
//          PETLE
// ------------------------------------

// for
// przyjmuje info od jakiej liczby zaczynamy przechodzenie przez petle
// potem warunek, w ktorym jesli jest true to idziemy dalej, a false to koniec
// potem warunek co ma sie dziac za kazdym razem jak przechodizmy petle

for (int idx = 0; idx < 10; idx++)
{
    Console.WriteLine(idx);
}

// while
// przyjmuje warunek w ktorym jesli jest true, to caly czas robi to co jest w srodku petli
// a jesli false to koniec

int idx1 = 0;
while (idx1 < 10)
{
    Console.WriteLine(idx1);

    // idx1 = idx1 + 1 | za kazdym razem zwiekszam wartosc idx1 o liczbe 1
    // idx1 += 1
    // idx1++ -> 
    idx1++;
}

Console.WriteLine("--------------------");

// --------------------------------
//          TYPY CALKOWITE
// --------------------------------

// od gory najmniejszy:
// byte
// short
// int

// Console -> to jest obiekt naszej konsoli i mozemy na niej wykonywac rozne dzialania
// WriteLine -> wyswietla jedna linie tekstu i na koniec daje breakline
// Wrtie -> wyswietla jedna linie tekstu, ale wszystko jest w jednym rzedzie
Console.WriteLine("byte -> min:" + byte.MinValue + " max:" + byte.MaxValue);

// byte l1 = 256; // blad, ze nie zmiescisz liczby 256 w maksymalnej 255 dla byte

Console.WriteLine("short -> min:" + short.MinValue + " max:" + short.MaxValue);

Console.WriteLine("int -> min:" + int.MinValue + " max:" + int.MaxValue);

// Sam zapis np. int, byte, short, to sa aliasy, czyli skrotowce nazewnicze do konkretnych typow
// int -> Int32
// short -> Int16
// byte -> Byte

Console.WriteLine("--------------------");
Console.WriteLine("--------------------");

// ----------------------------------------------------------
//              TYPY ZMIENNOPRZECINKOWE
// ----------------------------------------------------------

// Najwazniejsze to:
// float (32bit)
// double (64bit)
// decimal (128bit)

Console.WriteLine("float -> min:" + float.MinValue + " max:" + float.MaxValue);
Console.WriteLine("double -> min:" + double.MinValue + " max:" + double.MaxValue);
Console.WriteLine("decimal -> min:" + decimal.MinValue + " max:" + decimal.MaxValue);

// decimal -> zajmuje najwiecej miejsca w pamieci bo jako jedyny w .NET jest liczony w systemie 10-tnym, a nie 2-jkowym


// Zadanie 1. Wyswielt wszystkie liczby z przedzialu <0.0 1.0> z dokladnoscia do jednego miejsca po przecinku
// Domyslnie w C# wszystkie liczby po przecinku, ktore zapisujesz jako np. 10, 12 itd. to jest typ double
// for (double i = 0; i <= 1; i = i + 0.1)
// {
//     Console.WriteLine(i);
// }

// Tutaj mamy blad bo liczba 0.1 jest typu double, a i jest typu decimal. Nie da sie niejawnie (bez udzialy programisty) dodac jednej do drugiej
// wiec moge albo uzyc konwersji, albo literalu mowiacego jaka ja liczbe przekazuje
// for (decimal i = 0; i <= 1; i = i + 0.1)
// {
//     Console.WriteLine(i);
// }

// ---------------
//     LITERALY
// ---------------
// d lub D - double
// f lub F - float
// m lub M - decimal (prawdopodobnie m bo money czyli dokladne liczenie)

for (decimal i = 0; i <= 1; i = i + 0.1m)
{
    Console.WriteLine(i);
}


Console.WriteLine("--------------------");
Console.WriteLine("--------------------");


// --------------------------------------------
//        KONWERSJE WARTOSCI LICZBOWYCH
// --------------------------------------------

// W tym przypadku mam liczbe byte, ktora zajmuje 8bit i wskazuje jej wartosc 100
// pozniej tworze zmienna typu int, ktora zajmuje 32bit i przypisuje jej ta sama wartosc jaka jest w byte
// bez problemu mozemy zmiescic liczbe 8bit w 32bit
// TAKA KONWERSJA NAZYWA SIE NIEJAWNA -> przypadek w ktorym robimy wszystko zgodnie ze sztuka i logika, gdzie kompilator (program zmieniajacy nasz kod, na kod dla kompa)
// nie widzi bledow i daje sobie rade ze zmienianiem typow
byte l3 = 100;

int l4 = l3;


// Tutaj mamy problem, bo konwersja niejawna nie umie sobie poradzic ze zmieszczeniem typu int 32bit w typie byte 8bit
int l5 = 10;
// byte l6 = l5;

// rozwiazaniem jest KONWERSJA JAWNA, czyli wskazanie przez programiste ze ma na sile zmienic z jednego typu na drugi dana wartosc
// konwersji jawnych mamy kilka, ale podstawowa to RZUTOWANIE

// w nawiasie wskazujemy info na jaki typ ma byc konwertowane to co jest po prawej stronie nawiasu
// (byte) l5
byte l6 = (byte)l5;

// W tym przypadku pod spodem dzieje sie to, ze usuwane sa wszystkie zera i jedynki, ktore sie nie mieszcza w 8bit
int l8 = 2000000;
byte l9 = (byte)l8;

// Console.WriteLine(l9);

// -- ciekawostka 
// aby pokazac jak liczba wyglada w systemie binarnym musimy uzyc metody Convert.ToString(liczba, 2)

Console.WriteLine(l8);
Console.WriteLine(Convert.ToString(l8, 2));
Console.WriteLine(l9);
Console.WriteLine(Convert.ToString(l9, 2));

// TODO: sprawdzic czemu wyswietla sie 128 a nie 255