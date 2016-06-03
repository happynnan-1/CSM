using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSM.Models
{
    public class ViewModelTaskInfo
    {

        public ViewModelTaskInfo()
        { }

        #region Model       


        private string _taskid;
        private string _customerName;
        private string _productName;

        private string _content;

       
        private string _phone;       
        private string _remark;

        private string _assignID;

        public string AssignID
        {
            get { return _assignID; }
            set { _assignID = value; }
        }

      


        /// <summary>
        /// 
        /// </summary>
        public string TaskID
        {
            set { _taskid = value; }
            get { return _taskid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerName
        {
            set { _customerName = value; }
            get { return _customerName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productName = value; }
            get { return _productName; }
        }
        /// <summary>
        /// 
        /// </summary>
              
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }       
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

         //TaskID = a.TaskID,
         //                    ProductName = b.Name,                           
         //                    CustomerName = c.NickName,
         //                    Remark = a.Remark,
         //                    Phone = a.Phone,
         //                    Content = a.Content,



        #endregion Model
    }
}