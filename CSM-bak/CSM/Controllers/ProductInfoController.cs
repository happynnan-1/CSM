using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSM.Class;

namespace CSM.Controllers
{
    public class ProductInfoController : Controller
    {
        //
        // GET: /ProductInfo/
       // [OAuth(OAuthType="公众号")]
        public JsonResult  Index()
        {
            IList<Product> list=new List<Product>();
            for (int i = 1; i < 20; i++)
            {
                Product p = new Product();
                p.id = "PID"+i.ToString();
                p.name = "PName" + i.ToString();
                list.Add(p);
            }
                //return View();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetView()
        {
            IList<Product> list = new List<Product>();
            for (int i = 1; i < 20; i++)
            {
                Product p = new Product();
                p.id = "PID" + i.ToString();
                p.name = "PName" + i.ToString();
                list.Add(p);
            }
            EntityList enlist = new EntityList();
            enlist.plist = list;
            return View("../ProductInfo", enlist);
        }
        public ActionResult GetView1()
        {
          
                Product p = new Product();
                p.id = "PID1";
                p.name = "PName1";
                
            return View("../ProductInfo1", p);
        }

    }
}
