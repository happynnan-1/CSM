using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSM.Models
{
    public class Productinfo
    {
        public Productinfo()
		{}
		#region Model
		private string _productid;
		private string _vendorid;
		private string _name;
		private string _type;
		private string _desc;
		private string _imgpath;
		private string _createuser;
		private DateTime? _createtime;
		private string _updateuser;
		private DateTime? _updatetime;
		private string _status;
		/// <summary>
		/// 
		/// </summary>
		public string ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VendorID
		{
			set{ _vendorid=value;}
			get{return _vendorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Desc
		{
			set{ _desc=value;}
			get{return _desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IMGPath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
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
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateUser
		{
			set{ _updateuser=value;}
			get{return _updateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

