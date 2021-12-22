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
                comboBox1.Items.Add("Salon: " + salon_id.ToString());
            }
            comboBox1.SelectedIndex = 0;
            salon_reader.Close();
            SqlCommand film_cmd = new SqlCommand("SELECT * FROM film", conn);
            SqlDataReader film_reader = film_cmd.ExecuteReader();
            while (film_reader.Read())
            {

                comboBox2.Items.Add(film_reader.GetString("filAdi"));
            }
            comboBox2.SelectedIndex = 0;
            film_reader.Close();

            /*
            SqlCommand seans_cmd = new SqlCommand("SELECT * FROM seans ", conn);
            SqlDataReader seans_reader = seans_cmd.ExecuteReader();
            comboBox2.SelectedIndex = 0;
            while (seans_reader.Read())
            {
                string value = "Salon Numarası: " + seans_reader.GetInt32("salonId").ToString() + " Salon Kapasitesi: " + seans_reader.GetInt32("koltukSayisi").ToString();
                listBox1.Items.Add(value);
            }
            seans_reader.Close();
            */
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();
            SqlCommand insert = new SqlCommand("INSERT INTO seans (seansSaati, seansDili, seansSalonu, filmId, seansiOlusturan, fiyat) VALUES (@salonId, @koltukSayisi, @salonTuru)", conn);
            //insert.Parameters.AddWithValue("@salonId", salonId);
            //insert.Parameters.AddWithValue("@salonId", salonId);
            //insert.Parameters.AddWithValue("@salonId", salonId);
            //insert.Parameters.AddWithValue("@salonId", salonId);


        }
    }
}
