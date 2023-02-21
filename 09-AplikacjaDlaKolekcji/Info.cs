using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_AplikacjaDlaKolekcji
{
    internal class Info
    {
        // -----------
        // STRUMIENIE

        // To jest jedna z mozliwych metod na przesylanie danych Z i DO programu. Co jest wazne w strumieniach:
        // - w C# strumienie sa w bibliotece System.IO (In and Out)
        // - w C# mamy wiele roznych typow strumieni m. in. bitowe, tekstowe, plikowe, 'pamieciowe' (zapis/oczyt do pamieci)
        //  sieciowe itd.
        // - w strumieniach BARDZO WAZNE jest to, ze trzeba je OTWORZYC oraz ZAMKNAC!!!! Np. podczas pracy z plikami
        // czy to .txt czy .doc jesli mamy otwarty do nich strumien to plik jest zablokowany tzn. ze nie mozemy
        // go normlanie otworzyc w innym programie


        // Najwazniejsze klasy z biblioteki System.IO:
        // - Directory -> pozwala na zmiane struktury katalogow
        // - DirectoryInfo -> uzywane do operacji na katalogach
        // - File -> pomaga w operacjach na plikach
        // - FileInfo -> słuzy do wykonywania operacji na plikach
        // - FileStream -> służy do odczytu i zapisu do dowolnego pliku
        // - Path -> wykonuje operacje na sciezce dostepu (czyli sciezce do plikow i folderow)
        // - BinaryReader / BinaryWriter -> pozwala zapisac/ocztywac wartosci binarne
        // - StreamReader / StreamWriter -> otwiera strumien zapisu/oczytu wartosci binarnych

        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/ -> TUTORIAL MICROSOFTU

        // wykorzystanie BinaryReader i BinaryWriter
        public static void Binary()
        {
            // Metoda utworzy w podanej sciezce plik przetrzymujacy wartosci w formacie binarnym
            var path = "C:\\tempFolder\\tempFile1";

            // Wartosci do zapisania w pliku
            var linesToSave = new List<string>
            {
                "The following code example creates\n",
                "If there is an exception, the exception is displayed on the console.\n",
                "In the above example, the file name is the complete path including a file on a Universal Naming Convention (UNC) share.\n",
                "The default encoding is UTF8Encoding and the buffer size to 1024 bytes.\n",
            };

            // UWAGA: StreamWriter -> wali bledem jesli nie istnieje plik!
            //var stream = new StreamWriter(path);

            //foreach(var line in linesToSave)
            //{
            //    stream.Write(line);
            //}

            //stream.Close(); // tylko zamyka polaczenie strumienia
            //stream.Flush(); // czysci bufor z pozostlaych danych do przeslania/odczytu
            //stream.Dispose(); // to polaczenie Close + Flush

            // UWAGA -> NIE POWINNISMY RECZNIE ZAJMOWAC SIE ZAMYKANIEM STRUMIENI
            // Do zamykania strumieni stworzono slowo 'using' ktore sie tym zajmuje samemu
            // using dodajemy przy tworzeniu zmiennej ktora bedzie otwierac strumienie

            // Stare uzycie usinga:
            //using (var stream2 = new StreamWriter(path))
            //{
            //    foreach (var line in linesToSave)
            //    {
            //        stream2.Write(line);
            //    }
            //}

            // NOWE ROZWIAZANIE
            //using var stream = new StreamWriter(path);
            //foreach (var line in linesToSave)
            //{
            //    stream.Write(line);
            //}


            // JAK NAJPROSCIEJ ODCZYTAC LUB ZAPISAC RZECZY DO/Z PLIKU
            // https://learn.microsoft.com/pl-pl/dotnet/api/system.io.file?view=net-7.0 -> wiecej o File

            File.WriteAllLines(path, linesToSave);

            var allLines = File.ReadAllLines(path);

            Console.WriteLine(string.Join("", allLines));
        }
    }
}
