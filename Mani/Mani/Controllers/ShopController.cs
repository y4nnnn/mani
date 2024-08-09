using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mani.ViewModels;

namespace Mani.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        private ManiEntities _db = new ManiEntities();
        public ActionResult Index(int? id)
        {

            List<Product> model = _db.Products.ToList();

            return View(model);
        }

        public ActionResult ShopDetail(int? id)
        {
            Product product = _db.Products.FirstOrDefault(r => r.ProductID == id);


            Product currentProduct = _db.Products.FirstOrDefault(r => r.ProductID == id);

            
            var otherProducts = _db.Products
                                .Where(b => b.ProductID != id && b.ProductImg != currentProduct.ProductImg)
                                .OrderBy(b => Guid.NewGuid()) // 隨機排序
                                .Take(3)
                                .ToList();

            ViewBag.CurrentProduct = currentProduct;
            ViewBag.OtherProducts = otherProducts;

            return View(currentProduct);
        }

        public ActionResult ShoppingCartList()
        {
            //去session拿回購物車
            List<ShoppingItem> cart = (List<ShoppingItem>)Session["Cart"];

            if (cart == null)
            {
                cart = new List<ShoppingItem>();
            }

            return View(cart);
        }

        

        [HttpPost]
        public ActionResult AddToCart(ShoppingItem model)
        {
            //檢查有沒有購物車
            if (Session["Cart"] == null)
            {
                //沒有先準備一台空的
                Session["Cart"] = new List<ShoppingItem>();
            }
            //去session拿回購物車
            List<ShoppingItem> cart = (List<ShoppingItem>)Session["Cart"];

            //檢查商品是否已經在車內
            if (cart.Any(item => item.ProductID == model.ProductID))
            {
                //先取出該商品物件
                ShoppingItem exitProduct = cart.FirstOrDefault(c => c.ProductID == model.ProductID);

                //將數量做累加
                exitProduct.Amount += model.Amount;
            }
            else
            {
                //不在車內,直接加該商品
                cart.Add(model);
            }

            return RedirectToAction("ShoppingCartList");
        }

        public ActionResult SearchInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchInfo(OrderinfoViewModel model)
        {
            if (ModelState.IsValid)
            {

                var existingInfo = _db.Orders.Where(m => m.Name == model.Name && m.PhoneNumber == model.PhoneNumber && m.Email == model.Email)
                                            .OrderByDescending(m => m.CreatedDate)
                                            .FirstOrDefault();
                if (existingInfo != null)
                {
                    Session["Namee"] = model.Name;
                    Session["PhoneNumberrr"] = model.PhoneNumber;
                    Session["Emailll"] = model.Email;

                    var result = new { msg = "資料正確" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }


            }

            return View(model);

        }

        public ActionResult OrderDetail()
        {
            ManiEntities db = new ManiEntities();



            string Name = Session["Namee"] as string;
            string phoneNumber = Session["PhoneNumberrr"] as string;
            string email = Session["Emailll"] as string;

            var orders = db.Orders.Where(f => f.Name == Name &&
                                              f.PhoneNumber == phoneNumber &&
                                              f.Email == email)
                                .ToList();

            ViewBag.TotalPages = Math.Ceiling((double)orders.Count() / 10);
            ViewBag.CurrentPage = 1;
            return View(orders);
            //return View(db.Forms.Take(5).ToList());
        }

        public ActionResult ChangePage(int pageIndex)
        {

            ManiEntities db = new ManiEntities();
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 10;

            string Name = Session["Namee"] as string;
            string phoneNumber = Session["PhoneNumberrr"] as string;
            string email = Session["Emailll"] as string;

            var orders = db.Orders.Where(f => f.Name == Name &&
                                              f.PhoneNumber == phoneNumber &&
                                              f.Email == email)

                                  .ToList();

            ViewBag.TotalPages = Math.Ceiling((double)orders.Count() / 10);

            ViewBag.CurrentPage = pageIndex;

            return View("OrderDetail",orders.OrderBy(f => f.OrderID).Skip(offestNumbers).Take(10).ToList());
            //return View("OrderDetail",
            //    db.Orders.OrderBy(x => x.OrderID).Skip(offestNumbers).Take(10).ToList());
        }
    }
}