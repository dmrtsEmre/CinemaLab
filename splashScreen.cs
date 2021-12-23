using CinemaLab.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaLab
{
    public partial class splashScreen : Form
    {

        public splashScreen()
        {
            InitializeComponent();
        }

        private async void splashScreen_Load(object sender, EventArgs e)
        {
            //Program.cs'deki 'splashScreenTimeout' süresi kadar bekle ve HomeScreen'i aç
            await Task.Delay(Config.splashScreenTimeout);
            Form main = new GirisEkrani();
            main.Show();
            this.Hide();
        }        
    }
}