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
                         join c in mdb.all<Models.Customer>() on a.CustomerID.Trim() equals c.GUID.Trim()
                         select new Models.ViewModelTaskInfo
                         {
                             TaskID = a.TaskID,
                             ProductName = b.Name,                           
                             CustomerName = c.NickName,
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


        private void showWeixinUserList()
        {
            
        }

        public ActionResult dd()
        {
            return View();
        }

    }
}
