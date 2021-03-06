using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CinemaLab
{
    public partial class AddFilm : Form
    {
        public AddFilm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Film İsmi Boş Olamaz ");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Film Url Boş Olamaz");
            }
            else
            {
                SqlConnection conn = new SqlConnection(Config.connection_string);
                conn.Open();

                SqlCommand insert = new SqlCommand("INSERT INTO film (filAdi) VALUES(@filmAdi)", conn);

                insert.Parameters.AddWithValue("@filmAdi", textBox1.Text + "=" + textBox2.Text);
                int result = insert.ExecuteNonQuery();

                conn.Close();

                if (result < 0)
                {
                    MessageBox.Show("Film Eklenirken Hata Oluştu", "Hata");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Film Eklendi", "Bilgi");
                    this.Close();
                }
            }
        }

        private void AddFilm_Load(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();
            SqlCommand seans_cmd = new SqlCommand("SELECT * FROM film", conn);
            SqlDataReader seans_reader = seans_cmd.ExecuteReader();
            while (seans_reader.Read())
            {
                dataGridView1.Rows.Add(
                        seans_reader.GetString("filAdi").Split("=")[0],
                        seans_reader.GetString("filAdi").Split("=")[1]
                    );
            }
            conn.Close();
        }

        private void AddFilm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.mainForm.Show();
        }
    }
}
