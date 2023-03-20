namespace _12_WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize(); // metoda potrzebna by wywolac zanim stworzycie jakies okienka

            // Aby po odpaleniu aplikacji pojawilo sie domyslnie okienko musze zrobic insntacje klasy Form1
            // oraz wrzucic ja do metody Application.Run(mainForm);
            var mainForm = new Form1();
            Application.Run(mainForm);
        }
    }
}