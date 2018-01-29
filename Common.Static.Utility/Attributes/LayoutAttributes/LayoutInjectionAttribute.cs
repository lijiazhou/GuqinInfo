using System.Web.Mvc;

namespace Common.Static.Utility.Attributes
{
    public class LayoutInjectionAttribute : ActionFilterAttribute
    {
        private readonly string _masterName;
        public LayoutInjectionAttribute(string masterName)
        {
            _masterName = masterName;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.MasterName = _masterName;
            }
        }
    }
}
