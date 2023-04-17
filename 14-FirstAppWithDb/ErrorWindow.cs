using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_FirstAppWithDb
{
    public partial class ErrorWindow : Form
    {
        public ErrorWindow(string message)
        {
            InitializeComponent();
            var label = Controls
                .Find("label1", true)
                .FirstOrDefault() as Label;

            label.Text = message;
        }
    }
}
