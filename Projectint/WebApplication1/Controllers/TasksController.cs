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
    //public enum stat { To_Do, In_Progress, Done }
    public class TasksController : Controller
    {
        TasksService Ts = new TasksService();
        ProjectService Ps = new ProjectService();
       
        // GET: Tasks
        public ActionResult Index()
        {
            List<TasksViewModel> List = new List<TasksViewModel>();
            foreach (var item in Ts.GetAll())
            {
                TasksViewModel Tvm = new TasksViewModel();
                //Tvm.deadline = item.deadline;
                Tvm.duration = item.duration;
                Tvm.taskId = item.tasksId;
                Tvm.projectId = item.projectId;

                
                List.Add(Tvm);
            }
            return View(List);
           // return View();
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            var c = Ps.GetAll();

            foreach (var item in c)
            {
                ProjectViewModel Cvm = new ProjectViewModel();
                Cvm.projectId = item.projectId;
                Cvm.projectname = item.projectname;
              /*  Cvm.categoryId = item.categoryId;
                Cvm.description = item.description;
                Cvm.plan = item.plan;
                Cvm.goals = item.goals;
                Cvm.state = (WebApplication1.Models.stat)stat.To_Do;*/

            }


            ViewBag.cat = new SelectList(c, "projectId", "projectname");
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(TasksViewModel pvm, ProjectViewModel id)
        {
            var c = Ps.GetAll();

            foreach (var item in c)
            {
                ProjectViewModel Cvm = new ProjectViewModel();
                Cvm.projectId = item.projectId;
                Cvm.projectname = item.projectname;
                /*Cvm.categoryId = item.categoryId;
                Cvm.description = item.description;
                Cvm.plan = item.plan;
                Cvm.goals = item.goals;
                Cvm.state = (WebApplication1.Models.stat)stat.To_Do;*/

            }

           // ViewBag.cat = new SelectList(c, "projectId", "projectname");

            Tasks p = new Tasks();
            p.tasksId = pvm.taskId;
            p.projectId= id.projectId;
           // p.deadline = pvm.deadline;
            p.duration = pvm.duration;
            
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
        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tasks/Edit/5
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

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tasks/Delete/5
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
