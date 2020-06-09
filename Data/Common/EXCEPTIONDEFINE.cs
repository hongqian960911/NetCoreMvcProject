using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.Common
{
    public class EXCEPTIONDEFINE
    {
        public enum ErrComIndex
        {
            VALUE = 0, TYPE = 1,
        }

        public static string TYPE_ERROR = "E";
        public static string TYPE_CONFIRM = "Q";
        public static string TYPE_INFO = "I";
        public static string[] ELW001 = {"数据重复！", "E"};
    }
}
