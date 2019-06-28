using online_shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.Web.Mvc;

namespace online_shopping.Controllers
{
    public class adminController : Controller
    {
        Onlineshop db = new Onlineshop();

        public ActionResult login(user login)
        {

            if ("admin" == login.Name && "123" == login.password)
            {
                return Redirect("/admin/addcategory");

            }
            else
            {
                ModelState.AddModelError("", "Invalid login credentials.");

            }
            return View(login);
        }

        public ActionResult addproduct()
        {
            return View();
        }
        public ActionResult addcategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addcategory(category ca)
        {
            db.categories.Add(ca);
            db.SaveChanges();

            return RedirectToAction("addproduct");
        }

        public ActionResult showuser()
        {
            List<user> st = db.users.ToList();
            return View(st);
           
        }

        public ActionResult delete(int id)
        {
            user s = db.users.FirstOrDefault(n => n.Id == id);
            db.users.Remove(s);
            db.SaveChanges();
            return RedirectToAction("showuser");
        }


    }
}