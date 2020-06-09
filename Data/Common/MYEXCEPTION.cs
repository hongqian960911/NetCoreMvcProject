using System;

namespace IC.Common
{
    public class MYEXCEPTION:Exception 
    {        
        protected string sErrInfo;
        protected string sErrType;
        protected string sErrOtherInfo;
        protected string sErrFieldInfo;
        public string[] ErrArray;
        protected int iIndex;
        
        public string ErrInfo
        {
            get 
            {
                return sErrInfo;
            }
            set
            {
                sErrInfo = value;
            }
        }

        public string ErrType
        {
            get
            {
                return sErrType;
            }
            set
            {
                sErrType = value;
            }
        }

        public string ErrOtherInfo
        {
            get
            {
                return sErrOtherInfo;
            }
            set
            {
                sErrOtherInfo = value;
            }
        }

        public string ErrFieldInfo
        {
            get
            {
                return sErrFieldInfo;
            }
            set
            {
                sErrFieldInfo = value;
            }
        }

        public int ChildIndex
        {
            get
            {
                return iIndex;
            }
            set
            {
                iIndex = value;
            }
        }

        public MYEXCEPTION():base()
        {
            sErrInfo = "Unknow error";
            sErrType = "E";
        }

        public MYEXCEPTION(Exception e):base()
        {
            sErrInfo = "未预期错误" + "\\r";
            sErrInfo += "异常信息:" + "\\r";
            sErrInfo += e.Message + "\\r";
            sErrInfo += "发生于:" + "\\r";
            sErrInfo += e.StackTrace;

            sErrType = "E";
        }

        public MYEXCEPTION(string msg, Exception e):base()
        {
            sErrInfo = msg;
            sErrInfo += "未预期错误" + "\\r";
            sErrInfo += "异常信息:" + "\\r";
            sErrInfo += e.Message + "\\r";
            sErrInfo += "发生于:" + "\\r";
            sErrInfo += e.StackTrace;

            sErrType = "E";
        }

        public MYEXCEPTION(MYEXCEPTION e):base()
        {
            ErrArray = e.ErrArray;
            sErrInfo = e.ErrInfo;
            sErrType = e.ErrType;
            sErrOtherInfo = e.ErrOtherInfo;
            sErrFieldInfo = e.ErrFieldInfo;
            iIndex = e.ChildIndex;
        }

        public MYEXCEPTION(string msg):base()
	    {
		    sErrInfo = msg;
            sErrType = "E";
	    }

        public MYEXCEPTION(string msg, string stype):base()
        {
            sErrType = stype;
            sErrInfo = msg;
        }

        public MYEXCEPTION(string msg, string stype, string sothermsg):base()
        {
            sErrType = stype;
            sErrInfo = msg;
            sErrOtherInfo = sothermsg;
        }

        public MYEXCEPTION(string msg,string stype,string sothermsg, int iChildIndex):base()
        {
            sErrType = stype;
            sErrInfo = msg;
            sErrOtherInfo = sothermsg;
            iIndex = iChildIndex;
        }

        //使用ErrorConst数组构造Error
        public MYEXCEPTION(string[] ErrorConstString):base()
        {
            ErrArray = ErrorConstString;
            sErrInfo = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.VALUE];
            sErrType = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.TYPE];
        }

        //使用ErrorConst数组构造Error,sOtherInfo用来填充信息中的@
        public MYEXCEPTION(string[] ErrorConstString, string sotherinfo):base()
        {
            ErrArray = ErrorConstString;
            sErrInfo = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.VALUE];
            sErrType = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.TYPE];
            sErrOtherInfo = sotherinfo;
        }

        //使用ErrorConst数组构造Error,sOtherInfo用来填充信息中的@
        public MYEXCEPTION(string[] ErrorConstString, string sotherinfo, string AppendErrMsg):base()
        {
            ErrArray = ErrorConstString;
            sErrInfo = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.VALUE] + " 『" + AppendErrMsg + "』";
            sErrType = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.TYPE];
            sErrOtherInfo = sotherinfo;
        }

        //使用ErrorConst数组构造Error, sOtherInfo用来填充信息中的@,iChildIndex用来指定明细数据中第几条出错(0一般用来指定HEAD)
        public MYEXCEPTION(string[] ErrorConstString, string sotherinfo, int iChildIndex):base()
        {
            ErrArray = ErrorConstString;
            sErrInfo = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.VALUE];
            sErrType = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.TYPE];
            sErrOtherInfo = sotherinfo;
            iIndex = iChildIndex;
        }

        //用于具有明细的数据报错, sOtherInfo用来填充信息中的@，sErrorFieldInfo用来指定那个字段出错 ,iChildIndex用来指定明细数据中第几条出错(0一般用来指定HEAD)
        public MYEXCEPTION(string[] ErrorConstString, string sotherinfo, string sErrorFieldInfo, int iChildIndex):base()
        {
            ErrArray = ErrorConstString;
            sErrInfo = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.VALUE];
            sErrType = ErrorConstString[(int)EXCEPTIONDEFINE.ErrComIndex.TYPE];
            sErrOtherInfo = sotherinfo;
            sErrFieldInfo = sErrorFieldInfo;
            iIndex = iChildIndex;
        }

    }
}
