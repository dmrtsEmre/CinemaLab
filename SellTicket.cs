using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CinemaLab
{
    public partial class SellTicket : Form
    {

        bool bitti = false;
        int secilenKoltuk = -1;
        List<Seans> seanslar = new List<Seans>();
        List<(int, int, int)> seciliMenuler = new List<(int, int, int)>(); //MenuId, adet, Fiyat


        public SellTicket()
        {
            InitializeComponent();
        }

        private void koltukSec(object sender, System.EventArgs e)
        {
            Button koltukButon = (Button)sender;
            secilenKoltuk = int.Parse(koltukButon.Name.Split("button")[1]);
            calcFiyat(comboBox3.SelectedIndex);
        }

        private void calcFiyat(int selected_seans)
        {
            int menuToplam = seciliMenuler.Aggregate(0, (acc, x) => acc + (x.Item3));
            Seans aktifSeans = seanslar[selected_seans];
            button21.Text = "Ödeme: " + (aktifSeans.fiyat + menuToplam) + "tl";
            for (int i = 1; i < 21; i++)
            {
                Button koltukButon = (Button)this.Controls.Find("button" + i.ToString(), true)[0];
                if (i == secilenKoltuk)
                {
                    koltukButon.BackColor = Color.FromArgb(100, 0, 200, 0);
                }
                else if (aktifSeans.alinanKoltuklar.Contains(i))
                {
                    koltukButon.BackColor = Color.FromArgb(100, 255, 0, 0);
                    koltukButon.Enabled = false;
                }
                else
                {
                    koltukButon.Enabled = true;
                    koltukButon.BackColor = Color.FromArgb(100, 6, 38, 57);
                }
            }
        }


        private void update_menu_item(object sender, DataGridViewCellEventArgs e)
        {
            seciliMenuler = new List<(int, int, int)>();
            for (int i = 1; i < (dataGridView1.Rows.Count - 1); i++)
            {
                int adet = int.Parse(dataGridView1.Rows[i - 1]
             .Cells["adet"].Value.ToString());

                if (adet != 0)
                {
                    int fiyat = int.Parse(dataGridView1.Rows[i - 1]
           .Cells["menuFiyat"].Value.ToString().Split("tl")[0]);
                    int yiyecekId = int.Parse(dataGridView1.Rows[i - 1]
           .Cells["menuAd"].Value.ToString());

                    int toplam = adet * fiyat;
                    seciliMenuler.Add((yiyecekId, adet, toplam));
                }
            }
            calcFiyat(comboBox3.SelectedIndex);
        }

        private void SellTicket_Load(object sender, System.EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            SqlConnection conn = new SqlConnection(Config.connection_string);
            conn.Open();

            SqlCommand yiyecek_cmd = new SqlCommand("SELECT * FROM yiyecek", conn);
            SqlDataReader yiyecek_reader = yiyecek_cmd.ExecuteReader();
            while (yiyecek_reader.Read())
            {
                dataGridView1.Rows.Add(yiyecek_reader.GetInt32("yiyecekId").ToString(), yiyecek_reader.GetString("yiyecekAdi"), yiyecek_reader.GetString("yiyecekFiyati") + "tl", 0);
            }
            yiyecek_reader.Close();

            dataGridView1.CellValueChanged += update_menu_item;

            SqlCommand seans_cmd = new SqlCommand("SELECT * FROM seans INNER JOIN film ON film.filmId = seans.filmId", conn);
            SqlDataReader seans_reader = seans_cmd.ExecuteReader();
            while (seans_reader.Read())
            {
                int seans_id = seans_reader.GetInt32("seansId");
                Seans seans = new Seans
                {
                    seansId = seans_id,
                    seansSalonu = seans_reader.GetInt32("seansSalonu"),
                    filmId = seans_reader.GetInt32("filmId"),
                    fiyat = seans_reader.GetInt32("fiyat"),
                    alinanKoltuklar = new List<int>()
                };

                seanslar.Add(seans);
                comboBox3.Items.Add("Seans: " + seans_id + " : " + seans_reader.GetString("filAdi").Split("=")[0]);
            }
            seans_reader.Close();

            comboBox3.SelectedIndex = 0;
            comboBox3.SelectedText = "Seans: " + (seanslar[0].seansId.ToString());

            foreach (Seans seans in seanslar)
            {
                List<int> koltuk = new List<int>();
                SqlCommand bilet_cmd = new SqlCommand("SELECT * FROM bilet WHERE seansId = " + seans.seansId, conn);
                SqlDataReader bilet_reader = bilet_cmd.ExecuteReader();
                while (bilet_reader.Read())
                {
                    koltuk.Add(bilet_reader.GetInt32("koltukNumarası"));
                }
                seans.alinanKoltuklar = koltuk;
                bilet_reader.Close();
            }
            calcFiyat(0);
            conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            calcFiyat(comboBox3.SelectedIndex);
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void button21_Click(object sender, System.EventArgs e)
        {


            if (secilenKoltuk == -1)
            {
                MessageBox.Show("Lütfen bir koltuk seçiniz", "Hata");
            }
            else
            {
                SqlConnection conn = new SqlConnection(Config.connection_string);
                conn.Open();


                SqlCommand insert = new SqlCommand("INSERT INTO bilet(biletiKesen, seansId, odemeYontemi, koltukNumarası) output INSERTED.biletId VALUES (@biletiKesen, @seansId, @odemeYontemi, @koltukNumarası)", conn);

                var seans_id = (string)comboBox3.SelectedItem;
                insert.Parameters.AddWithValue("@biletiKesen", Config.account_id);
                insert.Parameters.AddWithValue("@seansId", int.Parse(seans_id.Split(":")[1]));
                insert.Parameters.AddWithValue("@odemeYontemi", comboBox1.SelectedIndex);
                insert.Parameters.AddWithValue("@koltukNumarası", secilenKoltuk);
                int biletId = (int)insert.ExecuteScalar();


                //Varsa Yemekleri ekle
                if (seciliMenuler.Count != 0)
                {
                    //Alınan tüm menüleri döngüye al
                    foreach ((int, int, int) menu in seciliMenuler)
                    {
                        //Alınan miktar kadar fatura kes
                        for (int i = 0; i < menu.Item2; i++)
                        {
                            SqlCommand menuCmd = new SqlCommand("INSERT INTO yiyecekFatura(alinanYiyecekId, biletId) VALUES (@alinanYiyecekId, @biletId)", conn);
                            menuCmd.Parameters.AddWithValue("@alinanYiyecekId", menu.Item1);
                            menuCmd.Parameters.AddWithValue("@biletId", biletId);
                            menuCmd.ExecuteNonQuery();
                        }
                    }
                }
                conn.Close();
                MessageBox.Show("Bilet Satışı Başarılı");
                this.Close();
            }
        }
    }
}
