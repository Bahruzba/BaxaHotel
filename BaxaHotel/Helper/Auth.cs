using BaxaHotel.Data;
using BaxaHotel.Models;
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

            if (HttpContext.Current.Request.Cookies["token"] == null)
            {
                string token = HttpContext.Current.Request.Cookies["token"].ToString();
                User user = context.Users.FirstOrDefault(u=>u.Token==token);
                if (user == null)
                {
                    filterContext.Result = new RedirectResult("/login");
                    return;
                }
            }
        }
    }
}