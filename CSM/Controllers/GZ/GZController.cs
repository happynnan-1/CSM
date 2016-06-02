using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSM.Models;

namespace CSM.Controllers.GZ
{
    public class GZController : Controller
    {
        //
        // GET: /WXGZ/

        public ActionResult InputSN()
        {
            return View();
        }
        public ActionResult CreateTask(string para)
        {
            DB _db = new DB();
            List<TemProduct> _list = _db.exesql<TemProduct>(string.Format(@"select t.`Name`,t1.StartTime,t1.EndTime from productinfo t
                            left join productmnt t1 on t1.SN=t.SN
                            where t.SN='{0}'", para)).ToList();
            string _name = _list[0].Name;
            //string x = _list.;
            ViewData["sn"]=para;
            ViewData["list"] = _list;

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
