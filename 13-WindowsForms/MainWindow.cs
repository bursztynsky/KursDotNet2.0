using System.Text;

namespace _13_WindowsForms
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePathWindow = new FilePathWindow();

            //filePathWindows.Show(); // otwiera okno I NIE BLOKUE OKNA-MATKI wiec mozesz utworzyc miliard tych okienek
            filePathWindow.ShowDialog(); // blokuje okno matka wiec nie moge klikac juz w poprzednie okno
            // poki nie zamkne tego

            var filePath = filePathWindow.FilePath;

            var allLines = File.ReadAllLines(filePath);

            var textBox1 = Controls.Find("textBox1", true).FirstOrDefault() as TextBox;

            // JESLI POTRZEBUJEMY CHODZIC PETLA I TWORZYC ELEMENT PO ELEMENCIE STRING
            // TO NIGDY NIE UZYWAJCIE DO TEGO PLUSA!!!!
            // Uzywamy wtedy StringBuilder
            var sb = new StringBuilder();
            foreach (var line in allLines)
            {
                sb.AppendLine(line);
            }

            textBox1.Text = sb.ToString();
        }
    }
}