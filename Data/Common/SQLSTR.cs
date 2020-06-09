using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.Common
{
    public class SQLSTR
    {
        private string sCondition;
        private string sOrderBy;
        private string sGroupBy;
        private string sAscDescFlg;
        private string sDistinctFlg;

        public SQLSTR()
        {
            sCondition = "";
            sOrderBy = "";
            sGroupBy = "";
            sAscDescFlg = CONSTDEFINE.CONST_SQL_SORT_ACS;
            sDistinctFlg = CONSTDEFINE.CONST_SQL_DISTINCT_FALSE;
        }

        public string Condition
        {
            get
            {
                return sCondition;
            }
            set
            {
                if (value == null)
                    sCondition = "";
                else
                    sCondition = value.Trim();
            }
        }

        public string OrderBy
        {
            get
            {
                return sOrderBy;
            }
            set
            {
                if(value == null)
                    sOrderBy = "";
                else
                    sOrderBy = value.Trim();
            }
        }

        public string GroupBy
        {
            get
            {
                return sGroupBy;
            }
            set
            {
                if(value == null)
                    sGroupBy = "";
                else
                    sGroupBy = value.Trim();
            }          
        }

        public string AscDescFlg
        {
            get
            {
                return sAscDescFlg;
            }
            set
            {
                if(value == null)
                    sAscDescFlg = "";
                else
                    sAscDescFlg = value.Trim();
            }          
        }

        public string DistinctFlg
        {
            get
            {
                return sDistinctFlg;
            }
            set
            {
                if(value == null)
                    sDistinctFlg = "";
                else
                    sDistinctFlg = value.Trim();
            }
        }
    }
}
