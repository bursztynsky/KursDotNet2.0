//-------------------------------------
// CONDITIONAL OPERATOR
//-------------------------------------
// W C# mamy rozne mozliwosci na skracanie naszego kodu
// Jednym z nich jest Conditional Operator, ktory umozliwia nam zmniejszenie ilosci
// if w naszym kodzie
// Jesli tworzymy zmienna i przypisujemy jej wartosc zgodnie z pewnym warunkiem
// mo mozemy to zapisac w if w ten sposob:
// Zadanie. Dla losowej liczby sprawdz czy jest podzielna przez 2. Jesli jest, zwroc ja pomnozona razy 3.
// Jesli nie jest, zwroc ja pomnozona razy 2
int randomNumber = -12012902;
int result; // deklarujemy zmienna, mozemy jej nie przypisywac wartosci jesli mamy 100% pewnosci, ze
// zanim zostanie uzyta to bedzie zainicjowana (przypisana warotsc). Bedzie, poniewaz mamy nizej if-else
// ktory tego pilnuje
if (randomNumber % 2 == 0)
{
    result = randomNumber * 3;
}
else
{
    result = randomNumber * 2;
}

// Mozemy jednak skorzystac z conditional operator. Pozwala on na podstawie warunkow true/false
// przypisywac inne wartosci. Budowa:

// warunekZwracajacyBool ? zwracamToJesliTrue : zwracamToJesliFalse;

// Rozwiazanie zadania korzystajac z conditional operator:
int randomNumber2 = 141434124;
int result2 = randomNumber2 % 2 == 0 ? randomNumber2 * 3 : randomNumber2 * 2;

// Zazwyczaj, kiedy formatujemy kod, najlepiej jest recznie rozbic conditional operator na 3 linie, jesli
// jest dosc dlugi:
int result3 = randomNumber2 % 2 == 0
    ? randomNumber2 * 3
    : randomNumber2 * 2;

// UWAGA - mozemy tez oczywiscie ladowac operator w operatorze, ale latwo sie pogubic, wiec
// pilnujcie formatowania ;)
int result4 = randomNumber2 % 2 == 0
    ? randomNumber2 % 3 == 0
        ? 100
        : 500
    : randomNumber2 % 5 == 0
        ? randomNumber2 % 10 == 0
            ? 100000
            : 200000
        : 23456;


//----------------------------------
// JAK ZROBIC METODE GENERUJACA NAM LOSOWE LICZBY?
//----------------------------------
// W tym celu skorzystamy z klasy Random, ktora ma zaimplementowany algorytm zwracajacy pseudo-losowe liczby
// Random posiada metode Next ktora zwraca nam pseudo-losowa liczbe
// Mamy kilka mozliwosci jej uzycia: 
// Next() -> Zwraca losowa nie ujemna liczbe z domyslnego przedzialu od -2,147,483,648 do 2,147,483,647
// Next(int maxValue) -> Zwraca losowa nie ujemna liczbe, ktora jest mniejsza niz liczba podana jako argument
// Next(int minValue, int maxValue) -> Zwraca losowa nie ujemna liczbe, z podanego przedzialu. min wchodzi w przedzial, max juz nie, wiec to przedzial: <min, max)

// Mamy jeszcze takie metody:
// NextDouble() -> Zwraca losowa nie ujemna liczbe typu double która jest wieksza od 0.0 i mniejsza od 1.0
// NextInt64() -> Zwraca losowa nie ujemna liczbe typu long
// NextSingle() -> Zwraca losowa nie ujemna liczbe typu float która jest wieksza od 0.0 i mniejsza od 1.0
// NextByte(byte[]) -> Wypelnia podana talbice bitow losowymi liczbami z jej zakresu

// Zadanie 1. Napisz metode zwracajaca losowe liczby calkowite
int GenRandom()
{
    Random rand = new Random();
    return rand.Next();
}

Console.WriteLine(GenRandom());

Console.WriteLine("---");

// Zadanie 2. Napisz metode zwracajaca losowe liczby calkowite z podanego przedzialu np. <10, 50)
int GenRandom2(int minValue, int maxValue)
{
    Random rand = new Random();
    return rand.Next(minValue, maxValue);
}

Console.WriteLine(GenRandom2(10, 50));
Console.WriteLine(GenRandom2(10, 50));
Console.WriteLine(GenRandom2(10, 50));
Console.WriteLine(GenRandom2(10, 50));
Console.WriteLine(GenRandom2(10, 50));
Console.WriteLine(GenRandom2(10, 50));

Console.WriteLine("---");

// Zadanie 3. Napisz metode zwracajaca losowe liczby calkowite z przedzialu <10, 50>
int GenRandom3(int minValue, int maxValue)
{
    maxValue++;

    Random rand = new Random();
    // return rand.Next(minValue, maxValue + 1);
    return rand.Next(minValue, maxValue);
}

// --------------------------------- SKROT KLAWIATUROWY!
// Ctrl + Alt + strzalka gora/dol -> zaznaczanie kilku linii na raz

Console.WriteLine(GenRandom3(10, 50));
Console.WriteLine(GenRandom3(10, 50));
Console.WriteLine(GenRandom3(10, 50));
Console.WriteLine(GenRandom3(10, 50));
Console.WriteLine(GenRandom3(10, 50));
Console.WriteLine(GenRandom3(10, 50));

// Zadanie 3.1 Wyswietlaj liczby losowe z przedzialu <10,50> az dostaniesz liczbe 50
int num = GenRandom3(10, 50);
Console.WriteLine("-- " + num);
while (num != 50)
{
    num = GenRandom3(10, 50);
    Console.WriteLine("-- " + num);
}

Console.WriteLine("---");


// Zadanie 4. Napisz metode zwracajaca losowe liczby calkowite z przedzialu <-10,10>
// Tutaj juz mamy ciezsze zadanie, poniewaz Next nigdy nie zwraca liczb na minusie.
// Musimy wiec ustalic jakis losowy warunek ktory bedzie mowil, czy teraz zwracamy liczbe na minusie czy na plusie
// Mozemy wiec najpierw wylosowac liczbe z przedzialu podanego przedzialu, ktora na pewno bedzie na plusie
// oraz sprawdzic czy jest podzielna przez 2
// Nastepnie zwracamy kolejna losowa liczbe z podanego przedzialu i jesli poprzednia byla podzielna
// przez dwa, to zwracamy ja bez zmian (czyli wynik bedzie na +). Jesli jednak nie byla podzielna
// przez dwa, to zwracamy ja ze znakiem -
int GenRandom4(int min, int max)
{
    // zwiekszamy przedzial z <10,50) na <10,51)
    max++;

    Random random = new Random();

    // Zwracamy next(), dzielimy przez dwa i sprawdzamy, czy reszta jest 0. 
    // Jesli tak to jest parzysta czyli even
    bool isEven = random.Next() % 2 == 0;

    // Skorzystamy z conditional operator ktory nam skroci zapis sprawdzajacy
    // czy liczba ma byc na + czy -
    int result = random.Next(min, max + 1);
    return isEven ? result : -result;

    // ewentualnie za pomoc if
    // if(isEven) {
    //     return result;
    // }
    // else {
    //     return -result;
    // }
}

Console.WriteLine(GenRandom4(-10, 10));
Console.WriteLine(GenRandom4(-10, 10));
Console.WriteLine(GenRandom4(-10, 10));
Console.WriteLine(GenRandom4(-10, 10));
Console.WriteLine(GenRandom4(-10, 10));
Console.WriteLine(GenRandom4(-10, 10));

Console.WriteLine("---");
/*--------------------------------
ZADANIE 4
Stworz tablice zawierającą 5 losowych liczb. Następnie
wyświetl najmniejszą liczbę z tej tablicy.
--------------------------------*/

int[] nums = new int[] {
    GenRandom3(0, 10),
    GenRandom3(0, 10),
    GenRandom3(0, 10),
    GenRandom3(0, 10),
    GenRandom3(0, 10),
    };

// aby ulatwic wyswietlanie wynikow zrobimy metode do wyswietlania tablic:
void PrintArray(int[] array)
{
    int idx = 0;

    Console.Write("[");
    // while (idx <= array.Length - 1) // to jest to samo co ponizej
    while (idx < array.Length)
    {
        // if(idx == array.Length) {
        //     // \n w string to oznacza nowa line (new line)
        //     Console.Write(array[idx] + "]\n");
        // }
        // else {
        //     Console.Write(array[idx], ", ");
        // }

        Console.Write(array[idx]);

        if (idx == array.Length - 1)
        {
            Console.Write("]\n");
        }
        else
        {
            Console.Write(", ");
        }

        idx++;
    }
}

PrintArray(nums);

// Jak chcemy to zrobic?
// Jedno z rozwiazan:
// 1. Ustalamy, ze na poczatku namniejszaliczba to ta, ktora jest pierwsza w tablicy
// 2. Wchodzimy do petli i sprawdzamy kazda nastepna liczbe po tej pierwsza (dlatego idx ustawiamy na 1, a nie na 0
//    bo chcemy zaczac od drugiej liczby w tablicy az do ostatniej)
// 3. Jesli nastepna liczba jest mniejsza od aktualnego min, to ustawiamy ta nowa jako nowy min

int minNum = nums[0];

for (int idx = 1; idx < nums.Length; idx++)
{
    if (nums[idx] < minNum)
    {
        minNum = nums[idx];
    }
}

Console.WriteLine("Min num is: " + minNum);

Console.WriteLine("----");

/*--------------------------------
ZADANIE 2
Napisz metodę, która umożliwi dodawanie nowej wartosci dla podanej tablicy liczb calkowitych
--------------------------------*/
// TABLICE W C# MAJA ZMIENIENNA DLUGOSC!!!
// Rozwiazaniem bedzie napisanie metody, ktora przyjmuje jakis array
// nastepnie tworzy NOWY ARRAY o dlugosci wiekszej o 1 od tego array przekazanego
// ORAZ kopiujemy warotsc z array do NOWY ARRAY i ostatnia pozycje ustawiamy na przekazana nowa wartosc
int[] AddToArray(int[] array, int newValue)
{
    // tworzymy nowa tablice wieksza o 1 niz ta przekazana
    // uzyjemy do tego jej wartosci .Length i zwiekszymy o jeden
    int[] newArray = new int[array.Length + 1];

    // teraz, korzystajac z petli while przejdziemy po wszystkich pozycjach w nowej 
    // tablicy i przypiszemy jej te same wartosci z przekazanej tablicy.
    // W momencie, jak skoncza sie wartosci w zmiennej 'array' to ustawimy ostatnia wartosc na przekazane 'newValue'

    int idx = 0;
    while (idx < newArray.Length)
    {
        // najpierw sprawdzamy, czy idx nie jest przypadkiem tym ostatnim dostepnym w newArray
        // jesli jest = jego wartosc ustawiamy na newValue
        if (idx == newArray.Length - 1)
        {
            newArray[idx] = newValue;
        }
        else
        {
            // ineksy:                0  1    2   3   4  5
            // np. array ma wartosci: 4, 10, 423, 23, 2  x
            // newArray jest pusty:   0,  0,   0,  0, 0, 0
            newArray[idx] = array[idx];
        }

        idx++;
    }

    return newArray;
}

// testujemy rozwiazanie:
int[] array1 = new int[] { 1, 2, 3, 4, 5, 6 };

PrintArray(array1);

AddToArray(array1, 1111);
PrintArray(array1);

array1 = AddToArray(array1, 7);
PrintArray(array1);
array1 = AddToArray(array1, 8);
PrintArray(array1);
array1 = AddToArray(array1, 9);
PrintArray(array1);
array1 = AddToArray(array1, 10);
PrintArray(array1);

// WSZYSTKIE METODY TYPU AddToArray, PrintArray GetRandom wykorzustucie w swoich zadaniach :)