using Mani.Models;
using Mani.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Mani.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        private ManiEntities _db = new ManiEntities();
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 在這裡可以加入進一步的驗證邏輯，例如檢查密碼強度、確認密碼等

                // 檢查用戶名是否已經存在
                var existingMember = _db.Members.FirstOrDefault(m => m.UserName == model.UserName);
                if (existingMember != null)
                {
                    //var results = new { msg = "該用戶名已經被使用。請選擇另一個用戶名" };
                    return View(model);
                    //ModelState.AddModelError("UserName", "該用戶名已經被使用。請選擇另一個用戶名。");
                    //return View(model);
                }

                //創建新的Member對象並將表單提交的資料賦值給它
                var newMember = new Member
                {
                    UserName = model.UserName,
                    PassWord = model.PassWord,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    CreatedDate = DateTime.Now,
                    Status = "正常"
                };

                _db.Members.Add(newMember);
                _db.SaveChanges(); // 保存變更到資料庫

                var result = new { msg = "註冊成功" };
                // 註冊成功後，跳轉頁面
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return View(model);

        }

        public ActionResult MemberInfo(int? id)
        {
            Member member = _db.Members.FirstOrDefault(x => x.MemberID == id);

            return View(member);
        }

        public ActionResult MemberEdit(int? id)
        {
            Member member = _db.Members.FirstOrDefault(x => x.MemberID == id);

            return View(member);
        }

        [HttpPost]
        public ActionResult MemberEdit(Member model)
        {
            Member oldData = _db.Members.FirstOrDefault(x => x.MemberID == model.MemberID);

            oldData.UserName = model.UserName;
            oldData.PassWord = model.PassWord;
            oldData.Name = model.Name;
            oldData.PhoneNumber = model.PhoneNumber;
            oldData.Email = model.Email;

            _db.SaveChanges();

            return RedirectToAction("MemberInfo", new { id = model.MemberID });
        }

        public ActionResult CheckOut(int? id)
        {
            // 從 Session 中獲取會員 ID
            int? memberId = Session["memberID"] as int?;

            // 建立一個空的 MemberViewModel
            MemberViewModel memberInfo = new MemberViewModel();

            if (memberId != null)
            {
                // 如果Session中有會員ID，從資料庫查找會員資料
                Member member = _db.Members.FirstOrDefault(x => x.MemberID == memberId);

                if (member != null)
                {
                    // 將會員資料加入 MemberViewModel 中
                    memberInfo.Name = member.Name;
                    memberInfo.PhoneNumber = member.PhoneNumber;
                    memberInfo.Email = member.Email;
                    memberInfo.Address = member.Address ?? "";


                }
            }

            // 建立 CheckOutViewModel 
            var viewModel = new CheckOutViewModel
            {
                MemberInfo = memberInfo,
            };

            List<ShoppingItem> cart = (List<ShoppingItem>)Session["Cart"];
            decimal subtotal = cart.Sum(item => item.Amount * item.ProductPrice);
            decimal delivery = 60;
            decimal discount = subtotal > 1000 ? 60 : 0;

            ViewBag.Subtotal = subtotal;
            ViewBag.Delivery = delivery;
            ViewBag.Discount = discount;
            ViewBag.Total = subtotal + delivery - discount;

            return View(viewModel);
        }



        [HttpPost]
        public ActionResult CheckOut(CheckOutViewModel viewModel)
        {
            var total = viewModel.Total;

            List<ShoppingItem> cart = (List<ShoppingItem>)Session["Cart"];

            string orderProducts = string.Join(", ", cart.Select(item => $"{item.ProductName}*{item.Amount}"));

            Order newOrder = new Order
            {

                Name = viewModel.MemberInfo.Name,
                PhoneNumber = viewModel.MemberInfo.PhoneNumber,
                Email = viewModel.MemberInfo.Email,
                Address = viewModel.MemberInfo.Address,
                //Price = viewModel.Total.ToString(),
                Price = viewModel.Total,
                OrderProduct = orderProducts,
                CreatedDate = DateTime.Now,
                Status = "未出貨"
            };

            foreach (var item in cart)
            {
                var product = _db.Products.Find(item.ProductID);
                if (product != null)
                {
                    // 減去購買數量
                    product.UnitInStock -= item.Amount;
                }
            }

            int? memberId = Session["memberID"] as int?;

            if (memberId != null)
            {
                Member member = _db.Members.FirstOrDefault(x => x.MemberID == memberId);

                if (member != null)
                {
                    // 更新會員的地址信息
                    member.Address = viewModel.MemberInfo.Address; 

                }
            }

            _db.Orders.Add(newOrder);
            _db.SaveChanges();

            Session["Cart"] = null;

            return RedirectToAction("Index", "Home"); 
        }

        public ActionResult MemberOverview()
        {
            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Members.Count() / 5);
            ViewBag.CurrentPage = 1;
            ViewBag.TotalMembers = db.Members.Count();

            return View(db.Members.Take(5).ToList());
        }
        public ActionResult ChangePage(int pageIndex)
        {
            //要忽略的筆數 page2=>10  page3=>20
            int offestNumbers = (pageIndex - 1) * 5;

            ManiEntities db = new ManiEntities();

            ViewBag.TotalPages = Math.Ceiling((double)db.Members.Count() / 5);
            ViewBag.CurrentPage = pageIndex;
            ViewBag.TotalMembers = db.Members.Count();

            return View("MemberOverview",
                db.Members.OrderBy(x => x.MemberID).Skip(offestNumbers).Take(5).ToList());
        }

        [HttpPost]
        public ActionResult UpdateStatus(int memberId)
        {
            Member oldData = _db.Members.FirstOrDefault(x => x.MemberID == memberId);

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
        public ActionResult UpdateStatus2(int memberId)
        {
            Member oldData = _db.Members.FirstOrDefault(x => x.MemberID == memberId);

            if (oldData != null)
            {
                oldData.PassWord = oldData.PassWord.TrimEnd('e', 'r', 'R').TrimEnd();
                oldData.Status = "正常";
                _db.SaveChanges();
                return Json(new { msg = "更新成功" });
            }
            return View();
        }

        public ActionResult ForgetPWD(Member model)
        {
            if (ModelState.IsValid)
            {
                Member member = _db.Members.FirstOrDefault(m => m.UserName == model.UserName && m.Email == model.Email && m.PhoneNumber == model.PhoneNumber);

                if (member != null)
                {
                    SendPasswordEmail(member.Email, member.PassWord);

                    var result = new { msg = "資料正確，密碼已發送" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
        }

        private void SendPasswordEmail(string email, string password)
        {
            MailMessage msg = new MailMessage();

            msg.To.Add(email);
            msg.From = new MailAddress("demotzengyu@outlook.com", "Mani'Garden", System.Text.Encoding.UTF8);

            msg.Subject = "您的密碼為:";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = $"您的密碼是：{password}"; // 
            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("demotzengyu@outlook.com", "bq3rb5l10");
            smtpClient.EnableSsl = true;

            smtpClient.Send(msg);


        }
    }
}