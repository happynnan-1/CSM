using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSM.Controllers.GZ
{
    public class WXGZController : Controller
    {
        //
        // GET: /WXGZ/

        public ActionResult InputSN()
        {
            return View();
        }
        public ActionResult CreateTask(string para)
        {
            ViewData["sn"]=para;
            return View();
        }
        public ActionResult ProductInfo(string para)
        {
            ViewData["sn"] = para;
            return View();
        }
        public ActionResult ProductMnt(string para)
        {
            ViewData["sn"] = para;
            return View();
        }

    }
}
