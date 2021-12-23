using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace CinemaLab
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Mail Boş Olamaz");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Şifre Boş Olamaz");
            }
            else
            {
                SqlConnection conn = new SqlConnection(Config.connection_string);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from personel where  personelMail = '" + textBox1.Text + "'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetString("personelSifre")==textBox2.Text)
                    {
                        Config.account_type = reader.GetInt32("personelTip");
                        Config.account_id = reader.GetInt32("personelId");
                        Config.account_mail = reader.GetString("personelMail");

                        Application.Run(new HomeScreen());

                    }
                    else
                    {
                        MessageBox.Show("Şifre yanlıştır.");
                    }

                    MessageBox.Show("Mail mevcut", "Hata");
                }
                else
                {
                    MessageBox.Show("Böyle Bir Hesap Bulunmamaktadır.");
                }
                
            }

        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {

        }
    }
}
