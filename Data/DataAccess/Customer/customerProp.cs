using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IC.Common;

namespace IC.DataAccess
{
    public class customerProp : EntityProperty
{
	public customerProp()
		: base()
	{
		this.setTable(customerField.TABLE_NAME);
		ArrayList al = new ArrayList();
		int index = 1;//列索引

		al.Add(new PropertyEntry(customerField.guid_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.guid_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, true, index++));
		al.Add(new PropertyEntry(customerField.district_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.district_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.copyvalue_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.copyvalue_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.sceneguid_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.sceneguid_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.customername_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.customername_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.isinclude_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.isinclude_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.address_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.address_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.longitude_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.longitude_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.latitude_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.latitude_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.province_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.province_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));
		al.Add(new PropertyEntry(customerField.city_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, customerField.city_FIELD, CONSTDEFINE.CONST_DATATYPE_NVARCHAR, false, index++));

		this.setEntryList(al);
	}

}
}
