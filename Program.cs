using CinemaLab.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CinemaLab
{

    //Global iþleme deðiþkenleri
    class Config
    {
        //Milisaniye cinsinden splashScreen'in ekranda kalma süresi. Debug ederken bunu düþürebilirsiniz 3s = 3000ms
        public static int splashScreenTimeout = 3000;

        //Login sayfasýný yapan kiþi login baþarýlý olunca bunu deðiþtirmeli
        //0 Admin, 1: Personel
        //Login sayfasýný bekleyene kadar bu iki variable ayný kalsýn
        public static int account_type = 0;

        //Login sayfasýný yapan kiþi login baþarýlý olunca bunu deðiþtirmeli
        public static string account_mail = "admin@admin.com";

        //Database url
        public static string connection_string = "Data Source=" + Resources.ResourceManager.GetString("ServerName") + "SQLEXPRESS; Initial Catalog=DataBase; Integrated Security=True";
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
