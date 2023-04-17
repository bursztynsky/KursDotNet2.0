using _13_WindowsForms.Models;
using System.Text;

namespace _13_WindowsForms
{
    public partial class MainWindow : Form
    {
        private readonly DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();

            _dataService = new DataService();

            InitDataView();
        }

        public void LoadData(string filePath)
        {
            _dataService.GetCarsFromFile(filePath);

            ResetDataView();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            var filePathWindow = new FilePathWindow(this);

            //filePathWindows.Show(); // otwiera okno I NIE BLOKUE OKNA-MATKI wiec mozesz utworzyc miliard tych okienek
            filePathWindow.ShowDialog(); // blokuje okno matka wiec nie moge klikac juz w poprzednie okno
            // poki nie zamkne tego

            var filePath = filePathWindow.FilePath;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }
        }

        private void InitDataView()
        {
            _dataService.InitData();

            ResetDataView();
        }

        private void ResetDataView()
        {
            var dataView = Controls
                .Find("dataView", true)
                .FirstOrDefault()
                as DataGridView;

            dataView.Rows.Clear();

            foreach (var car in _dataService.Cars)
            {
                var newRowId = dataView.Rows.Add();
                var newRow = dataView.Rows[newRowId];

                newRow.Cells["CarName"].Value = car.Name;
                newRow.Cells["CarModel"].Value = car.Model;
                newRow.Cells["CarYear"].Value = car.Year;
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dataService.SaveCarsToFile();
        }
    }
}