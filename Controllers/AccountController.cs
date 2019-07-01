using CAS_MVC_4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CentralAcademy.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return RedirectToAction("SignIn");
        }

        public ActionResult SignIn()
        {
           // License lic = new License();
           // if (!lic.Check())
           // {
           //     return RedirectToAction("install", "license");
           //}
            return View();
        }
        public string GetHash(string id)
        {
            Response.ContentType = "text/plain";
            return PasswordHash.CreateHash(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(MyModels.AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CentralAcademyContext())
                {
                    var _user = db.AdminLogins.Where(m => m.Username.Equals(model.UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                    if (_user == null || !PasswordHash.ValidatePassword(model.Password, _user.Password))
                    {
                        ViewBag.Error = 1;
                    }
                    else
                    {
                        IssueAuthTicket(model.UserName, model.RememberMe);
                        if (string.IsNullOrWhiteSpace(Request.QueryString["ReturnUrl"]))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return Redirect(Request.QueryString["ReturnUrl"]);
                        }
                    }
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", new { signout = 1 });
        }

        public ActionResult InvalidLicence()
        {
            return View();
        }

        private void IssueAuthTicket(string userData, bool rememberMe)
        {
            FormsAuthenticationTicket ticket =
                new FormsAuthenticationTicket(1, userData,
                    DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout),
                    rememberMe, userData);

            string ticketString = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie =
              new HttpCookie(FormsAuthentication.FormsCookieName, ticketString);
            if (rememberMe)
                cookie.Expires = DateTime.Now.AddDays(10);

            HttpContext.Response.Cookies.Add(cookie);
        }

    }

    public class License
    {
        public string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CMS");
        public string fileName = "ftpCheck.txt";

        public bool Check ()
        {
            bool isFileExist = false;
            bool isLicenseValid = false;

            isFileExist = File.Exists(Path.Combine(directory, fileName));

            if (isFileExist)
            {
                WebClient wc = new WebClient();
                string response = string.Empty;
                var fileLines = File.ReadAllLines(Path.Combine(directory, fileName));
                if (fileLines.Length != 2)
                    throw new Exception("License file is Invalid");

                try { response = wc.DownloadString(string.Format("http://www.myignou.com/We/ValidateKey?productKey={0}&randomKey={1}", fileLines[0], fileLines[1])); }
                catch { }
                int responseCode = 0;
                int.TryParse(response, out responseCode);
                if (responseCode != 0)
                {
                    switch (responseCode)
                    {
                        case 101:
                            // Key Not Found
                            break;
                        case 102:
                            // Key Expired
                            break;
                        case 103:
                            // OK
                            isLicenseValid = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isLicenseValid = true;
                }
            }

            return isFileExist && isLicenseValid;
        }

        public bool Install(string productKey)
        {
            int response = 0;

            WebClient wc = new WebClient();
            try
            {
                string strResponse = wc.DownloadString(string.Format("http://www.myignou.com/We/InstallKey?productKey={0}", productKey));
                
                response = int.Parse(strResponse);
                if (response == 102)
                {
                    Directory.CreateDirectory(directory);
                    File.WriteAllLines(Path.Combine(directory, fileName), new[] { productKey, Guid.NewGuid().ToString() });
                }
            }
            catch { response = 0; }

            return response == 102 ? true : false;
        }
    }
}
