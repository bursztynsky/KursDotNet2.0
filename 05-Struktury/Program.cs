// ------------------------------
//          STRUKTURY
// ------------------------------

// TYP WARTOSCIOWY ktory pozwala nam na trzymanie w srodku wiecej niz jednej wartosci
// moze miec w srodku wszystko, czyli np. int, double, string, inne klasy, inne struktury
// itd.

// Cechy:
// - posiada konstruktor (i moze posiadac ich wiele, ale musza sie roznic iloscia argumentow i typami argumentow)
// - moze posiadac w srodku swoje wlasne metody
// - moze posiadac pola oraz wlasciwosci
// - NIE MOZE dziedziczyc, byc dziedziczonym, implementowac interfejsow* -> o tym potem przy klasach


// *konstruktor (constructor) -> to metoda ktora jest odpalana zawsze
// kiedy uzyjesz slowa 'new' jak tworzysz klase lub strukture. Konstruktor
// jest zawsze typu 'void' bo on nie zwrac zadnych, ma zawsze nazwe taka sama jak struktura/klasa.
// ZADANIE KONSTRUKTORA -> kiedy uzyjesz slowa 'new' to w pamieci tworzone jest miejsce
// na klase/strukture. Konsturktor pod spodem wlasnie rezerwuje miejsca w pamieci oraz
// inicjuje wszystkie wartosci danej klasy/struktury na ich domyslne wartosci

// domyslne wartosci w przypadku typow liczbowych to 0, a w przypadku referencyjncyh to null

// kontunuacja opisu w strukturze -> Point.cs

using _05_Struktury;

var pointA = new Point();
pointA.X = 100;
pointA.Y = 200;

//Console.WriteLine("Moj punkt ma: X=" + pointA.X + " Y=" + pointA.Y);

pointA.Print();


var pointB = new Point();

pointB.Print(); // tutaj widac ze ma wartosci x=0 i y=0 bo konstruktor ustawil je na takie

// UWAGA: konstruktor moze nie uzywac slowa 'new', mozemy go zapisac tak jak ponizej
// W STARSZYCH WERSJA C# jesli bym to zrobil i nie ustawil recznie wartosc X i Y
// to odpalac metode Print albo wgl probuja wyswietlic cokolwiek w srodku tego pointa
// dostalbym blad!
// ALE juz w .NET 7, juz nie ma tego bledu i jak widac mimo braku uzycia slowa 'new'
// domyslny konstruktor i tak jest odpalany
// UWAGA 2: MIMO ZE DZIALA, NIGDY NIE TWORZCIE STRUKTUR BEZ SLOWA NEW!!!!!
//Point pointC;
//pointB.Print();

// jak to wiec zrobic poprawnie mimo braku new?
// TO JEST OK ALE NADAL NIE ROBIC!!!
//Point pointC;
//pointC.X = 100;
//pointC.Y = 300;
//pointC.Print();

Console.WriteLine("--- konstruktory dla Point:");

var pointD = new Point();
pointD.Print();
var pointE = new Point(100);
pointE.Print();
var pointF = new Point(100, 300);
pointF.Print();

Console.WriteLine("--- Odleglosc miedzy punktami:");

// tera zuzyjemy BetterPoint bo on zmusza do podania X i Y
var betterPointA = new BetterPoint(100, 300);
var betterPointB = new BetterPoint(100, 300);
var betterPointC = new BetterPoint(12, 232);

Console.WriteLine("A i B -> " + betterPointA.GetDistance(betterPointB));
Console.WriteLine("A i C -> " + betterPointA.GetDistance(betterPointC));

Console.WriteLine("----- zachowanie typu wartosciowego");

// Porownanie zachowania typu wartosciowego (int) w przekazywaniu do metod
var num = 2137;
Console.WriteLine("Number: " + num);
RandomizeNumber(num); // w tym momencie biore sobie liczbe jaka sie kryje pod zmienna 'num'
// i do metody RandomizeNumber ja przekazuje
Console.WriteLine("Number: " + num);

// tutaj znowu przekazuje kopie 'num' do metody
// metoda zas zwraca kopie rezultatu (tam sie nazywa 'number')
// I REZULTAT TEJ METODY PRZYPISUJE DO ZMIENNEJ 'num'
num = RandomizeNumber2(num);
Console.WriteLine("Number: " + num);


// Porownanie zachowania typu wartosciowego (struct) w przekazywaniu do metod
var betterPointToChage1 = new BetterPoint(100, 300);
betterPointToChage1.Print();

// przekazuje do Randomize zmienna typu BetterPoint i jej wartosci
Randomize(betterPointToChage1);

betterPointToChage1.Print();

// ZAWSZE W METODACH przekazywane argumenty to ICH KOPIA
// czyli jak przekazuje powyzej zmienna ktora nazywa sie 'betterPointToChage1'
// tp Randomize najpierw tworzy sobie na chwile nowa zmienna o nazwie 'point' i 
// KOPIUJE do niej wszystkie wartosci jakie ma 'betterPointToChage1'
void Randomize(BetterPoint point)
{
    var rand = new Random();
    point.X = rand.Next(0, 100);
    point.Y = rand.Next(0, 100);

    //point.Print();
}

// Kiedy przekazujemy typ waretosciowy np. int to ten 'number' w srodku nawiasow RandomizeNumber(...)
// to jest NOWA ZMIENNA ktora ma taka sama wartosc liczbowa co przekazywana do metody inna zmienna
// NO I JA W SRODKU METODY ZMIENIAM TO MOJA TYMCZASOWA ZMIENNA 'number' NA LOSOWA LICZBE
// ALE ta zmienna ktora przekazalem do metody pozostaje niezmieniona
void RandomizeNumber(int number)
{
    var rand = new Random();
    number = rand.Next(0, 100);
    Console.WriteLine("Number in RandomizeNumber:" + number);

    // w void moze byc return ale pusty
    //return;

    // ale nie moze zwracac jakiejs wartosci
    //return 0;
}


// JAK WIEC ZROBIC METODE RandomizeNumber zeby miala sens?
int RandomizeNumber2(int number)
{
    var rand = new Random();
    number = rand.Next(0, 100);
    Console.WriteLine("Number in RandomizeNumber:" + number);

    return number;
}


// PODSUMOWANIE CO TO JEST TYP WARTOSCIOWY???
// - To typ prosty (poza struct moze trzymac tylko jedna wartosc)
// - Jak przekazujemy zmienna (ktora jest type wartosciowym) do metody
// to w tej metodzie tworzona jest nowa zmienna z KOPIA WARTOSCI tego co przekazalismy
// tzn. jesli zedytuje zmienna w metodzie, to zedytuje zupelnie inna komorke w pamieci
// wiec ta zmienna pierwotna ktora przekazalem do metody jest nadal nie zmieniona



// ---------------
//  MODYFIKATORY DOSTEPU (np. public, private, internal...)
// ---------------
// Jezyki obiektowe sa stworzone na podstawie zalozen hermetyzacji/enkapsulacji.

// CO TO ENKAPSULACJA?
// To po prostu zalozenie, ze to co ma byc schowane, to ma byc schowane, a to co ma byc widoczne
// to ma byc widczone
// Innymi slowy to zalozenie ze Ty jako programista masz kontrolowac (slowami kluczowymi) dostep
// do: struktur, klas, pol, wlasciwosci, metod itd.
// CZYLI jesli np. mamy w klasie pole ktore ma byc niewidoczne z zewnatrz (bo np. wykorzystywane jest
// tylko w wewnetrznej logice obliczen), to kontrolujemy to czy to jest widoczne czy nie
// Innymi slowy 2: trzeba pamietac nie jest sztuka napisac program, ale sztuka napisac program
// ktory jest EDYTOWALNY i ZROZUMIALY dla programistow postronnych
// Nie ma nic gorszego niz programista ktory pisze np. nazwy zmiennych typu x, y, dupa, aha, mhm itd.
// Nie ma nic gorszego niz zagmatwany kod/petle/funckje ktore kompletnie nic nie tlumacza a licza cos i Ty tracisz
// czas na analizowaniu kodu
// Enkapsulacja pomaga nam ogarnac kod i jej celem jest ukrycie przed innymi programista rzeczy ktorych nie powinni
// dotykac, oraz upubliczniac tylko to co ma byc publiczne

// Wykorzystanie publicznej struktury
var car1 = new PublicCar("Toyota", "XYZ");
Console.WriteLine(car1.Name);
//Console.WriteLine(car1._vin); // prywatne pole jest dostepne TYLKO w srodku klast PublicCar
// nie widze jej juz z poziuomu innych klas

car1.OwnerAddress = new Address("x", "y", "z", "c");

// ZALECENIA NAZYWANIA POL i zmiennych W STUKTURACH/KLASACH:
// 1. pola typu public piszemy z pierwszej duzej litery (PascalCase) np. Street, PostCode
// 2. pola typu private piszemy w camelCase + znak '_' przed nazwa np. _vin, _name, _maxSpeed
// 3. argumenty w metodach zapisujemy w camelCase


// ---------------------------
// POLE a WLASCIWOSC
// ---------------------------

// Pole (ang. field) -> to warotsc danej klasy/stuktury. Jesli nie jest private to jest dostepne z zewnatrz
// i mam bezposredni dostep do tego pola i moge go edytowac z 'zewnatrz' tzn. jak stworze strukture PublicCar
// to mam jej pole Name i moge je edytowac zawsze i wszedzie np. w kodzie pliku Program.cs
// PLUSY pola typu public:
// - moge go edytowac kiedy chce i jak chce i nie ma kontroli nad nim
//   ale np. moge do Name wpisac wtedy liczbe "123" i Name bedzie bez sensu ale moze tak potrzebujecie

// MINUSY pola typu public:
// - MOZNA EDYTOWAC BEZ KONTROLI Z ZEWNATRZ tzn. jesli mam np. VIN, albo Name albo City, to do tych zmiennych
// moge wpisac co mi sie zapragnie wiec moge wpisac dane z dupy np. VIN bedzie dlugim napisem lorem ipsum, a
// Name bedzie typu JanKowalski
// Takie zostawianie pol jako publiczne ryzykuje tym ze ktos wprowadzi bledne dane
// np. mamy w aplikacji pole tekstowe do uzupelnienia adresu (typ string) i jesli jest to pole publiczne
// i przed zapisaniem tego co ktos podal nie kontrolujemy zawartosci to user moze wpisac "dupa123" i taki
// adres zapisze sie w bazie danych
// NIE FAJNIE

// Aby kontrolowac wprowadzone dane do pola mamy dwa rozwiazania (najpierw ustawiamy pole na private):
// 1. Napisac wlasny Getter i Setter -> getter i setter to metody ktore nazywamy zykle np. GetName i SetName
// Get ma zwracac wartosc typu private
// Set ma ustawiac wartosc dla pola typu private
// 2. Uzyc wlasciwosci (property)

var worker = new Worker();

worker.Name = "John";

worker.SetAge(100);
Console.WriteLine($"Pracownik {worker.Name} ma wiek {worker.GetAge()}");

worker.SetId(-10);
Console.WriteLine($"Pracownik {worker.Name} ma id {worker.GetId()}");

worker.ZmniejszWiek();
Console.WriteLine($"Pracownik {worker.Name} ma wiek {worker.GetAge()}");


// ----------------------
// ZALECENIA MICROSOFT DOT. POL

// Zaleceniem jest by pola zawsze byly prywatne, a dostep do nich odbywal sie poprzez dedykowane gettery
// i settery


// typ wartosciowy:
var liczba = 1200;

ZmienLicze(liczba);
ZmienLicze(2600);


var pies = new Dog();
pies.SetOwner("Mark");

Console.WriteLine("Wlasicicel przed edycja: " + pies.GetOwner());
ZmienPsuWlasciciela(pies);
Console.WriteLine("Wlasicicel po edycji: " + pies.GetOwner());


var kot = new Cat();
kot.Name = "Fatty";

Console.WriteLine(kot.Name);

kot.Owner = "Johny";

Console.WriteLine($"Kot: {kot.Name}, wlasciciel: {kot.Owner}");

void ZmienLicze(int number)
{
    number = number * 2;
}

void ZmienPsuWlasciciela(Dog dog)
{
    dog.SetOwner("Johny");
    Console.WriteLine(dog.GetOwner());
}
