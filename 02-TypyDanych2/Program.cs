// SKROTY W VISUAL STUDIO CODE:

// Shift+Alt+F -> auto-format kodu w calym pliku
// Shift+Alt+ strzalka w dol -> duplikacja lini do linii ponizej
// Shift+Alt+ strzalka w gore -> duplikacja lini do linii powyzej


// ----------------------------------------------
//                  ZMIENNE
// ----------------------------------------------

//Co to jest zmienna?
// Zmienna to po prostu element pamieci, w ktory mozemy wpisac wartosci konrketnego typu (przede wszystkim w jezykach OOP - Object Oriented Programming)
// Zmienne umozliwiaja nam zmiane ich wartosci - jedyny wymog jest taki, ze to co przypisujesz, musi byc tego samego typu
// co przy tworzeniu zmiennej

// Tworze zmienna o nazwie 'number1' i przypisuje jej wartosc 10
int number1 = 10;

// Tutaj probuje przypisac jej wartosc string - error, nie mozna zmapowac string na int
// number1 = "Ala";

// Reakcja na takie dzialanie jest przykladem tego co to znaczy MOCNE TYPOWANIE


// CYKL ZYCIA ZMIENNEJ (kiedy zmienna istnieje w pamieci a kiedy jest usuwana):
// 
// Wszystko w C# jest budowane w srodku nawiasow {} klamrowych (poza szablonem program.cs z .NET6 ktory jest uproszczony)
// Zmienna istnieje w pamieci poki nie wyjdziemy z klamr w ktorych zostala utworzona

{
    int zmienna2 = 100;

    Console.WriteLine(zmienna2);

    zmienna2 = 1000;

    Console.WriteLine(zmienna2);
} // w tym momencie aplikacja stwierdzila, ze zmienna2 juz nie jest uzywana i wywalila ja z pamieci

{
    int zmienna3 = 21;

    {
        int zmienna4 = 100;

        Console.WriteLine(zmienna3);
        Console.WriteLine(zmienna4);
    }

    Console.WriteLine(zmienna3);
    // Console.WriteLine(zmienna4); // tutaj mamy blad, bo zmienna4 przestala istniec bo wsyszlismy z nawiasow klamrowych gdzie byla tworzona
}


//Deklaracja zmiennej - to utworzenie obszaru w pamieci, gdzie bedzie przechowywana dana zmienna
// np. string x;
//int number5; // w przypadku zadeklarowania zmiennej nie mozemy jej uzyc poki nie dostanie ona jakiejs wartosci

//Inicjalizacja zmiennej - to nadanie wartosci dla zadeklarowanej zmiennej
// np. x = "10";

//Deklaracja i inicjalizacja zmiennej za jednym razem
// string x = "10";


// ---------------------------------------------
//      PODSTAWOWE OPERATORY
// ---------------------------------------------

// ARYTMETYCZNE - JEDNOARGUMENTOWE:
// ++ -> inkrementacja, czyli podniesienie wartosci o 1
// -- -> dekrementacja, czyli obnizenie wartosci o 1
// + -> zmiana znaku w liczbie na +
// - -> zmiana znaku w liczbie na - 

// ARYTMETYCZNE - BINARNE:
// + -> dodawanie
// - -> odejmowanie
// / -> dzielenie
// * -> mnozenie
// % -> reszta z dzielenia
// NIE MA POTEGI per se w postaci znaku ^, ten znak to inny operator (o tym pozniej)

// OPERATORY POROWNANIA I ROWNOSCI:
// (pamietaj - ten operator zawsze zwraca wartosc typu bool (true, false))
// == -> sprawdza czy wartosci po obu stronach sa rowne
// != -> sprawdza czy wartosci po obu stronach sa rozne
// > -> sprawdza czy to po lewej jest wieksze od tego po prawej
// < -> sprawdza czy to po lewej jest mniejsze od tego po prawej
// >= -> sprawdza czy to po lewej jest wieksze lub rowne tego po prawej
// <= -> sprawdza czy to po lewej jest mniejsze lub rowne tego co po prawej


// 1. Utworz 5 zmiennych i porownaj ich wartosci wszystkimi operatorami
int num1 = 10;
int num2 = 21;
int num3 = 1233;
int num4 = 12;
int num5 = -100;

Console.WriteLine("---- ZADANIE 1");
Console.WriteLine(num1);
Console.WriteLine(num2);
Console.WriteLine(num3);
Console.WriteLine(num4);
Console.WriteLine(num5); // Console.WriteLine wyswietla osobna linie w konsoli (czyli daje break line po wartosci)

// Console.Write(num1); // Console.Write wyswietla na konsoli podana wartosc i nie daje break line (nowej linii) po
// Console.Write(num2);
// Console.Write(num3);
// Console.Write(num4);
// Console.Write(num5);

/*
    TO KOMENTARZ
    WIELOLINIOWY
*/


if (num1 == num2)
{
    Console.WriteLine("num1 jest rowne num2");
}
else
{
    Console.WriteLine("num1 NIE jest rowne num2");
}

Console.Write("czy num1 jest rowne num2?");
Console.WriteLine(num1 == num2);



// ------------------------------------------
//              PETLE
// ------------------------------------------

// for -> w nim najpierw podajemy od jakiej wartosci zaczynami liczyc, potem warunek sprawdzajacy
// CZY DALEJ MOZEMY ISC W PETLI, a potem co ma sie dziac za kazdym jednym razem przejscia petli

for (int number = 0; number < 10; number++)
{
    Console.WriteLine(number);
}

//                  poki w warunku jest true, to petla dalej sie kreci
for (int number = 9; number >= 0; number--)
{
    Console.WriteLine(number);
}

// for wali bledem jesli daje wynik dzialania arytmetycznego jako ostatni argument
// przyjmuje m.in inkrementacje, dekrementacje oraz skroty obliczen matematycznych

var num10 = 10;
num10 = num10 + 2; // wynik 12
num10 += 2; // wynik 24; to jest skrotowiec

for (int number = 0; number < 10; number += 2)
{
    Console.WriteLine(number);
}

Console.WriteLine("----- ZADANIE 2");
// ZADANIE 2 - wyswietl liczby parzyste z przedzialu <0,9>
for (int number = 0; number < 10; number++)
{
    if (number % 2 == 0)
    {
        Console.WriteLine(number);
    }
}

Console.WriteLine("----- ZADANIE 2.1");
// ZADANIE 2 - opisz czy liczby z przedzialu sa parzyste lub nie <0,9>
for (int number = 0; number < 10; number++)
{
    if (number % 2 == 0)
    {
        Console.WriteLine("Liczba " + number + " jest parzysta");
    }
    else
    {
        Console.WriteLine("Liczba " + number + " jest nieparzysta");
    }
}

// while -> to petla, ktora bedzie wykonywac kod, dopoki w jej nawiasach () warunek zwraca wartosc true

// *UWAGA -> istnieje slowo kluczowe 'break', ktore powoduje, ze petla jest przerywana

Console.WriteLine("----- ZADANIE 3");
// ZADANIE 3 - wyswietl liczby z <0,9> za pomoca while

// int num = 0;
// while (true)
// {
//     Console.WriteLine(num);

//     num++;

//     if (num > 9)
//         break;
// }

int num = 0;
while (num < 9)
{
    Console.WriteLine(num);

    num++;
}


// do-while -> rozni sie od while tym, ze while najpierw sprawdza warunek a potm wykonuje kod,
//              a do-while najpierw wykonuje kod, a potem sprawdza warunek

// int num01 = 0;
// do
// {
//     Console.WriteLine(num01);

//     num01++;
// }
// while (num01 <= 9);

