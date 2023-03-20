// -------------------------
//      DZIEDZICZENIE
// -------------------------

// Co to jest?
// To jest sytuacja w ktorej mamy klase matke (np. Human) i ta klasa ma jakies pola (np. Name i Surname)
// Nastepnie tworzymy sobie klase dziecko (np. Worker) i ta klasa ma tez miec te same pola (np. Name i Surname) oraz kilka dodaktowych
// (np. WorkerId, Salary), ale NIE CHCEMY POWIELAC KODU. W takim wypadku dziecko bedzie 'dziedziczyc' po matce, wiec bedzie mialo wszystko co
// ma matka oraz dodatkowe

// PO CO DZIEDZICZENIE?
// - pozbywamy sie sytuacji w ktorej mamy wiele obiektow z tymi samymi polami (np. Name i Surname) i piszemy je oddzielnie dla kazdego
// - umozliwia nam tworzenie kodu ktory jest dynamiczny (czyli moge np. do metody Print wyswietlajacej info o danej pozycji przekazac i Human, i 
// Worker i np. Client


// Case kiedy nie mam klasy Human a chce miec metode ktora wyswietli imie i nazwisku obu klas: Worker i Client
using _11_Klasy;

Console.WriteLine("");

var worker = new Worker { Name = "Johny", Surname = "Kowaltzky", Salary = 2300 };
var client = new Client { Name = "Jack", Surname = "Sparrow", Address = "24th Noname Street" };

Tools.PrintValues(worker);
Tools.PrintValues(client);