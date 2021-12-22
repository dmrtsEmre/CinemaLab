using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CinemaLab
{
    public partial class AddSalon : Form
    {
        public AddSalon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var isNumeric = int.TryParse(textBox1.Text, out int salonId);
            //TextBox'dan gelen text int mi diye kontrol et
            if (isNumeric)
            {
                SqlConnection conn = new SqlConnection(Config.connection_string);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM salon WHERE salonId = " + textBox1.Text, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Aynı numarada bir salon zaten mevcut.", "Hata");
                }
                else
                {
                    if (!reader.HasRows)
                    {
                        //Başka bir komut çalıştırmadan önce satır 25'de olan komutu kapat
                        reader.Close();

                        SqlCommand identity = new SqlCommand("SET IDENTITY_INSERT salon ON;", conn);
                        identity.ExecuteNonQuery();

                        SqlCommand insert = new SqlCommand("INSERT INTO salon (salonId, koltukSayisi, salonTuru) VALUES (@salonId, @koltukSayisi, @salonTuru)", conn);
                        insert.Parameters.AddWithValue("@salonId", salonId);
                        insert.Parameters.AddWithValue("@koltukSayisi", 20);                       
                        int salonTuru = 1;
                        if (radioButton1.Checked)
                        {
                            salonTuru = 0;
                        }
                        insert.Parameters.AddWithValue("@salonTuru", salonTuru);
                        int result = insert.ExecuteNonQuery();

                        if (result < 0)
                        {
                            MessageBox.Show("Salon eklenirken bir hata oluştu", "Hata");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Salon eklendi", "Bilgi");
                            this.Close();
                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Salon Bilgisi Okunamadı", "Hata");
                    }
                }
                
                conn.Close();
            }
            else
            {
                MessageBox.Show("Verilen sinema salonu numarası bir rakam değil.", "Hata");
            }


        }

        private void AddSalon_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM salon", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string value = "Salon Numarası: " + reader.GetInt32("salonId").ToString() + " Salon Kapasitesi: " + reader.GetInt32("koltukSayisi").ToString() + " Salon Tipi: " + (reader.GetInt32("salonTuru") == 0 ? "3D" : "2D");
                listBox2.Items.Add(value);
            }
            reader.Close();
            conn.Close();
        }
    }
}
