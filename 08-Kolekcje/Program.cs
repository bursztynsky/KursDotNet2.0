// -----------------------------
// KOLEKCJE
// -----------------------------
// Kolekcja to jest 'inteligentna' tablica
// Kolekcja pod spodem dziala na tablicach ale to jej zadaniem jest tworzyc sobie te tablice
// pod spodem i nimi zarzadzac
// Plusem tego jest ze ja nie musze pisac wlasnych metod Add czy Remove, bo one juz istnieja

// W C# mamy kolekcje NIEGENERYCZNE i GENERYCZNE
// NIEGENRYCZNE kolekcje to takie, ktore maja juz zapisane w kodzie zrodlowym jakie typy danych moga przechowywac
// NIE POLECAM KORZYSTAC Z NIEGENERYCNZYCH kolekcji, bo sa stare i gowniane i bez sensu
// Najpopularniejsza kolekcja niegenryczna to ArrayList
// ArrayList moze tylko przetrzymywac w srodku typ object

// BOXING i UNBOXING
// -> Object to klasa matka wszystkie w c#
// istnieje on na szczycie piramidy typow, wiec KAZDY OBIEKT w C# moze byc przekonwertowany na object

// BOXING -> to konwersja z jakiegokolwiek typu na object

// W tej bibliotece leza wszystkie NIEGENERYCZNE kolekcje

using System.Collections;
using _08_Kolekcje;

var name = "John";
Console.WriteLine(name);
Console.WriteLine(name.ToUpper());

// rzutowanie -> to konwersja z jednego typu na drugi, z czego w nawias () wpisuje na jaki typ konwertuje
// a po prawej stronie daje to co chce przekonwertowac
var objName = (object)name;

Console.WriteLine(objName);
//Console.WriteLine(objName.ToUpper()); // tu mam blad, ze ja wiem ze objName to object a object nie ma metody ToUpper

// UNBOXING -> to konwersja z object na ten typ pierwotny (przed boxingiem)
var newName = (string)objName;
Console.WriteLine(newName);
Console.WriteLine(newName.ToUpper());

// Jak wiec widac boxing jest metoda na zmiane kazdego typu na typ object
// a ArrayList moze zbierac w sobie tylko liste typow object
// WIEC zanim cos moge wrzucic do listy to musze zrobic boxing

// Przyklad uzycia ArrayList
var arrayList = new ArrayList();

// Pierwszy sposob na dodawanie obiektow do ArrayList
var car1 = new Car()
{
    Id = 1,
    Brand = "BMW",
    Model = "i3",
    VIN = 3132323,
};

//arrayList.Add((object)car1); // w starszych wersjach .NET musialem recznie castowac obiekt Car na object
arrayList.Add(car1); // teraz .NET jest inteligentny i wie ze ma to zrobic sam

// Drugi sposob na dodawanie obiektow do ArrayList
arrayList.Add(new Car
{
    Id = 2,
    Brand = "AUDI",
    Model = "Q2",
    VIN = 123213,
});

//Console.WriteLine(string.Join("; ", arrayList)); // to nie dziala, bo klasy nie maja stworzonej sensowne metody ToString i zwraca ona zawsze nazwe
// * -> kiedys bedzie poprawiac metode ToString by wyswietlala to co chcemy
Console.WriteLine("-----");
foreach (var car in arrayList)
{
    // Kiedy ide element po elemencie w ArrayList to do zmiennej 'car' przypisywane sa obiekty typu Object
    // no i Object nie posiada ani .Model ani .Brand ani nic takiego
    //Console.WriteLine(car.Model);

    // Musze wiec zrobic UNBOXING zanim uzyje tego elementu
    var unboxed = (Car)car;

    Console.WriteLine(unboxed.Id);
    Console.WriteLine(unboxed.Brand);
    Console.WriteLine(unboxed.Model);
    Console.WriteLine(unboxed.VIN);
    Console.WriteLine("---");
}


// ------ KOLEKCJE GENERYCZNE
// Generycznosc oznacza ze w momencie kompilacji program nie wie jaki typ bedzie gdzies uzywany
// (w przeciwienstwie do np. ArrayList gdzie od zawsze wiem ze to bedzie tylko object)
// Generycznosc pozwala mi np. zrobic kolekcje ktora raz przyjmuj int, raz bool, albo zrobic metode
// ktora raz pryjmuje Car a raz Cat

// Najpopulanriejsza kolekcja generyczna to List<T>
// to <T> to umowna nazwa na generyczny typ ktory tam wrzucam

// Tworzenie listy
// w nawiasy <> musze podac jaki typ bedzie przechowywany w liscie juz w momencie jej deklaracji
// UWAGA -> typ ten jest niezmienialny!
var list = new List<int>();

// NAJWAZNIEJSZE METODY

// Add -> dodaje do listy to co przekazemy jako arugment
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);

var liczba1 = 101;
list.Add(liczba1);
list.Add(liczba1);
list.Add(liczba1);
list.Add(liczba1);

Console.WriteLine("-- add:");
Console.WriteLine(string.Join("; ", list));

// *-> Kiedy tworzymy liste i od razu chcemy wrzucic do niej jakies obiekty
// to zamaist osobno inicjowac liste i robic Add, to mozemy tak:
var stringList = new List<string>
{
    "Alicja",
    "MAciek",
    "tomek",
    "Adam",
};

Console.WriteLine("-- add:");
Console.WriteLine(string.Join("; ", stringList));

var car4 = new Car()
{
    Id = 4,
    Brand = "Fiat",
    Model = "Punto",
    VIN = 122131,
};

var carsList = new List<Car>
{
    new Car()
    {
        Id = 1,
        Brand = "BMW",
        Model = "i3",
        VIN = 3132323,
    },
    new Car()
    {
        Id = 2,
        Brand = "Toyota",
        Model = "Yaris",
        VIN = 212121,
    },
    new Car()
    {
        Id = 3,
        Brand = "AUDI",
        Model = "dupa",
        VIN = 1234565,
    },
    car4,
};

carsList.Add(new Car()
{
    Id = 5,
    Brand = "AUDI",
    Model = "dupa1",
    VIN = 12313,
});

Console.WriteLine("-- add:");
foreach (var car in carsList)
{
    Console.Write(car.Brand + " " + car.Model);
    Console.Write("; ");
}
Console.WriteLine();

// Remove -> usuwa to co przekazuje
// Case 1: kiedy przekazuje typ wartosciowy (np. int) to usunie on pierwszy napotkany element o tej samej wartosci
// Case 2: kiedy przekazuje typ referencyjny (np. klase) to usunie on referencje do obiektu jaki przekazalem (a jesli go nie ma to pewnie walnie bledem*-> do sprawdzenia)
list.Remove(101);

Console.WriteLine("-- remove:");
Console.WriteLine(string.Join("; ", list));

//stringList.Remove("Adam");
//Console.WriteLine("-- remove:");
//Console.WriteLine(string.Join("; ", stringList));

// UWAGA: klasycznie, domyslnie mamy caseSensitive wiec nie usunie Adama bo podales z malej litery
stringList.Remove("adam");
Console.WriteLine("-- remove:");
Console.WriteLine(string.Join("; ", stringList));

//carsList(new Car() { }); // JBC moge przekazac do Remove nowy samochod, ale oczywiscie nie ma to sensu

// aby usunac samochod musze znac referencje do niego
// znam referencje tylko do jednego samochodu bo mam zmienna car4 wiec i jego usune
carsList.Remove(car4);

Console.WriteLine("-- remove:");
foreach (var car in carsList)
{
    Console.Write(car.Brand + " " + car.Model);
    Console.Write("; ");
}
Console.WriteLine();

// OCZYWSCIE mozna car4 znowu dodac do listy po usunieciu
carsList.Add(car4);
carsList.Add(car4);
carsList.Add(car4);
carsList.Remove(car4);
carsList.Remove(car4);

Console.WriteLine("-- remove:");
foreach (var car in carsList)
{
    Console.Write(car.Brand + " " + car.Model);
    Console.Write("; ");
}
Console.WriteLine();
Console.WriteLine();

// Contains -> przyjmuje jako argument wartosc/referencje i sprawdza czy w liscie taka istnieje
// ZWRACA BOOL


Console.WriteLine("-- contains:");

var car5 = new Car();

Console.WriteLine(list.Contains(-5));
Console.WriteLine(list.Contains(0));
Console.WriteLine(list.Contains(101));
Console.WriteLine(stringList.Contains("tomek"));
Console.WriteLine(stringList.Contains("TOMEK"));
Console.WriteLine(carsList.Contains(car4));
Console.WriteLine(carsList.Contains(car5));


#region DODATEK O LAMBDA EXPRESSION!!!!
// Lambda expression to skrocony zapis tworzenia metod I SA ONE BEZIMIENNE
// Jest ona tak jakby JEDNORAZOWEGO UZYTKU bo nie ma nazwy wiec jak raz ja gdzies przekaze
// to juz nigdy wiecej jej nie odpale (bo nie ma nazwy wiec nie mam jak jej uzyc)
// KONSTRUKCJA METODY
// [public/private] [void/typ zwracany] [nazwaMetody] ([argument1], [argument2]) { [cialo metody] }
// public void PokazListe(List<int> list) { ... }

// KONSTRUKCJA LAMBDA EXPRESSION
// Roznice wzgledem zwyklej metody:
// 1. Nie ma public/private
// 2. Nie ma typu zwracanego (c# sam sie domysla)
// 3. Nie ma nazwy
// ([argument1], [argument2]) => { [cialo metody] }

// mozliwosci:
// lambda moze nie miec zadnego argumentu:
// () => Conole.WriteLine('dupa'); 

// lambda moze miec jeden lub wiecej argumentow (ile chcesz)
// (name) => { Conole.WriteLine(name); }
// (name, description) => { Conole.WriteLine(name + "\n" + description); }

// UWAGA lambda moze byc jednolinijkowa (jak powyzej) lub wielolinijkowa
// JEDNOLINIJKOWA NIE WYMAGA STOSOWANIA {} NA CIALO METODY
// WIELOLINIJKOWA to jest taka w ktorej otworzyles {} i masz wiecej niz jedna linie -> TO POWODUJE ZE JESLI TYP ZWRACANY
// NIE JEST VOID TO MUSZE UZYC 'return'

//Console.WriteLine(list.Exists(x => x == 10));
//Console.WriteLine(list.Exists(x => { return x == 10; });

//PRZYKLADY
// Lambda jednolinijkowa ktora nic nie zwraca
//() => Console.WriteLine('lambda1');

// Lambda jednolinijkowa ktora zwraca liczbe (na podstawie argumentu)
//(num) => num * 2;

// Lambda wielolinijkowa ktora zwraca liczbe (na podstawie argumentu)
//(num) => {
//  return num * 2;
//}
#endregion

// Exists -> przyjmuje predykat (funkcje ktora mowi jak ma sprawdzac obiekty w liscie) i na jego podstawie
// weryfikuje wszystkie elementy w liscie i zwraca true, jesli znajdzie taki obiekt, a false jesli nie
Console.WriteLine("-- exists:");
// CZYLI do Exists musze przekazac funkcje ktora zwraca bool, moge przekazac na dwa sposoby:
// 1. Przekazac nazwe funkcji (NAZWE CZYLI BEZ WYWOLYWANIA JEJ NAWIASAMI () !!!!)
// 2. Przekazac lambda expression (nazywane tez 'arrow function' lub 'anonymous function')

// Case1 : nazwa funkcji
Console.WriteLine(list.Exists(IsTen));
// Case2 : lambda
Console.WriteLine(list.Exists(num => num == 10));
Console.WriteLine(list.Exists(num => num == 101));
Console.WriteLine(list.Exists(num => num == 0));

// UWAGA -> Exists rozwiazuje problem tego, ze znamy referencje tylko do dwoch obiektow car4 i car5
// dzieki temu ze przekazuje metode, ktora mowi, jak Exists ma porownywac miedzy soba obiekty
// to moge przekazac info jakiego konkretnego samochodu szukam

Console.WriteLine(carsList.Exists(IsToyota));
Console.WriteLine(carsList.Exists(car => car.Brand == "Toyota"));
Console.WriteLine(carsList.Exists(car => car.Brand == "Nissan"));
Console.WriteLine(carsList.Exists(car => car.Brand == "AUDI"));
Console.WriteLine(carsList.Exists(car => car.Brand == "audi"));


// Find -> przyjmuje tak jak exists PREDYKAT i na jego podstawie zwraca PIERWSZY element spelniajacy warunek z predykatu
// UWAGA! Jesli Find nie znajdzie nic w liscie spelniajacego warunek, to zwraca default value
// default values dla klas to NULL!!!!
// Kiedy zwroci null to zmienna ktora jest wskazywana na wynik Find wskazuje na null
// WIEC jesli sprobuje dostac sie do niej korzystajac z kropki to pierdolnie mi blad NullReferenceException
Console.WriteLine("-- find:");
var toyota = carsList.Find(car => car.Brand == "Toyota");
Console.WriteLine(toyota.Brand + " " + toyota.Model);
var nissan = carsList.Find(car => car.Brand == "Nissan");
//Console.WriteLine(nissan.Brand + " " + nissan.Model); // tutaj mamy exception

// bledom zapobiegamy ALBO obslugujac try...catch ALBO chociazby sprawdzajac czy zmienna nissan nie jest null
if (nissan != null)
    Console.WriteLine(nissan.Brand + " " + nissan.Model);
else
    Console.WriteLine("There is no Nissan here");

var audi = carsList.Find(car => car.Id == 3);
Console.WriteLine(audi.Brand + " " + audi.Model);


bool IsTen(int num)
{
    return num == 10;
}

bool IsToyota(Car car)
{
    return car.Brand == "Toyota";
}