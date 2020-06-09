using IC.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IC.DataAccess
{
    public class ShellConnection : DataUtil
	{
		public ShellConnection(MySqlConnection myCon, MySqlTransaction myTrans)
			: base(myCon, myTrans)
		{

		}

		private string[] targetColumns;

		//实行中的SQL的保持域
		private string executeSQLString;

		//再利用Flag
		protected bool isClosed;

		public DataTable execFindSQL(string sqlString)
		{
			executeSQLString = sqlString;
			RunSQL rs = new RunSQL(connection, myTrans);
			DataTable ds;
			try
			{
                //Console.Write(executeSQLString);
				ds = rs.Query_SQL(executeSQLString);
				return ds;
			}
			catch (Exception e)
			{
                //throw new MYEXCEPTION(e.Message + "： " + sqlString, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
		}

		public DataTable execFindSQL(string sqlString, MySqlParameter[] parameters)
		{
			executeSQLString = sqlString;
			RunSQL rs = new RunSQL(connection, myTrans);
			DataTable ds;
			try
			{
				ds = rs.Query_SQL_PARAMETERS(executeSQLString, parameters);
				return ds;
			}
			catch (Exception e)
			{
				//throw new MYEXCEPTION(e.Message + "： " + sqlString, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
		}

		public DataTable execFindSQL(SQLMsg sqlMsg)
		{
			try
			{
				return execFindSQL(formSelectSQLString(sqlMsg));
			}
            //catch (MYEXCEPTION mye)
            //{
            //    throw mye;
            //}
			catch (Exception e)
			{
				throw e;
			}
		}

		//根据SQLMSG生成select SQL
		public string formSelectSQLString(SQLMsg sqlMsg)
		{
			string SqlSb = "";
			string buffer;
			try
			{
				buffer = sqlMsg.getSelectExpression();
				SqlSb = SqlSb + " " + buffer;
				buffer = sqlMsg.getFromExpression();
				SqlSb = SqlSb + " " + buffer;
				buffer = sqlMsg.getWhereExpression();
				SqlSb = SqlSb + " " + buffer;
				buffer = sqlMsg.getForUpdateExpression();
				SqlSb = SqlSb + " " + buffer;
				buffer = sqlMsg.getGroupByExpression();
				SqlSb = SqlSb + " " + buffer;
				buffer = sqlMsg.getOrderByExpression();
				SqlSb = SqlSb + " " + buffer;
				targetColumns = sqlMsg.getColumns();
                //Console.Write(SqlSb);
				return SqlSb;
			}
			catch (Exception e)
			{
                //throw new MYEXCEPTION(e.Message + "： " + SqlSb, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
			finally
			{ }
		}

		//执行SQL
		public int execSQL(string sqlString)
		{
			int execRowCount = 0;
			MySqlCommand command = new MySqlCommand(sqlString, connection, myTrans);

			try
			{
				execRowCount = command.ExecuteNonQuery();
				if (execRowCount < 1)
				{
					string failedMsg = "数据已被其他用户更改，请先刷新页面再尝试操作";
					failedMsg += "\r\n\r\n" + "调试信息:更新失败，影响行数为0" + "\r\n" + sqlString;
                    //throw new MYEXCEPTION(failedMsg, EXCEPTIONDEFINE.TYPE_ERROR);
                    throw new Exception(failedMsg);
				}
				return execRowCount;
			}
            //catch (MYEXCEPTION mye)
            //{
            //    throw mye;
            //}
			catch (Exception e)
			{
                throw e;
			}
			finally
			{ }
		}

		public int execSQL(string sqlString, MySqlParameter[] parameters)
		{
			int execRowCount = 0;
			RunSQL rs = new RunSQL(connection, myTrans);
			try
			{
				execRowCount = rs.RunSQLUpdate(sqlString, parameters);
				return execRowCount;
			}
			catch (Exception e)
			{
                //throw new MYEXCEPTION(e.Message + "： " + sqlString, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
		}

		//执行insert SQL 
		public int execCreateSQL(SQLMsg sqlMsg)
		{
			try
			{
				return execSQL(formCreateSQLString(sqlMsg));
			}
            //catch (MYEXCEPTION mye)
            //{
            //    throw mye;
            //}
			catch (Exception e)
			{
				throw e;
			}
		}

		//根据SQLMSG生成insert SQL
		public string formCreateSQLString(SQLMsg sqlMsg)
		{
			string sqlSb = "INSERT INTO ";
			string buffer;
			try
			{
				buffer = sqlMsg.getTableExpression();
				sqlSb = sqlSb + " " + buffer;
				buffer = sqlMsg.getColumnsExpression();
				sqlSb = sqlSb + " " + buffer;
				buffer = sqlMsg.getValuesExpression();
				sqlSb = sqlSb + " " + buffer;
				//Console.Write(sqlSb);
				return sqlSb;
			}
			catch (Exception e)
			{
                //throw new MYEXCEPTION(e.Message + "： " + sqlSb, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
			finally
			{ }
		}

		//执行update SQL 
		public int execUpdateSQL(SQLMsg sqlMsg)
		{
			try
			{
				return execSQL(formUpdateSQLString(sqlMsg));
			}
            //catch (MYEXCEPTION mye)
            //{
            //    throw mye;
            //}
			catch (Exception e)
			{
				throw e;
			}
		}

        //执行多条update SQL 
        public int execUpdateSQL(List<SQLMsg> list_sqlMsg)
        {
            try
            {
                return execSQL(formUpdateSQLString(list_sqlMsg));
            }
            //catch (MYEXCEPTION mye)
            //{
            //    throw mye;
            //}
            catch (Exception e)
            {
                throw e;
            }
        }

		//根据SQLMSG生成Update SQL
		public string formUpdateSQLString(SQLMsg sqlMsg)
		{
			string sqlSb = "UPDATE ";
			string buffer;
			try
			{
				buffer = sqlMsg.getTableExpression();
				if (buffer == null || buffer == "")
					throw new Exception("SQLMsg.tables not set.");
				sqlSb = sqlSb + " " + buffer;
				buffer = sqlMsg.getSetExpression();
				sqlSb = sqlSb + " " + buffer;
				buffer = sqlMsg.getWhereExpression();
				sqlSb = sqlSb + " " + buffer;
				//Console.Write(sqlSb);
				return sqlSb;
			}
			catch (Exception e)
			{
                //throw new MYEXCEPTION(e.Message + "： " + sqlSb, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
			finally
			{ }
		}

        //根据多个SQLMSG生成Update SQL
        public string formUpdateSQLString(List<SQLMsg> list_sqlMsg)
        {
            string sqlSb = "";
            try
            {
                foreach (SQLMsg sqlMsg in list_sqlMsg)
                {
                    string buffer;
                    buffer = sqlMsg.getTableExpression();
                    if (buffer == null || buffer == "")
                        throw new Exception("SQLMsg.tables not set.");
                    buffer = "UPDATE " + buffer;
                    sqlSb = sqlSb + " " + buffer;
                    buffer = sqlMsg.getSetExpression();
                    sqlSb = sqlSb + " " + buffer;
                    buffer = sqlMsg.getWhereExpression();
                    sqlSb = sqlSb + " " + buffer;
                    //Console.Write(sqlSb);
                }
                return sqlSb;

            }
            catch (Exception e)
            {
                //throw new MYEXCEPTION(e.Message + "： " + sqlSb, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
            }
            finally
            { }


        }

		//执行delete SQL 
		public int execRemoveSQL(SQLMsg sqlMsg)
		{
			try
			{
				return execSQL(formRemoveSQLString(sqlMsg));
			}
            //catch (MYEXCEPTION mye)
            //{
            //    throw mye;
            //}
			catch (Exception e)
			{
				throw e;
			}
		}
		//执行多条sql语句
		public int execRemoveSQL(List<SQLMsg> list_sqlMsg)
		{
			try
			{
				return execSQL(formRemoveSQLString(list_sqlMsg));
			}
            //catch (MYEXCEPTION mye)
            //{
            //    throw mye;
            //}
			catch (Exception e)
			{
				throw e;
			}

		}
		//根据SQLMSG生成delete SQL
		public string formRemoveSQLString(SQLMsg sqlMsg)
		{
			string sqlSb = "DELETE FROM ";
			string buffer;
			try
			{
				buffer = sqlMsg.getTableExpression();
				if (buffer == null || buffer == "")
					throw new Exception("SQLMsg.tables not set.");
				sqlSb = sqlSb + " " + buffer;
				buffer = sqlMsg.getWhereExpression();
				sqlSb = sqlSb + " " + buffer;
                //Console.Write(sqlSb);
				return sqlSb;
			}
			catch (Exception e)
			{
				//throw new MYEXCEPTION(e.Message + "： " + sqlSb, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
			finally
			{ }
		}
		//根据SQLMSG生成delete SQL
		public string formRemoveSQLString(List<SQLMsg> list_sqlMsg)
		{
			string sqlSb = "";
			try
			{
				foreach (SQLMsg sqlMsg in list_sqlMsg)
				{
					string buffer;
					buffer = sqlMsg.getTableExpression();

					if (buffer == null || buffer == "")
						throw new Exception("SQLMsg.tables not set.");

					buffer = "DELETE FROM " + buffer;

					sqlSb = sqlSb + " " + buffer;
					buffer = sqlMsg.getWhereExpression();
					sqlSb = sqlSb + " " + buffer;
					sqlSb += ";";
                    //Console.Write(sqlSb);
				}
				if (sqlSb == null || sqlSb == "")//没有要删除的记录
					throw new Exception("SQLMsg.tables not set.");
				return sqlSb;
			}
			catch (Exception e)
			{
				//throw new MYEXCEPTION(e.Message + "： " + sqlSb, EXCEPTIONDEFINE.TYPE_ERROR);
                throw e;
			}
			finally
			{ }
		}

		public void releaseResource()
		{ }

		public void close()
		{ }
	}
}
