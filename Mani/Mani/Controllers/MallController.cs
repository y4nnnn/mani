using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mani.Controllers
{
    public class MallController : Controller
    {
        // GET: Mall
        private ManiEntities _db = new ManiEntities();
        public ActionResult ProductOverview()
        {
            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Products.Count() / 5);
            ViewBag.CurrentPage = 1;

            return View(db.Products.Take(5).ToList());
        }
        public ActionResult ChangePage2(int pageIndex)
        {
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 5;

            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Products.Count() / 5);
            ViewBag.CurrentPage = pageIndex;

            return View("ProductOverview",
                db.Products.OrderBy(x => x.ProductID).Skip(offestNumbers).Take(5).ToList());
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product model, HttpPostedFileBase pImage)
        {
            //1.存檔案
            string path = Server.MapPath($@"\Pic\product\{pImage.FileName}");
            pImage.SaveAs(path);

            //2.存DB
            model.ProductImg = pImage.FileName;
            _db.Products.Add(model);
            _db.SaveChanges();

            return RedirectToAction("ProductOverview", "Mall");
        }

        public ActionResult EditProduct(int? id)
        {
            Product product = _db.Products.FirstOrDefault(x => x.ProductID == id);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product model, HttpPostedFileBase pImage)
        {
            Product oldData = _db.Products.FirstOrDefault(x => x.ProductID == model.ProductID);

            oldData.Type = model.Type;
            oldData.ProductName = model.ProductName;
            oldData.ProductPrice = model.ProductPrice;
            oldData.UnitInStock = model.UnitInStock;
            oldData.ProductDesc = model.ProductDesc;

            if (pImage != null)
            {
                //存檔案
                oldData.ProductImg = pImage.FileName;
                string path = Server.MapPath($@"\Pic\product\{pImage.FileName}");
                pImage.SaveAs(path);
            }

            //存DB
            _db.SaveChanges();

            return RedirectToAction("ProductOverview", "Mall");
        }

        public ActionResult DelProduct(int id)
        {
            Product product = _db.Products.FirstOrDefault(x => x.ProductID == id);

            _db.Products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction("ProductOverview", "Mall");
        }

        public ActionResult MallOrder()
        {
            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Orders.Count() / 5);
            ViewBag.CurrentPage = 1;

            ViewBag.TotalOrders = db.Orders.Count();

            ViewBag.Resolve = db.Orders.Where(o => o.Status == "已出貨").Count();

            ViewBag.Pending = db.Orders.Where(o => o.Status == "未出貨").Count();

            //var order = db.Orders.Take(5).ToList();
            var order = db.Orders.OrderBy(o => o.Status != "未出貨")
                                 .ThenBy(o => o.OrderID)
                                 .Take(5)
                                 .ToList();
            return View(order);
        }

        public ActionResult ChangePage(int pageIndex)
        {
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 5;

            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Orders.Count() / 5);
            ViewBag.CurrentPage = pageIndex;
            ViewBag.TotalOrders = db.Orders.Count();
            ViewBag.Resolve = db.Orders.Where(o => o.Status == "已出貨").Count();
            ViewBag.Pending = db.Orders.Where(o => o.Status == "未出貨").Count();

            var orders = db.Orders.OrderBy(o => o.Status != "未出貨")
                                 .ThenBy(o => o.OrderID)
                                 .Skip(offestNumbers)
                                 .Take(5)
                                 .ToList();

            return View("MallOrder", orders);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int orderId)
        {
            Order oldData = _db.Orders.FirstOrDefault(x => x.OrderID == orderId);

            if (oldData != null)
            {
                oldData.Status = "已出貨";
                _db.SaveChanges();
                return Json(new { msg = "更新成功" });
            }
            return View();
        }
    }
}