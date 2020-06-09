using MySql.Data.MySqlClient;
using System.Data.OleDb;

namespace IC.Common
{
    public class DataUtil
    {
        protected MySqlConnection connection = null;
        protected MySqlTransaction myTrans = null;

        public DataUtil(MySqlConnection conn, MySqlTransaction tran)
        {
            connection = conn;
            myTrans = tran;
        }
    }
}
