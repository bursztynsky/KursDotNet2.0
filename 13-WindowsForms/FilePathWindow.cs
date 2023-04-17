using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_WindowsForms
{
    public partial class FilePathWindow : Form
    {
        public string FilePath { get; set; }
        private readonly MainWindow _mainWindow;

        public FilePathWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        // w metodach mozemy miec OPCJONALNE parametry
        // jesli do argumentu dodam = domyslna wartosc
        // to nie musze jej podawac przy odpalaniu
        private void ShowError(string message = "YOU NEED TO SELECT A FILE!!!")
        {
            //MessageBox.Show("YOU NEED TO SELECT A FILE!!!", "Some title", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show(message, "Some title", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Zanim zamkne okno to nie pozwalam na to by filePath nie zostal wybrany!
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                ShowError("You have to select a file to save!");

                return;
            }

            // Mozemy zamknac okno z poziomu kodu w taki sposob
            Close();

            // Tutaj chcemy uruchomic na oknie matka ladowanie danych z naszego pliku
            _mainWindow.LoadData(FilePath);
        }

        private void buttonFileButton_Click(object sender, EventArgs e)
        {
            // chce utworzyc obiekt klasy OpenFileDialog ktory umozliwia mi wybor recznie
            // przez systemowe okienko pliku

            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
            };

            // OpenFileDialog moge otworzyc koszystajac z metody ShowDialog()
            // ZABLOKUJE ona nam kod w linii 34 i nie pusci dalej az nie zamkne okna/ wybiore plik
            // UWAGA: ShowDialog zwrac wartosc typu DialogResult
            DialogResult dialogResult = openFileDialog.ShowDialog();

            // DialogResult.OK oznacza ze ktos zamknal ten dialog i mamy wybrany plik!
            if (dialogResult == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;

                //MessageBox.Show(FilePath, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // mam juz filePath wiec wyciagam textbox
                var textBox = Controls.Find("textBox1", true)
                    .FirstOrDefault() as TextBox;

                textBox.Text = FilePath;
            }
            else
            {
                //var errorWindows = new ErrorWindow("YOU NEED TO SELECT A FILE!!!");
                //errorWindows.ShowDialog();


                // jbc sa wbudowane okienka do wiadomosci i np mozna tak:
                ShowError();
            }
        }
    }
}
