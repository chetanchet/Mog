using Mog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mog.Controllers
{
    public class AdminController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        [HttpGet]
        public ActionResult Index()
        {
            using (var _context = new ApplicationDbContext())
            {
                var userList = _context.BranchAdmins.Where(x=>!x.IsApproved).ToList();
                return View(userList);
            }
            return View();
        }

        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var admin = db.BranchAdmins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            admin.IsApproved = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var admin = db.BranchAdmins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            db.BranchAdmins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}