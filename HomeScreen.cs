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
            Form seanslar = new AddSeans();
            seanslar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form yiyecek = new AddFood();
            yiyecek.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form salonlar = new AddSalon();
            salonlar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form personel = new AddPersonel();
            personel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form seanslar = new AddSeans();
            seanslar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form yiyecek = new AddFood();
            yiyecek.Show();
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
