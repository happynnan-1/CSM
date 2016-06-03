﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CSM.Controllers.QY
{
    public class QYController : Controller
    {
        //
        // GET: /QY/

        public ActionResult Taskinfor(string guid,string strTaskId)
        {
            Models.DB mdb = new Models.DB();

            //任务单号
            var taskList = mdb.Search<Models.TaskInfo>(i => i.TaskID.Trim() == strTaskId);

           // var taskList = mdb.all<Models.TaskInfo>();

            var result = from a in taskList
                         join b in mdb.all<Models.Productinfo>() on a.ProductID.Trim() equals b.ProductID.Trim()
                         join c in mdb.all<Models.TaskAssign>() on a.TaskID.Trim() equals c.TaskID.Trim()
                         select new Models.ViewModelTaskInfo
                         {
                             TaskID = a.TaskID,
                             ProductName = b.Name,                           
                             CustomerName = a.ContactName,
                             Remark = a.Remark,
                             Phone = a.Phone,
                             Content = a.Content,
                             AssignID = c.AssignID
                         };

            return View("Taskinfor", result);
        }

        private IEnumerable<Models.Customer> ShowList()
        {
            Models.DB mdb = new Models.DB(); 

            return mdb.all<Models.Customer>();
        }

        /// <summary>
        /// 接受任务
        /// </summary>
        /// <param name="AssignID"></param>
        /// <returns></returns>
        public ActionResult AcceptService(string AssignID)
        {
            Models.DB mdb = new Models.DB();


            var searchTa = mdb.Search<Models.TaskAssign>(i => i.AssignID == AssignID);

            var result = searchTa.FirstOrDefault<Models.TaskAssign>();
            if(result!=null)
                    result.TaskStatus = "1";
           
            bool flag =  mdb.update<Models.TaskAssign>(result);

            return RedirectToAction("ServiceTime");
        }


        /// <summary>
        /// 拒绝任务
        /// </summary>
        /// <param name="AssignID"></param>
        /// <returns></returns>
        public ActionResult RepulseService(string AssignID)
        {
            Models.DB mdb = new Models.DB();


            var searchTa = mdb.Search<Models.TaskAssign>(i => i.AssignID == AssignID);

            var result = searchTa.FirstOrDefault<Models.TaskAssign>();
            if (result != null)
                result.TaskStatus = "2";

            bool flag = mdb.update<Models.TaskAssign>(result);

            return RedirectToAction("Taskinfor");
        }



        public ActionResult ServiceTime(string AssignId)
        {


            return View();
        }

        /// <summary>
        /// 返回JSON
        /// </summary>
        /// <returns></returns>
        public JsonResult GetData()
        {
            Models.DB mdb = new Models.DB();

            var result = mdb.all<Models.Customer>();

            var res = new JsonResult();

            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            res.Data = result;

            return res;
            

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
