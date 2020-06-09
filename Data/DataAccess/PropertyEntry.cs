using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.DataAccess
{
    public class PropertyEntry
    {
        //实体属性中的列名称
        public string sEtCol;
        //实体属性中的列类型
        public string sEtType;
        //实体表中的列名称
        public string sDbCol;
        //实体表中的列类型
        public string sDbType;
        //是否为数据表中的关键字列
        public bool bDbKey;
        //实体表的列编号
        public int iDbColNo;

        public PropertyEntry()
        {
        }

        public PropertyEntry(string etCl, string etTp, string dbCl, string dbTp, bool dbKy, int dbCN)
        {
            sEtCol = etCl;
            sEtType = etTp;
            sDbCol = dbCl;
            sDbType = dbTp;
            bDbKey = dbKy;
            iDbColNo = dbCN;
        }
    }
}
