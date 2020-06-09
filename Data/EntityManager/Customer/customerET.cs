using IC.Common;
using IC.DataAccess;
using MySql.Data.MySqlClient;
using System;

namespace IC.EntityManager
{
    public class customerET : LightWeightEntity
{
    public customerET(MySqlConnection myCon, MySqlTransaction myTrans)
        : base(myCon, myTrans, customerField.CLASS_NAME)
    {
    }

    public customerField SearchByCondition(customerTerm dsTerm)
    {
        RunSQL rs = new RunSQL(connection, myTrans);
        string sSql;
        customerField HeadInfo;

        sSql = "SELECT * FROM customer WHERE 1=1";


        if (dsTerm.guid != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.guid_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.guid) + "%' ";
            else
                sSql += " AND customer." + customerField.guid_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.guid) + "' ";

        if (dsTerm.district != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.district_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.district) + "%' ";
            else
                sSql += " AND customer." + customerField.district_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.district) + "' ";

        if (dsTerm.copyvalue != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.copyvalue_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.copyvalue) + "%' ";
            else
                sSql += " AND customer." + customerField.copyvalue_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.copyvalue) + "' ";

        if (dsTerm.sceneguid != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.sceneguid_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.sceneguid) + "%' ";
            else
                sSql += " AND customer." + customerField.sceneguid_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.sceneguid) + "' ";

        if (dsTerm.customername != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.customername_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.customername) + "%' ";
            else
                sSql += " AND customer." + customerField.customername_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.customername) + "' ";

        if (dsTerm.isinclude != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.isinclude_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.isinclude) + "%' ";
            else
                sSql += " AND customer." + customerField.isinclude_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.isinclude) + "' ";

        if (dsTerm.address != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.address_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.address) + "%' ";
            else
                sSql += " AND customer." + customerField.address_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.address) + "' ";

        if (dsTerm.longitude != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.longitude_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.longitude) + "%' ";
            else
                sSql += " AND customer." + customerField.longitude_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.longitude) + "' ";

        if (dsTerm.latitude != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.latitude_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.latitude) + "%' ";
            else
                sSql += " AND customer." + customerField.latitude_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.latitude) + "' ";

        if (dsTerm.province != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.province_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.province) + "%' ";
            else
                sSql += " AND customer." + customerField.province_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.province) + "' ";

        if (dsTerm.city != "")
            if (dsTerm.LikeFlag)
                sSql += " AND customer." + customerField.city_FIELD + " like '%" + DATAPROCESS.RemoveInValidWordForLike(dsTerm.city) + "%' ";
            else
                sSql += " AND customer." + customerField.city_FIELD + " = '" + DATAPROCESS.RemoveInValidWord(dsTerm.city) + "' ";

        try
        {
            HeadInfo = new customerField(rs.Query_SQL(sSql));

            if (!dsTerm.IsReturnDetail)
                return HeadInfo;                 //仅返回头部数据
            else
            {
                int i;
                for (i = 0; i < HeadInfo.Rows.Count; i++)
                {
                    //查询各头部数据的明细数据，放入头部 Table 一起返回
                }
            }
        }
        catch (Exception e)
        {
            throw new MYEXCEPTION(e);
        }
        return HeadInfo;
    }
}
}
