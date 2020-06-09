using IC.Common;
using IC.DataAccess;
using System;
using System.Data;

namespace IC.EntityManager
{
    public class FunctionET
    {
        public static DataTable GetPageTable(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTable(string sql, string countSql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from");
            //string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            //totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            totalCount = sumCountDt.Rows.Count;
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTable2(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable2(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable2(newSql);
            return dt;
        }

        public static DataTable GetPageTable3(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY {0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTable4(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from agencyfee");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY {0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTable_General(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage,string LastIndexOf)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf(LastIndexOf.ToLower());
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY {0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static string GetPageJson(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage, string LastIndexOf)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf(LastIndexOf.ToLower());
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY {0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return DATAPROCESS.CreateJson(dt, totalCount);
        }

        public static DataTable GetPageTable_Ensure(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();

            //hq update begin
            int firstFromIndex = sql.LastIndexOf("from ensurenpolicy left");
            //hq update end

            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY {0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTable_NPolicy(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from npolicy");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY {0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTable_Policy(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from epolicy");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTable_PolicyBGY(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from policy_byg");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }



        public static DataTable GetPageTable2_Policy(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from epolicy");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable2(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable2(newSql);
            return dt;
        }

        public static DataTable GetPageTable2_Declare(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from remotedata");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable2(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable2(newSql);
            return dt;
        }

        public static DataTable GetPageTable3_Declare(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from remotedata");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable3(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable3(newSql);
            return dt;
        }

        public static DataTable GetPageTable4_Declare(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from remotedata");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable4(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable4(newSql);
            return dt;
        }

        public static DataTable GetPageTableV_Declare(string conn, string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from remotedata");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTableV(countSql,conn);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTableV(newSql, conn);
            return dt;
        }

        public static DataTable GetPageTable_RegisterMoneyAccountDetail(string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf("from registermoneyaccountdetail");
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTable(countSql);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTable(newSql);
            return dt;
        }

        public static DataTable GetPageTableV2_Declare(string conn, string sql, string orderBy, int pageIndex, int pageSize, out int totalCount, out int totalPage,string LastIndexStr)
        {
            DataTable dt = null;
            sql = sql.ToLower();
            int firstFromIndex = sql.LastIndexOf(LastIndexStr.ToLower());
            string countSql = "select count(1) as sumCount " + sql.Substring(firstFromIndex);
            DataTable sumCountDt = RunSQL.GetTableV(countSql, conn);
            totalCount = Convert.ToInt32(sumCountDt.Rows[0][0]);
            int pageInt = Convert.ToInt32(totalCount / pageSize);
            float pageDec = (float)totalCount / pageSize;
            totalPage = pageDec > pageInt ? pageInt + 1 : pageInt;
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            string newSql = string.Format(@"SELECT  *
                                        FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY a.{0} ) AS rownumber ,
                                                            a.*
                                                  FROM      ( {1}
                                                            ) a
                                                ) b
                                        WHERE   b.rownumber BETWEEN {2} AND {3}", orderBy, sql, startIndex, endIndex);
            dt = RunSQL.GetTableV(newSql, conn);
            return dt;
        }

    }
}
