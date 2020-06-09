using System;

namespace IC.DataAccess
{
	[Serializable]
	public class customerTerm
	{
		/// <summary>
		/// 
		/// </summary>
		public string guid = "";

		/// <summary>
		/// 
		/// </summary>
		public string district = "";

		/// <summary>
		/// 
		/// </summary>
		public string copyvalue = "";

		/// <summary>
		/// 
		/// </summary>
		public string sceneguid = "";

		/// <summary>
		/// 
		/// </summary>
		public string customername = "";

		/// <summary>
		/// 
		/// </summary>
		public string isinclude = "";

		/// <summary>
		/// 
		/// </summary>
		public string address = "";

		/// <summary>
		/// 
		/// </summary>
		public string longitude = "";

		/// <summary>
		/// 
		/// </summary>
		public string latitude = "";

		/// <summary>
		/// 
		/// </summary>
		public string province = "";

		/// <summary>
		/// 
		/// </summary>
		public string city = "";

		/// <summary>
		/// 是否使用模糊查询
		/// </summary>
		public bool LikeFlag = false;

		/// <summary>
		/// 是否返回从表
		/// </summary>
		public bool IsReturnDetail = false;
	}
}

