using CinemaLab.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CinemaLab
{

    //Global i�leme de�i�kenleri
    class Config
    {
        //Milisaniye cinsinden splashScreen'in ekranda kalma s�resi. Debug ederken bunu d���rebilirsiniz 3s = 3000ms
        public static int splashScreenTimeout = 1500;

        //Altda belirtilen veriler ile otomatik giriş yap
        public static bool autoLogin = false;

        //0 Admin, 1: Personel
        public static int account_type = 0;
        public static int account_id = 0;

        public static string account_mail = "ahmet@admin.com";
        public static string account_pass= "1234";

        //Database url
        public static string connection_string = "Data Source=localhost\\SQLEXPRESS;Database=CinemaLab;Integrated Security=SSPI";
        public static Form koltukForm = new KoltukEkranı();

        public static Form mainForm;
    }

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new splashScreen());
        }
    }
}
