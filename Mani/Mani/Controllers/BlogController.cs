using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mani.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private ManiEntities _db = new ManiEntities();
        public ActionResult Blog()
        {
            List<Blog> model = _db.Blogs.ToList();



            return View(model);
        }

        public ActionResult BlogDetail(int? id)
        {
            

            Blog currentBlog = _db.Blogs.FirstOrDefault(r => r.BlogID == id);


            // 隨機選取三個不同於目前Blog的Blog
            var otherBlogs = _db.Blogs
                                .Where(b => b.BlogID != id && b.BlogImg != currentBlog.BlogImg)
                                .OrderBy(b => Guid.NewGuid()) // 隨機排序
                                .Take(3)
                                .ToList();

            ViewBag.CurrentBlog = currentBlog;
            ViewBag.OtherBlogs = otherBlogs;

            return View(currentBlog);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog model, HttpPostedFileBase pImage)
        {
            string path = Server.MapPath($@"\Pic\blog\{pImage.FileName}");
            pImage.SaveAs(path);

            model.BlogImg = pImage.FileName;
            model.CreatedDate = DateTime.Now;
            _db.Blogs.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Blog", "Blog"); // 存檔後跳轉
        }

        public ActionResult Edit(int? id)
        {
            Blog blog = _db.Blogs.FirstOrDefault(x => x.BlogID == id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult Edit(Blog model)
        {
            Blog oldData = _db.Blogs.FirstOrDefault(x => x.BlogID == model.BlogID);

            oldData.BlogTitle = model.BlogTitle;
            oldData.BlogContent = model.BlogContent;


            _db.SaveChanges();

            return RedirectToAction("Blog", "Blog");
        }
    }
}