using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mani.ViewModels;

namespace Mani.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private ManiEntities _db = new ManiEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                Member member =
                    _db.Members.FirstOrDefault(m => m.UserName == model.UserName && m.PassWord == model.PassWord);
                if (member != null)
                {
                    //登入成功

                    //記起來
                    Session["UserName"] = model.UserName;
                    Session["memberID"] = member.MemberID;
                    Session["Name"] = member.Name;
                    Session["PhoneNumber"] = member.PhoneNumber;
                    Session["Email"] = member.Email;
                    Session["Address"] = member.Address ?? "";
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "帳號或密碼不正確");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Home/Index");
        }
    }
}