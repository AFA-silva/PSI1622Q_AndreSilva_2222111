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
    public partial class EmployeePage : Form
    {
        public int EmployeeClose { get; set; }
        public EmployeePage()
        {
            EmployeeClose = 1;
            InitializeComponent();
        }
    }
}
