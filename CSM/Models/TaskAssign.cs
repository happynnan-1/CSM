using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace CSM.Models
{
    public class TaskAssign
    {
        public TaskAssign()
		{}
		#region Model
		private string _guid;
		private string _assignid;
		private string _taskid;
		private string _taskstatus;
		private DateTime? _booktime;
		private string _feedback;
		private string _assignuser;
		private string _createuser;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public string GUID
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Key(KeyType.Assigned)]
		public string AssignID
		{
			set{ _assignid=value;}
			get{return _assignid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskID
		{
			set{ _taskid=value;}
			get{return _taskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskStatus
		{
			set{ _taskstatus=value;}
			get{return _taskstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BookTime
		{
			set{ _booktime=value;}
			get{return _booktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FeedBack
		{
			set{ _feedback=value;}
			get{return _feedback;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AssignUser
		{
			set{ _assignuser=value;}
			get{return _assignuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
        }
        #endregion
    }
}