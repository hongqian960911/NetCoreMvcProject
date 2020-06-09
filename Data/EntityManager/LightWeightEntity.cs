using IC.Common;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace IC.EntityManager
{
    public class LightWeightEntity : LightWeightETMgr
	{
		public string entityString;

		public LightWeightEntity(MySqlConnection myCon, MySqlTransaction myTrans, string entityStr)
			: base(myCon, myTrans)
		{
			entityString = entityStr;
		}

		public bool createEntity(DataTable inData)
		{
			try
			{
				return base.createEntity(inData, entityString);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public int updateEntity(DataTable inData)
		{
			try
			{
				return base.updateEntity(inData, entityString, null);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public int updateEntity(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.updateEntity(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

        public int updateMultipleEntity(DataTable inData)
        {
            try
            {
                return base.updateMultipleEntity(inData, entityString, null);
            }
            catch (MYEXCEPTION mye)
            {
                throw mye;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int updateMultipleEntity(DataTable inData, SQLSTR sqlStruct)
        {
            try
            {
                return base.updateMultipleEntity(inData, entityString, sqlStruct);
            }
            catch (MYEXCEPTION mye)
            {
                throw mye;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

		public int removeEntity(DataTable inData)
		{
			try
			{
				return base.removeEntity(inData, entityString, null);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 删除一到多个个实体
		/// </summary>
		/// <param name="inData"></param>
		/// <returns></returns>
		public int removeMultipleEntity(DataTable inData)
		{
			try
			{
				return base.removeMultipleEntity(inData, entityString, null);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public int removeEntity(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.removeEntity(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public int removeEntityByEqualCondition(DataTable inData)
		{
			try
			{
				return base.removeEntityByEqualCondition(inData, entityString, null);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public int removeEntityByEqualCondition(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.removeEntityByEqualCondition(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public int removeEntityAnyCondition(DataTable inData)
		{
			try
			{
				return base.removeEntityAnyCondition(inData, entityString, null);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public int removeEntityAnyCondition(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.removeEntityAnyCondition(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public DataTable findEntityByPrimaryKey(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.findEntityByPrimaryKey(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public DataTable findEntityByEqualCondition(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.findEntityByEqualCondition(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public DataTable findEntityAnyCondition(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.findEntityAnyCondition(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public DataTable findEntityByLikeCondition(DataTable inData, SQLSTR sqlStruct)
		{
			try
			{
				return base.findEntityByLikeCondition(inData, entityString, sqlStruct);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public new DataTable findEntityBySQL(string sSQL)
		{
			try
			{
				return base.findEntityBySQL(sSQL);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public new int removeEntityBySQL(string sSQL)
		{
			try
			{
				return base.removeEntityBySQL(sSQL);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public new int updateEntityBySQL(string sSQL)
		{
			try
			{
				return base.updateEntityBySQL(sSQL);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public new DataTable findEntityBySQL(string sSQL, MySqlParameter[] parameters)
		{
			try
			{
				return base.findEntityBySQL(sSQL, parameters);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public new int removeEntityBySQL(string sSQL, MySqlParameter[] parameters)
		{
			try
			{
				return base.removeEntityBySQL(sSQL, parameters);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public new int updateEntityBySQL(string sSQL, MySqlParameter[] parameters)
		{
			try
			{
				return base.updateEntityBySQL(sSQL, parameters);
			}
			catch (MYEXCEPTION mye)
			{
				throw mye;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

	}
}
