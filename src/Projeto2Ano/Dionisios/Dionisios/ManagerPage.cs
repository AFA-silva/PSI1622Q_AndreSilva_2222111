using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dionisios
{
    public partial class ManagerPage : Form
    {
        public int Managerclose { get; set; }
        public ManagerPage()
        {
            Managerclose = 1;
            InitializeComponent();
        }

        private void StockBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
