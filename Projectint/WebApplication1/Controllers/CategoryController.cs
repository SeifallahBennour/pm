using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService Cs = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryViewModel> List = new List<CategoryViewModel>();
            foreach (var item in Cs.GetAll())
            {
                CategoryViewModel Cvm = new CategoryViewModel();
                Cvm.categoryId = item.categoryId;
                Cvm.categoryname = item.categoryname;
                List.Add(Cvm);
            }
            return View(List);
        }
        [HttpPost]
        public ActionResult Index(string recherche)
        {
            List<CategoryViewModel> List = new List<CategoryViewModel>();

            foreach (var item in Cs.GetAll())
            {
                CategoryViewModel Cvm = new CategoryViewModel();

                Cvm.categoryId = item.categoryId;
                Cvm.categoryname = item.categoryname;



                List.Add(Cvm);
            }
            if (!String.IsNullOrEmpty(recherche))
            {
                List = List.Where(m => m.categoryname.Contains(recherche)).ToList();
            }

            return View(List);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var cat = Cs.GetById(id);


            CategoryViewModel cvm = new CategoryViewModel();
            cvm.categoryId = cat.categoryId;
            cvm.categoryname = cat.categoryname;
            return View(cvm);

        }
        [HttpPost]
        public ActionResult IndexDetail(CategoryViewModel cvm)
        {
            List<CategoryViewModel> List = new List<CategoryViewModel>();

            foreach (var item in Cs.GetAll())
            {
                CategoryViewModel Cvm = new CategoryViewModel();

                Cvm.categoryId = item.categoryId;
                Cvm.categoryname = item.categoryname;



                List.Add(Cvm);
            }
            
            
                List = List.Where(m => m.Equals(cvm)).ToList();
            

            return View(List);
        }
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel Cvm)
        {
            Category c = new Category();
            c.categoryId = Cvm.categoryId;
            c.categoryname = Cvm.categoryname;
            Cs.Add(c);
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = Cs.GetById(id);


            CategoryViewModel cvm = new CategoryViewModel();
            cvm.categoryId = cat.categoryId;
            cvm.categoryname= cat.categoryname;
         

            return View(cvm);

        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel cvm)
        {
            Category c = Cs.GetById(id);

            c.categoryId= cvm.categoryId;
            c.categoryname = cvm.categoryname;
            Cs.Update(c);
            Cs.Commit();
            return RedirectToAction("Index");

        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = Cs.GetById(id);


            CategoryViewModel cvm = new CategoryViewModel();
            cvm.categoryId = cat.categoryId;
            cvm.categoryname = cat.categoryname;

            return View(cvm);

        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryViewModel cvm)
        {
            Category c = Cs.GetById(id);
            cvm.categoryId = c.categoryId;
            cvm.categoryname = c.categoryname;

            Cs.Delete(c);
            Cs.Commit();
            return RedirectToAction("Index");
            
        }
    }
}
