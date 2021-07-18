using Mog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mog.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult RegisterUser(int id = 0)
        {
            User u = new User();
            return View(u);
        }

        [HttpPost]
        public ActionResult RegisterUser(User u)
        {
            using (var _context = new ApplicationDbContext())
            {
                if (_context.Users.SingleOrDefault(x => x.Email == u.Email) != null)
                {
                    //user alredy exits
                }
                else
                {
                    //add user
                    _context.Users.Add(u);
                    _context.SaveChanges();
                }
            }

            if (ViewBag.Message != null)
            {
                ViewBag.Message = "hell";
            }
            return View(u);

        }

        [HttpGet]
        public ActionResult RegisterAdmin(int id = 0)
        {
            BranchAdmin b = new BranchAdmin();
            return View(b);
        }

        [HttpPost]
        public ActionResult RegisterAdmin(BranchAdmin u)
        {
        


            using (var _context = new ApplicationDbContext())
            {
                if (_context.BranchAdmins.SingleOrDefault(x => x.Email == u.Email) != null)
                {
                    //branch admin alredy exits
                }
                else
                {
                    //add branch admin
                    _context.BranchAdmins.Add(u);
                    _context.SaveChanges();
                }
            }
            //ViewBag.Title("Hell");
            return View(u);

        }
    }
}