using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.Common
{
	public class CONSTDEFINE
	{
		//日期格式名称
		public const string YYMMDDFORMAT = "yyMMdd";
		public const string YYYYMMDDFORMAT = "yyyyMMdd";
		public const string YYYYMMFORMAT = "yyyyMM";
		public const string DATEFORMAT = "yyyy/MM/dd";
		public const string DATETIMEFORMAT = "yyyy-MM-dd HH:mm:ss";
		public const int YYYYMMDDLENGTH = 8;
		public const int YYYYMMLENGTH = 6;
		public const int DATELENGTH = 10;

		//数据显示方式名称
		public const string CONST_SQL_DISTINCT_TRUE = "TRUE";
		public const string CONST_SQL_DISTINCT_FALSE = "FALSE";
		public const string CONST_SQL_SORT_ACS = "ACS";
		public const string CONST_SQL_SORT_DESC = "DESC";
		public const string CONST_DV_SORT_ACS = "asc";
		public const string CONST_DV_SORT_DESC = "desc";
		public const string CONST_SORT_BY = "SortBy";
		public const string CONST_SORT_BY_EXPR = "SortByExpr";

		//数据类型名称
		public const string CONST_DATATYPE_BIT = "bit";
		public const string CONST_DATATYPE_INT = "int";
		public const string CONST_DATATYPE_LONG = "Long";
		public const string CONST_DATATYPE_STRING = "String";
		public const string CONST_DATATYPE_DECIMAL = "Decimal";
		public const string CONST_DATATYPE_CHAR = "Char";
		public const string CONST_DATATYPE_VARCHAR = "VarChar";
		public const string CONST_DATATYPE_NVARCHAR = "nVarChar";
		public const string CONST_DATATYPE_VARBINARY = "VarBinary";
		public const string CONST_DATATYPE_IMAGE = "image";
		public const string CONST_DATATYPE_DATETIME = "DateTime";
		public const string CONST_DATATYPE_DATETIME_COMPARE = "DateTimeCompare";
		public const string CONST_DATATYPE_DateTimeAllowNull = "DateTimeAllowNull";
		public const string CONST_DATATYPE_NVARCHARCHS = "nVarCharCHS";

		public const string CONST_TRUE = "1";
		public const string CONST_FALSE = "0";

		//其他
		public const string CONST_ETNAME = "DataAccess";

		//超级用户
		public const string CONST_ADMIN = "admin";
		public const string CONST_VICE_MANAGER = "dingying";

		#region 会议室预订
		/// <summary>
		/// 内部的
		/// </summary>
		public const string MEETING_TYPE_IN = "0";
		/// <summary>
		/// 外部的
		/// </summary>
		public const string MEETING_TYPE_OUT = "1";
		/// <summary>
		/// 预订--新建
		/// </summary>
		public const string MEETING_RESERVE_NEW = "0";
		/// <summary>
		/// 预订--确认中
		/// </summary>
		public const string MEETING_RESERVE_CONFIRMING = "1";
		/// <summary>
		/// 预订--已确认
		/// </summary>
		public const string MEETING_RESERVE_CONFIRM = "2";
		/// <summary>
		/// 预订--退回
		/// </summary>
		public const string MEETING_RESERVE_REFUSE = "-1";
		/// <summary>
		/// 预订--新建
		/// </summary>
		public const string MEETING_RESERVE_NEW_NAME = "新建";
		/// <summary>
		/// 预订--确认中
		/// </summary>
		public const string MEETING_RESERVE_CONFIRMING_NAME = "确认中";
		/// <summary>
		/// 预订--已确认
		/// </summary>
		public const string MEETING_RESERVE_CONFIRM_NAME = "已确认";
		/// <summary>
		/// 预订--退回
		/// </summary>
		public const string MEETING_RESERVE_REFUSE_NAME = "退回";
		#endregion

		#region 综合报修
		/// <summary>
		/// 报修单状态--新建
		/// </summary>
		public const string REPAIR_RESERVE_NEW = "0";
		/// <summary>
		/// 报修单状态--等待受理
		/// </summary>
		public const string REPAIR_RESERVE_READY = "1";
		/// <summary>
		/// 报修单状态--受理中
		/// </summary>
		public const string REPAIR_RESERVE_WORKING = "2";
		/// <summary>
		/// 报修单状态--完成
		/// </summary>
		public const string REPAIR_RESERVE_WORKOVER = "3";
		/// <summary>
		/// 报修单状态--无法完成
		/// </summary>
		public const string REPAIR_RESERVE_ABORTIVE = "-1";
		/// <summary>
		/// 报修单状态--新建
		/// </summary>
		public const string REPAIR_RESERVE_NEW_NAME = "新建";
		/// <summary>
		/// 报修单状态--等待受理
		/// </summary>
		public const string REPAIR_RESERVE_READY_NAME = "等待受理";
		/// <summary>
		/// 报修单状态--受理中
		/// </summary>
		public const string REPAIR_RESERVE_WORKING_NAME = "受理中";
		/// <summary>
		/// 报修单状态--完成
		/// </summary>
		public const string REPAIR_RESERVE_WORKOVER_NAME = "完成";
		/// <summary>
		/// 报修单状态--无法完成
		/// </summary>
		public const string REPAIR_RESERVE_ABORTIVE_NAME = "无法完成";
		/// <summary>
		/// ITC报修名称
		/// </summary>
		public const string REPAIR_TYPE_ITC = "ITC";
		/// <summary>
		/// 综合办报修名称
		/// </summary>
		public const string REPAIR_TYPE_ZHBBX = "ZHBBX";
		/// <summary>
		/// 项目支持报修名称
		/// </summary>
		public const string REPAIR_TYPE_XMZC = "XMZC";
		/// <summary>
		/// 人事报修名称
		/// </summary>
		public const string REPAIR_TYPE_HRM = "HRM";
		/// <summary>
		/// 法务支持名称
		/// </summary>
		public const string REPAIR_TYPE_FW = "FWZC";
		/// <summary>
		/// 运营支持名称
		/// </summary>
		public const string REPAIR_TYPE_YY = "YYZC";
		/// <summary>
		/// 建议&投诉名称
		/// </summary>
		public const string REPAIR_TYPE_YJTS = "YJTS";
		/// <summary>
		/// 车辆调度报修名称
		/// </summary>
		public const string REPAIR_TYPE_CLDD = "CLDD";
		/// <summary>
		/// 会议室调度报修名称
		/// </summary>
		public const string REPAIR_TYPE_HYSDD = "HYSDD";
		/// <summary>
		/// ITC其他报修类型
		/// </summary>
		public const string REPAIR_TYPE_ITCQT = "ITCQT";
		/// <summary>
		/// 人事其他报修类型
		/// </summary>
		public const string REPAIR_TYPE_RSQT = "RSQT";
		/// <summary>
		/// 项目支持其他报修类型
		/// </summary>
		public const string REPAIR_TYPE_XMZCQT = "XMZCQT";
		/// <summary>
		/// 运营支持其他报修类型
		/// </summary>
		public const string REPAIR_TYPE_YYQT = "YYQT";
		/// <summary>
		/// 综合办其他报修类型
		/// </summary>
		public const string REPAIR_TYPE_ZHBQT = "ZHBQT";
		/// <summary>
		/// ITC其他报修类型中文名
		/// </summary>
		public const string REPAIR_TYPE_ITCQT_NAME = "其他IT支持";
		/// <summary>
		/// 人事其他报修类型中文名
		/// </summary>
		public const string REPAIR_TYPE_RSQT_NAME = "其他人事支持";
		/// <summary>
		/// 项目支持其他报修类型中文名
		/// </summary>
		public const string REPAIR_TYPE_XMZCQT_NAME = "其他项目支持";
		/// <summary>
		/// 综合办其他报修类型中文名
		/// </summary>
		public const string REPAIR_TYPE_ZHBQT_NAME = "其他行政支持";
		/// <summary>
		/// 运营支持其他报修类型中文名
		/// </summary>
		public const string REPAIR_TYPE_YYQT_NAME = "其他运营支持";
		/// <summary>
		/// ITC报修页面传值类型
		/// </summary>
		public const string REPAIR_TYPE_ITC_SUPPORTTYPE = "it";
		/// <summary>
		/// 综合办报修页面传值类型
		/// </summary>
		public const string REPAIR_TYPE_ZHBBX_SUPPORTTYPE = "administration";
		/// <summary>
		/// 项目支持报修页面传值类型
		/// </summary>
		public const string REPAIR_TYPE_XMZC_SUPPORTTYPE = "project";
		/// <summary>
		/// 人事报修页面传值类型
		/// </summary>
		public const string REPAIR_TYPE_HRM_SUPPORTTYPE = "hr";

		/// <summary>
		/// 法务支持报修页面传值类型
		/// </summary>
		public const string REPAIR_TYPE_FW_SUPPORTTYPE = "law";

		/// <summary>
		/// 建议投诉报修页面传值类型
		/// </summary>
		public const string REPAIR_TYPE_YJTS_SUPPORTTYPE = "suggest";

		/// <summary>
		/// 运营支持报修页面传值类型
		/// </summary>
		public const string REPAIR_TYPE_YY_SUPPORTTYPE = "manage";
		/// <summary>一号楼会议室管理员</summary>
		public const string MEETING_BUILTING1_MANAGER = ",yuanling,bqyao,";
		/// <summary>一号楼需要管理的会议室</summary>
		public const string MEETING_BUILTING1_MEETINGROOM = ",#1FM,#1FV,";

		/// <summary>
		/// 项目支持 我要刻盘报修类型
		/// </summary>
		public const string REPAIR_TYPE_WYKP = "WYKP";
		/// <summary>
		/// 项目支持 我要调资料报修类型
		/// </summary>
		public const string REPAIR_TYPE_WYDZL = "WYDZL";
		/// <summary>
		/// 图书管理
		/// </summary>
		public const string REPAIR_TYPE_TSGL = "TSGL";
        /// <summary>
        /// 名片申请
        /// </summary>
        public const string REPAIR_TYPE_MPSQ = "MPSQ";

       
		#region  光盘类型
		public const string REPAIR_KPTYPE_BULECD = "蓝色世博LOGO CD（成片）";

		public const string REPAIR_KPTYPE_BULEDVD = "蓝色世博LOGO DVD（成片）";

		public const string REPAIR_KPTYPE_GREENCD = "绿色世博LOGO CD（宣传）";

		public const string REPAIR_KPTYPE_GREENDVD = "绿色世博LOGO DVD（宣传）";

		public const string REPAIR_KPTYPE_NOLOGO = "无LOGO CD（备份）";
		#endregion


		#endregion

        #region 供应商管理
        /// <summary>
        /// 是长期合作伙伴
        /// </summary>
        public const string VENDORINFO_ISLONGFRIEND_TRUE = "1";

        /// <summary>
        /// 不是长期合作伙伴
        /// </summary>
        public const string VENDORINFO_ISLONGFRIEND_FALSE = "0";
        #endregion

        #region 车辆预订
        /// <summary>
		/// 预定--新建
		/// </summary>
		public const string VEHICLE_RESERVE_NEW = "0";//新建

		/// <summary>
		/// 预定--确认中
		/// </summary>
		public const string VEHICLE_RESERVE_CONFIRMING = "1";//确认中


		/// <summary>
		/// 预定--车辆确认
		/// </summary>
		public const string VEHICLE_RESERVE_CONFIRM = "2";//审核中

		/// <summary>
		/// 审核-主管审核
		/// </summary>
		public const string VEHICLE_RESERVE_APPROVE = "3";//审核通过


		/// <summary>
		/// 预定--退回
		/// </summary>
		public const string VEHICLE_RESERVE_REFUSE = "-1";//预定退回

		/// <summary>
		/// 预定--新建
		/// </summary>
		public const string VEHICLE_RESERVE_NEW_NAME = "新建";
		/// <summary>
		/// 预定--确认中
		/// </summary>
		public const string VEHICLE_RESERVE_CONFIRMING_NAME = "确认中";//确认中

		/// <summary>
		/// 审核-主管审核
		/// </summary>
		public const string VEHICLE_RESERVE_APPROVE_NAME = "审核通过";//审核通过

		/// <summary>
		/// 预定--车辆确认
		/// </summary>
		public const string VEHICLE_RESERVE_CONFIRM_NAME = "审核中";//车辆确认

		/// <summary>
		/// 预定--退回
		/// </summary>
		public const string VEHICLE_RESERVE_REFUSE_NAME = "退回";//预定退回
		#endregion

		#region 图书状态

		public const string BOOK_LEND_STOCK = "1";

		public const string BOOK_LEND_STOCK_NAME = "在库";

		public const string BOOK_LEND_RESERVE = "2";

		public const string BOOK_LEND_RESERVE_NAME = "预约";

		public const string BOOK_LEND_LENDING = "3";

		public const string BOOK_LEND_LENDING_NAME = "借出";

		public const string BOOK_LEND_LOST = "4";

		public const string BOOK_LEND_LOST_NAME = "遗失";

		#endregion

		#region 文件类型

		/// <summary>
		/// word文档Value
		/// </summary>
		public const string DOC_TYPE_WORD = "doc";

		/// <summary>
		/// word文档Text
		/// </summary>
		public const string DOC_TYPE_WORD_NAME = "WORD文档";

		/// <summary>
		/// excel文档Value
		/// </summary>
		public const string DOC_TYPE_EXCEL = "xls";

		/// <summary>
		/// excel文档Text
		/// </summary>
		public const string DOC_TYPE_EXCEL_NAME = "EXCEL文档";

		/// <summary>
		/// PDF文件
		/// </summary>
		public const string DOC_TYPE_PDF = "pdf";

		/// <summary>
		/// PDF文件
		/// </summary>
		public const string DOC_TYPE_PDF_NAME = "PDF文件";

		/// <summary>
		/// ppt幻灯片Value
		/// </summary>
		public const string DOC_TYPE_PPT = "ppt";

		/// <summary>
		/// ppt幻灯片Text
		/// </summary>
		public const string DOC_TYPE_PPT_NAME = "PPT幻灯片";

		/// <summary>
		/// 文本文档Value
		/// </summary>
		public const string DOC_TYPE_TXT = "txt";

		/// <summary>
		/// 文本文档Text
		/// </summary>
		public const string DOC_TYPE_TXT_NAME = "文本文档";

		/// <summary>
		/// mp3音频Value
		/// </summary>
		public const string DOC_TYPE_MP3 = "mp3";

		/// <summary>
		/// mp3音频Text
		/// </summary>
		public const string DOC_TYPE_MP3_NAME = "MP3音频";

		/// <summary>
		/// wav音频文件Value
		/// </summary>
		public const string DOC_TYPE_WAV = "wav";

		/// <summary>
		/// wav音频文件Text
		/// </summary>
		public const string DOC_TYPE_WAV_NAME = "WAV音频文件";

		/// <summary>
		/// 压缩文件Value
		/// </summary>
		public const string DOC_TYPE_RAR = "rar/zip";

		/// <summary>
		/// 压缩文件Text
		/// </summary>
		public const string DOC_TYPE_RAR_NAME = "压缩文件";

		/// <summary>
		/// 视频文件Value
		/// </summary>
		public const string DOC_TYPE_RM = "rm/rmvb";

		/// <summary>
		/// 视频文件Text
		/// </summary>
		public const string DOC_TYPE_RM_NAME = "视频文件";

		/// <summary>
		/// 其它Value
		/// </summary>
		public const string DOC_TYPE_OTHER = "other";

		/// <summary>
		/// 其它Text
		/// </summary>
		public const string DOC_TYPE_OTHER_NAME = "其它";

		#endregion

		#region 我的申请类别
		/// <summary>
		/// 会议室预订
		/// </summary>
		public const string MYAPPLY_TYPE_MEETING = "1";
		/// <summary>
		/// 综合报修
		/// </summary>
		public const string MYAPPLY_TYPE_REPAIR = "2";
		/// <summary>
		/// 车辆预订
		/// </summary>
		public const string MYAPPLY_TYPE_VEHICLE = "3";
		/// <summary>
		/// 图书预约
		/// </summary>
		public const string MYAPPLY_TYPE_BOOK = "4";
        /// <summary>
        /// 名片申请
        /// </summary>
        public const string MYAPPLY_TYPE_BUSINESSCARD = "5";
		/// <summary>
		/// 会议室预订
		/// </summary>
		public const string MYAPPLY_TYPE_NAME_MEETING = "会议室预订";
		/// <summary>
		/// 综合报修
		/// </summary>
		public const string MYAPPLY_TYPE_NAME_REPAIR = "综合报修";
		/// <summary>
		/// 车辆预订
		/// </summary>
		public const string MYAPPLY_TYPE_NAME_VEHICLE = "车辆预订";
		/// <summary>
		/// 图书预约
		/// </summary>
		public const string MYAAPLY_TYPE_NAME_BOOK = "图书预约";
        /// <summary>
        /// 名片申请
        /// </summary>
        public const string MYAPPLY_TYPE_NAME_BUSINESSCARD = "名片申请";
		#endregion

        #region 水晶石运营
        /// <summary>
        /// 目标类型-目标签单计划
        /// </summary>
        public const string BUDGET_WORKTARGET_TYPE_SELL = "1";
        /// <summary>
        /// 目标类型-目标大客户
        /// </summary>
        public const string BUDGET_WORKTARGET_TYPE_CLINET = "2";

        #region 季度报告 时间类型
        /// <summary>
        /// 年报
        /// </summary>
        public const string BUDGET_REPORT_TYPE_ALLYEAR = "1";
        public const string BUDGET_REPORT_TYPE_ALLYEAR_NAME = "年报";
        /// <summary>
        /// 半年报
        /// </summary>
        public const string BUDGET_REPORT_TYPE_HALFYEAR = "2";
        public const string BUDGET_REPORT_TYPE_HALFYEAR_NAME = "半年报";
        /// <summary>
        /// 月报
        /// </summary>
        public const string BUDGET_REPORT_TYPE_MONTH = "3";
        public const string BUDGET_REPORT_TYPE_MONTH_NAME = "月报";
        /// <summary>
        /// 季报
        /// </summary>
        public const string BUDGET_REPORT_TYPE_QUARTER = "4";
        public const string BUDGET_REPORT_TYPE_QUARTER_NAME = "季报";


        /// <summary>
        /// 季度报告级别-公司
        /// </summary>
        public const string BUDGET_REPORT_LEVEL_COMPANY = "1";
        public const string BUDGET_REPORT_LEVEL_COMPANY_NAME = "公司";
        /// <summary>
        /// 季度报告级别-部门
        /// </summary>
        public const string BUDGET_REPORT_LEVEL_DEPT = "2";
        public const string BUDGET_REPORT_LEVEL_DEPT_NAME = "部门";
        /// <summary>
        /// 季度报告级别-二级部门
        /// </summary>
        public const string BUDGET_REPORT_LEVEL_SECONDDEPT = "3";
        public const string BUDGET_REPORT_LEVEL_SECONDDEPT_NAME = "二级部门";
        /// <summary>
        /// 季度报告级别-小组
        /// </summary>
        public const string BUDGET_REPORT_LEVEL_GROUP = "4";
        public const string BUDGET_REPORT_LEVEL_GROUP_NAME = "小组";
        /// <summary>
        /// 季度报告级别-个人
        /// </summary>
        public const string BUDGET_REPORT_LEVEL_WORKUSER = "5";
        public const string BUDGET_REPORT_LEVEL_WORKUSER_NAME = "个人";

      

        #endregion
        #endregion

        #region 客户发短信
        /// <summary>
        /// 客户短信已经发送
        /// </summary>
        public const string CUST_MSG_SENDSTATUS_TRUE = "1";
        /// <summary>
        /// 客户短信未发送
        /// </summary>
        public const string CUST_MSG_SENDSTATUS_FALSE = "0";
        /// <summary>
        /// 客户短信直接发送
        /// </summary>
        public const string CUST_MSG_ISNOWSEND_TRUE = "0";
        /// <summary>
        /// 直接发送
        /// </summary>
        public const string CUST_MSG_ISNOWSEND_TRUE_NAME = "直接发送";
        /// <summary>
        /// 客户短信定时发送
        /// </summary>
        public const string CUST_MSG_ISNOWSEND_FALSE = "1";
        /// <summary>
        /// 定时发送
        /// </summary>
        public const string CUST_MSG_ISNOWSEND_FALSE_NAME = "定时发送";
        #endregion

        #region 名片申请
        /// <summary>
        /// 名片申请
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_ADD = "5";
        /// <summary>
        /// 名片申请名字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_ADD_NAME = "未提交";
        /// <summary>
        /// 名片申请
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_NEW = "0";
        /// <summary>
        /// 名片申请名字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_NEW_NAME = "主管核准";
        /// <summary>
        /// 主管签字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_CHARGECHECK = "1";
        /// <summary>
        /// 主管签字名字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_CHARGECHECK_NAME = "HR核准";
        /// <summary>
        /// HR签字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_HRCHECK = "2";
        /// <summary>
        /// HR签字名字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_HRCHECK_NAME = "等待制作";
        /// <summary>
        /// 完成
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_FINISH = "3";
        /// <summary>
        /// 完成名字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_FINISH_NAME = "制作完成";
        /// <summary>
        /// 退回
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_CALLBACK = "4";
        /// <summary>
        /// 退回名字
        /// </summary>
        public const string BUSINESSCARD_SAUTUS_CALLBACK_NAME = "申请驳回";
        /// <summary>
        /// 名片完成确认者
        /// </summary>
        public const string BUSINESSCARD_FINISH_USER = "jianglehui";
        /// <summary>
        /// 名片申请主管审核
        /// </summary>
        public const string BUSINESSCARD_MPSQZGSH = "MPSQZGSH";
        /// <summary>
        /// 名片申请HR审核
        /// </summary>
        public const string BUSINESSCARD_MPSQHRSH = "MPSQHRSH";
        /// <summary>
        /// 名片申请制作
        /// </summary>
        public const string BUSINESSCARD_MPSQZZ = "MPSQZZ";

        #endregion

		#region 监控时间类型
		/// <summary>
		/// 会议室开始事件
		/// </summary>
		public const string SENDEMAILLOG_EVENTTYPE_MEETING_BEGIN = "1";
		/// <summary>
		/// 会议室结束事件
		/// </summary>
		public const string SENDEMAILLOG_EVENTTYPE_MEETING_END = "2";
		#endregion

		#region 项目进度 发短消息状态类型
		public const string WBXMSPZZB_SENDSMS_STATUS = "6";//5 为总经理审核  6为北京请款
		public const string WBXMSPZZB_SENDSMS_ZJLSP_STATUS = "5";//5 为总经理审核
		public const string WBXMSPZZB_SENDSMS_BJQK_STATUS = "6";//6为北京请款

		#endregion

		#region WorkFlow
		/// <summary>创建人
		/// </summary>
		public const string WFIMPTYPE_CreateUser = "1";
		/// <summary>执行角色
		/// </summary>
		public const string WFIMPTYPE_ImpRole = "2";
		/// <summary>执行人
		/// </summary>
		public const string WFIMPTYPE_ImpUsers = "3";
		/// <summary>执行角色和执行人都可
		/// </summary>
		public const string WFIMPTYPE_ImpRoleAndImpUsers = "4";
		/// <summary>
		/// 提交人的部门主管
		/// </summary>
		public const string WFIMPTYPE_DeptManager = "5";
		/// <summary>
		/// 所有人都可操作
		/// </summary>
		public const string WFIMPTYPE_Everyone = "7";
		/// <summary>
		/// 执行人是ImpUsers中记录的页面控件的值
		/// </summary>
		public const string WFIMPTYPE_UserByFrom = "10";


		/// <summary>
		/// 流程开始
		/// </summary>
		public const string FlowFlag_Begin = "B";
		/// <summary>
		/// 流程进行中
		/// </summary>
		public const string FlowFlag_Runing = "R";
		/// <summary>
		/// 流程结束
		/// </summary>
		public const string FlowFlag_End = "E";
		#endregion

		#region itcWorkFlow
		/// <summary>
		/// 入职
		/// </summary>
		public const string ITCPersonnelChangeType_ruzhi = "1";
		/// <summary>
		/// 离职
		/// </summary>
		public const string ITCPersonnelChangeType_lizhi = "2";
		/// <summary>
		/// 内部调整
		/// </summary>
		public const string ITCPersonnelChangeType_neibutiaozheng = "3";
		/// <summary>
		/// 支援
		/// </summary>
		public const string ITCPersonnelChangeType_zhiyuan = "4";
		#endregion

	}
}

