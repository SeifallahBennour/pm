using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AmisController : Controller
    {
        AmisService Cs = new AmisService();
        // GET: Amis
        public ActionResult Index()
        {
            List<AmisVIewModel> List = new List<AmisVIewModel>();
            foreach (var item in Cs.GetAll())
            {
                AmisVIewModel Pvm = new AmisVIewModel();
                Pvm.AmisId = item.AmisId;
                Pvm.User1Id = item.User1Id;
                Pvm.user2Id =item.user2Id ;
                Pvm.Etat = item.Etat;
               
                List.Add(Pvm);
            }
            return View(List);
        }

        // GET: Amis/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Amis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amis/Create
        [HttpPost]
        public ActionResult Create(AmisVIewModel pvm)
        {

            //var c = Cs.GetAll();

            //foreach (var item in c)
            //{
            //    CategoryViewModel Cvm = new CategoryViewModel();
            //    Cvm.categoryname = item.categoryname;
            //    Cvm.categoryId = item.categoryId;

            //}


            var C = Cs.GetAll();

            foreach (var item in C)
            {
                AmisVIewModel Cvm = new AmisVIewModel();
                Cvm.User1Id = item.User1Id;
                Cvm.user2Id = item.user2Id;

            }


            ViewBag.cate = new SelectList(C, "user2Id", "user2Id");

            //ViewBag.cat = new SelectList(c, "categoryId", "categoryname");

        


            

            Amis p = new Amis();
            p.AmisId = pvm.AmisId;
            p.User1Id =Convert.ToInt32( Membership.GetUser().ProviderUserKey.ToString());
            p.user2Id = pvm.user2Id;
            p.Etat = "0";
            Cs.Add(p);
            Cs.Commit();

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Amis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Amis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Amis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Amis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
