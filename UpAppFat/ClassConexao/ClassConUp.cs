using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UpAppFat.ClassConexao
{
    class ClassConUp
    {
        public static SQLiteConnection ConUp()
        {
            string strCon = @"Data Source=C:\django\django-appfat\django-AppFat\appfat\dbup.sqlite3; Version = 3;";
            SQLiteConnection con = new SQLiteConnection(strCon);

            try
            {
                con.Open();
            }
            catch (Exception)
            {

            }
            return con;
        }
    }
}
