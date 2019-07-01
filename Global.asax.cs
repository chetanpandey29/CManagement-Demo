using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CentralAcademy
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(DateTime?), new MyDateTimeModelBinder());
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-in");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-in");

            HttpCookie decryptedCookie =
               Request.Cookies[FormsAuthentication.FormsCookieName];

            if (decryptedCookie != null)
            {
                FormsAuthenticationTicket ticket =
                   FormsAuthentication.Decrypt(decryptedCookie.Value);

                var identity = new GenericIdentity(ticket.Name);
                var principal = new GenericPrincipal(identity, null);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = HttpContext.Current.User;
            }

          //  if (!Request.Url.ToString().Contains("/Content/") && !Request.Url.ToString().Contains("/Scripts/") && !Request.Url.ToString().Contains("/fonts/") && !Request.Url.ToString().Contains("Account/InvalidLicence"))
            //    Utilities.LicenseCheck();
        }
    }
}