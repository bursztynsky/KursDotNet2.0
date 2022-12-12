// ---------------------------------
//          KALKULATOR
// ---------------------------------

// Napisz aplikacje ktora bedzie umozliwiac wykonywanie najprostszych
// zadan matematycznych w kalkulatorze:
// - dodawanie
// - odejmowanie
// - dzielenie
// - mnozenie

// - potegowanie
// - pierwiastkowanie

// Program ma byc przystepny wizualnie dla uzytkownika oraz umozliwiac w kazdej chwili wyjscie z 
// aplikacji przyciskiem ESC

var shutDown = false;

Console.WriteLine("Witaj w programie KALKULATOR\n\n");
//Console.WriteLine("Aby wyjsc z programu wcisnij przycisk ESC\n\n"); // \n -> to newline, wiec dwa \n to dwie nowe puste linie

while (!shutDown)
{
    Console.WriteLine("Aby wyjsc z programu wcisnij [ESC]. Wcisnij jakikolwiek inny przycisk jesli chcesz isc dalej");
    var pressedKey = Console.ReadKey();

    //Console.WriteLine("Wcisnales przycisk: "+pressedKey);
    //Console.WriteLine("Wcisnales przycisk: "+pressedKey.Key);
    //Console.WriteLine("Wcisnales przycisk: "+pressedKey.KeyChar);

    // jak sprawdzic czy wcisnelismy ESC
    //if (pressedKey.Key.ToString() == "Escape")
    //{
    //    // TODO Dla mnie i dla was -> dlaczego po wywoalniu ReadKey ucina nam pierwszy znak w nastepnym
    //    //  Console.WriteLine
    //    Console.WriteLine("WCISNALES ESCAPE");
    //}

    // NIGDY NIE PISZCIE KODU TAK JAK TEN POWYZEJ
    // Nie po to zostaly stworzone typy jak ConsoleKeyInfo czy ConsoleKey by pozniej
    // konwertowac jest na string i porownywac string do string
    // Praktyczne zastosowanie tego dlaczego porownywanie stringow tak jak tutaj
    // pokaze w bardziej rozbudowanej aplikacji

    // Lepiej skorzystac z ConsoleKey ktore jest enumeratorem (typ enum)
    // enum -> to typ wartosciowy
    //         to typ w ktorym mozemy sobie wyliczyc jakies wartosci np. Poniedzialek, Wtorek, Sroda itd...
    //         dzieki czemu uzywanie tych wartosci bedzie wygodniejsze, niz ustalanie, ze np. metoda
    //         zwracaja dzisiejszy dzien tygodnia bedzie zwracac enum typu DzienTygodnia np. DzienTygodnia.Poniedzialek
    //         zamiast int 0, bo zakladamy ze 0 to pierwszy dzien tygodnia
    //         Deklarowanie wlasnych pokaze next time
    //         UWAGA: Enum pod spodem pod ta nazwa rozumiana przez czlowieka trzyma typ calkowity int

    if (pressedKey.Key == ConsoleKey.Escape)
    {
        shutDown = true;
    }
    else
    {
        Console.WriteLine("Wybierz typ operatora matematycznego: [dod - dodawanie, od - odejmowanie, dz - dzielenie, mn - mnozenie]");
        var providedValue = Console.ReadLine();

        switch (providedValue)
        {
            case "dod":
                Console.WriteLine("Podaj liczby do dodania i po kazdej z nich kliknij enter. Aby zobaczyc wynik wpisz znak =");
                Add();
                break;
            case "od":
                Console.WriteLine("Zaczynam odejmowanie...");
                break;
            case "dz":
                Console.WriteLine("Zaczynam dzielenie...");
                break;
            case "mn":
                Console.WriteLine("Zaczynam mnozenie...");
                break;
        }
    }
}

void Add()
{
    var stopAdding = false;
    var sum = 0;

    while (!stopAdding)
    {
        var value = Console.ReadLine();

        // ten jeden raz uzyje TryParse by pokazac jak go dobrze uzyc
        // ALE dalej uzyje Parse ktory ryzykuje bledem jak ktos poda litere a nie liczbe
        // ZADANIE DOMOWE: uzyc wszedzie TryParse ALBO obsluzyc try...catchem mozliwe bledy

        // out to jest slowo kluczowe ktore powoduje ze z metody mozna zwrocic
        // wiecej niz jedna wartosc
        // WIEC metoda TryParse zwraca bool mowiacy czy konwersja sie udala
        // ORAZ out wyrzuca nam przekonwertowana wartosc
        var parseResult = int.TryParse(value, out int num);

        if (!parseResult)
        {
            // To uzycie tutaj jest ok, bo ta aplikacja jest mala i nierozbudowana
            // wiec nie musimy pisac jej doskonale na kazdym poziomie

            if (value == "=")
            {
                Console.WriteLine("Wynik: " + sum);
            }
            else
            {
                // Zakladam, ze jak ktos podal zla wartosc to pogram ma sie wylaczyc
                Console.WriteLine("Podales zla wartosc, mozesz podac tylko liczby!!!");
                shutDown = true;
            }
            stopAdding = true;
        }
        else
        {
            //sum = sum + num; // to jest to samo co ponizej
            sum += num;
        }
    }
}

Console.WriteLine("Shutting down the app...");
