using IC.Common;
using IC.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IC.EntityManager
{
    public class LightWeightETMgr : DataUtil
    {
        public LightWeightETMgr(MySqlConnection myCon, MySqlTransaction myTrans)
            : base(myCon, myTrans)
        {
            sc = new ShellConnection(connection, myTrans);
        }

        private ShellConnection sc = null;

        //function:insert one row into the table
        //paramaters:
        //        msgInp-contains the name and the value of the input
        //        entity-the class name of tale property 
        public bool createEntity(DataTable inData, string entity)
        {
            try
            {
                EntityProperty prop = getEntityProperty(entity);

                //SQLMassage 生成
                SQLMsg sqlMsg = new SQLMsg();

                //取得全部的columns
                string[] columns = prop.getColumns();

                //SQLmassage的columns设定
                sqlMsg.setColumns(columns);

                //取得表信息
                string table = prop.getTable();

                string[] tables = { table };

                //SQLmassage的表设定
                sqlMsg.setTables(tables);

                //fields name
                string[] attrs = prop.getAttrs();

                string dataType;

                //SQLmassage's column的值(VALUE)的生成及设定
                string[] values = new string[columns.Length];
                string valueStr = "";
                string condStr = "";
                string sTMP;
                int j;
                int i;
                for (j = 0; j < inData.Rows.Count; j++)
                {
                    for (i = 0; i < columns.Length; i++)
                    {
                        sTMP = DATAPROCESS.DBNULL2STR(inData.Rows[j][attrs[i]], false);

                        dataType = prop.getDataType(attrs[i]);
                        switch (dataType)
                        {
                            case CONSTDEFINE.CONST_DATATYPE_DECIMAL:
                                valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_INT:
                                valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_LONG:
                                valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_DATETIME:
                                valueStr = sqlMsg.charactersOfTime(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_DATETIME_COMPARE:
                                valueStr = sqlMsg.charactersOfTimeCompare(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_DateTimeAllowNull:
                                valueStr = sqlMsg.charactersOfTimeAllowNull(inData.Rows[j][attrs[i]]);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_NVARCHARCHS:
                                valueStr = sqlMsg.charactersOfCHS(sTMP);
                                break;
                            default:
                                valueStr = sqlMsg.charactersOf(sTMP);
                                break;
                        }
                        values[i] = valueStr;
                    }
                    sqlMsg.setValues(values);
                    //SQLMassage的WHERE句的设定
                    sqlMsg.setCondition(condStr);
                    try
                    {
                        DataTable dtTemp = new DataTable();
                        dtTemp = inData.Clone();
                        dtTemp.ImportRow(inData.Rows[j]);
                        SQLSTR sqlstr = new SQLSTR();
                        DataTable dt = this.findEntityByPrimaryKey(dtTemp, entity, sqlstr);
                        if (dt.Rows.Count > 0)
                            throw new MYEXCEPTION(EXCEPTIONDEFINE.ELW001);
                        sc.execCreateSQL(sqlMsg);
                    }
                    catch (MYEXCEPTION e)
                    {
                        throw e;
                    }
                }
            }
            catch (MYEXCEPTION mye)
            {
                throw mye;
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        //function:update one row in the table
        //paramaters:
        //        msgInp-contains the name and the value of the input
        //        entity-the class name of tale property 
        public int updateEntity(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return sc.execUpdateSQL(ComposeSqlMsg(inData, entity, "UPDATE", sqlStruct));
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

        //function:update multi row in the table
        //paramaters:
        //        msgInp-contains the name and the value of the input
        //        entity-the class name of tale property 
        public int updateMultipleEntity(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return sc.execUpdateSQL(ComposeMultipleSqlMsg(inData, entity, "UPDATE", sqlStruct));
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

        //function:delete one row from the table by the table's primary key 
        //paramaters:
        //        msgInp-contains the name and the value of the input
        //        entity-the class name of tale property 
        public int removeEntity(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return sc.execRemoveSQL(ComposeSqlMsg(inData, entity, "DELETE", sqlStruct));
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

        //function:delete multiple row from the table by the table's primary key
        //paramaters:
        //        msgInp-contains the name and the value of the input
        //        entity-the class name of tale property 
        public int removeMultipleEntity(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                
                return sc.execRemoveSQL(ComposeMultipleSqlMsg(inData, entity, "DELETE", sqlStruct));
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

        //function:delete one row from the table by the equal conditions  (=)
        //paramaters:
        //        msgInp-contains the name and the value of the input
        //        entity-the class name of tale property 
        public int removeEntityByEqualCondition(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return sc.execRemoveSQL(ComposeSqlMsg(inData, entity, "EQUALCONDITION", sqlStruct));
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

        //function:delete one row from the table when the conditions are haphazard
        //paramaters:
        //        msgInp-contains the name and the value of the input
        //        entity-the class name of tale property 
        public int removeEntityAnyCondition(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return sc.execRemoveSQL(ComposeSqlMsg(inData, entity, "ANYCONDITION", sqlStruct));
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

        //function:Compose multiple sql msg
        //
        public List<SQLMsg> ComposeMultipleSqlMsg(DataTable inData, string entity, string tag, SQLSTR sqlStruct)
        {
            try
            {
                //要返回的sqlmsg列表
                List<SQLMsg> list_SQLMsg = new List<SQLMsg>();

                EntityProperty prop = getEntityProperty(entity);
                //取得全部的columns
                string[] columns = prop.getColumns();
                //取得表信息
                string table = prop.getTable();
                string[] tables = { table };



                if (sqlStruct == null)
                    sqlStruct = new SQLSTR();

                if (tag != "ANYCONDITION")
                {
                    string[] attrs = prop.getAttrs();
                    string dataType;
                    dataType = prop.getDataType(attrs[0]);


                    string valueStr = "";
                    string valueStrLike = "";

                    int i;
                    bool KeyFlag;
                    string sTMP;
                    foreach (DataRow dr in inData.Rows)
                    {
                        string condStr = "";

                        //SQLMassage 生成
                        SQLMsg sqlMsg = new SQLMsg();
                        //SQLmassage的columns设定
                        sqlMsg.setColumns(columns);
                        //SQLmassage的表设定
                        sqlMsg.setTables(tables);

                        //SQLmassage's column的值(VALUE)的生成及设定
                        string[] values = new string[columns.Length];
                        for (i = 0; i < columns.Length; i++)
                        {
                            sTMP = DATAPROCESS.DBNULL2STR(dr[attrs[i]], false);
                            dataType = prop.getDataType(attrs[i]);
                            switch (dataType)
                            {
                                case CONSTDEFINE.CONST_DATATYPE_DECIMAL:
                                    valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                    break;
                                case CONSTDEFINE.CONST_DATATYPE_INT:
                                    valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                    break;
                                case CONSTDEFINE.CONST_DATATYPE_LONG:
                                    valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                    break;
                                case CONSTDEFINE.CONST_DATATYPE_DATETIME:
                                    valueStr = sqlMsg.charactersOfTime(sTMP);
                                    break;
                                case CONSTDEFINE.CONST_DATATYPE_DATETIME_COMPARE:
                                    valueStr = sqlMsg.charactersOfTimeCompare(sTMP);
                                    break;
                                case CONSTDEFINE.CONST_DATATYPE_DateTimeAllowNull:
                                    valueStr = sqlMsg.charactersOfTimeAllowNull(inData.Rows[0][attrs[i]]);
                                    break;
                                default:
                                    valueStr = sqlMsg.charactersOf(sTMP);
                                    break;
                            }
                            valueStrLike = sqlMsg.charactersOfLike(sTMP);
                            values[i] = valueStr;
                            if (tag != "EQUALCONDITION" && tag != "LIKECONDITION")
                            {
                                KeyFlag = prop.getKeyFlag(attrs[i]);
                                if (KeyFlag)
                                {
                                    if (valueStr != "''")
                                        condStr = condStr + prop.getColumn(attrs[i]) + " = " + valueStr + " AND ";
                                }
                                //if (dataType == CONSTDEFINE.CONST_DATATYPE_DATETIME_COMPARE && (tag == "UPDATE" || tag == "DELETE"))
                                //{
                                //    if (sTMP == "")
                                //        condStr = condStr + prop.getColumn(attrs[i]) + " IS NULL AND ";
                                //    else
                                //        condStr = condStr + "DATEDIFF(SECOND, " + prop.getColumn(attrs[i]) + " , '" + sTMP + "') = 0 AND ";
                                //}
                            }
                            else if (tag == "EQUALCONDITION")
                            {
                                if (valueStr != "''")
                                    condStr = condStr + prop.getColumn(attrs[i]) + " = " + valueStr + " AND ";
                            }
                            else if (tag == "LIKECONDITION")
                            {
                                if (valueStr != "''")
                                    condStr = condStr + prop.getColumn(attrs[i]) + " LIKE  " + valueStrLike + " AND ";
                            }
                        }//end for columns


                        sqlMsg.setValues(values);
                        //SQLMassage的WHERE句的设定
                        int len = condStr.Length;
                        if (len >= 4)
                            condStr = condStr.Substring(0, len - 4);
                        condStr = condStr + " " + sqlStruct.Condition;
                        sqlMsg.setCondition(condStr);

                        //不重复
                        if (sqlStruct.DistinctFlg == CONSTDEFINE.CONST_SQL_DISTINCT_TRUE)
                            sqlMsg.setDistinctSelectMode();
                        else
                            sqlMsg.setAllSelectMode();
                        //没有查询条件
                        if (sqlMsg.getCondition().Trim() == "")
                            sqlMsg.setCondition("1=0");
                        //排序
                        sqlMsg.setOrderBy(sqlStruct.OrderBy);
                        //groupby
                        sqlMsg.setGroupBy(sqlStruct.GroupBy);

                        list_SQLMsg.Add(sqlMsg);
                    }//end for indata
                }
                else
                {
                    //SQLMassage 生成
                    SQLMsg sqlMsg = new SQLMsg();
                    //SQLmassage的columns设定
                    sqlMsg.setColumns(columns);
                    //SQLmassage的表设定
                    sqlMsg.setTables(tables);

                    sqlMsg.setCondition(sqlStruct.Condition);

                    //不重复
                    if (sqlStruct.DistinctFlg == CONSTDEFINE.CONST_SQL_DISTINCT_TRUE)
                        sqlMsg.setDistinctSelectMode();
                    else
                        sqlMsg.setAllSelectMode();
                    //没有查询条件
                    if (sqlMsg.getCondition().Trim() == "")
                        sqlMsg.setCondition("1=0");
                    //排序
                    sqlMsg.setOrderBy(sqlStruct.OrderBy);
                    //groupby
                    sqlMsg.setGroupBy(sqlStruct.GroupBy);

                    list_SQLMsg.Add(sqlMsg);
                }
                return list_SQLMsg;
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

        //function:Compose single sql msg
        //
        public SQLMsg ComposeSqlMsg(DataTable inData, string entity, string tag, SQLSTR sqlStruct)
        {
            try
            {
                EntityProperty prop = getEntityProperty(entity);

                //SQLMassage 生成
                SQLMsg sqlMsg = new SQLMsg();

                //取得全部的columns
                string[] columns = prop.getColumns();

                //SQLmassage的columns设定
                sqlMsg.setColumns(columns);

                //取得表信息
                string table = prop.getTable();

                string[] tables = { table };


                //SQLmassage的表设定
                sqlMsg.setTables(tables);

                if (sqlStruct == null)
                    sqlStruct = new SQLSTR();

                if (tag != "ANYCONDITION")
                {
                    string[] attrs = prop.getAttrs();
                    string dataType;
                    dataType = prop.getDataType(attrs[0]);

                    //SQLmassage's column的值(VALUE)的生成及设定
                    string[] values = new string[columns.Length];
                    string valueStr = "";
                    string valueStrLike = "";
                    string condStr = "";
                    int i;
                    bool KeyFlag;
                    string sTMP;

                    for (i = 0; i < columns.Length; i++)
                    {
                        sTMP = DATAPROCESS.DBNULL2STR(inData.Rows[0][attrs[i]], false);
                        dataType = prop.getDataType(attrs[i]);
                        switch (dataType)
                        {
                            case CONSTDEFINE.CONST_DATATYPE_DECIMAL:
                                valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_INT:
                                valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_LONG:
                                valueStr = sqlMsg.charactersOfNoComma(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_DATETIME:
                                valueStr = sqlMsg.charactersOfTime(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_DATETIME_COMPARE:
                                valueStr = sqlMsg.charactersOfTimeCompare(sTMP);
                                break;
                            case CONSTDEFINE.CONST_DATATYPE_DateTimeAllowNull:
                                valueStr = sqlMsg.charactersOfTimeAllowNull(inData.Rows[0][attrs[i]]);
                                break;
                            default:
                                valueStr = sqlMsg.charactersOf(sTMP);
                                break;
                        }
                        valueStrLike = sqlMsg.charactersOfLike(sTMP);
                        values[i] = valueStr;
                        if (tag != "EQUALCONDITION" && tag != "LIKECONDITION")
                        {
                            KeyFlag = prop.getKeyFlag(attrs[i]);
                            if (KeyFlag)
                            {
                                if (valueStr != "''")
                                    condStr = condStr + prop.getColumn(attrs[i]) + " = " + valueStr + " AND ";
                            }
                            //if (dataType == CONSTDEFINE.CONST_DATATYPE_DATETIME_COMPARE && (tag == "UPDATE" || tag == "DELETE"))
                            //{
                            //    if (sTMP == "")
                            //        condStr = condStr + prop.getColumn(attrs[i]) + " IS NULL AND ";
                            //    else
                            //        condStr = condStr + "DATEDIFF(SECOND, " + prop.getColumn(attrs[i]) + " , '" + sTMP + "') = 0 AND ";
                            //}
                        }
                        else if (tag == "EQUALCONDITION")
                        {
                            if (valueStr != "''")
                                condStr = condStr + prop.getColumn(attrs[i]) + " = " + valueStr + " AND ";
                        }
                        else if (tag == "LIKECONDITION")
                        {
                            if (valueStr != "''")
                                condStr = condStr + prop.getColumn(attrs[i]) + " LIKE  " + valueStrLike + " AND ";
                        }
                    }

                    sqlMsg.setValues(values);
                    //SQLMassage的WHERE句的设定
                    int len = condStr.Length;
                    if (len >= 4)
                        condStr = condStr.Substring(0, len - 4);
                    condStr = condStr + " " + sqlStruct.Condition;
                    sqlMsg.setCondition(condStr);
                }
                else
                    sqlMsg.setCondition(sqlStruct.Condition);
                if (sqlStruct.DistinctFlg == CONSTDEFINE.CONST_SQL_DISTINCT_TRUE)
                    sqlMsg.setDistinctSelectMode();
                else
                    sqlMsg.setAllSelectMode();

                if (sqlMsg.getCondition().Trim() == "")
                    sqlMsg.setCondition("1=0");
                sqlMsg.setOrderBy(sqlStruct.OrderBy);
                sqlMsg.setGroupBy(sqlStruct.GroupBy);
                return sqlMsg;
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

        public DataTable findEntityByPrimaryKey(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return DBNullConv(sc.execFindSQL(ComposeSqlMsg(inData, entity, "PRIMARYKEY", sqlStruct)), entity);
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

        public DataTable findEntityByEqualCondition(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return DBNullConv(sc.execFindSQL(ComposeSqlMsg(inData, entity, "EQUALCONDITION", sqlStruct)), entity);
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

        public DataTable findEntityAnyCondition(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return DBNullConv(sc.execFindSQL(ComposeSqlMsg(inData, entity, "ANYCONDITION", sqlStruct)), entity);
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

        public DataTable findEntityByLikeCondition(DataTable inData, string entity, SQLSTR sqlStruct)
        {
            try
            {
                return DBNullConv(sc.execFindSQL(ComposeSqlMsg(inData, entity, "LIKECONDITION", sqlStruct)), entity);
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

        public DataTable findEntityBySQL(string sSQL)
        {
            try
            {
                return DBNullConv(sc.execFindSQL(sSQL));
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

        public DataTable findEntityBySQL(string sSQL, MySqlParameter[] parameters)
        {
            try
            {
                return DBNullConv(sc.execFindSQL(sSQL, parameters));
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

        public int removeEntityBySQL(string sSQL)
        {
            try
            {
                return sc.execSQL(sSQL);
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

        public int removeEntityBySQL(string sSQL, MySqlParameter[] parameters)
        {
            try
            {
                return sc.execSQL(sSQL, parameters);
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

        public int updateEntityBySQL(string sSQL)
        {
            try
            {
                return sc.execSQL(sSQL);
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

        public int updateEntityBySQL(string sSQL, MySqlParameter[] parameters)
        {
            try
            {
                return sc.execSQL(sSQL, parameters);
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

        //function:get the entity property according to the given the class name of the entity property 
        //parameters: entity-the class name of the entity property 
        public EntityProperty getEntityProperty(string entity)
        {
            //从EntityManager中取得EntityProperty
            EntityPropertyMgr mgr = new EntityPropertyMgr();
            return mgr.getEntityProperty(entity);
        }

        public DataTable DBNullConv(DataTable Ds, string entity)
        {
            EntityProperty prop = getEntityProperty(entity);
            string[] attrs = prop.getAttrs();
            string[] dataType = new string[attrs.Length];
            int i;
            int j;
            int k;
            for (i = 0; i < attrs.Length; i++)
                dataType[i] = prop.getEntityType(attrs[i]);

            if (Ds != null)
            {
                for (j = 0; j < Ds.Rows.Count; j++)
                {
                    for (k = 0; k < attrs.Length; k++)
                    {
                        if (dataType[k] == CONSTDEFINE.CONST_DATATYPE_STRING || dataType[k] == CONSTDEFINE.CONST_DATATYPE_CHAR || dataType[k] == CONSTDEFINE.CONST_DATATYPE_VARCHAR)
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2STR(Ds.Rows[j].ItemArray[k], false);
                        if (dataType[k] == CONSTDEFINE.CONST_DATATYPE_DECIMAL)
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2DECIMAL(Ds.Rows[j].ItemArray[k]);

                        if (dataType[k] == CONSTDEFINE.CONST_DATATYPE_INT)
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2INT(Ds.Rows[j].ItemArray[k]);

                        if (dataType[k] == CONSTDEFINE.CONST_DATATYPE_LONG)
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2LONG(Ds.Rows[j].ItemArray[k]);

                        if (dataType[k] == CONSTDEFINE.CONST_DATATYPE_DATETIME)
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2DATETIME(Ds.Rows[j].ItemArray[k], System.DateTime.Now);
                    }
                }
            }
            return Ds;
        }

        public DataTable DBNullConv(DataTable Ds)
        {
            int j;
            int k;

            if (Ds != null)
            {
                for (j = 0; j < Ds.Rows.Count; j++)
                {
                    for (k = 0; k < Ds.Columns.Count; k++)
                    {
                        if (Ds.Rows[j].ItemArray[k].GetType().FullName == "System.String")
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2STR(Ds.Rows[j].ItemArray[k], false);

                        if (Ds.Rows[j].ItemArray[k].GetType().FullName == "System.Decimal")
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2DECIMAL(Ds.Rows[j].ItemArray[k]);

                        if (Ds.Rows[j].ItemArray[k].GetType().FullName == "System.Int32")
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2INT(Ds.Rows[j].ItemArray[k]);

                        if (Ds.Rows[j].ItemArray[k].GetType().FullName == "System.Int64")
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2LONG(Ds.Rows[j].ItemArray[k]);

                        if (Ds.Rows[j].ItemArray[k].GetType().FullName == "System.DateTime")
                            Ds.Rows[j].ItemArray[k] = DATAPROCESS.DBNULL2DATETIME(Ds.Rows[j].ItemArray[k], System.DateTime.Now);
                    }
                }

            }
            return Ds;
        }
    }
}
