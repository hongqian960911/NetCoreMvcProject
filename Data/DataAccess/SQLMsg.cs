using IC.Common;
using System;
using System.Collections;

namespace IC.DataAccess
{
    public class SQLMsg
    {
        public string[] columns;

        public string[] values;

        public bool isDistinct = false;

        public string[] tables;

        public string condition;

        public Hashtable equalCondition = new Hashtable();

        public bool isForUpdate = false;

        public string groupBy;

        public string orderBy;

        public string charactersOfTime(string value)
        {
            return " getdate() ";
        }

        public string charactersOfTimeCompare(object value)
        {
            return " getdate() ";
        }

        public string charactersOfTimeAllowNull(object value)
        {
            if (Convert.IsDBNull(value))
                return " NULL ";
            if (value.ToString().Trim() == "")
                return " NULL ";
            return "'" + Convert.ToDateTime(value).ToString() + "'";
        }

        public string charactersOfNoComma(string value)
        {
            if (value == "")
                value = "0";
            return value;
        }

        public string charactersOf(string value)
        {
            return "N'" + DATAPROCESS.RemoveInValidWord(value) + "'";
        }

        public string charactersOfCHS(string value)
        {
            return "N'" + DATAPROCESS.RemoveInValidWord(value) + "'";
        }

        public string charactersOfLike(string value)
        {
            return "N'" + DATAPROCESS.RemoveInValidWord(value) + "%'";
        }

        public string charactersOf(bool _bool)
        {
            if (_bool)
                return "1";
            else
                return "0";
        }

        public string charactersOf(char value)
        {
            return charactersOf(value.ToString());
        }

        public string charactersOf(int value)
        {
            return charactersOf(value.ToString());
        }

        public string charactersOf(long value)
        {
            return charactersOf(value.ToString());
        }

        public string charactersOf(decimal value)
        {
            return charactersOf(value.ToString());
        }

        public void setColumns(string[] columns)
        {
            this.columns = columns;
        }

        public string[] getColumns()
        {
            return this.columns;
        }

        public void setDistinctSelectMode()
        {
            isDistinct = true;
        }

        public void setAllSelectMode()
        {
            isDistinct = false;
        }

        public string getSelectExpression()
        {
            string selectExpression = arrayConcat(columns);
            if (selectExpression == "")
                return "";
            
            //SELECT句生成
            string selectPrefix = "SELECT ";
            if (isDistinct)
                selectPrefix = "SELECT DISTINCT ";
            return selectPrefix + cnvUpperCaseString(selectExpression);
        }

        //设定 insert句的COLUMNS域
        public string getColumnsExpression()
        {
            string columnsExpression = arrayConcat(columns);
            if (columnsExpression == "")
                return "";
            return "(" + cnvUpperCaseString(columnsExpression) + ")";
        }

        private string cnvUpperCaseString(string str)
        {
            return str.ToUpper();
        }

        private string arrayConcat(string[] strArray)
        {
            if (strArray == null)
                return "";
            if (strArray.Length == 0)
                return "";
            string sb = "";
            string str;
            int i;

            for(i=0;i<strArray.Length;i++)
            {
                str = strArray[i].Trim();
                if(sb != "")
                    sb = sb + ",";
                sb = sb + str;
            }
            return sb;
        }

        //values设定
        public void setValues(string[] values)
        {
            this.values = values;
        }

        //values指定位置的值得设定
        public void setValue(string colName, string value)
        {
            setValue(getColumnIndex(colName).ToString(), value);
        }

        //得到与检索项目一致的列号
        private int getColumnIndex(string colName)
        {
            int i;
            int j = 0;
            for(i=0;i< columns.Length;i++)
            {
                if (columns[i] == colName)
                    j = i;
            }
            return j;
        }

        //values值的取得
        public string[] getValues()
        {
            return values;
        }

        //设定insert 用的value值
        public string getValuesExpression()
	    {
            string valuesExpression;
            string valuesPrefix = "VALUES ";
            if (values.Length != columns.Length)
                throw new Exception("error!");
            valuesExpression = arrayConcat(values);
            if (valuesExpression != "")
                valuesPrefix = valuesPrefix + "(" + valuesExpression + ")";
            return valuesPrefix;

        }

        //设定update 用的value值
        public string getSetExpression()
	    {
            string[] cleanColumns = getCleanStringArray(columns);
            string[] cleanValues = getCleanStringArray(values);
        
            if (cleanValues.Length != cleanColumns.Length)
                throw new Exception("not equal error!");
            if (cleanValues.Length == 0)
                throw new Exception("null error!");

            string setExpressionSb = "";
            int i;
            for (i = 0;i<cleanValues.Length;i++)
		    {
                if (i > 0)
                    setExpressionSb = setExpressionSb + ", ";
                setExpressionSb = setExpressionSb + cnvUpperCaseString(cleanColumns[i]);
                setExpressionSb = setExpressionSb + "=" + cleanValues[i];
            }
            string setPrefix = "SET ";
            return setPrefix + setExpressionSb;

        }

        //nothing to "" 的变换
        private string[] getCleanStringArray(string[] strArray)
	    {
            string[] stringList = new string[strArray.Length];
            int i;
            string cleanString;
            for( i = 0; i<strArray.Length;i++)
		    {
                cleanString = getCleanString(strArray[i]);
                if((cleanString != null) && cleanString != "")
                    stringList[i] = cleanString;
            }
            return stringList;

        }

        //tables值设定
        public void setTables(string[] tables)
	    {
            this.tables = tables;
        }

        //根据table设定From句
        public string getFromExpression()
	    {
            string fromExpression = arrayConcat(tables);
            if(fromExpression==null || fromExpression.Trim() == "")
                return "";
            string fromPrefix = "FROM ";
            return fromPrefix + cnvUpperCaseString(fromExpression);
        }

        //table 文字列生成
        public string getTableExpression()
	    {
            if( tables.Length != 1)
                throw new Exception("error");
            string tableExpression = arrayConcat(tables);
            return cnvUpperCaseString(tableExpression);
        }

        //CleanString值的取得
        private string getCleanString(string str)
	    {
            return str;
        }

        //condition值的设定
        public void setCondition(string condition)
        {
		    this.condition = condition;
        }


        //condition值的取得
        public string getCondition()
	    {
            return condition;
        }

        //Equal condition值的设定
        public void setEqualCondition(string column, string condition)
	    {
            this.equalCondition.Add(column, condition);
        }


        //Equal condition值的取得
        public Hashtable getEqualCondition()
	    {
            return equalCondition;
        }

        //根据condition设定WHERE句
        public string getWhereExpression()
	    {

            string wherePrefix = "WHERE ";

            string whereExpression = getCleanString(condition.Trim());

            whereExpression = cnvUpperCaseString(whereExpression);
            if (whereExpression != "")
                return wherePrefix + whereExpression;
            else
                return whereExpression;
        }

        //设定UPDATE句
        public string getForUpdateExpression()
	    {
            string forUpdate = "FOR UPDATE";
            if (isForUpdate)
                return forUpdate;
            else
                return "";
        }

        //groupBy设定
        public void setGroupBy(string groupBy)
	    {
            this.groupBy = groupBy;
        }

        //groupBy取得
        public string getGroupBy()
	    {
            return groupBy;
        }

        //根据 groupBy 设定 Group By 句
        public string getGroupByExpression()
	    {
            string groupByPrefix = "GROUP BY ";
            string groupByExpression;

            groupByExpression = getCleanString(groupBy);
            if (groupByExpression == "")
                return "";
            groupByExpression = cnvUpperCaseString(groupByExpression);
            return groupByPrefix + groupByExpression;

        }

        //orderBy设定
        public void setOrderBy(string orderBy)
	    {
            this.orderBy = orderBy;
        }

        //orderBy取得
        public string getOrderBy()
	    {
            return orderBy;
        }

        //根据 orderBy设定 ORDER BY  句
        public string getOrderByExpression()
	    {

            string orderByPrefix = "ORDER BY ";
            string orderByExpression;

            orderByExpression = getCleanString(orderBy);
            if (orderByExpression == "")
                return "";
            orderByExpression = cnvUpperCaseString(orderByExpression);
            return orderByPrefix + orderByExpression;
        }
    }
}
