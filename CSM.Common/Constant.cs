using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.Common
{
    public class Constant
    {
        public class AppKeys
        {
            public const string BlogPageSize = "blogPageSize";
            public const string NoticcePageSize = "noticcePageSize";
            public const string WapPhotoRoot = "wapPhotoRoot";
        }
        public class Status
        {
            //激活
            public const string Active = "A";

            //删除
            public const string Deleted = "D";

            //待审
            public const string Pending = "P";

            //拒绝
            public const string Rejected = "R";

            //通过
            public const string Approved = "AR";
        }

        public class CacheKey
        {
            public const string CommonCode = "COMMON_CODE";
        }

       

        
    }
}
