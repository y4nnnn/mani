using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mani.Controllers
{
    public class HostelController : Controller
    {
        // GET: Hostel
        private ManiEntities _db = new ManiEntities();
        public ActionResult RoomOverview()
        {
            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Rooms.Count() / 3);
            ViewBag.CurrentPage = 1;

            return View(db.Rooms.Take(3).ToList());
        }
        public ActionResult ChangePage2(int pageIndex)
        {
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 3;

            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Rooms.Count() / 3);
            ViewBag.CurrentPage = pageIndex;

            return View("RoomOverview",
                db.Rooms.OrderBy(x => x.RoomID).Skip(offestNumbers).Take(3).ToList());
        }

        public ActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRoom(Room model, HttpPostedFileBase pImage)
        {
            //1.存檔案
            string path = Server.MapPath($@"\Pic\room\{pImage.FileName}");
            pImage.SaveAs(path);

            //2.存DB
            model.RoomImg = pImage.FileName;
            _db.Rooms.Add(model);
            _db.SaveChanges();

            return RedirectToAction("RoomOverview", "Hostel");
        }

        public ActionResult EditRoom(int? id)
        {
            Room room = _db.Rooms.FirstOrDefault(x => x.RoomID == id);

            return View(room);
        }

        [HttpPost]
        public ActionResult EditRoom(Room model, HttpPostedFileBase pImage)
        {
            Room oldData = _db.Rooms.FirstOrDefault(x => x.RoomID == model.RoomID);

            oldData.Type = model.Type;
            oldData.RoomName = model.RoomName;
            oldData.RoomSize = model.RoomSize;
            oldData.CatsLimit = model.CatsLimit;
            oldData.SunTime = model.SunTime;
            oldData.OverTime = model.OverTime;
            oldData.AddCats = model.AddCats;
            oldData.Price = model.Price;
            oldData.RoomDesc = model.RoomDesc;

            if (pImage != null)
            {
                //存檔案
                oldData.RoomImg = pImage.FileName;
                string path = Server.MapPath($@"\Pic\room\{pImage.FileName}");
                pImage.SaveAs(path);
            }

            //存DB
            _db.SaveChanges();

            return RedirectToAction("RoomOverview", "Hostel");
        }

        public ActionResult DelRoom(int id)
        {
            Room room = _db.Rooms.FirstOrDefault(x => x.RoomID == id);

            _db.Rooms.Remove(room);
            _db.SaveChanges();

            return RedirectToAction("RoomOverview", "Hostel");
        }

        public ActionResult RoomOrder()
        {
            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Forms.Count() / 5);
            ViewBag.CurrentPage = 1;

            ViewBag.TotalOrders = db.Forms.Count();

            ViewBag.Resolve = db.Forms.Where(o => o.Status == "已入住").Count();

            ViewBag.Pending = db.Forms.Where(o => o.Status == "未入住").Count();

            var order = db.Forms.OrderBy(o => o.Status != "未入住")
                                .ThenBy(o => o.FormID)
                                .Take(5)
                                .ToList();
            return View(order);
        }

        public ActionResult ChangePage(int pageIndex)
        {
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 5;

            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Forms.Count() / 5);
            ViewBag.CurrentPage = pageIndex;
            ViewBag.TotalOrders = db.Forms.Count();
            ViewBag.Resolve = db.Forms.Where(o => o.Status == "已入住").Count();
            ViewBag.Pending = db.Forms.Where(o => o.Status == "未入住").Count();

            var orders = db.Forms.OrderBy(o => o.Status != "未入住")
                                .ThenBy(o => o.FormID)
                                .Skip(offestNumbers)
                                .Take(5)
                                .ToList();

            return View("RoomOrder", orders);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int formId)
        {
            Form oldData = _db.Forms.FirstOrDefault(x => x.FormID == formId);

            if (oldData != null)
            {
                oldData.Status = "已入住";
                _db.SaveChanges();
                return Json(new { msg = "更新成功" });
            }
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Calendar2()
        {
            List<Form> eventsList = new List<Form>();

            using (var dbContext = new ManiEntities()) 
            {
                eventsList = dbContext.Forms
                    .Where(e => e.Status == "未入住")
                    .ToList();
            }

            return Json(eventsList.Select(e => new {
                id = e.FormID.ToString(),
                start = e.CheckIn,
                end = e.CheckOut,
                title = e.CatsName,
                color = "#1221ba"  
            }), JsonRequestBehavior.AllowGet);
        }
    }
}