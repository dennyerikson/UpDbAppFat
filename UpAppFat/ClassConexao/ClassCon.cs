using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UpAppFat.ClassConexao
{
    class ClassCon 
    {
        public static SQLiteConnection ConOpen()
        {
            
            string strCon = @"Data Source=C:\django\django-appfat\django-AppFat\appfat\db.sqlite3; Version = 3;";

            SQLiteConnection con = new SQLiteConnection(strCon);

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERRO CONEXÃO: " + ex);
            }
           


            return con;
        }

    }
}
