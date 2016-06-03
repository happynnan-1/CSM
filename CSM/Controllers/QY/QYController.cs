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
            var taskList = mdb.Search<Models.TaskInfo>(i => i.GUID == "123456");
            
            //var l = from a in taskList join b in mdb.Search<Models.productinfo>(p=>p.VendorID) where a.CustomerID 



           // var result = from




           // ViewBag.Model = mdb.Search<Models.taskinfo>(i => i.GUID == "123456");
            return View("IndexTask");
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
