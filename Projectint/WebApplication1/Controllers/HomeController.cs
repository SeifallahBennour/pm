using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Helpers;
using System.Data.SqlClient;
using Service;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       Service.ServiceSpeciality servicespecialite;
       UserService Cs = new UserService();
        public HomeController()
        {
            servicespecialite = new Service.ServiceSpeciality();

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inscri()
        {
            return View();
        }
        public ActionResult SingIn()
        {
            return View();
        }
        public ActionResult Recherche()
        {
            return View();
        }

        // GET: Home/Home
        public ActionResult Home()
        {

            

            return View();
           
        }
        public ActionResult HomePatient()
        {
            return View();
        }

        public ActionResult HomeMembre()
        {
            return View();
        }
        public ActionResult HomeTleader()
        {
            return View();
        }

        public ActionResult HomeManager()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //public ActionResult Edit(int id)
        //{
        //    var cat = Cs.GetById(id);


        //    User cvm = new User();
        //    var userId = User.Identity.GetUserId();

        //    cvm.Id = Convert.ToInt32(userId);
        //    cvm.Email = cat.Email;
        //    cvm.firstName = cat.firstName;


        //    return View(cvm);

        //}

        //// POST: Category/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, User Cvm)
        //{
        //    User cvm = new User();
        //    var userId = User.Identity.GetUserId();
        //    Domain.Entities.User c  = Cs.GetById(id);

        //    c.Id = Convert.ToInt32(userId);
        //    c.Email = Cvm.Email;
        //    c.firstName = Cvm.firstName;
        //    Cs.Update(c);
        //    Cs.Commit();
        //    return RedirectToAction("Index");

        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LayoutPatient()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}