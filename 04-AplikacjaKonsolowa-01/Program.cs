// -------------------
// Co zrobic jesli chcemy wyciagnac informacje od uzytkownika (w konsoli)

// W bibliotece Console mamy 3 metody ktore umozliwiaja czytanie informacji od uzytkownika:
// - Console.Read() -> pozwala na doczytywanie kolejnych znakow ze strumieni (np. plik txt, albo wprowadzane
//                      dane w konsoli)
// - Console.ReadLine() -> zwraca nam cala linie tekstu wprowadzonego do konsoli (zwrac zawsze STRING)
// - Console.ReadKey() -> 


// Console.ReadLine()

//Console.WriteLine("Podaj zdanie:");

// aby wyswietlic to co podano w konsoli nalezy uzyc tego:
//Console.WriteLine(Console.ReadLine());

//var text = Console.ReadLine();
//Console.WriteLine(text);
//Console.WriteLine(text.ToUpper());
//Console.WriteLine(text.ToLower());
//Console.WriteLine(text);

// Przekazywanie tekstu jest proste, bo ReadLine zawsze zwraca string
// Jesli chcemy korzystac z przekazanych liczb, to musimy uzyc konwersji

// Moze pojsc wiele rzeczy źle - ktoś nie przekazał w konsoli nic, to mam błąd konwersji
// ktoś przekazał zdanie - błąd konwersji

// To wszystko w dobrej aplikacji musimy brać pod uwagę

//Console.WriteLine("Podaj liczbe:");
//var number = Console.ReadLine();

// jak spojrzycie na metode ReadLine to zwraca ona string?
// string? od zwyklego string rozni sie tym, ze informuje nas, ze zwrocona moze byc
// wartosc null, co, jesli okaze sie prawda, wywali bledem w linii ponizej
//Console.WriteLine(number.GetType());

//if(number == null)
//{
//    Console.WriteLine("Podaj poprawna liczbe:");
//    number = Console.ReadLine();
//}

// w przypadku powyzej sprawdzenie bedzie jednorazowe i zeby to mialo sens najlepiej opakowac taka
// walidacje w petle

// zrobie zmienna shutDown ktora jesli jest true, to mowi, ze aplikacja ma sie wylaczyc, a jesli 
// false, to dziala dalej
// DZIEKI TEMU mam kontrole nad tym kiedy aplikacja ma byc wylacozna, wiec moja nieskonczona 
// petla zostanie w pewnym momencie przerwana

var shutDown = false;

// dajac ! przed zmienna typu bool odwracam jej wartosc:
// z true na false
// z false na true
while (!shutDown)
{
    Console.WriteLine("Podaj liczbe:");
    var number = Console.ReadLine();

    if (number != null)
    {
        // jak wiec wyciagnac czy przekazany tekst to liczba czy nie?
        // moglbym uzyc konwersji () ale ona wywala blad jesli sie nie uda 
        // a wywalenie bledu tutaj (bez jego obsluzenia) wylaczy mi aplikacje

        //var convertedNumber = (int)number; // NIESTETY VS i .NET zabrania mi konwertowac string na int
        // widocznie jest to zbyt ryzykowne (BO JEST)

        // Lepsze do konwertowania liczb jest uzycie metod Parse i TryParse
        // metoda int.Parse(string value) -> metoda ta silowo konwertuje string na int
        // ALE moze walnac bledem (jesli np. string jest null lub ma litery) jesli cos pojdzie nie tak
        // WIEC dziala podobnie do rzutowania

        //var parsedValue = int.Parse(number);

        //Console.WriteLine("Podana liczba -> " + parsedValue);

        // Parse wali bledem FormatException ktory wskazuje na to ze string ma znaki
        // ktorych nie mogl przekonwertowac na liczbe

        // C# umozliwia nam tzw. obsluge bledow czy opakowanie RYZYKOWNEGO kodu
        // w nawiasy {} i wypalywanie bledow
        // np. jesli ja sie spodziewam, ze FormatException zostanie zwrocony
        // to moge uzyc tej obslugi i np. wyswietlic inny komunikat uzytkownikowi
        // albo... po prostu zapobiegne wylaczeniu sie aplikacji kiedy dostane blad

        // do obslugi bledow uzywamy try...catch
        // try -> posiada nawiasy {} i w srokdu tych nawiasow zapisujemy ryzykowny kod
        // catch -> moge ich zapisac ile chce na koncu try
        //          catch ma za zadanie wylapywac KONKRETNY TYP BLEDU
        //          Nie musze wyliczac wszystkich mozliwych bledow w catch
        //          Aby wylapac JAKILKOWIEK blad (czyli niedoprecyzowany jak FormatException)
        //          moge po prostu przekazac do catch typ Exception
        // Exception -> to klasa ktora mowi ze walnelo bledem, to KLASA MATKA wszystkich bledow
        //              wiec kazdy doprecyzowany blad bedzie tez typu Exception

        // catch moze byc wiele, najlepiej isc od najbardziej precyzyjnego bledu
        // do najbardziej ogolnego - dawaj zawsze Exception na samym koncu

        try
        {
            // tutaj podaje ryzykowny kod
            // TO JEST TA RYZYKOWNA LINIA
            var parsedValue = int.Parse(number); // tutaj jak walnie blad to kod ponizej sie nie wywola
            // ale przekieruje nas do catcxh

            Console.WriteLine("Podana liczba -> " + parsedValue);

            // innym sposobem jest metoda TryParse
            // int.TryParse(string vlaue) -> robi to samo co Parse ALE nie wywala bledu
            // metoda ta ZWRACA BOOL KTORY MOWI CZY SIE UDALA KONWERSJA
            // W tym wypadku metoda TryParse zwraca w normlany sposob bool, ale zwraca
            // tez za pomoca slowa out wynik konwersji (czyli string zmieniony na liczbe)
            // UWAGA: korzystanie z out jest juz calkiem niemodne, ale warto pocwiczyc jego uzycie
            // bo nadal bardzo duzo metod w .NET i dodatkowych bibliotekach go uzywa

            //parsedValue = int.TryParse(number); // to za malo, musze podac out

            // out -> mowi, ze metoda zwraca dodatkowe wartosci
            //        w out podaje tylko slowo 'out', typ jaki zwraca oraz nazwe zmiennej
            //        UWAGA: zmienna ta nie musi byc wczesniej deklarowana, out samo w sobie
            //        deklaruje te zmienne

            // tak bylo kiedys:
            //var result = 0;
            //var efektKonwersji = int.TryParse(number, out int result);
            // TAK SIE JUZ NIE DA, I DOBRZE

            // zmienna w out moge nazwa jak chce, ale zostawie result
            var efektKonwersji = int.TryParse(number, out int result);
            Console.WriteLine("Efekt konwersji ->" + efektKonwersji);
            Console.WriteLine("Przekonwertowana wartosc ->" + result);

            // PODSUMOWANIE:
            // Parse() -> konwertuje string na dany typ (bo nie tylko int to posiada) i go zwraca
            // TryParse() -> zwraca true/false mowiace czy sie udalo czy nie, oraz w out variable
            //              przekazuje nam wynik konwersji

            // TryParse przydaje sie kiedy NIE CHCE NAM SIE obslugiwac za pomoca try...catch
            // wszystkich mozliwych bledow
            // Parse walnie zawsze bledem wiec by aplikacja sie nie wylaczyla to musze uzyc try...catch

            // Co lepiej? TO ZALEZY od tego co uzywacie i co chcecie osiagnac
            // Ja polecam korzystac z TryParse, bo bedzie jeszcze wieleeeee innych wazniejszych
            // miejsc w ktorych bedziemy musieli obslugiwac bledy, wiec po co dodawac kolejne
        }
        // Zawsze wyladuje blad tego konkretnego typu
        catch (FormatException ex)
        {
            Console.WriteLine("BLAD FORMAT EXCEPTION!!!");
        }
        // Wszystkie bledy ktore nie sa FormatException wyladuja tutaj
        catch (Exception ex)
        {
            Console.WriteLine("Udalo mi sie, zlapalem blad i jestem w catch!");
            //Console.WriteLine(ex); // jak wyswietle caly ex to mam bardzo duzo info o tym co tam jest
            // moge po prostu wyswietlic jego properties
            Console.WriteLine("BŁĄD!!!!");
            Console.WriteLine(ex.Message);
        }
    }
}

// jesli shutDown osiagnie wartosc true to dojdzie do tej linii
// a poniewaz nie ma tutaj juz wiecej zadan dla aplikacji to zostanie ona wylaczona
// Zostawie wiec tylko info - uwaga zamykam aplikacje
Console.WriteLine("Shutting down the app...");
