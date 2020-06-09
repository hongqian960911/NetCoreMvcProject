using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Reflection;

namespace IC.Common
{
    public class DATAPROCESS
    {
        //处理可能为NULL的数字数据类型（数据库中的数字），如果为DBNULL，则强制转换为0
        public static int DBNULL2INT(object dbField)
        {
            if (Convert.IsDBNull(dbField))
                return 0;
            else
                return (int)dbField;
        }


        //处理可能为NULL的数字数据类型（数据库中的数字），如果为DBNULL，则强制转换为指定的数字
        public static int DBNULL2INT(object dbField, int specNum)
        {
            if (Convert.IsDBNull(dbField))
                return specNum;
            else
                return (int)dbField;
        }


        //将可能的DBNULL类型吃掉为String
        public static string DBNULL2STR(object dbField)
        {
            if (Convert.IsDBNull(dbField))
                return "";
            else
                return Convert.ToString(dbField).Trim();
        }

        public static double DBNULL2Double(object dbField)
        {
            if (Convert.IsDBNull(dbField))
                return 0;
            else if (dbField.ToString() == "")
                return 0;
            else
                return Convert.ToDouble(dbField);
        }

        //将可能的DBNULL类型吃掉为String
        public static string DBNULL2STR(object dbField, bool ConvertDotFlag)
        {
            if (Convert.IsDBNull(dbField))
                return "";
            else
                if (ConvertDotFlag)
                    return ConvertDot(Convert.ToString(dbField));
                else
                    return Convert.ToString(dbField).Trim();
        }
        //将可能的DBNULL类型吃掉为String,,如果为null赋指定值
        public static string DBNULL2STR(object dbField, bool ConvertDotFlag, string specSTR)
        {
            if (Convert.IsDBNull(dbField))
                return specSTR;
            else
                if (ConvertDotFlag)
                    return ConvertDot(Convert.ToString(dbField));
                else
                    return Convert.ToString(dbField).Trim();
        }

        //将可能的DBNULL类型吃掉为Decimal
        public static decimal DBNULL2DECIMAL(object dbField)
        {
            if (Convert.IsDBNull(dbField))
                return 0;
            else if (dbField.ToString() == "")
                return 0;
            else
            {
                try
                {
                    return Convert.ToDecimal(dbField);
                }
                catch (Exception e)
                {
                    return 0;
                }

            }
        }

        //将可能的DBNULL类型吃掉为Decimal,如果为null或空值时赋指定值
        public static decimal DBNULL2DECIMAL(object dbField, decimal specDecimal)
        {
            if (Convert.IsDBNull(dbField))
                return specDecimal;
            else if (dbField.ToString() == "")
                return specDecimal;
            else
            {
                try
                {
                    return Convert.ToDecimal(dbField);
                }
                catch (Exception e)
                {
                    return 0;
                }

            }
        }

        //'将可能的DBNULL类型吃掉为LONG
        public static double DBNULL2LONG(object dbField)
        {
            if (Convert.IsDBNull(dbField))
                return 0;
            else
                return (long)dbField;
        }

        //将数字0转换为空字符串
        public static string ZEROSTR2SPACE(string dbField)
        {
            try
            {
                if (double.Parse(dbField) == 0)
                    return "";
                else
                    return Convert.ToString(dbField).Trim();
            }
            catch (Exception e)
            {
                return Convert.ToString(dbField).Trim();
            }
        }

        //'将可能的DBNULL类型吃掉为LONG,若为空则赋指定值
        public static long DBNULL2LONG(object dbField, long specDouble)
        {
            if (Convert.IsDBNull(dbField))
                return specDouble;
            else
                return (long)dbField;
        }

        //将可能的DBNULL类型吃掉为DataTime
        public static DateTime DBNULL2DATETIME(object dbField)
        {
            if (Convert.IsDBNull(dbField))
                return System.DateTime.Now;
            else
                return Convert.ToDateTime(dbField);
        }

        //将可能的DBNULL类型吃掉为DataTime,若为空则赋指定值
        public static DateTime DBNULL2DATETIME(object dbField, DateTime specDateTime)
        {
            if (Convert.IsDBNull(dbField))
                return specDateTime;
            else
                return Convert.ToDateTime(dbField);
        }

        //转换日期时间为 YYYY-MM-DD : HH:mm:ss
        public static string DATE2YYMMDDHHmmss(DateTime specDatetime)
        {
            string YYYY = "";
            string MM = "";
            string DD = "";
            string HH = "";
            string mm = "";
            string ss = "";
            YYYY = specDatetime.Year.ToString();
            MM = specDatetime.Month.ToString();
            DD = specDatetime.Day.ToString();
            HH = specDatetime.Hour.ToString();
            mm = specDatetime.Minute.ToString();
            ss = specDatetime.Second.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            if (int.Parse(DD) < 10)
                DD = "0" + int.Parse(DD).ToString();
            if (int.Parse(HH) < 10)
                HH = "0" + int.Parse(HH);
            if (int.Parse(mm) < 10)
                mm = "0" + int.Parse(mm);
            if (int.Parse(ss) < 10)
                ss = "0" + int.Parse(ss);
            //return YYYY + "-" + MM + "-" + DD + " " + HH + ":" + mm + ":" + ss;
            return specDatetime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //转换日期时间为 MM-DD : HH:mm
        public static string DATE2MMDDHHmm(DateTime specDatetime)
        {
            string MM = "";
            string DD = "";
            string HH = "";
            string mm = "";
            MM = specDatetime.Month.ToString();
            DD = specDatetime.Day.ToString();
            HH = specDatetime.Hour.ToString();
            mm = specDatetime.Minute.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            if (int.Parse(DD) < 10)
                DD = "0" + int.Parse(DD).ToString();
            if (int.Parse(HH) < 10)
                HH = "0" + int.Parse(HH);
            if (int.Parse(mm) < 10)
                mm = "0" + int.Parse(mm);
            return MM + "-" + DD + " " + HH + ":" + mm;
            //return specDatetime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //转换日期时间为 YYYY-MM-DD : HH:mm:ss
        public static string TIME2HHmm(DateTime specDatetime)
        {
            string HH = "";
            string mm = "";

            HH = specDatetime.Hour.ToString();
            mm = specDatetime.Minute.ToString();
            if (int.Parse(HH) < 10)
                HH = "0" + int.Parse(HH);
            if (int.Parse(mm) < 10)
                mm = "0" + int.Parse(mm);
            return HH + ":" + mm;

        }
        //转换日期时间为 YYYY-MM-DD : HH:mm:ss
        public static string TIME2HHmmss(DateTime specDatetime)
        {
            string HH = "";
            string mm = "";
            string ss = "";
            HH = specDatetime.Hour.ToString();
            mm = specDatetime.Minute.ToString();
            ss = specDatetime.Second.ToString();
            if (int.Parse(HH) < 10)
                HH = "0" + int.Parse(HH);
            if (int.Parse(mm) < 10)
                mm = "0" + int.Parse(mm);
            if (int.Parse(ss) < 10)
                ss = "0" + int.Parse(ss);
            return HH + ":" + mm + ":" + ss;

        }

        //转换日期为 YYYY-MM-DD
        public static string DATE2YYMMDD(DateTime specDatetime)
        {
            string YYYY = "";
            string MM = "";
            string DD = "";
            YYYY = specDatetime.Year.ToString();
            MM = specDatetime.Month.ToString();
            DD = specDatetime.Day.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            if (int.Parse(DD) < 10)
                DD = "0" + int.Parse(DD).ToString();
            return YYYY + "-" + MM + "-" + DD;
        }

        //转换日期为 YYYYMM
        public static string DATE2YYMM(DateTime specDatetime)
        {
            string YYYY = "";
            string MM = "";
            YYYY = specDatetime.Year.ToString();
            MM = specDatetime.Month.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            return YYYY + MM;
        }

        //转换日期时间为 YYYY-MM-DD : HH:mm:ss
        public static string DATE2YYMMDDHHmmssNOTLINE(DateTime specDatetime)
        {
            string YYYY = "";
            string MM = "";
            string DD = "";
            string HH = "";
            string mm = "";
            string ss = "";
            YYYY = specDatetime.Year.ToString();
            MM = specDatetime.Month.ToString();
            DD = specDatetime.Day.ToString();
            HH = specDatetime.Hour.ToString();
            mm = specDatetime.Minute.ToString();
            ss = specDatetime.Second.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            if (int.Parse(DD) < 10)
                DD = "0" + int.Parse(DD).ToString();
            if (int.Parse(HH) < 10)
                HH = "0" + int.Parse(HH);
            if (int.Parse(mm) < 10)
                mm = "0" + int.Parse(mm);
            if (int.Parse(ss) < 10)
                ss = "0" + int.Parse(ss);
            return YYYY + MM + DD + HH + mm + ss;

        }

        //转换日期时间为 年月日  HH:mm:ss
        public static string DATE2YYMMDDHHmmssLong(DateTime specDatetime)
        {
            string YYYY = "";
            string MM = "";
            string DD = "";
            string HH = "";
            string mm = "";
            string ss = "";
            YYYY = specDatetime.Year.ToString();
            MM = specDatetime.Month.ToString();
            DD = specDatetime.Day.ToString();
            HH = specDatetime.Hour.ToString();
            mm = specDatetime.Minute.ToString();
            ss = specDatetime.Second.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            if (int.Parse(DD) < 10)
                DD = "0" + int.Parse(DD).ToString();
            if (int.Parse(HH) < 10)
                HH = "0" + int.Parse(HH);
            if (int.Parse(mm) < 10)
                mm = "0" + int.Parse(mm);
            if (int.Parse(ss) < 10)
                ss = "0" + int.Parse(ss);
            return YYYY + "年" + MM + "月" + DD + "日 " + HH + ":" + mm + ":" + ss;

        }

        //将DATE2YYMMDDHHmmssNOTLINE日期字符串转换为带“-”的日期字符串形式（20150318121833）
        public static string AddLine_yyyyMMddHHmmssNOTLINE(string yyyyMMddHHmmssNOTLINE)
        {
            string YYYY = "";
            string MM = "";
            string DD = "";
            string HH = "";
            string mm = "";
            string ss = "";
            YYYY = yyyyMMddHHmmssNOTLINE.Substring(0, 4);
            MM = yyyyMMddHHmmssNOTLINE.Substring(5, 2);
            DD = yyyyMMddHHmmssNOTLINE.Substring(7, 2);
            HH = yyyyMMddHHmmssNOTLINE.Substring(9, 2);
            mm = yyyyMMddHHmmssNOTLINE.Substring(11, 2);
            ss = yyyyMMddHHmmssNOTLINE.Substring(13, 2);

            return YYYY + "-" + MM + "-" + DD + " " + HH + ":" + mm + ":" + ss;

        }

        //转换日期为 YYYYMMDD
        public static string DATE2YYMMDDNOTLINE(DateTime specDatetime)
        {
            string YYYY = "";
            string MM = "";
            string DD = "";
            YYYY = specDatetime.Year.ToString();
            MM = specDatetime.Month.ToString();
            DD = specDatetime.Day.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            if (int.Parse(DD) < 10)
                DD = "0" + int.Parse(DD).ToString();
            return YYYY + "" + MM + "" + DD;
        }

        //转换日期为 YYYYMMDDHHMMSS
        public static string DATE2YYMMDDHHMMSS(DateTime specDatetime)
        {
            string YYYY = specDatetime.Year.ToString();
            string MM = specDatetime.Month.ToString();
            string DD = specDatetime.Day.ToString();
            string HH = specDatetime.Hour.ToString();
            string FF = specDatetime.Minute.ToString();
            string SS = specDatetime.Millisecond.ToString();
            if (int.Parse(MM) < 10)
                MM = "0" + int.Parse(MM).ToString();
            if (int.Parse(DD) < 10)
                DD = "0" + int.Parse(DD).ToString();
            return YYYY + "" + MM + "" + DD + "" + HH + "" + FF + "" + SS;
        }

        //将可能的NULL类型吃掉为STRING，若为NULL，则赋值“”
        public static string NULL2STR(object strObj)
        {
            if (strObj == null)
                return "";
            else
                return strObj.ToString();
        }

        //截取指定长度的字符串，超过部分用...显示
        public static string cutStr(string Str, int cutNum, bool displayHint)
        {
            if (Str.Length <= cutNum)
                return Str;
            else
            {
                if (displayHint)
                    return "<A title='" + Str + "'>" + Str.Substring(0, cutNum) + "...</A>";
                else
                    return Str.Substring(0, cutNum) + "...";
            }
        }

        //SQL 转义
        public static string RemoveInValidWord(string Value)
        {
            string strReturn;
            string strTmp;

            strTmp = Value;
            strTmp = strTmp.Replace("'", "''");
            strReturn = strTmp;
            return strReturn;
        }

        //SQL 转义(用于Like语句)
        public static string RemoveInValidWordForLike(string Value)
        {
            string strReturn;

            strReturn = Value;
            strReturn = strReturn.Replace("'", "''");
            strReturn = strReturn.Replace("[", "[[]");
            strReturn = strReturn.Replace("%", "[%]");
            strReturn = strReturn.Replace("_", "[_]");

            return strReturn;
        }

        //字符串中的,换成javascript中的字符
        //在打印模块中可能有回车换行的字符串请用本函数转换一下
        public static string ConvertDot(string Value)
        {
            string sRtn;
            if (Value.Equals(""))
                return "";
            sRtn = Value.Replace(",", "，");
            return sRtn;
        }

        //判断是否为数字
        public static bool IsNumberic(string oText)
        {
            try
            {
                Decimal var1 = Convert.ToDecimal(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //检查传入的日期字符串的有效性,并转换为YYYY/MM/DD格式
        // 名称		FormatDate(in_str)
        // 功能		检查传入的日期字符串的有效性
        // 参数		要检查日期有效性的字符串
        // 返回值   如果字符串是日期，返回####/##/##的格式；
        //			如果不是日期，返回空字符串
        /////////////////////////////////
        public static string FormatDate(string inputDate)
        {
            //合法的时间输入有以下三种
            //1. 20090601
            //2. 2009/06/01
            //3. 2009-06-01
            string sTempDate = "";
            string sReturnDate = "";
            if (inputDate.Length > 10 || inputDate.Length < 8 || inputDate.Length == 9)
            {//以上长度全部不合法
                return "";
            }
            else
            {
                try
                {
                    //处理第一种 20090601
                    if (inputDate.Length == 8)
                        sTempDate = inputDate.Substring(0, 4) + "-" + inputDate.Substring(4, 2) + "+" + inputDate.Substring(6, 2);
                    else
                        sTempDate = inputDate;
                    //判断日期是否合法
                    DateTime tempDate = DateTime.Parse(sTempDate);
                    string yyyy = tempDate.Year.ToString();
                    string mm = tempDate.Month.ToString();
                    string dd = tempDate.Day.ToString();
                    if (int.Parse(mm) < 10)
                        mm = "0" + mm;
                    if (int.Parse(dd) < 10)
                        dd = "0" + dd;
                    sReturnDate = yyyy + "-" + mm + "-" + dd;
                    return sReturnDate;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string CreateJson(DataTable dt, int totalCount, int totalPage)
        {
            /* /**************************************************************************** 
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview 
             * As soon as this method gets a DataTable it starts to convert it into JSON String, 
             * it takes each row and in each row it grabs the cell name and its data. 
             * This kind of JSON is very usefull when developer have to have Column name of the . 
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName> 
             * NOTE: One negative point. by this method user will not be able to call any cell by its index. 
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling          
            if (dt != null)
            {
                JsonString.Append("{ \"totalPage\":" + totalPage + ",\"totalCount\":" + totalCount + ",");
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\"");
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
            }
            return JsonString.ToString();
        }


        public static string CreateJsonChangeReturn(DataTable dt, int totalCount, int totalPage)
        {
            /* /**************************************************************************** 
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview 
             * As soon as this method gets a DataTable it starts to convert it into JSON String, 
             * it takes each row and in each row it grabs the cell name and its data. 
             * This kind of JSON is very usefull when developer have to have Column name of the . 
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName> 
             * NOTE: One negative point. by this method user will not be able to call any cell by its index. 
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling          
            if (dt != null)
            {
                JsonString.Append("{ \"totalPage\":" + totalPage + ",\"totalCount\":" + totalCount + ",");
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r\n", "<br>") + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r\n", "<br>") + "\"");
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
            }
            return JsonString.ToString();
        }

        public static string CreateJson(DataTable dt, int totalCount)
        {
            /* /**************************************************************************** 
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview 
             * As soon as this method gets a DataTable it starts to convert it into JSON String, 
             * it takes each row and in each row it grabs the cell name and its data. 
             * This kind of JSON is very usefull when developer have to have Column name of the . 
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName> 
             * NOTE: One negative point. by this method user will not be able to call any cell by its index. 
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling          
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{\"total\":" + totalCount + ",");
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\"");
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                JsonString.Append("{ \"total\":\"0\",");
                JsonString.Append("\"rows\":[ ");
                JsonString.Append("]}");
                return JsonString.ToString();
            }
        }

        /// <summary>
        /// Json转DataTable
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson, string tableName)
        {
            //取出表名  
            //Regex rg = new Regex(@"(?<={)[^:]+(?=:/[)", RegexOptions.IgnoreCase);
            //string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名  
            //strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            //strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据  
            Regex rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                if (tableName == "Questionnaire")
                {
                    strRow = strRow.Replace("rgb(255, 255, 255)", "white");
                }
                else if (tableName == "AnswerResult")
                {
                    strRow = strRow.Replace("(必填, 单选)", "");
                    strRow = strRow.Replace("(必填, 多选)", "");
                    strRow = strRow.Replace("(必填, 问答题)", "");
                }
                string[] strRows = strRow.Split(',');

                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = tableName;
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.ColumnName = strCell[0].ToString();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    if (tableName == "Questionnaire" && strRows[r].Split(':')[0] == "Content")
                    {
                        dr[r] = strRows[r].Substring(strRows[r].IndexOf(":") + 1).Trim().Replace("，", ",").Replace("：", ":");
                    }
                    else if (tableName == "AnswerResult" && strRows[r].Split(':')[0] == "Content")
                    {
                        dr[r] = strRows[r].Substring(strRows[r].IndexOf(":") + 1).Trim().Replace("，", ",").Replace("：", ":");
                    }
                    else
                    {
                        dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":");
                    }
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }


        public static string CreateJson(DataTable dt)
        {
            /* /**************************************************************************** 
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview 
             * As soon as this method gets a DataTable it starts to convert it into JSON String, 
             * it takes each row and in each row it grabs the cell name and its data. 
             * This kind of JSON is very usefull when developer have to have Column name of the . 
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName> 
             * NOTE: One negative point. by this method user will not be able to call any cell by its index. 
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling          
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ \"total\":" + dt.Rows.Count + ",");
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\"");
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                JsonString.Append("{ \"total\":\"0\",");
                JsonString.Append("\"rows\":[ ");
                JsonString.Append("]}");
                return JsonString.ToString();
            }
        }

        /// <summary>
        /// 替换回车符为<br /> 在js中替换回来
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string CreateJsonReplaceReturn(DataTable dt)
        {
            /* /**************************************************************************** 
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview 
             * As soon as this method gets a DataTable it starts to convert it into JSON String, 
             * it takes each row and in each row it grabs the cell name and its data. 
             * This kind of JSON is very usefull when developer have to have Column name of the . 
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName> 
             * NOTE: One negative point. by this method user will not be able to call any cell by its index. 
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling          
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ \"total\":" + dt.Rows.Count + ",");
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r\n", "<br>").Replace("\n", "<br>") + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r\n", "<br>").Replace("\n", "<br>") + "\"");
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                JsonString.Append("{ \"total\":\"0\",");
                JsonString.Append("\"rows\":[ ");
                JsonString.Append("]}");
                return JsonString.ToString();
            }
        }

        public static string CreateOriginalJson(DataTable dt)
        {
            /* /**************************************************************************** 
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview 
             * As soon as this method gets a DataTable it starts to convert it into JSON String, 
             * it takes each row and in each row it grabs the cell name and its data. 
             * This kind of JSON is very usefull when developer have to have Column name of the . 
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName> 
             * NOTE: One negative point. by this method user will not be able to call any cell by its index. 
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling          
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\"");
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return JsonString.ToString();
            }
        }

        /// <summary>
        /// 实体对象转json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null)

                return dtReturn;

            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static string CreateJsonDataTables(DataTable dt)
        {
            /* /**************************************************************************** 
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview 
             * As soon as this method gets a DataTable it starts to convert it into JSON String, 
             * it takes each row and in each row it grabs the cell name and its data. 
             * This kind of JSON is very usefull when developer have to have Column name of the . 
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName> 
             * NOTE: One negative point. by this method user will not be able to call any cell by its index. 
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling          
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{\"data\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString().Replace("\"", "'").Replace("\r", "").Replace("\n", "") + "\"");
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                JsonString.Append("{\"data\":[ ");
                JsonString.Append("]}");
                return JsonString.ToString();
            }
        }
    }
}
