using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSM.Models;

namespace CSM.Controllers
{
    public class DemoController : Controller
    {
        
        // GET: /ProductInfo/
        // [OAuth(OAuthType="公众号")] 通过有参数的属性验证权限系统
        public JsonResult Index()
        {
            IList<Demo> list = new List<Demo>();
            for (int i = 1; i < 20; i++)
            {
                Demo p = new Demo();
                p.id = "PID" + i.ToString();
                p.name = "PName" + i.ToString();
                list.Add(p);
            }
            //return View();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 多个实体传入到view
        /// </summary>
        /// <returns></returns>
        public ActionResult GetView()
        {
            IList<Demo> list = new List<Demo>();
            for (int i = 1; i < 20; i++)
            {
                Demo p = new Demo();
                p.id = "PID" + i.ToString();
                p.name = "PName" + i.ToString();
                list.Add(p);
            }
            EntityList enlist = new EntityList();
            enlist.plist = list;
            return View("../ProductInfo", enlist);
        }
        /// <summary>
        /// 单个实体传到view
        /// </summary>
        /// <returns></returns>
        public ActionResult GetView1()
        {

            Demo p = new Demo();
            p.id = "PID1";
            p.name = "PName1";

            return View("../ProductInfo1", p);
        }


    }
}
