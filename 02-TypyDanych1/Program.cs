// ---------------------------------------------------------
//                          TYPY
// ---------------------------------------------------------

// C# jest jezykiem mocno typowanym - jako programista kontrolujesz jaki typ jest wpisywany do zmiennej i bedzie zawsze to ten sam co podales.
//                                    .NET na biezaco sprawdza czy do zmiennej typu calkowitego wpisujesz wartosc calkowita, czy moze jednak tekst
//                                    Jesli podasz wartosc inna niz typ zmiennej, to mamy blad

// W C# mamy dwa typy:
// - Wartosciowe
// - Referencyjne

// Zajmiemy sie teraz tylko typami wartosciowymi


// ---------------------------------------------------------
//                      TYPY LICZBOWE
// ---------------------------------------------------------

// To najprostrze typy wartosci znajdujacie w C#
// Sa typem wartosciowym

// TYPY WARTOSCIOWE - zawsze znaja swoj rozmiar w pamieci i nie wazne jaki obiekt tam wpiszesz, to zawsze bedzie zajmowac tyle samo miejsca w pamiec

/*
* TYPY LICZBOWE:
* 
* - byte (typ calkowity, zakres wartosci od 0 do 255)
* - int (typ calkowity, zakres )
* - short (typ calkowty, zakres )
* - float (typ zmiennoprzecinkowy, zakres )
* - double (typ zmiennoprzecinkowy, zakres )
* - decimal (typ zmiennoprzecinkowy, )
*
*/

//TYPY CALKOWITE
//sbyte 8 bit
Console.WriteLine($"sbyte od {sbyte.MinValue} do {sbyte.MaxValue}");

//byte  8 bit
Console.WriteLine($"byte od {byte.MinValue} do {byte.MaxValue}");

//short 16 bit
Console.WriteLine($"short od {short.MinValue} do {short.MaxValue}");

//ushort 16 bit
Console.WriteLine($"ushort od {ushort.MinValue} do {ushort.MaxValue}");

//int 32 bit
Console.WriteLine($"int od {int.MinValue} do {int.MaxValue}");

//uint 32 bit
Console.WriteLine($"uint od {uint.MinValue} do {uint.MaxValue}");

//long 64 bit
Console.WriteLine($"long od {long.MinValue} do {long.MaxValue}");

//ulong 64 bit
Console.WriteLine($"ulong od {ulong.MinValue} do {ulong.MaxValue}");

//nint 32/64 bit
Console.WriteLine($"nint od {nint.MinValue} do {nint.MaxValue}");

//nuint 32/64 bit
Console.WriteLine($"nuint od {nuint.MinValue} do {nuint.MaxValue}");


// DOMYSLNYM TYPEM CALKOWITYM JEST int
// 'int' to alias czyli skrotowiec od pelnej nazwy jaka sie kryje pod tym typem: Int32


// DEKLARACJA ZMIENNEJ
// w C# musisz najpierw podac typ wartosci, potem nazwe zmiennej, a potem mozesz (ale nie musisz) od razu podac wartosc
// - moment w ktorym podajesz typ wartosci i nazwe nazywa sie DEKLARACJA
// - moment w ktorym nadajesz zmiennej wartosc nazywa sie INICJACJA / INICJALIZACJA

// UWAGA -> w C# na koncu danej operacji zawsze musisz dac srednik ;

// deklaracja
int liczba1;

// inicjacje
liczba1 = 5;

// deklaracja + inicjacja
int liczba2 = 10;


// ZAKRESY LICZB ZMIENNOPRZECINWKOWYCH

//float
Console.WriteLine($"float od {float.MinValue} do {float.MaxValue}");

//double 
Console.WriteLine($"double od {double.MinValue} do {double.MaxValue}");

//decimal
Console.WriteLine($"decimal od {decimal.MinValue} do {decimal.MaxValue}");