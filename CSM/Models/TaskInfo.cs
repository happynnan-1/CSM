using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSM.Models
{
    public class TaskInfo
    {
        #region 成员变量、构造函数
        string _strTableName;
        string _GUID;
        string _TaskID;
        string _CustomerID;
        string _ProductID;
        string _Channel;
        string _Content;
        string _Level;
        string _Adress;
        string _ContactName;
        string _Phone;
        string _Email;
        DateTime _CreateTime;
        string _Remark;


        /// <summary>
        /// 获取实体类对应的数据库表名。
        /// </summary>
        public string TableName
        {
            get
            {
                return _strTableName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string GUID
        {
            get
            {
                return _GUID;
            }
            set
            {
                _GUID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TaskID
        {
            get
            {
                return _TaskID;
            }
            set
            {
                _TaskID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Channel
        {
            get
            {
                return _Channel;
            }
            set
            {
                _Channel = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get
            {
                return _Content;
            }
            set
            {
                _Content = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Adress
        {
            get
            {
                return _Adress;
            }
            set
            {
                _Adress = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ContactName
        {
            get
            {
                return _ContactName;
            }
            set
            {
                _ContactName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                _CreateTime = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }

        #endregion
    }
}