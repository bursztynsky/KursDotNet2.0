namespace _12_WindowsForms
{
    public partial class Form1 : Form
    {
        public int howManyClicks { get; set; } = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void clickMeButton_Click(object sender, EventArgs e)
        {
            var label = Controls.Find("clickMeLabel", true).FirstOrDefault() as Label;

            howManyClicks++;

            label.Text = "Clicked: " + howManyClicks;
        }
    }
}