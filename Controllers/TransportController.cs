using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CAS_MVC_4.Models;
using CentralAcademy.MyModels;

namespace CentralAcademy.Controllers
{
    [Authorize]
    public class TransportController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("TransportDetail");
        }

        [HttpGet]
        public ActionResult TransportDetail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TransportDetail(MyModels.TransportDetail m)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CentralAcademyContext())
                {
                    var f = new CAS_MVC_4.Models.TransportDetail()
                    {
                        Type = m.Type,
                        ContactNumber = m.ContactNumber,
                        DriverName = m.DriverName,
                        VehicleNumber = m.VehicleNumber,
                        UpdatedOn = DateTime.Now
                    };
                    db.TransportDetails.Add(f);
                    db.SaveChanges();
                    return RedirectToAction("TransportDetail", new { save = "1" });
                }
            }
            return View(m);
        }

        [HttpGet]
        public ActionResult Allocation(string scholar)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Allocation(MyModels.TransportAllocation m)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CentralAcademyContext())
                {
                    var student = db.Students.Where(s => s.ScholarNumber == m.ScholarNumber).FirstOrDefault();
                    if (student != null)
                    {
                        db.TransportAllocations.Add(new CAS_MVC_4.Models.TransportAllocation
                        {
                            LeftDate = m.LeftDate,
                            ScholarNumber = m.ScholarNumber,
                            StartDate = m.StartDate,
                            Type = m.Type,
                            SourceLocation = m.SourceLocation
                        });

                        db.SaveChanges();

                        return RedirectToAction("Allocation", new { scholar = student.ScholarNumber, Success = "Tranport Allocation Successful" });
                    }
                    else
                    {
                        
                    }
                }
            }
            else
            {
                return RedirectToAction("Allocation", new { scholar = m.ScholarNumber, Error = "There were error in Date format. Valid date format is dd-mm-yyyy" });
            }

            return View(m);
        }

        public ActionResult AdvanceSearch(CentralAcademy.MyModels.TransportSearch model1)
        {

            return View(model1);
        }

        public ActionResult Deallocate(string scholarNumber, string leftDate)
        {
            int _scholarNumber = int.Parse(scholarNumber);

            DateTime _dt = new DateTime();

            if (!DateTime.TryParseExact(leftDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out _dt))
            {
                return RedirectToAction("Allocation", new { scholar = scholarNumber, Error = "Invalid Left Date Format. Format Should be dd-mm-yyyy" });
            }
            else
            {
                using (var db = new CentralAcademyContext())
                {
                    var trans = db.TransportAllocations.Where(s => s.ScholarNumber == _scholarNumber).OrderBy(s => s.StartDate).ToList().Last(s => true);
                    trans.LeftDate = _dt;
                    db.SaveChanges();
                    return RedirectToAction("Allocation", new { scholar = scholarNumber, Success = "Tranport Deallocation Successful." });
                }
            }
        }
    }
}
