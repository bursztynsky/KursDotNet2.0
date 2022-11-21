// --------------------------------
//          SLOWO KLUCZOWE VAR
// --------------------------------
// var mozemy wstawic przy tworzeniu zmiennej po lewej stronie od jej nazwy (czyli zamiast typu zmiennej)
// var domysla sie jaki to bedzie typ zmiennej przez pryzmat tego jaka wartosc mu przypisujesz

string zmienna1 = "dupa";

var zmienna2 = 2;
var zmienna3 = 2d;
var zmienna4 = 2m;
var zmienna5 = true;

// WAZNE ZASADY W STOSOWANIU VAR!!!!
// Nie mozesz uzyc var jesli nie podasz od razu wartosci zmiennej
// var zmienna6; // mamy blad, ze kompilator nie moze znalesc typu jaki ma przypisac BO NIE ZAINICJOWALES WARTOSCI

// Moge do var wpisac wartosc zwracana przez metode:
string ReturnString()
{
    return "Ala ma kota";
}

var ala = ReturnString();

Console.WriteLine("Zmienna ala jest typu " + ala.GetType());

var tablica1 = new int[] { 1, 2, 3, 4, 5 };
foreach (var value in tablica1)
{
    Console.WriteLine(value);
}


// --------------------------
// SWITCH STATEMENT
// --------------------------
// switch to narzedzie ktorze polecam uzywac zamiast wielu if-ow na raz
// semantyka:
// switch(wartoscPorownywana) {
//      case opcja1:
//          ...
//        break;
//      case opcja2:
//          ...
//        break;
//      ...
//      default:
//          ...
//      break;
//}

// ten switch ponizej dziala tak samo jak if-y tutaj:
// if(literka == 'D') {
//     //..
// }
// else if(literka == 'B'){
//     //...
// }
// else if(literka == 'A'){
//     //...
// }
// else {
//     //...
// }

char literka = 'Q';

switch(literka) {
    case 'D':
        Console.WriteLine("znalazlem litere D");
        break; // break oznacza, ze jesli juz zlapalem case ktory odpowiada wartosci zmiennej 'literka' to odpalam kod tego case'a oraz koncze dzialanie switcha 
    case 'B':
        Console.WriteLine("znalazlem litere B");
        break;
    case 'A':
        Console.WriteLine("znalazlem litere B");
        break;
    default: 
        Console.WriteLine("nie znalazlem litery");
        break;
}

literka = 'D';

switch(literka) {
    case 'D':
        Console.WriteLine("znalazlem litere D");
        break; // break oznacza, ze jesli juz zlapalem case ktory odpowiada wartosci zmiennej 'literka' to odpalam kod tego case'a oraz koncze dzialanie switcha 
    case 'B':
        Console.WriteLine("znalazlem litere B");
        break;
    case 'A':
        Console.WriteLine("znalazlem litere B");
        break;
    default: 
        Console.WriteLine("nie znalazlem litery");
        break;
}

literka = 'A';

switch(literka) {
    case 'D':
        Console.WriteLine("znalazlem litere D");
        break; // break oznacza, ze jesli juz zlapalem case ktory odpowiada wartosci zmiennej 'literka' to odpalam kod tego case'a oraz koncze dzialanie switcha 
    case 'B':
        Console.WriteLine("znalazlem litere B");
        break;
    case 'A':
        Console.WriteLine("znalazlem litere B");
        break;
    default: 
        Console.WriteLine("nie znalazlem litery");
        break;
}