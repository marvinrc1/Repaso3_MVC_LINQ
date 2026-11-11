using System.Web;
using System.Web.Mvc;

namespace Repaso3_MVC_LINQ
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
