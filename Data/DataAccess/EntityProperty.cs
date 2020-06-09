using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace IC.DataAccess
{
    public class EntityProperty
    {
        private string table;
        public ArrayList entryList = new ArrayList();

        public EntityProperty()
        {
        }

        //获取实体属性类的所有列
        protected ArrayList getEntryList()
        {
            return this.entryList;
        }

        //设置实体属性类的所有列
        protected void setEntryList(ArrayList list)
        {
            try
            {
                if (entryList == null)
                    entryList = list;
                else if (entryList.Count == 0)
                    entryList = list;
                else if (entryList.Count > 0)
                {
                    int i;

                    for (i = 0; i < list.Count; i++)
                        entryList.Add(list[i]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //获取数据表的名称
        public string getTable()
        {
            return this.table;
        }

        //设置数据表的名称
        public void setTable(string name)
        {
            this.table = name;
        }

        //获取数据表中指定列的名称
        public string getColumn(string attr)
        {
            string ret = "";
            int i;
            for (i = 0; i < entryList.Count; i++)
            {
                if (((PropertyEntry)entryList[i]).sEtCol == attr)
                    if (ret == "")
                        ret = ((PropertyEntry)entryList[i]).sDbCol;
            }
            return ret;
        }

        //获取数据表所有列的名称列表
        public string[] getColumns()
        {
            string[] ret = new string[entryList.Count];
            int i;
            for (i = 0; i < entryList.Count; i++)
            {
                ret[i] = ((PropertyEntry)entryList[i]).sDbCol;
            }
            return ret;
        }


        //获取数据表的关键字字段名
        public string[] getKeyColumns()
        {
            string[] newList = new string[entryList.Count];
            int i;
            for (i = 0; i < entryList.Count; i++)
            {
                if (((PropertyEntry)entryList[i]).bDbKey)
                    newList[i] = ((PropertyEntry)entryList[i]).sDbCol;
            }
            return newList;
        }


        //获取实体属性中的所有列的名称列表
        public string[] getAttrs()
        {
            string[] ret = new string[entryList.Count];
            int i;
            for (i = 0; i < entryList.Count; i++)
                ret[i] = ((PropertyEntry)entryList[i]).sEtCol;
            return ret;
        }


        //获取数据表中指定列的数据类型
        public string getDataType(string attr)
        {
            string ret = "";
            int i;
            for (i = 0; i < entryList.Count; i++)
            {
                if (((PropertyEntry)entryList[i]).sEtCol == attr)
                {
                    if (ret == "")
                        ret = ((PropertyEntry)entryList[i]).sDbType;
                }
            }
            return ret;
        }

        //获取实体属性中指定列的类型
        public string getEntityType(string attr)
        {
            string ret = "";
            int i;

            for (i = 0; i < entryList.Count; i++)
            {
                if (((PropertyEntry)entryList[i]).sEtCol == attr)
                {
                    if (ret == "")
                        ret = ((PropertyEntry)entryList[i]).sEtType;
                }
            }
            return ret;
        }

        //获取指定列是否为数据表关键字
        public bool getKeyFlag(string attr)
        {
            bool ret = true;
            int i;
            for (i = 0; i < entryList.Count; i++)
            {
                if (((PropertyEntry)entryList[i]).sEtCol == attr)
                    if (ret)
                        ret = ((PropertyEntry)entryList[i]).bDbKey;
            }
            return ret;
        }

    }
}
