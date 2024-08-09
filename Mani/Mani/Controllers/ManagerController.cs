using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mani.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        private ManiEntities _db = new ManiEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Manager model)
        {

            if (ModelState.IsValid)
            {
                Manager manager =
                    _db.Managers.FirstOrDefault(m => m.UserName == model.UserName && m.PassWord == model.PassWord);
                if (manager != null)
                {
                    //登入成功

                    //記起來
                    Session["UserName2"] = model.UserName;
                    Session["ManagerID"] = manager.ManagerID;
                    Session["ManagerImg"] = manager.ManagerImg;
                    Session["level"] = manager.level;

                    return RedirectToAction("Index", "Backend");
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
            return RedirectToAction("Login", "Manager");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Manager model)
        {
            var existingManager = _db.Managers.FirstOrDefault(m => m.UserName == model.UserName);
            if (existingManager != null)
            {
                ModelState.AddModelError("UserName", "用戶名已存在。");
                return View(); 
            }
            //2.存DB
            model.CreatedDate = DateTime.Now;
            model.Status = "正常";
            model.ManagerImg = "manager.png";
            model.level = 2;
            _db.Managers.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index", "Backend");
        }

        public ActionResult ManagerOverview()
        {
            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Managers.Count() / 5);
            ViewBag.CurrentPage = 1;
            ViewBag.TotalManagers = db.Managers.Count();

            return View(db.Managers.Take(5).ToList());
        }

        public ActionResult ChangePage(int pageIndex)
        {
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 5;

            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Managers.Count() / 5);
            ViewBag.CurrentPage = pageIndex;
            ViewBag.TotalManagers = db.Managers.Count();

            return View("ManagerOverview",
                db.Managers.OrderBy(x => x.ManagerID).Skip(offestNumbers).Take(5).ToList());
        }

        public ActionResult EditManager(int? id)
        {
            Manager manager = _db.Managers.FirstOrDefault(x => x.ManagerID == id);

            return View(manager);
        }

        [HttpPost]
        public ActionResult EditManager(Manager model, HttpPostedFileBase pImage)
        {
            Manager oldData = _db.Managers.FirstOrDefault(x => x.ManagerID == model.ManagerID);

            oldData.Name = model.Name;
            oldData.PhoneNumber = model.PhoneNumber;

            if (pImage != null)
            {

                oldData.ManagerImg = pImage.FileName;
                //存檔案
                string path = Server.MapPath($@"\Pic\manager\{pImage.FileName}");
                pImage.SaveAs(path);
            }

            //存DB
            _db.SaveChanges();

            return RedirectToAction("ManagerOverview", "Manager");
        }

        public ActionResult DelManager(int id)
        {
            Manager manager = _db.Managers.FirstOrDefault(x => x.ManagerID == id);

            _db.Managers.Remove(manager);
            _db.SaveChanges();

            return RedirectToAction("ManagerOverview", "Manager");
        }

        [HttpPost]
        public ActionResult UpdateStatus(int managerId)
        {
            Manager oldData = _db.Managers.FirstOrDefault(x => x.ManagerID == managerId);

            if (oldData != null)
            {
                oldData.PassWord += "erR";
                oldData.Status = "異常";
                _db.SaveChanges();
                return Json(new { msg = "更新成功" });
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateStatus2(int managerId)
        {
            Manager oldData = _db.Managers.FirstOrDefault(x => x.ManagerID == managerId);

            if (oldData != null)
            {
                oldData.PassWord = oldData.PassWord.TrimEnd('e', 'r', 'R').TrimEnd();
                oldData.Status = "正常";
                _db.SaveChanges();
                return Json(new { msg = "更新成功" });
            }
            return View();
        }

        public ActionResult ForgerPWD()
        {

            return View();
        }
    }
}