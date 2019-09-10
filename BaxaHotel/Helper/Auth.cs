using BaxaHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BaxaHotel.Helper
{
    public class Auth:ActionFilterAttribute
    {
        private BaxaHotelContext context;
        public Auth()
        {
            context = new BaxaHotelContext();
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Request.Headers["token"] == null)
            {
                filterContext.Result = new RedirectResult("/login");
                return;
            }
        }
    }
}