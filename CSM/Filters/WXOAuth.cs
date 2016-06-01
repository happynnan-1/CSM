using System.Web.Http.Filters;
using System.Web.Mvc;

namespace CSM.Filters
{
    public class WXOAuth
    {
        public class OAuthAttribute : System.Web.Mvc.ActionFilterAttribute
        {
            public string OAuthType { get; set; }

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
                filterContext.HttpContext.Response.Write("Action执行之前验证" + OAuthType + "<br />");
            }

            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
                filterContext.HttpContext.Response.Write("Action执行之后验证" + OAuthType + "<br />");
            }

            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                base.OnResultExecuting(filterContext);
                filterContext.HttpContext.Response.Write("返回Result之前验证" + OAuthType + "<br />");
            }

            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                base.OnResultExecuted(filterContext);
                filterContext.HttpContext.Response.Write("返回Result之后验证" + OAuthType + "<br />");
            }
        }
    }
  
    
}