using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mani.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> imagePaths = new List<string>();

            // 圖片路徑
            string imagesFolderPath = Server.MapPath("~/images/cat");

            // 取得所有圖片
            string[] imageFiles = Directory.GetFiles(imagesFolderPath);

            // 將圖片轉為列表
            List<string> allImagePaths = imageFiles.Select(file => "~/Pic/cat/" + Path.GetFileName(file)).ToList();

            // 隨機選4張照片
            Random random = new Random();
            List<string> selectedImagePaths = allImagePaths.OrderBy(x => random.Next()).Take(4).ToList();

            // 圖片路徑放入ViewBag傳入
            ViewBag.ImagePaths = selectedImagePaths;

            return View();
        }
    }
}