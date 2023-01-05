namespace _05_Struktury;


// Domyslnym modyfikatory dostepu (slowo np. public, private, internal)
// jest 'internal'
// Tzn ze jesli ja nie podam przed np. struktura zadnego operatora dostepu
// to kompilator domyslnie wklei tam 'internal'

public struct PublicCar
{
    // MODYFIKATORY DOSTEPU W C#:
    // - public -> to modyfiukator otwierajacy klase/strukture itd. na wszystko
    //             tzn ze moze jej uzyc kazda inna klasa/struktura w calym projekcie/aplikacji (nazywam czasami assembly)
    //              ORAZ moze jej uzyc tez inna aplikacja/projekt ktory znajduje sie w tej samej solucji
    // The type or member can be accessed by any other code in the same assembly or another assembly that references it.The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
    //
    // - private -> dane pole/wlasciwosci/metode/klase/sturkture itd widac TYLKO w obrebie tej klasy/strukury
    //              w ktorej zostalo utworzone
    // The type or member can be accessed only by code in the same class or struct.

    // - internal -> jest to to samo co public ALE nie ma dostepu do obiektu z innego projekut/aplikacji
    // The type or member can be accessed by any code in the same assembly, but not from another assembly.In other words, internal types or members can be accessed from code that is part of the same compilation.
    
    // OPIS ZOSTAWIAM NA POZNIEJ, ale macie ten po ang i mozecie sobie przeczytac
    // - protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
    // - protected internal: The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
    // - private protected: The type or member can be accessed by types derived from the class that are declared within its containing assembly.

    // KONSTRUKTOR ZAWSZE MUSI BYC PUBLIC!!!
    public PublicCar(string name, string vin)
    {
        Name = name;
        _vin = vin;

        Console.WriteLine("VIN created: " + _vin);
        //Console.WriteLine("VIN created: " + vin);
    }

    // Modyfikator dostepu moge tez przypisac do pola
    public string Name;

    // Dodaje pole 'private'
    // ZASADY TWORZENIA PRYWATNYCH POL:
    // 1. Zawsze nazywasz je poprzedzajac podloga czyli znakiem '_'
    // 2. Zapisujemy nazwy w konwencji camelCase -> np. _numerTelefonu, _vin, _nazwaModelu, _maksymalnaPredkosc
    private string _vin;

    public Address OwnerAddress;
}

public struct Address
{
    // Semantyka (czyli zasady jezyka programowania) umozliwia nam przekazywanie do konstruktora zmiennych
    // nazwanych tak samo jak pola ktore chcemy ustawiac w klasie
    public Address(string Street, string HouseNumber, string City, string Country)
    {
        // Street = Street; // w takim przypadku program nie wie ktore Street przypisuje do ktorego Street
        // w takiej sytuacji z pomoca nam przychodzi slowo kluczowe 'this'
        // this -> mowi programowi ze to co ja teraz po kropce podam to jest pole/wlasciwosc/metoda TEGO
        // KONKRETNEGO OBIEKTU MOJEJ KLASY
        this.Street = Street;
        this.HouseNumber = HouseNumber;
        this.City = City;
        this.Country = Country;

        // UWAGA: this juz sie nie uzywa
        // po to powstalo zalozenie ze np. argumenty piszemy z malej litery 
        // oraz pola publiczne piszemy z duzej litery oraz pola prywatne piszemy z malej litery + _ przed nazwa
    }

    public string Street;
    public string HouseNumber;
    public string City;
    public string Country;
}