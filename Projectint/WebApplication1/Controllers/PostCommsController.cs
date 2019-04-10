using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PostCommsController : Controller
    {
        PostCommmService Cs = new PostCommmService();
        PostCommViewModel Pvm = new PostCommViewModel();

        // GET: PostComms
        public ActionResult Index()
        {
            List<PostCommViewModel> List = new List<PostCommViewModel>();
            foreach (var item in Cs.ListPostId())
            {

                PostCommViewModel Cvm = new PostCommViewModel();
                Cvm.postId = item.postId;
                //Cvm.PostCommId = item.PostCommId;
                Cvm.titre = item.Titre;
                Cvm.user = item.user;
                Cvm.datecom = item.datecom;
                Cvm.imagePath = item.imagePath;
                

                //Cvm.titre = item.pos.posttitre;
                //Cvm.categoryname = item.categoryname;


                

                List.Add(Cvm);


            }

            




            return View(List);
        }

        public ActionResult postcomm(int id)
        {
            
            var cat1 = Cs.ListPostComm(id);
            //project
            List<PostCommViewModel> List = new List<PostCommViewModel>();
            foreach (var item in Cs.ListPostComm((int)id))
            {
                PostCommViewModel Pvm = new PostCommViewModel();
                Pvm.Commentaire = item.Commentaire;
                Pvm.user = item.user;
                Pvm.datecom = item.datecom;
                Pvm.imagePath = item.imagePath;


                List.Add(Pvm);


            }
            return View(List);

        }

        // GET: PostComms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostComms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostComms/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
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

        // GET: PostComms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostComms/Edit/5
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

        // GET: PostComms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostComms/Delete/5
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
