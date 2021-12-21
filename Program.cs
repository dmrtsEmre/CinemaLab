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
        public static int splashScreenTimeout = 3000;

        //Login sayfas�n� yapan ki�i login ba�ar�l� olunca bunu de�i�tirmeli
        //0 Admin, 1: Personel
        //Login sayfas�n� bekleyene kadar bu iki variable ayn� kals�n
        public static int account_type = 0;

        //Login sayfas�n� yapan ki�i login ba�ar�l� olunca bunu de�i�tirmeli
        public static string account_mail = "admin@admin.com";

        //Database url
        public static string connection_string = "Data Source=" + Resources.ResourceManager.GetString("ServerName") + "\\SQLEXPRESS; Initial Catalog=DataBase; Integrated Security=True";
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
