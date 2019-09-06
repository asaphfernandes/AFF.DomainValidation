using System.Web;
using System.Web.Mvc;

namespace AFF.DomainValidation.AspNet472Example
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
