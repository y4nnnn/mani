using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Mani.ViewModels;

namespace Mani.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        private ManiEntities _db = new ManiEntities();
        public ActionResult Form()
        {
            ViewBag.RoomList = new SelectList(_db.Rooms, "RoomName", "RoomName");

            return View();
        }

        [HttpPost]
        public ActionResult Form(FormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newForm = new Form
                {
                    CheckIn = model.CheckIn,
                    CheckOut = model.CheckOut,
                    CatsName = model.CatsName,
                    OwnerName = model.OwnerName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    RoomName = model.RoomName,
                    CatsNum = model.CatsNum,
                    CreatedDate = DateTime.Now,
                    Status = "未入住"

                };

                
                _db.Forms.Add(newForm);
                _db.SaveChanges(); // 保存變更到資料庫

                var result = new { msg = "訂房成功" };
                
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View(model);
        }

        public ActionResult SearchInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchInfo(SearchinfoViewModel model)
        {
            if (ModelState.IsValid)
            {

                var existingInfo = _db.Forms.Where(m => m.OwnerName == model.OwnerName && m.PhoneNumber == model.PhoneNumber && m.Email == model.Email)
                                            .OrderByDescending(m => m.CreatedDate)
                                            .FirstOrDefault();
                if (existingInfo != null)
                {
                    Session["OwnerNamee"] = model.OwnerName;
                    Session["PhoneNumberr"] = model.PhoneNumber;
                    Session["Emaill"] = model.Email;

                    var result = new { msg = "資料正確" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }


            }

            return View(model);

        }


        public ActionResult FormDetail()
        {
            ManiEntities db = new ManiEntities();



            string ownerName = Session["OwnerNamee"] as string;
            string phoneNumber = Session["PhoneNumberr"] as string;
            string email = Session["Emaill"] as string;

            var forms = db.Forms.Where(f => f.OwnerName == ownerName &&
                                            f.PhoneNumber == phoneNumber &&
                                            f.Email == email)
                                .ToList();

            ViewBag.TotalPages = Math.Ceiling((double)forms.Count() / 10);
            ViewBag.CurrentPage = 1;
            return View(forms);
            //return View(db.Forms.Take(5).ToList());
        }

        public ActionResult ChangePage(int pageIndex)
        {
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 10;

            ManiEntities db = new ManiEntities();

            string ownerName = Session["OwnerNamee"] as string;
            string phoneNumber = Session["PhoneNumberr"] as string;
            string email = Session["Emaill"] as string;

            var forms = db.Forms.Where(f => f.OwnerName == ownerName &&
                                            f.PhoneNumber == phoneNumber &&
                                            f.Email == email)
                                .ToList();

            ViewBag.TotalPages = Math.Ceiling((double)forms.Count() / 10);
            ViewBag.CurrentPage = pageIndex;

            return View("FormDetail",
                forms.OrderBy(x => x.FormID).Skip(offestNumbers).Take(10).ToList());
        }
    }
}