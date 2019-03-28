using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Helpers;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       Service.ServiceSpeciality servicespecialite;
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