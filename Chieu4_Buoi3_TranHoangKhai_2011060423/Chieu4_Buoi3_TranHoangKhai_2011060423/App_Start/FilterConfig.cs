using System.Web;
using System.Web.Mvc;

namespace Chieu4_Buoi3_TranHoangKhai_2011060423
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
