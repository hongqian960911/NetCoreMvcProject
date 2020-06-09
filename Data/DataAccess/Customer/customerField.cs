using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IC.DataAccess
{
    public class customerField : DTSupport
{
	//数据表名
	public const string TABLE_NAME = "customer";
	//ENTITY属性文件
	public const string CLASS_NAME = "IC.DataAccess.customerProp";

	#region 字段

	/// <summary>
	/// 
	/// </summary>
	public const string guid_FIELD = "guid";

	/// <summary>
	/// 
	/// </summary>
	public const string district_FIELD = "district";

	/// <summary>
	/// 
	/// </summary>
	public const string copyvalue_FIELD = "copyvalue";

	/// <summary>
	/// 
	/// </summary>
	public const string sceneguid_FIELD = "sceneguid";

	/// <summary>
	/// 
	/// </summary>
	public const string customername_FIELD = "customername";

	/// <summary>
	/// 
	/// </summary>
	public const string isinclude_FIELD = "isinclude";

	/// <summary>
	/// 
	/// </summary>
	public const string address_FIELD = "address";

	/// <summary>
	/// 
	/// </summary>
	public const string longitude_FIELD = "longitude";

	/// <summary>
	/// 
	/// </summary>
	public const string latitude_FIELD = "latitude";

	/// <summary>
	/// 
	/// </summary>
	public const string province_FIELD = "province";

	/// <summary>
	/// 
	/// </summary>
	public const string city_FIELD = "city";

	#endregion

	public customerField()
		: base(TABLE_NAME)//'调用基类DTSupport的NEW,创建一个DATATABLE的实例
	{
		//创建自身结构的DATATABLE
		BuildTables(this);
	}

	public customerField(DataTable dt)
		: base(TABLE_NAME)
	{
		BuildTables(this);
		//将对象参数dt的数据拷贝,调用父类DTSupport里的copyRows方法
		copyRows(dt);
	}

	private void BuildTables(DataTable dt)
	{
		dt.Columns.Add(guid_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(district_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(copyvalue_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(sceneguid_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(customername_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(isinclude_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(address_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(longitude_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(latitude_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(province_FIELD, Type.GetType("System.String"));
		dt.Columns.Add(city_FIELD, Type.GetType("System.String"));
	}
}
}
