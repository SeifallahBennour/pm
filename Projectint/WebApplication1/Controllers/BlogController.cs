using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        BlogService Bs = new BlogService();
        UserService Us = new UserService();

        // GET: Blog
        public ActionResult Index()
        {
            List<BlogViewModel> List = new List<BlogViewModel>();
            foreach (var item in Bs.ListBlog())
            {
                BlogViewModel Tvm = new BlogViewModel();
                //Tvm.deadline = item.deadline;
                Tvm.blogId = item.blogId;
                Tvm.titreblog = item.titreblog;
                Tvm.contenu = item.contenu;
                Tvm.imagePath = item.imagePath;
              //  Tvm.userblogId = item.userblogId;
                Tvm.username = item.username;
                Tvm.dateblog = item.dateblog;


                //Tvm.user.firstName = item.user.firstName;

                //Tvm.catgoriepostId = item.categorypostId;


                List.Add(Tvm);
            }
            return View(List);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            var cat = Bs.GetById(id);


            BlogViewModel cvm = new BlogViewModel();
            cvm.titreblog = cat.titreblog;
            cvm.contenu = cat.contenu;
            cvm.imagePath = cat.imagePath;
            cvm.dateblog = cat.dateblog;
          //  cvm.username = cat.username;
            
            return View(cvm);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(BlogViewModel Cvm,HttpPostedFileBase imagePath)
        {

            var userId = User.Identity.GetUserId();


            int ide = Convert.ToInt32(userId);


            Blog c = new Blog();
            c.blogId = Cvm.blogId;
            c.titreblog = Cvm.titreblog;
            c.contenu = Cvm.contenu;
            c.dateblog = DateTime.Now;
            c.imagePath = imagePath.FileName;
            c.userblogId = ide;

            
            Bs.Add(c);
            Bs.Commit();
            imagePath.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), imagePath.FileName));
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

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
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

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
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
