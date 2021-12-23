using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CinemaLab
{
    public partial class AddFood : Form
    {
        public AddFood()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            

            if (textBox1.Text == "")
            {
                MessageBox.Show("Menü İsmi Boş Olamaz ");
            }else if(textBox2.Text == "")
            {
                MessageBox.Show("Menü Fiyatı Boş Olamaz");
            }else if(!int.TryParse(textBox2.Text, out int yiyecekFiyati))
            {
                MessageBox.Show("Menü Fiyatı Sadece Rakamdan Oluşmaktadır");
            }
            else
            {
                SqlConnection conn = new SqlConnection(Config.connection_string);
                conn.Open();

                SqlCommand insert = new SqlCommand("INSERT INTO yiyecek (yiyecekAdi, yiyecekFiyati) VALUES(@yiyecekAdi, @yiyecekFiyati)", conn);

                insert.Parameters.AddWithValue("@yiyecekAdi", textBox1.Text);
                insert.Parameters.AddWithValue("@yiyecekFiyati", yiyecekFiyati);
                int result = insert.ExecuteNonQuery();

                conn.Close();

                if(result < 0)
                {
                    MessageBox.Show("Eklenirken Hata Oluştu", "Hata");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Yemek Eklendi", "Bilgi");
                    this.Close();
                }
            }

            
        }
    }
}
