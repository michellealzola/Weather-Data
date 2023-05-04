using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather_Data
{
    struct Weather
    {
        public DateTime date;
        public int precipitation;
        public int highTemp;
        public int lowTemp;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
    }
}
