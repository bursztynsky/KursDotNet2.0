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
foreach(var car in arrayList)
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

list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);

Console.WriteLine("---");
foreach(var num in list)
{
    Console.WriteLine(num);
}
Console.WriteLine("---");