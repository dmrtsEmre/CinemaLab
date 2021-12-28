using System;
using System.Windows.Forms;

namespace CinemaLab
{
    public partial class KoltukEkranı : Form
    {
        public KoltukEkranı()
        {
            InitializeComponent();
        }

        private void KoltukEkranı_Load(object sender, EventArgs e)
        {
            label1.Width = this.Width;
            label1.Left = 0;
            label1.Top = this.Height / 10;
            tableLayoutPanel1.Width = this.Width / 2;
            tableLayoutPanel1.Height = this.Height / 2;
            tableLayoutPanel1.Left = (this.Width / 2) - (tableLayoutPanel1.Width / 2);
            tableLayoutPanel1.Top = (this.Height / 2) - (tableLayoutPanel1.Height / 2);
            pictureBox1.Left = (this.Width / 2) - (pictureBox1.Width / 2);
            pictureBox1.Top = tableLayoutPanel1.Top + (tableLayoutPanel1.Height) + 20;
        }
    }
}
