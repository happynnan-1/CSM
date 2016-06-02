using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSM.Models
{
    /// <summary>
    /// customer:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Customer
    {
        public Customer()
        { }
        #region Model
        private string _guid;
        private string _uid;
        private string _openid;
        private string _channel;
        private string _nickname;
        private string _headimgurl;
        private int? _sex;
        private string _city;
        private string _province;
        private string _country;
        private string _email;
        private string _phone;
        private DateTime? _followtime;
        private string _createuser;
        private DateTime? _createtime;
        private string _updateuser;
        private DateTime? _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public string GUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpenID
        {
            set { _openid = value; }
            get { return _openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Channel
        {
            set { _channel = value; }
            get { return _channel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string headimgurl
        {
            set { _headimgurl = value; }
            get { return _headimgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string country
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FollowTime
        {
            set { _followtime = value; }
            get { return _followtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

    }
}

