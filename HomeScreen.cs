using System;
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

            if(Config.account_type == 0)
            {
                Form seanslar = new AddSeans();
                seanslar.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Config.account_type == 0)
            {
                Form yiyecek = new AddFood();
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
                personel.Show();
            }
            else
            {
                MessageBox.Show("Bu İşlem İçin Yetkiniz Bulunmamaktadır.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form bilet = new SellTicket();
            bilet.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            label5.Text = Config.account_mail;
        }
    }
}
