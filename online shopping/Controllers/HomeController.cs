using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using online_shopping.Models;
namespace online_shopping.Controllers
{
    public class HomeController : Controller
    {

        Onlineshop db = new Onlineshop();
        [HttpGet]
        public ActionResult signUp()
        {

            return View();
        }
        [HttpPost]
        public ActionResult signUp(user us)
        {
            db.users.Add(us);
            db.SaveChanges();

            return RedirectToAction("login");
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(user login)
        {

            if (ModelState.IsValid)
            {
                Onlineshop db = new Onlineshop();
                var user = (from userlist in db.users
                            where userlist.Name == login.Name && userlist.password == login.password
                            select new
                            {
                                userlist.Id,
                                userlist.Name,
                                userlist.age,
                                userlist.email
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["Name"] = user.FirstOrDefault().Name;
                    Session["age"] = user.FirstOrDefault().age;
                    Session["email"] = user.FirstOrDefault().email;
                    Session["Id"] = user.FirstOrDefault().Id;
                    return Redirect("/home/profile");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }
        public ActionResult home()
        {

            List<product> st = db.products.Include(n => n.category).ToList();
            return View(st);

           
        }
        public ActionResult profile()
        {
            ViewData["id"] = @Session["Id"].ToString();

            ViewData["Name"] = @Session["Name"].ToString();
            ViewData["age"] = @Session["age"].ToString();
            ViewData["email"] = @Session["email"].ToString();



            return View();
        }
        public ActionResult Editeprofile(int id)
        {
            user s = db.users.FirstOrDefault(n => n.Id == id);
            ViewData["id"] = @Session["Id"].ToString();

            ViewData["Name"] = @Session["Name"].ToString();
            ViewData["age"] = @Session["age"].ToString();
            ViewData["email"] = @Session["email"].ToString();


            return View(s);
        }
        [HttpPost]
        public ActionResult Editeprofile(user s)
        {
            db.Entry(s).State = EntityState.Modified;
           user ss = db.users.FirstOrDefault(n => n.Id == s.Id);
            ss.Name = s.Name;
            ss.email = s.email;
            ss.password = s.password;
            ss.age = s.age;
            db.SaveChanges();

            return RedirectToAction("home");


            
        }

        public ActionResult changepassword(int id)
        {
            user s = db.users.FirstOrDefault(n => n.Id == id);
            ViewData["id"] = @Session["Id"].ToString();

            ViewData["Name"] = @Session["Name"].ToString();
            ViewData["age"] = @Session["age"].ToString();
            ViewData["email"] = @Session["email"].ToString();


            return View(s);
            
        }
        [HttpPost]
        public ActionResult changepassword(user s)
        {

            db.Entry(s).State = EntityState.Modified;
            user ss = db.users.FirstOrDefault(n => n.Id == s.Id);
            ss.Name = s.Name;
            ss.email = s.email;
            ss.password = s.password;
            ss.age = s.age;
            db.SaveChanges();

            return RedirectToAction("home");

           
        }


    }
}