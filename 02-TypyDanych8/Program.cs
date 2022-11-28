using System.Globalization;
// ---------------------------------------
//          STRING - kontynuacja
// ---------------------------------------

// POROWNYWANIE STRINGOW
// Mozemy je prownac korzystajac z:
// operatora ==
// metody Equals()

// Podstawowe użycie metody Equals ma praktycznie identyczne działanie co operator porównania ==
var word1 = "Elizabeth";
var word2 = "Elizabeth";

//Console.WriteLine("operator == -> " + word1 == word2); // tutaj kompilator troche swiruje przez dodanie
// do string operatorem + wyniku typu bool, najlepiej albo opasac porownanie w ()
// albo uzyc string interpolation
Console.WriteLine($"operator == -> {word1 == word2}");
Console.WriteLine($"Equals() -> {word1.Equals(word2)}");

// W przypadku takiego zastosowania metody Equals mozemy miec jednak problem,
// kiedy jedna z tych zmiennych bedzie null
// word1 = null; // jesli word1 jest null, to nie mozemy wykorzystac metody Equals, ani nic co jest po .
// w tym wypadku mamy blad NullReferenceException
word2 = null;
Console.WriteLine($"Equals() -> {word1.Equals(word2)}");
// Console.WriteLine($"length -> {word2.Length}"); // tu znow mamy blad

// Wniosek? PAMIETAJCIE, ze metoda Equals wywolana z poziomu zmiennej zawsze ryzykuje nam zwroceniem bledu NullReferenceException
// Jakie zatem jest lepsze rozwiazanie?


// Okazuje sie ze metoda Equals istnieje jeszcze w innej konfiguracji
// Mozemy ja wywolac piszac po prostu typ string i wykorzystajac jej metode
// Jaka to jest roznica? Na te chwile moge odpowiedziec tak, ze jest to metoda statyczna, czyli wspoldzielona
// wsrod całego typu string, ale to nie wiele nam teraz powie
// rozwiązanie tej zagadki będzie przy klasach
// word1.Equals() -> tutaj odpalamy metode Equals na zmiennej word1, ktora przyjmuje tylko
// jeden argument, czyli inny string do porownania
// string.Equals() -> tutaj musimy przekazac przynajmniej dwa argumenty, ktore wskazuja na to
// co chcemy porownac
word2 = "Elizabeth";
Console.WriteLine($"string.Equals() -> {string.Equals(word1, word2)}");
Console.WriteLine($"string.Equals() -> {string.Equals(word2, word1)}");
word1 = null;
Console.WriteLine($"string.Equals() -> {string.Equals(word2, word1)}");

// jak widac nie wazne, czy jedno jest null, drugie jest null czy oba sa null, to metoda dziala
// I UWAGA CO CIEKAWE -> jesli obie zmienne maja wartosc null, to Equals zwraca true :)

// Co jesli chcemy jednak porownac znaki nie zwracajac uwagi na to, czy sa to duze czy male litery?

// Najglupsze rozwiazanie to byloby wykorzystac metode ToLower lub ToUpper i wrzucic je w Equals:
word1 = "LOREM Ipsum";
word2 = "lorem ipsum";
Console.WriteLine($"string.Equals() -> {string.Equals(word1.ToLower(), word2.ToLower())}");
// działa, jednak jest to bardzo 'nieeleganckie rozwiazanie'

// W C# istnieje jednak typ, ktory mozna przekazac do roznych metod i okresla on
// dodatkowe informacje w jaki sposob ma on
// porownywac znaki
// Typ ten nazywa sie StringComparison
// Posiada on nastepujace wartosci:
// CurrentCulture -> korzystajac z aktualnie ustawionych w programie ustawien regionalnych (kraju) porownuje on znaki tekstowe zgodnie z jego np. alfabetem
// o co chodzi dokladnie? o to że np. w polskim alfabecie ó jest po o, ź jest to ż i po z. to samo dotyczy się wszystkich innych jezyków, więc ten setting bierze to zawsze pod uwagę
// CurrentCultureIgnoreCase -> to samo co powyżej, ALE NIE SPRAWDZA CZY TO DUZE CZY MALE LITERY (jest case insensitive)
// InvariantCulture -> nie zwraca uwagi na aktualne ustawienia regionalne
// InvariantCultureIgnoreCase -> to samo ale case insensitive
// Ordinal -> konweruje string na ciag binarny (kodujac znaki np. w ASCII) i porownuje ich wartosci
// OrdinalIgnoreCase -> to samo ale case insensitive

// jesli chcecie zobaczyc jakie ustawienia regionalne ma wasz komputerow to uzyjcie tego:
// using System.Globalization;
Console.WriteLine(CultureInfo.CurrentCulture);


// Temat tego jaki StirngComparison powinnysmy uzywac zalezy mocno od przypadku
// Link do oficjalnych zalecen Microsoft: https://learn.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings?redirectedfrom=MSDN
// TL;DR -> jesli nie ma znaczenia w przypadku string jaki to region i jaki kraj 
// (bo czesto nie ma) to uzywajcie Ordinal i OrdinalIgnoreCase bo dziala szybciej
// Ustawienia jakie to culture przydaja sie w przypadku dat co omowimy pozniej

// tu kilka puntkow:
// - Use StringComparison.Ordinal or StringComparison.OrdinalIgnoreCase for comparisons as your safe default for culture-agnostic string matching.
// - Use comparisons with StringComparison.Ordinal or StringComparison.OrdinalIgnoreCase for better performance.
// - Use the non-linguistic StringComparison.Ordinal or StringComparison.OrdinalIgnoreCase values instead of string operations based on CultureInfo.InvariantCulture when the comparison is linguistically irrelevant (symbolic, for example).
// - Do not use string operations based on StringComparison.InvariantCulture in most cases. One of the few exceptions is when you are persisting linguistically meaningful but culturally agnostic data.

// case in-sensitive porownania
word1 = "LOREM IPSUM";
word2 = "lorem ipsum";

Console.WriteLine($"case sensitive string.Equals() -> {string.Equals(word1, word2)}");
Console.WriteLine($"case in-sensitive string.Equals() -> {string.Equals(word1, word2, StringComparison.CurrentCultureIgnoreCase)}");
Console.WriteLine($"case in-sensitive string.Equals() -> {string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine($"case sensitive string.Equals() -> {string.Equals(word1, word2, StringComparison.Ordinal)}");

// TODO: sprawdz jak zrobic by ignorowal polskie litery

// PRZDATNE METODY W STRING

// string.Compare(arg1, arg2)
// ta metoda porownuje arg1 i arg2, nastepnie zwraca -1, 0 lub 1
// wyniki:
// -1 -> oznacza, ze arg1 jest alfanumerycznie wczesniej niz arg2
// 0 -> oznacza, ze arg1 == arg2
// 1 -> oznacza, ze arg1 jest alfanumerycznie pozniej niz arg2
var word3 = "Ala";
var word4 = "Zosia";

Console.WriteLine(string.Compare(word3, word4));
Console.WriteLine(string.Compare(word4, word3));
Console.WriteLine(string.Compare(word3, word3));

// string.Concat()
// ta metoda laczy ze soba podane stringi
// mozemy przekazac do niej string po przecinku lub
// tablice stringow
// lub kolekcje stringow
// nie ma organiczenia co do ilosci

var words = new string[] { "Adam", "Maciek", "Stefan" };
var wordsInCollections = new List<string>()
{
    "Iza",
    "Mateusz",
};
Console.WriteLine($"string.Concat: {string.Concat(word3, word4, words[0])}");
Console.WriteLine($"string.Concat: {string.Concat(words)}");
Console.WriteLine($"string.Concat: {string.Concat(wordsInCollections)}");
Console.WriteLine($"string.Concat: {string.Concat("Zdanie numer 1.", " ", "Zdanie numer 2.")}");

// CIEKAWOSTKA: jak wyswietlic cudzyslow w konsoli?
// Console.WriteLine("""");
// Console.WriteLine(""");
Console.WriteLine("\"");
Console.WriteLine(@"""");
Console.WriteLine(@"

    Przerwa

");

// string.Join()
// ta metoda przyjmuje jako pierwszy argument separator (czyli to co chcemy wkleic miedzy wszystkie stringi)
// 2 i wszystkie najstepne argumenty to stringi ktore chcemy ze soba polaczyc
Console.WriteLine($"string.Join: {string.Join(" ; ", word3, word4, words[0])}");
Console.WriteLine($"string.Join: {string.Join(" | ", words)}");
Console.WriteLine($"string.Join: {string.Join(" . ", wordsInCollections)}");
Console.WriteLine($"string.Join: {string.Join(" ", "Zdanie numer 1.", "Zdanie numer 2.")}");
var nums = new int[] { 1, 2, 3, 4, 5 };
Console.WriteLine($"string.Join: {string.Join(" | ", nums)}");


// .Replace()
// to jest metoda ktora odpalamy na zmiennej typu string
// zwraca ona nowa wersje naszego stringa, w ktorym zamieniamy podany char/string na inny char/string
var text1 = "Lorem  ipsum  lorem  ipsum  ";
Console.WriteLine(text1);
Console.WriteLine(text1.Replace("  ", " "));
Console.WriteLine(text1.Replace("ipsum", "IPSUM"));
Console.WriteLine(text1);

// tak wiec zmienic text1 na wynik Replace?
text1 = text1.Replace("  ", " ").Replace("ipsum", "IPSUM");
Console.WriteLine(text1);
// .Replace i wszystkie inne metody string moge odpalic nie tylko na zmiennej zawierajacej
// wartosc string, ale na samym stringu (tutaj jest on tymczasowy)
Console.WriteLine("lorem  ipsum  lorem  ipsum".Replace("  ", "."));

// .StartsWith i .EndsWith
// te metody jak nazwa wskazuje zwracaja bool mowiacy czy na poczatku/koncu stirng jest przekazana wartosc
Console.WriteLine(text1.StartsWith("Lorem"));
Console.WriteLine(text1.StartsWith("lorem"));
Console.WriteLine(text1.EndsWith("ipsum"));
Console.WriteLine(text1.EndsWith(" "));
Console.WriteLine(text1);

// .Split(separator)
// dzieli string na podstawie przekazanej wartosci i zwraca tablice
var words2 = text1.Split(" ");
foreach (var word in words2)
{
    Console.WriteLine(word);
}

// .Trim()
// to metoda ktora zwraca string z ucietymi wszystkimi znakami wodnymi na poczatku i na koncu
// stringa
words2 = text1.Trim().Split(" ");
foreach (var word in words2)
{
    Console.WriteLine(word);
}

Console.WriteLine("     adam".Trim());
Console.WriteLine("     adam     ".Trim());
Console.WriteLine("     adam  adam   ".Trim());

// TrimEnd -> czysci na koncu
// TrimgStart -> czysci na poczatku

// WAZNA!!!
// string.IsNullOrEmpty(arg1)
// ta metoda zwraca bool mowiacy czy przekazany arg1 jest null, lub jest pustym ""
Console.WriteLine(string.IsNullOrEmpty(null));
Console.WriteLine(string.IsNullOrEmpty(""));
// tutaj juz mamy true, bo biale znaki sa brane jako wypelnienie
Console.WriteLine(string.IsNullOrEmpty(" "));
Console.WriteLine(string.IsNullOrEmpty("    "));
Console.WriteLine(string.IsNullOrEmpty("    adam"));
Console.WriteLine(string.IsNullOrEmpty("adam"));

Console.WriteLine("----");
// string.IsNullOrWhiteSpace(arg1)
// ta metoda zwraca bool mowiacy czy przekazany arg1 jest null, lub biale znaki (wszystko typou spacji
// tabulacji, endline itd)
Console.WriteLine(string.IsNullOrWhiteSpace(null));
Console.WriteLine(string.IsNullOrWhiteSpace(""));
Console.WriteLine(string.IsNullOrWhiteSpace(" "));
Console.WriteLine(string.IsNullOrWhiteSpace("    "));
// tu mamy false, bo mamy juz litery
Console.WriteLine(string.IsNullOrWhiteSpace("    adam"));
Console.WriteLine(string.IsNullOrWhiteSpace("adam"));

// LINK DO RESZTY https://learn.microsoft.com/en-us/dotnet/api/system.string.split?view=net-7.0