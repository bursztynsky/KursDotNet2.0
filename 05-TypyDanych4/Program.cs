// ------------------------------------------------
//                  TABLICE
// ------------------------------------------------
// Tablice to takie worki, ktore przechowuja z gory zalozona ilosc danych zdefiniowanego typu.
// Mozna je porownac jak do np. definicji funkcji liniowej -> na osi X mamy odpowiednio jej zakreslone punkty i dostajemy sie do nich
// podajac wartosc X

// Tablice indeksowane sa od 0 do n-1, gdzie n to jej rozmiar

// Deklaracja tablic:
// typDanych[] nazwaZmiennej;
// typDanych[iloscElementow] nazwaZmiennej;
// typDanych[] nazwaZmiennej = { element1, element2, element3};

double[] liczbyDouble = { 2.2, 5.5, 7.7 };
// index:           0   1  2  3  4  5
int[] liczbyInt = { 5, 24, 3, 6, 7, 8 };

// niestety tablice w C# nie sa tak trywialne w wyswietlaniu
// jak wyswietlisz zmienna zawierajaca tablice, to wyswietli nazwe typu jakiego jest tablica
// w tym wypadku: System.Int32[]
Console.WriteLine(liczbyInt);

Console.WriteLine(liczbyInt[0]);
Console.WriteLine(liczbyInt[1]);
Console.WriteLine(liczbyInt[2]);
Console.WriteLine(liczbyInt[3]);
Console.WriteLine(liczbyInt[4]);
Console.WriteLine(liczbyInt[5]);

// W przypadku tablic jesli odniesiemy sie do liczby spoza naszej dlugosci tablicy to mamy blad ktory wywala aplikacje
// Console.WriteLine(liczbyInt[6]);

// Aby temu przeciwdzialac mozemy korzystac z property nazwanego Length ktore nam mowi jaka dlugosc jest danej tablicy
Console.WriteLine("Dlugosc tablicy liczbyInt: " + liczbyInt.Length);

for (int idx = 0; idx < liczbyInt.Length; idx++)
{
    Console.Write(liczbyInt[idx] + ", ");
}

// PODSUMOWUJAC: Tablice maja zawsze staly rozmiar i jesli wyjdziemy poza jej zakres odwolujac sie do indeksu ktorego nie posiada
// to program wali bledami

// Kiedy stworze tablice w ponizszy sposob to ona nie jest gotowa do dzialania
// Ten zapis mowi ze dopiero ZADEKLAROWALISMY zmienna nazwa liczby1 ktora jest type int[]
// Mimo ze podalismy jej rozmiar, ona nadal nie utworzyla sobie w pamieci miejsca na swoje wartosci
// int[5] liczby1;

// DWA ROZWIAZANIA:
// 1. Nadac od razu wartosci
int[] liczby1 = { 1, 2, 3, 4, 5 };

for (int idx = 0; idx < liczby1.Length; idx++)
{
    Console.Write(liczby1[idx] + ", ");
}
Console.WriteLine();

// 2. Skorzystac ze slowa kluczowego new()
// new -> powoduje, ze w pamieci alokowane jest miejsce dla danej zmiennej i w to miejsce wpisywane sa domyslne wartosci
// w przypadku int = 0, w przypadku double = 0
int[] liczby2 = new int[5];

for (int idx = 0; idx < liczby2.Length; idx++)
{
    Console.Write(liczby2[idx] + ", ");
}
Console.WriteLine();

// Ustawiamy wartosci wszystkich elementow tablicy na wartosc 10
for (int idx = 0; idx < liczby2.Length; idx++)
{
    liczby2[idx] = 10;
}
Console.WriteLine();

// Wyswietlamy tablice
for (int idx = 0; idx < liczby2.Length; idx++)
{
    Console.Write(liczby2[idx] + ", ");
}
Console.WriteLine();

// Ustawiamy wartosci wszystkich elementow tablicy na wynik wartosc * index
for (int idx = 0; idx < liczby2.Length; idx++)
{
    //liczby2[idx] = liczby2[idx] * idx; // to to samo co ponizej
    liczby2[idx] *= idx;
}
Console.WriteLine();

// Wyswietlamy tablice
for (int idx = 0; idx < liczby2.Length; idx++)
{
    Console.Write(liczby2[idx] + ", ");
}
Console.WriteLine();

// To wszystko to co tu widzimy to sa tablice jednowymiarowe, czyli idziemy tak jakby od lewej do prawej po osi X i czytamy wartosci

// C# umozliwia nam tworzenie tablic wielowymiarowych
// TABLICA DWUWYMIAROWA
// musze podac typ na: int[,]
int[,] liczbyIntDwuwymiarowe = {
//    y0  y1  y2
    { 10, 11, 12}, // x0
    { 20, 21, 22}, // x1
    { 30, 31, 32} //  x2
};

Console.WriteLine(liczbyIntDwuwymiarowe[0, 0]); // pierwsza liczba z pierwszego wiersza: 10
Console.WriteLine(liczbyIntDwuwymiarowe[0, 1]); // druga liczba z pierwszego wiersza: 11
Console.WriteLine(liczbyIntDwuwymiarowe[0, 2]); // trzecia liczba z pierwszego wiersza: 12
Console.WriteLine(liczbyIntDwuwymiarowe[2, 2]); // ostatnia liczba z ostatniego wiersza: 32