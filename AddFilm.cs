using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

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
    }
}
