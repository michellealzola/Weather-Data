using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather_Data
{
    struct Weather
    {
        public DateTime date;
        public double precipitation;
        public int highTemp;
        public int lowTemp;
    }
    public partial class Form1 : Form
    {
        private List<string> rawData;
        public Form1()
        {
            InitializeComponent();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selected = dateTimePicker1.Value;
            DateTime dt;
            double precip;
            int highT;
            int lowT;

            try
            {
                rawData = new List<string>();
                StreamReader inputFile = File.OpenText("weather.txt");
                while(!inputFile.EndOfStream)
                {
                    rawData.Add(inputFile.ReadLine());
                }

                inputFile.Close();

                foreach (string line in rawData)
                {
                    char[] delim = { ';' };
                    string[] token = line.Trim().Split(delim);
                    Weather weather = new Weather();

                    if (DateTime.TryParse(token[0], out dt))
                    {
                       weather.date = dt;
                    }
                    else
                    {
                        weather.date = DateTime.MinValue;
                    }

                    if (double.TryParse(token[1], out precip))
                    {
                        weather.precipitation = precip;
                    }
                    else
                    {
                        weather.precipitation = 0;
                    }

                    if (int.TryParse(token[2], out highT))
                    {
                        weather.highTemp = highT;
                    }
                    else 
                    { 
                        weather.highTemp = 0;
                    }

                    if (int.TryParse(token[3], out lowT))
                    {
                        weather.lowTemp = lowT;
                    }
                    else
                    {
                        weather.lowTemp = 0;
                    }

                    if(weather.date == selected)
                    {
                        lblOutDate.Text = weather.date.ToString("D");
                        lblOutPrecipitation.Text = weather.precipitation.ToString();  
                        lblOutHighTemp.Text = weather.highTemp.ToString();
                        lblOutLowTemp.Text = weather.lowTemp.ToString();  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
