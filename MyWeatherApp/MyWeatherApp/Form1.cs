using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace MyWeatherApp
{
    public partial class Form1 : Form
    {
        string ApiKey = "7f8795f59ef60a8a7c0fba17702b59fd";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        void getWeather()
        {
            using(WebClient wc = new WebClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={textBox1.Text}&appid={ApiKey}";
                var json = wc.DownloadString(url);
                WeatherInfo.root Info=JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                label10.
                
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
