using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentralAcademy.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GenerateBackup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateBackup(string nothing)
        {
            string sqlCommand = "USE CentralAcademy BACKUP DATABASE CentralAcademy TO DISK = 'D:\\CAS_New_DatabaseBackup\\Backup " + DateTime.Now.ToString("yyyy.mm.dd hh.mm.ss") + ".bak' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of CentralAcademy'";
            SqlCommand com = new SqlCommand(sqlCommand, new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CentralAcademyContext"].ConnectionString));
            try
            {
                com.Connection.Open();
                com.ExecuteNonQuery();
                com.Connection.Close();
                ViewBag.Success = "1";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            finally
            {
                com.Connection.Close();
            }

            
            return View();
        }
    }
}
