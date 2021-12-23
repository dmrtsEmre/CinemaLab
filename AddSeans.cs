using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CinemaLab
{
    public partial class AddSeans : Form
    {
        public AddSeans()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
        }

        private void AddSeans_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();
            SqlCommand salon_cmd = new SqlCommand("SELECT * FROM salon", conn);
            SqlDataReader salon_reader = salon_cmd.ExecuteReader();

            while (salon_reader.Read())
            {
                int salon_id = salon_reader.GetInt32("salonId");
                if (salon_id == 0)
                {
                    comboBox1.Text = "Salon: 0";
                }
                comboBox1.Items.Add("Salon: " + salon_id.ToString());
            }
            comboBox1.SelectedIndex = 0;
            salon_reader.Close();
            SqlCommand film_cmd = new SqlCommand("SELECT * FROM film", conn);
            SqlDataReader film_reader = film_cmd.ExecuteReader();
            while (film_reader.Read())
            {
                comboBox2.Items.Add(film_reader.GetInt32("filmId") + ": " + film_reader.GetString("filAdi").Split("=")[0]);
            }
            comboBox2.SelectedIndex = 0;
            film_reader.Close();

            SqlCommand seans_cmd = new SqlCommand("SELECT * FROM seans INNER JOIN film ON film.filmId = seans.filmId", conn);
            SqlDataReader seans_reader = seans_cmd.ExecuteReader();
            while (seans_reader.Read())
            {
                listBox1.Items.Add("Seans Saati: " + seans_reader.GetDateTime("seansSaati").ToString("yyyy-MM-dd - HH:mm:ss") + " - Seans Dili: " + (seans_reader.GetInt32("seansDili") == 0 ? "Dublaj" : "Orijinal") + " - Film İsmi: " + seans_reader.GetString("filAdi").Split("=")[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();
            if (textBox2.Text == "")
            {
                MessageBox.Show("Ücret boş olamaz");
            }
            else if (!int.TryParse(textBox2.Text, out int ucret))
            {
                MessageBox.Show("Ücret sayı olmalı");
            }
            else
            {
                int.TryParse(comboBox1.Text.Split(":")[1].Trim(), out int salonId);
                int.TryParse(comboBox2.Text.Split(":")[0].Trim(), out int filmId);


                SqlCommand insert = new SqlCommand("INSERT INTO seans (seansSaati, seansDili, seansSalonu, filmId, seansiOlusturan, fiyat) VALUES (@seansSaati, @seansDili, @seansSalonu, @filmId, @seansiOlusturan, @fiyat)", conn);
                insert.Parameters.AddWithValue("@seansSaati", dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " +
dateTimePicker1.Value.ToString("HH:mm:ss"));
                insert.Parameters.AddWithValue("@seansDili", radioButton1.Checked ? 0 : 1);
                insert.Parameters.AddWithValue("@seansSalonu", salonId);
                insert.Parameters.AddWithValue("@filmId", filmId);
                insert.Parameters.AddWithValue("@seansiOlusturan", Config.account_id);
                insert.Parameters.AddWithValue("@fiyat", textBox2.Text);
                int result = insert.ExecuteNonQuery();
                conn.Close();
                
                if (result < 0)
                {
                    MessageBox.Show("Seans eklemesi başarısız");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seans eklendi");
                    this.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
