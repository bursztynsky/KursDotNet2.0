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

// METODA W NOWYM SZABLONIE - nie moze byc public, wiec nie dawajcie nic przed void/typem
ShowMessage();

void ShowMessage()
{
    Console.WriteLine("HELLO");
}

// W C# mozemy robic 'nieskonczona' liczbe wymiarow w tablicach
// TABLICA TRZYWYMIAROWA
int[,,] liczbyIntTrzywymiarowo =
{
    {
        {0, 0, 0}, //subSubElement1
        {1, 1, 1}, //subSubElement2
        {2, 2, 2}  //subSubElement3
    },
    {
        {3, 3, 3}, //subSubElement4
        {4, 4, 4}, //subSubElement5
        {5, 5, 5}  //subSubElement6
    },
    {
        {6, 6, 6}, //subSubElement7
        {7, 7, 7}, //subSubElement8
        {8, 8, 8}  //subSubElement9
    }
};

Console.WriteLine($"subSubElement1: {liczbyIntTrzywymiarowo[0, 0, 0]} {liczbyIntTrzywymiarowo[0, 0, 1]} {liczbyIntTrzywymiarowo[0, 0, 2]}");
Console.WriteLine($"subSubElement2: {liczbyIntTrzywymiarowo[0, 1, 0]} {liczbyIntTrzywymiarowo[0, 1, 1]} {liczbyIntTrzywymiarowo[0, 1, 2]}");
Console.WriteLine($"subSubElement3: {liczbyIntTrzywymiarowo[0, 2, 0]} {liczbyIntTrzywymiarowo[0, 2, 1]} {liczbyIntTrzywymiarowo[0, 2, 2]}");
Console.WriteLine($"subSubElement4: {liczbyIntTrzywymiarowo[1, 0, 0]} {liczbyIntTrzywymiarowo[1, 0, 1]} {liczbyIntTrzywymiarowo[1, 0, 2]}");
Console.WriteLine($"subSubElement5: {liczbyIntTrzywymiarowo[1, 1, 0]} {liczbyIntTrzywymiarowo[1, 1, 1]} {liczbyIntTrzywymiarowo[1, 1, 2]}");
Console.WriteLine($"subSubElement6: {liczbyIntTrzywymiarowo[1, 2, 0]} {liczbyIntTrzywymiarowo[1, 2, 1]} {liczbyIntTrzywymiarowo[1, 2, 2]}");
Console.WriteLine($"subSubElement7: {liczbyIntTrzywymiarowo[2, 0, 0]} {liczbyIntTrzywymiarowo[2, 0, 1]} {liczbyIntTrzywymiarowo[2, 0, 2]}");
Console.WriteLine($"subSubElement8: {liczbyIntTrzywymiarowo[2, 1, 0]} {liczbyIntTrzywymiarowo[2, 1, 1]} {liczbyIntTrzywymiarowo[2, 1, 2]}");
Console.WriteLine($"subSubElement9: {liczbyIntTrzywymiarowo[2, 2, 0]} {liczbyIntTrzywymiarowo[2, 2, 1]} {liczbyIntTrzywymiarowo[2, 2, 2]}");


// OSTATNI TYP TALBICY - JAGGED ARRAY
// Istnieje jeszcze tzw. jagged array (postrzepiona tablica?, tablica w tablicy)
// Jest to po prostu tablica tablic i co najciekawsze, moze miec ona rozne rozmiary tablic!
int[][] jaggedInt = new int[5][]; //najpierw jej ustalamy ile ma miec w sobie tablic
jaggedInt[0] = new int[2]; //tu dodajemy 2 elementowa
jaggedInt[1] = new int[5]; //tu 5 elementowa
jaggedInt[2] = new int[8]; //tu 8 elementowa itd
jaggedInt[3] = new int[10];
jaggedInt[4] = new int[4];

//Mozemy rowniez od razu dodac im wartosci
jaggedInt[0] = new int[] { 0, 0 };
jaggedInt[1] = new int[] { 1, 1, 1, 1, 1 };
jaggedInt[2] = new int[] { 2, 2, 2, 2, 2, 2, 2, 2 };
jaggedInt[3] = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
jaggedInt[4] = new int[] { 4, 4, 4, 4 };

// Mozemy tez od razu zainicjowac wszystko na raz
int[][] jaggedInt2 = new int[][]
{
    new int[]{1, 1, 1}, //musimy jednak niestety uzyc operatora new, poniewaz w tym przypadku tworzymy nowa tablice, nie jak w przypadku multidimensional array po prostu dodajemy element
    new int[]{2, 2, 2, 2},
    new int[]{3, 3},
    new int[]{4, 4, 4},
};

Console.WriteLine("Tablica numer 1:");
Console.WriteLine(jaggedInt2[0][0]);
Console.WriteLine(jaggedInt2[0][1]);
Console.WriteLine(jaggedInt2[0][2]);
Console.WriteLine("Tablica numer 2:");
foreach (int value in jaggedInt2[1])
{
    Console.WriteLine(value);
}

Console.WriteLine("Tablica numer 3:");
for (int idx = 0; idx < jaggedInt2[2].Length; idx++)
{
    Console.WriteLine(jaggedInt2[2][idx]);
}

Console.WriteLine("Tablica numer 4:");
int indeks = 0;
while (indeks < jaggedInt2[3].Length)
{
    Console.WriteLine(jaggedInt2[3][indeks]);

    indeks++;
}

// ZASTOSOWANIE: np. w wykresach slupkowych, gdzie zmienna chart to jaggedArray z tablica tablic z warotsciami w wykresie
// przechodzisz po kolei po tablicach warotsci i sobie wyswietlasz slupki

Console.WriteLine("----------");

// METODY PRZYDATKE W TYPIE ARRAY

// PROPERTIES (Własciwosci)
// array.Length -> zwraca dlugosc tablicy
// array.Rank -> zwraca ilosc wymiarow tablicy

string[] array1 = new string[] { "a", "b", "c" };
string[,] array2 = new string[,] { { "a1", "a2" }, { "b1", "b2" }, { "c1", "c2" } };

Console.WriteLine("Tablica array1 ma dlugosc " + array1.Length + ", posiada " + array1.Rank + " wymiarow");
Console.WriteLine("Tablica array2 ma dlugosc " + array2.Length + ", posiada " + array2.Rank + " wymiarow");
// Shift + Alt + F -> FORMATOWANIE KODU W DOKUMENCIE

// Clone() -> zwraca kopię danej tablicy
// UWAGA: w przypadku Clone() dostajemy blad 'Cannot implicitly convert type 'object' to 'string[]'
// to dlatego, ze .NET nie jest w stanie wydedukowac poprawnie na jaki typ ma kopiowac dana tablice (czemu? nie wiem)
// wiec musimy konwertowac to sami uzywajac KONWERSJI JAWNEJ
// najszybciej -> rzutowanie
// string[] copyOfArray1 = array1.Clone();
string[] copyOfArray1 = (string[])array1.Clone();

foreach (string key in copyOfArray1)
{
    Console.WriteLine(key);
}
Console.WriteLine("---");

// CopyTo() ->kopiuje wartosci od 0 do podanej dlugosci
//          pierwszy argument, do tablica DO ktorej kopiuje
//          drugi argument to indeks do ktorej zaczynam kopiowanie
// MINUS: po pierwsze, najpierw musze zrobic zmienna z tablica do ktorej bede kopiowal wartosci ORAZ musze sam podaj jej dlugosc odpowiednia do wrezultatu
// TODO: napraw to z wykorzystaniem tablicy dwuwymiarowej!!!
// string[,] copyOfArray2 = new string[1];
// array2.CopyTo(copyOfArray2, 2);

// foreach (string key in copyOfArray2)
// {
//     Console.WriteLine(key);
// }
// Console.WriteLine("---");

string[] copyOfArray1_1 = new string[3];
array1.CopyTo(copyOfArray1_1, 0);

foreach (string key in copyOfArray1_1)
{
    Console.WriteLine(key);
}

Console.WriteLine("---");

// Array.Fill() -> wypletnia tablice podana wartoscia
// ZADANIE DLA WAS: sprawdz czy mozna uzyc poprawnie metody generujacej liczby losowe
string[] emptyArr = new string[5];
Array.Fill(emptyArr, "Not-Empty");
foreach (string key in emptyArr)
{
    Console.WriteLine(key);
}
Console.WriteLine("---");

// CIEKAWOSTKA
// GetValue i SetValue
// Zamiast dostawac sie za pomoca nawiasow [] i numeru indeksu mozna uzyc tych metod
emptyArr.SetValue("ChangedValue", 1);
Console.WriteLine(emptyArr.GetValue(1));
Console.WriteLine("Cala tablica:");
foreach (string key in emptyArr)
{
    Console.WriteLine(key);
}
Console.WriteLine("---");