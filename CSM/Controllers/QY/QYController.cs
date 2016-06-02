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

        public ActionResult IndexTask()
        {
            ViewBag.Models = ShowList();
            return View();
        }

        private IEnumerable<Models.customer> ShowList()
        {
            Models.DB mdb = new Models.DB();

            return mdb.all<Models.customer>();
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
