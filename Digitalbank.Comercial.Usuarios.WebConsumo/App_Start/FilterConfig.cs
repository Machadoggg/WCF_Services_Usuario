using System.Web;
using System.Web.Mvc;

namespace Digitalbank.Comercial.Usuarios.WebConsumo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
