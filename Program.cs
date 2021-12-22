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
        public static int splashScreenTimeout = 500;

        //Login sayfasını yapan kişi login başarılı olunca bunu değiştirmeli
        //0 Admin, 1: Personel
        //Login sayfasını bekleyene kadar bu üçvariable aynı kalsın
        public static int account_type = 0;

        //[PersonelPrimaryKey] Login sayfasını yapan kişi login başarılı olunca bunu değiştirmeli
        public static int account_id = 0;

        //Login sayfasını yapan kişi login başarılı olunca bunu değiştirmeli
        public static string account_mail = "admin@admin.com";

        //Database url
        public static string connection_string = "Data Source=localhost;Database=CinemaLab;Integrated Security=SSPI";
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
