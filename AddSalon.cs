using CinemaLab.Properties;
using System;
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
            SqlConnection conn = new SqlConnection(Config.connection_string);
            string queryString = "SELECT OrderID, CustomerID FROM dbo.Orders;";
            MessageBox.Show("Connection Open  !");
            conn.Close();
        }
    }
}
