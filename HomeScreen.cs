using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaLab
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Config.account_type == 0)
            {
                Form seanslar = new AddSeans();
                this.Hide();
                seanslar.Show();
            }
            else
            {
                MessageBox.Show("Bu İşlem İçin Yetkiniz Bulunmamaktadır.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Config.account_type == 0)
            {
                Form yiyecek = new AddFood();
                this.Hide();
                yiyecek.Show();
            }
            else
            {
                MessageBox.Show("Bu İşlem İçin Yetkiniz Bulunmamaktadır.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Config.account_type == 0)
            {
                Form salonlar = new AddSalon();
                this.Hide();
                salonlar.Show();
            }
            else
            {
                MessageBox.Show("Bu İşlem İçin Yetkiniz Bulunmamaktadır.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Config.account_type == 0)
            {
                Form personel = new AddPersonel();
                this.Hide();
                personel.Show();
            }
            else
            {
                MessageBox.Show("Bu İşlem İçin Yetkiniz Bulunmamaktadır.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form bilet = new SellTicket();
            this.Hide();
            bilet.Show();
        }

        List<AnaSeans> seanslar = new List<AnaSeans>();
        int goruntuluSeans = 0;

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            Config.mainForm = this;
            Config.koltukForm.Show();
            label5.Text = Config.account_mail;
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();
            SqlCommand seans_cmd = new SqlCommand("SELECT * FROM seans INNER JOIN film ON film.filmId = seans.filmId", conn);
            SqlDataReader seans_reader = seans_cmd.ExecuteReader();
            while (seans_reader.Read())
            {
                AnaSeans seans = new AnaSeans
                {
                    kapakUrl = seans_reader.GetString("filAdi").Split("=")[1],
                    seansSalonu = seans_reader.GetInt32("seansSalonu"),
                    filmIsim = seans_reader.GetString("filAdi").Split("=")[0],
                    seansDili = seans_reader.GetInt32("seansDili"),
                    seansTarihi = seans_reader.GetDateTime("seansSaati")
                };
                seanslar.Add(seans);
            }

            //await Task.Run(Config.splashScreenTimeout);

            conn.Close();
            seansDeğiştir();
        }

        async void seansDeğiştir()
        {
            AnaSeans seans = seanslar[goruntuluSeans];
            seansFoto.LoadAsync(seans.kapakUrl);
            filmAdi.Text = seans.filmIsim;
            salon.Text = "Salon: " + seans.seansSalonu + " - " + (seans.seansDili == 0 ? "Orijinal" : "Dublaj");
            date.Text = seans.seansTarihi.ToString("yyyy-MM-dd - HH:mm:ss");
            if (goruntuluSeans == (seanslar.Count - 1))
            {
                goruntuluSeans = 0;
            }
            else
            {
                goruntuluSeans++;
            }
            await Task.Delay(5000);
            seansDeğiştir();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (Config.account_type == 0)
            {
                Form film = new AddFilm();
                this.Hide();
                film.Show();
            }
            else
            {
                MessageBox.Show("Bu İşlem İçin Yetkiniz Bulunmamaktadır.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Config.koltukForm.Visible)
            {
                Config.koltukForm.Hide();
            }
            else
            {
                Config.koltukForm.Show();
            }
        }

        private void HomeScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
