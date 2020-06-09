using NetCoreMvcPeoject.Data;
using MySql.Data.MySqlClient;
using System;

namespace IC.DataAccess
{
    public class TX
    {
        public MySqlConnection Connection = null;
        public MySqlTransaction myTrans = null;

        public TX()
        {
            try
            {
                string CONNECTION_STRING = DBContext.GetConfig("ConnectionStrings:DefaultConnection");
                Connection = new MySqlConnection(CONNECTION_STRING);
                Connection.Open();
                myTrans = Connection.BeginTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void commitTrans()
        {
            try
            {
                if(myTrans!=null)
                    myTrans.Commit();
            }
            catch(Exception e)
            { throw e; }
            finally 
            {
                if(myTrans != null)
                    myTrans = null;
                if(Connection != null)
                {
                    Connection.Dispose();
                    Connection = null;
                }
            }
        }

        public void abortTrans()
        {
            try
            {
                if (myTrans != null)
                    myTrans.Rollback();
            }
            catch(Exception e)
            { throw e; }
            finally
            {
                if(myTrans != null)
                    myTrans = null;
                if(Connection != null)
                {
                    Connection.Dispose();
                    Connection = null;
                }
            }
        }

    }
}
