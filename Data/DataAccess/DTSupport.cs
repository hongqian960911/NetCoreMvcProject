using System;
using System.Data;
using System.Runtime.Serialization;

namespace IC.DataAccess
{
	public class DTSupport : DataTable
	{
		public DTSupport()
			: base()
		{
		}

		public DTSupport(string tblName)
			: base(tblName)
		{
		}


		protected void cloneRows(DataTable dt)
		{
			int i;
			for (i = 0; i < dt.Rows.Count; i++)
			{
				this.ImportRow(dt.Rows[i]);
			}
		}

		protected void copyRows(DataTable dt)
		{
			int i;
			for (i = 0; i < dt.Rows.Count; i++)
			{
				this.ImportRow(dt.Rows[i]);
			}
		}

		protected void copyRows(DataRow dr)
		{
			int i;
			for (i = 0; i < dr.Table.Rows.Count; i++)
			{
				this.ImportRow(dr.Table.Rows[i]);
			}
		}

		public DataSet DataTable2DataSet()
		{
			DataSet ds = new DataSet();
			ds.Tables.Add(this);
			return ds;
		}

		public void ImportRowByView(DataRowView rowView)
		{
			int i;
			DataRow aRow = this.NewRow();
			for (i = 0; i < this.Columns.Count; i++)
			{
				if (rowView[this.Columns[i].ColumnName] != null && !Convert.IsDBNull(rowView[this.Columns[i].ColumnName]))
				{
					aRow[this.Columns[i].ColumnName] = rowView[this.Columns[i].ColumnName];
				}
			}
			this.Rows.Add(aRow);
		}
	}
}
