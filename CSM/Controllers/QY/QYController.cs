using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSM.Controllers.QY
{
    public class QYController : Controller
    {
        //
        // GET: /QY/

         public ActionResult IndexTask(string guid)
        {
            Models.DB mdb = new Models.DB();

            //任务单号
            var taskList = mdb.Search<Models.TaskInfo>(i => i.GUID.Trim() == "123456");

           // var taskList = mdb.all<Models.TaskInfo>();

            var result = from a in taskList
                         join b in mdb.all<Models.Productinfo>() on a.ProductID.Trim() equals b.ProductID.Trim()
                         join c in mdb.Search<Models.TaskAssign>(j=>j.TaskStatus == "0") on a.TaskID.Trim() equals c.TaskID.Trim()
                         select new Models.ViewModelTaskInfo
                         {
                             TaskID = a.TaskID,
                             ProductName = b.Name,                           
                             CustomerName = a.ContactName,
                             Remark = a.Remark,
                             Phone = a.Phone,
                             Content = a.Content,

                         };
          
            return View("IndexTask",result);
        }

        private IEnumerable<Models.Customer> ShowList()
        {
            Models.DB mdb = new Models.DB(); 

            return mdb.all<Models.Customer>();
        }


        public void ChangeService()
        {

        }

        private void showWeixinUserList()
        {
            string str = string.Empty;
        }

        public ActionResult dd()
        {
            return View();
        }

    }
}
