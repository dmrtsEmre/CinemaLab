using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace CinemaLab
{
    public partial class AddPersonel : Form
    {
        public AddPersonel()
        {
            InitializeComponent();
        }

        private void AddPersonel_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM personel", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString("personelMail").ToString(), reader.GetString("personelSifre").ToString(), reader.GetInt32("personelTip") == 0 ? "Admin" : "Kasiyer");
            }
            reader.Close();
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Mail boş olamaz");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("şifre boş olamaz");
            }
            else
            {
                int account_type = 1;
                if (radioButton1.Checked)
                {
                    account_type = 0;
                }
                SqlConnection conn = new SqlConnection(Config.connection_string);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from personel where  personelMail = '" + textBox2.Text+"'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Aynı personel girişi mevcut.", "Hata");
                }
                else
                {
                    if (!reader.HasRows)
                    {
                        reader.Close();


                        SqlCommand insert = new SqlCommand("INSERT INTO personel ( personelTip, personelSifre, personelMail) VALUES( @personelTip, @personelSifre, @personelMail)", conn);
                        insert.Parameters.AddWithValue("@personelMail",textBox2.Text);
                        insert.Parameters.AddWithValue("@personelSifre", textBox1.Text);
                        int HesapTipi = 1;
                        if (radioButton1.Checked)
                        {
                            HesapTipi = 0;
                        }
                        insert.Parameters.AddWithValue("@personelTip", HesapTipi);
                        int result = insert.ExecuteNonQuery();

                        if (result < 0)
                        {
                            MessageBox.Show("Personel türü yanlış bir hata oluştu.", "Hata");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("personel eklendi", "Bilgi");
                            this.Close();

                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("personel Bilgisi Okunamadı", "Hata");
                    }

                }
                conn.Close();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



















