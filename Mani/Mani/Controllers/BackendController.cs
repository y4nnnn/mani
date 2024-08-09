using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Mani.Controllers
{
    public class BackendController : Controller
    {
        // GET: Backend
        private ManiEntities _db = new ManiEntities();
        public ActionResult Index()
        {
            //if (Session["ManagerID"] == null)
            //{
            //    return RedirectToAction("Login", "Manager");
            //}

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            using (var db = new ManiEntities())
            {

                ViewBag.TotalMembers = db.Members.Count();

                decimal totalPriceThisMonth =
                    db.Orders
                      .Where(o => o.CreatedDate >= firstDayOfMonth && o.CreatedDate <= lastDayOfMonth)
                      .Sum(o => o.Price);

                int totalMemberThisMonth =
                    db.Members.Count(s => s.CreatedDate >= firstDayOfMonth && s.CreatedDate <= lastDayOfMonth);

                ViewBag.TotalPriceThisMonth = totalPriceThisMonth;
                ViewBag.TotalMemberThisMonth = totalMemberThisMonth;
            }
            
            return View();
        }
    }
}