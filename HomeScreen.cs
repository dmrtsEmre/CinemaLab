using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            Form  yiyecek = new AddFood();
            yiyecek.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form salonlar= new AddSalon();
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
    }
}
