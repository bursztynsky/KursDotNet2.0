// -----------------------------------------------------
//                    ZMIENNE I STALE
// -----------------------------------------------------

//Co to jest zmienna?
// Zmienna to po prostu element pamieci, w ktory mozemy wpisac wartosci konkretnego typu
// Zmienne umozliwiaja nam zmiane ich wartosci - jedyny wymog jaki musza spelniac, to ten sam typ,
// co zostal wskazany przy ich deklaracji

internal class Program
{
    private static void Main(string[] args)
    {
        int liczba1 = 10;
        // liczba1 = "dupa"; // mam blad poniewaz nie da sie niejawnie przekonwertowac string na int

        // DEKLARCJA ZMIENNEJ
        int liczba2;
        // kiedy zadeklaruje zmienna ale nie nadam jej wartosci, to nie moge jej uzyc poki nie zostanie ta wartosc nadana

        // Console.WriteLine(liczba2); // blad, bo liczba2 nie ma podanej wartosci (jest unassigned)

        // INICJACJA ZMIENNEJ
        liczba2 = 100;

        // DEKLARACJA + INICJACJA
        int liczba3 = 200;


        // CYKL ZYCIA ZMIENNEJ:
        // zmienna istnieje poki nie wyjdzie aplikacja z danych nawiasow klamrowych {}
        // Garbage Collector (GC) to jest aplikacja .NET ktora na biezaco sledzi co sie dzieje w aplikacji i zwalnia pamiec tam gdzie moze
        // czyli np. tutaj jak ywjdziemy za nawiasy {} to GC usuwa zmienna liczba1, liczba2 itd. z pamieci


        if (true)
        {
            // tutaj stworzylem zmienna liczba4
            int liczba4 = 300;
            // tutaj wychodze z klamry {} wiec liczba4 jest wywalana z pamieci
        }

        // Console.WriteLine(liczba4); // mam blad ze zmienna liczba4 nie istnieje

        // int liczba4 = 500;
        // Console.WriteLine(liczba4);

        // Zmienna w {}
        if (true)
        {
            int zmienna5 = 1000;

            if (true)
            {
                int zmienna6 = 6000;
                Console.WriteLine(zmienna5); // jest ok, bo jestem dalej w jej klamrach
            }

            // Console.WriteLine(zmienna6); // blad ze nie istnieje
        }


        // WAZNE - w przypadku zmiennych ktore maja wartosci typu WARTIOSCIOWEGO, kiedy kopiujemy z jednej zmiennej
        // wartosc do drugiej, i w tej drugiej zmienimi ta wartosc, to w pierwszej nic sie nie dzieje

        int zmienna11 = 2000;
        int zmienna12 = zmienna11;
        Console.WriteLine("zmienna11:" + zmienna11 + " zmienna12:" + zmienna12);

        zmienna12 = 5000;

        Console.WriteLine("zmienna11:" + zmienna11 + " zmienna12:" + zmienna12);

        // TYPY WARTOSCIOWE (np. liczbowe) kopiuja swoje wartosci, a nie odnosiniki do pamieci gdzie elzy dana wartosc


        // ----------------------------
        // Stala (const) - to slowo kluczowe zmienia zmienna w stala, czyli jest niemozliwe zmienienie jest wartosci.
        //                wazne jest to, ze kompilator w momencie natrafienia w czasie kompilacji na wartosc const
        //                zapisuje ja juz bezposrednio w kodzie wynikowym IL, ona nigdy nie wyladuje w pamieci wirtualnej.
        //                To oznacza, ze zmiennej const nigdy nie mozna nigdzie przekazac jako referencje, bo ona nie ma adresu w pamieci!
        //                Klasa, tablica czy struktura nie moze byc const, poniewaz one tworzone sa nie w trakcie kompilacji (compile time),
        //                a w trakcie uruchomienia aplikacji (runtime)!!!

        const int stala1 = 2137;
        // stala1 = 1234; // tutaj mamy blad bo const jest nieedytowalny

        // Przyklad wykorzystania const
        // Kiedy np. chcemy stworzyc role w apliakcji dla uzytkownikow i nie mamy 100% pewnosci, ze nazwa dla amina czy usera sie nigdy nie zmieni
        // Latwiej wiec zamiast wszedzie pisac z palca stringi z nazwami rol, to stworzyc stala, ktora zawsze bedzie miala poprawna wartosc
        // i jesli przyjdzie sytuacja ze trzeba zmienic nazwe, to moge ja zmienic tylk ow tym jednym pliku UserRole, a nie wszedzie gdzie pisalem lecznie wartosci
        string role1 = "Admin";
        string role2 = "User";

        //...
        string role11 = UserRole.Admin;


        // -------------------------------------------------------------------------------
        //                              METODY
        // -------------------------------------------------------------------------------

        // Metody to funkcjonalnosci tworzone dla konkrentych klas, w celu umozliwienia skrocienia kodu
        // Lepszym rozwiazaniem jest napisanie metody zajmujacej sie np. obliczaniem pochodnej i uzywanie jej wszedzie tam,
        // gdzie jest to potrzebne, niz pisanie lub kopiowanie za kazdym razem tego samego kodu

        // Metoda a funkcja:
        // Funkcja -> to kawalek kodu realizujacy jakas funkcjonalnosc; jest zazwyczaj ogolnodostepna
        // Metoda -> to kawalek kodu realizujacy jakas funkcjonalnosc, ale jest zdefiniowana w ramach konkretnej klasy

        // Metoda jest w klasie, ale nie moze byc w metodzie czyt. w metodzie nie mozesz definiowac nowej metody

        // METODA MOZE:
        // 1. Nic nie zwracac (typ void)
        // 2. Zwracac jakas wartosc (typ int, double, decimal, object itd...)

        ShowMessage(); // dzieki odpaleniu metody ShowMessage wyswietla mi sie tekst HELLO

        // ShowMessage2(); // tu mam blad, bo nie podalem zadnego argumentu do metody
        ShowMessage2("WITAJCIE");

        Console.WriteLine(GiveMeANumber());
        Console.WriteLine(GiveMeANumber2(true));
        Console.WriteLine(GiveMeANumber2(false));
    }

    // public -> to informacja ze ta metoda bedzie widziana z kazdego miejsca naszej aplikacji (wyjasnienie bedzie pozniej)
    // static -> NIE WAZNE NA TE CHWILE
    // void -> to slowo oznacza, ze metoda nic nie zwraca
    // ShowMessage -> nazwa mojej metody
    // () -> w srodku nich moge np. przyjmowac jakies dodatkowe argumenty
    public static void ShowMessage()
    {
        Console.WriteLine("HELLO");
    }

    // W nawiasach () tworzona jest zmienna 'message' i nastepnie w srodku metody jest wyswietlana
    public static void ShowMessage2(string message)
    {
        Console.WriteLine(message);
    }

    public static int GiveMeANumber()
    {
        // kiedy metoda nie jest 'void' czyli ma zwrocic jakas wartosc/obiekt
        // to musze na samym koncu tej metody uzyc slowa kluczowego 'return' i podac mu ta wartosc

        return 5;
    }

    public static int GiveMeANumber2(bool giveMe5)
    {
        // kiedy metoda nie jest 'void' czyli ma zwrocic jakas wartosc/obiekt
        // to musze na samym koncu tej metody uzyc slowa kluczowego 'return' i podac mu ta wartosc

        if (giveMe5 == true)
        {
            return 5;
        }

        return 2;
    }
}

class UserRole
{
    public const string Admin = "ADMINISTRATOR";
    public const string User = "USER";
}