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
    public class CommentController : Controller
    {
        Context db = new Context();
        PostService Ps = new PostService();
        CommentService Ts = new CommentService();


        // GET: Comment
        public ActionResult Index()
        {
            List<CommentViewModel> List = new List<CommentViewModel>();
            foreach (var item in Ts.GetAll())
            {
                CommentViewModel Cvm = new CommentViewModel();
                Cvm.commentId = item.commentId;
                Cvm.content = item.content;
                Cvm.postId = item.postId;
               

                List.Add(Cvm);
            }
            return View(List);
        }

        //// GET: Post/Edit/5
        //public ActionResult Lcommp(int id)
        //{
        //    Post update = db.Posts.ToList().Find(u => u.postId == id);
        //    update.post_like += 1;
        //    db.SaveChanges();
        //    return RedirectToAction("listepost");
        //}

        // GET: Post/Edit/5
        public ActionResult pcomm(int id)
        {
            Comment update = db.Comments.ToList().Find(u => u.commentId == id);
           
            db.SaveChanges();
            return RedirectToAction("listepost");
        }


        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {

            var c = Ps.GetAll();

            foreach (var item in c)
            {
                PostViewModel Cvm = new PostViewModel();
                Cvm.postId = item.postId;
                Cvm.posttitre = item.posttitre;
                Cvm.content = item.content;
                Cvm.posttitre = item.posttitre;

                /*  Cvm.categoryId = item.categoryId;
                  Cvm.description = item.description;
                  Cvm.plan = item.plan;
                  Cvm.goals = item.goals;
                  Cvm.state = (WebApplication1.Models.stat)stat.To_Do;*/

            }


            ViewBag.cat = new SelectList(c, "postId", "posttitre");
           
            return View();
        }


        //[HttpPost]
        //public ActionResult postcomm(CommentViewModel pvm, PostViewModel id)
        //{
        //    //pspost
        //    //tscomment
        //    var c = Ps.GetAll();

        //    foreach (var item in c)
        //    {
        //        CommentViewModel Cvm = new CommentViewModel();
        //        Cvm.postId = item.postId;
        //        Cvm.posttitre = item.posttitre;
        //        Cvm.content = item.content;

        //        /*Cvm.categoryId = item.categoryId;
        //        Cvm.description = item.description;
        //        Cvm.plan = item.plan;
        //        Cvm.goals = item.goals;
        //        Cvm.state = (WebApplication1.Models.stat)stat.To_Do;*/

        //    }

        //    // ViewBag.cat = new SelectList(c, "projectId", "projectname");

        //    Comment p = new Comment();
        //    p.commentId = pvm.commentId;
        //    p.postId = id.postId;
        //    // p.deadline = pvm.deadline;
        //    p.content = pvm.content;



        //    //p.state = (Domain.Entities.state)stat.To_Do;
        //    //p.ListTask = (ICollection<Domain.Entities.Task>)pvm.ListTask;
        //    Ts.Add(p);
        //    Ts.Commit();

        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentViewModel pvm, PostViewModel id)
        {
            var c = Ps.GetAll();

            foreach (var item in c)
            {
                PostViewModel Cvm = new PostViewModel();
                Cvm.postId = item.postId;
                Cvm.posttitre = item.posttitre;
                Cvm.content = item.content;

                /*Cvm.categoryId = item.categoryId;
                Cvm.description = item.description;
                Cvm.plan = item.plan;
                Cvm.goals = item.goals;
                Cvm.state = (WebApplication1.Models.stat)stat.To_Do;*/

            }

            // ViewBag.cat = new SelectList(c, "projectId", "projectname");

            Comment p = new Comment();
            p.commentId = pvm.commentId;
            p.postId = id.postId;
            // p.deadline = pvm.deadline;
            p.content = pvm.content;
           


            //p.state = (Domain.Entities.state)stat.To_Do;
            //p.ListTask = (ICollection<Domain.Entities.Task>)pvm.ListTask;
            Ts.Add(p);
            Ts.Commit();

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

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
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
