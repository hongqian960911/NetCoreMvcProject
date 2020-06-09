using NetCoreMvcPeoject.Data;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace IC.DataAccess
{
    public class RunSQL
    {
        private MySqlConnection connection;
        private MySqlTransaction myTrans;

        public RunSQL(MySqlConnection conn, MySqlTransaction trans)
        {
            connection = conn;
            myTrans = trans;
        }

        public int RunSQLUpdate(string sSqlUpdate)
        {
            try
            {
                int execRowCount;
                MySqlCommand command = new MySqlCommand(sSqlUpdate, connection);
                command.CommandType = CommandType.Text;
                if (myTrans != null)
                    command.Transaction = myTrans;
                execRowCount = command.ExecuteNonQuery();
                if (execRowCount < 1)
                    throw new Exception(sSqlUpdate);
                return execRowCount;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            { }
        }

        public int RunSQLUpdate(string sSqlUpdate, MySqlParameter[] parameters)
        {
            try
            {
                int execRowCount;
                MySqlCommand command = new MySqlCommand(sSqlUpdate, connection);
                command.CommandType = CommandType.Text;
                if (myTrans != null)
                    command.Transaction = myTrans;
                if (parameters != null)
                {
                    foreach (MySqlParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                }

                execRowCount = command.ExecuteNonQuery();
                if (execRowCount < 1)
                    throw new Exception(sSqlUpdate);
                return execRowCount;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            { }
        }

        public DataTable Query_SQL(string statement)
        {
            //函数说明，一般用于执行 SELECT 查询
            //以事务的方式执行指定的SQL语句，执行完成后，返回数据集（DATATABLE）。
            MySqlCommand command = new MySqlCommand (statement, connection);
            DataSet dataSet = new DataSet();
            if (myTrans != null)
            {
                command.Transaction = myTrans;
            }
            MySqlDataAdapter dt = new MySqlDataAdapter(command);
            try
            {
                dt.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static DataTable GetTable(string sql)
        {
            DataTable dt = null;
            string conStr = DBContext.GetConfig("ConnectionStrings:DefaultConnection");
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                trans.Commit();
                conn.Close();
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
            }
            return dt;
        }

        public static DataTable GetTable2(string sql)
        {
            DataTable dt = null;
            string conStr = DBContext.GetConfig("ConnectionStrings:DefaultConnection");
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                trans.Commit();
                conn.Close();
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
            }
            return dt;
        }

        public static DataTable GetTable3(string sql)
        {
            DataTable dt = null;
            string conStr = DBContext.GetConfig("ConnectionStrings:DefaultConnection");
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                trans.Commit();
                conn.Close();
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
            }
            return dt;
        }

        public static DataTable GetTable4(string sql)
        {
            DataTable dt = null;
            string conStr = DBContext.GetConfig("ConnectionStrings:DefaultConnection");
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                trans.Commit();
                conn.Close();
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
            }
            return dt;
        }

        public static DataTable GetTableV(string sql, string conStr)
        {
            DataTable dt = null;
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                trans.Commit();
                conn.Close();
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
            }
            return dt;
        }


        public DataTable Query_SQL_PARAMETERS(string statement, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(statement,connection);
            command.CommandType = CommandType.Text;
            if(myTrans!=null)
            {
                command.Transaction = myTrans;
            }
            DataSet dataSet = new DataSet();
            MySqlDataAdapter dt = new MySqlDataAdapter(command);

            if(parameters!=null)
            {
                foreach(MySqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                dt.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (MySqlException e)
            {
                Console.Write(e);
                return null; }
            finally
            {}
        }

        public void Update_SQL(string statement)
        {
            //函数说明，一般用于执行 Update,Insert,Delete
            //以事务的方式执行指定的SQL语句，执行完成后，不返回任何结果。
            MySqlCommand command = new MySqlCommand(statement, connection);
            try
            {
                if (myTrans != null)
                {
                    command.Transaction = myTrans;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Update_SQLQuery(string statement)
        {
            //函数说明，一般用于执行 Update,Insert,Delete,并要求返回执行情况
            //以事务的方式执行指定的SQL语句，执行完成后，返回影响的行数
            //一般>0表示操作没有问题，如果为0则表示影响的行数为0，如果为-1则表示数据操作被回滚
            MySqlCommand command = new MySqlCommand(statement, connection);
            try
            {
                if (myTrans != null)
                {
                    command.Transaction = myTrans;
                    return command.ExecuteNonQuery();
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
