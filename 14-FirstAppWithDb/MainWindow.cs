using _14_FirstAppWithDb.Models;
using System.Text;
using System.Windows.Forms;

namespace _14_FirstAppWithDb
{
    public partial class MainWindow : Form
    {
        private readonly DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();

            _dataService = new DataService();

            _dataService.LoadDataFromDb();

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

                newRow.Cells["CarId"].Value = car.Id;
                newRow.Cells["CarName"].Value = car.Name;
                newRow.Cells["CarModel"].Value = car.Model;
                newRow.Cells["CarYear"].Value = car.Year;
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var dataView = Controls
                .Find("dataView", true)
                .FirstOrDefault()
            as DataGridView;

            if (dataView.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataView.SelectedRows[0];

                var selectedCar = _dataService.GetCarFromRow(row);

                MessageBox.Show(selectedCar.Name + " " + selectedCar.Model);
            }
        }
    }
}