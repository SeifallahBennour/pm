using Data;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PostController : Controller
    {
        Context db = new Context();

        CategoryPostService Ps = new CategoryPostService();
        PostService Ts = new PostService();
        public ActionResult listepost()
        {
            List<PostViewModel> List = new List<PostViewModel>();
            foreach (var item in Ts.GetAll())
            {
                PostViewModel Cvm = new PostViewModel();
                Cvm.postId= item.postId;
                Cvm.posttitre = item.posttitre;
                Cvm.content = item.content;
                Cvm.categoriepostId = item.categorypostId;
                Cvm.post_like = item.post_like;
                Cvm.datepost = item.datepost;

                List.Add(Cvm);
            }
            return View(List);
        }

        //GET: Post
        public ActionResult Index()
        {

            List<PostViewModel> List = new List<PostViewModel>();
            foreach (var item in Ts.GetAll())
            {
                PostViewModel Tvm = new PostViewModel();
                //Tvm.deadline = item.deadline;
                 Tvm.categoriepostId = item.categorypostId;
                 //Tvm.categoriename = item.cat.nom;
                Tvm.content = item.content;
                Tvm.postId = item.postId;
                // Tvm.cat.nom = item.cat.nom;
                Tvm.posttitre = item.posttitre;
                Tvm.datepost = item.datepost;
                
                //Tvm.user.firstName = item.user.firstName;

                //Tvm.catgoriepostId = item.categorypostId;


                List.Add(Tvm);
            }
            return View(List);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var cat = Ts.GetById(id);


            PostViewModel cvm = new PostViewModel();
            cvm.postId = cat.postId;
            cvm.content = cat.content;
            return View(cvm);

        }

        // GET: Post/Create
        public ActionResult Create()
        {
            var c = Ps.GetAll();

            foreach (var item in c)
            {
                CategoryPostViewModel Cvm = new CategoryPostViewModel();
                //  Cvm.catgoriepostId = item.catgoriepostId;
                Cvm.categorypostId = item.categorypostId;
                Cvm.nom = item.nom;


                /*  Cvm.categoryId = item.categoryId;
                  Cvm.description = item.description;
                  Cvm.plan = item.plan;
                  Cvm.goals = item.goals;
                  Cvm.state = (WebApplication1.Models.stat)stat.To_Do;*/

            }


            ViewBag.cat = new SelectList(c, "categorypostId", "nom");
            return View();
        }

        


        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel pvm, CategoryPostViewModel id)
        {
           

            var c = Ps.GetAll();

            foreach (var item in c)
            {
                CategoryPostViewModel Cvm = new CategoryPostViewModel();
                Cvm.categorypostId = item.categorypostId;
                Cvm.nom = item.nom;

                /*Cvm.categoryId = item.categoryId;
                Cvm.description = item.description;
                Cvm.plan = item.plan;
                Cvm.goals = item.goals;
                Cvm.state = (WebApplication1.Models.stat)stat.To_Do;*/

            }

            // ViewBag.cat = new SelectList(c, "projectId", "projectname");

            Post p = new Post();
            p.postId = pvm.postId;
            //p.categoriepostId=id.categorypostId;
            p.categorypostId = id.categorypostId;
            p.post_like = pvm.post_like;
            p.posttitre = pvm.posttitre;
            p.content = pvm.content;
            p.datepost = DateTime.Now;




            //// p.catgoriepostId = id.categorypostId;
            // p.content = pvm.content;
            // //p.userId = 1;
            //// p.user.Id = pvm.user.Id;
            Ts.Add(p);
            Ts.Commit();
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("listepost");
            }
            catch
            {
                return View();
            }
        }


        // GET: Post/Edit/5
        public ActionResult Like(int id)
        {
            Post update = db.Posts.ToList().Find(u => u.postId == id);
            update.post_like += 1;
            db.SaveChanges();
            return RedirectToAction("listepost");
        }

        // GET: Post/Edit/5
        public ActionResult commp(int id)
        {
            Comment update = db.Comments.ToList().Find(u => u.commentId == id);
            
            db.SaveChanges();
            return RedirectToAction("listepost");
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
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

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
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
