using Mani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mani.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        private ManiEntities _db = new ManiEntities();
        public ActionResult Index()
        {
            List<Room> model = _db.Rooms.ToList();

            return View(model);
        }

        public ActionResult RoomDetail(int? id)
        {
            Room room = _db.Rooms.FirstOrDefault(r => r.RoomID == id);

            return View(room); 
        }

        
    }
}