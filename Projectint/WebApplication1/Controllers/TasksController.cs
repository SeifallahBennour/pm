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
        UserService Us = new UserService();
        DifficulteService Ds = new DifficulteService();


        // GET: Tasks
        public ActionResult Index()
        {
            List<TasksViewModel> List = new List<TasksViewModel>();
            foreach (var item in Ts.GetAll())
            {
                TasksViewModel Tvm = new TasksViewModel();
                //Tvm.deadline = item.deadline;
                Tvm.nomtask = item.nomtask;
                Tvm.duration = item.duration;
                Tvm.taskId = item.tasksId;
                Tvm.projectId = item.projectId;
                Tvm.projectname = item.proj.projectname;
                Tvm.diffname = item.Difficultes.Nomdiff;
                //Tvm.membname = item.team_member.firstName+" "+ item.team_member.lastName;


                List.Add(Tvm);
            }
            return View(List);
            // return View();
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var cat = Ts.GetById(id);


            TasksViewModel cvm = new TasksViewModel();
            cvm.projectname = cat.proj.projectname;
            cvm.membname = cat.team_member.firstName + " " + cat.team_member.lastName;
            cvm.diffname = cat.Difficultes.Nomdiff;
            cvm.nomtask = cat.nomtask;
            cvm.membemail = cat.team_member.Email;
            return View(cvm);

        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            var p = Ps.GetAll();
            foreach (var item in p)
            {
                ProjectViewModel Cvm = new ProjectViewModel();
                Cvm.projectId = item.projectId;
                Cvm.projectname = item.projectname;
                Cvm.categoryId = item.categoryId;
                Cvm.description = item.description;
                Cvm.plan = item.plan;
                Cvm.goals = item.goals;
                
                Cvm.state = (WebApplication1.Models.stat)stat.To_Do;

            }
            ViewBag.pro = new SelectList(p, "projectId", "projectname");


            var u = Us.GetAll();
            List<WebApplication1.Models.Entities.User> vm = new List<WebApplication1.Models.Entities.User>();

            foreach (var item in u)
            {
                Models.Entities.User Cvm = new Models.Entities.User();
                if (item.RoleUser == "Member")
                {
                    Cvm.Id = item.Id;
                    Cvm.Email = item.Email;
                    vm.Add(Cvm);

                }

            }
            ViewBag.usr = new SelectList(vm, "Id", "Email");

            var D = Ds.GetAll();
            foreach (var item in D)
            {
                
                DifficulteViewModel df = new DifficulteViewModel();
                df.DifficulteId = item.DifficulteId;

            }
            ViewBag.diff = new SelectList(D, "DifficulteId", "Nomdiff");

            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(TasksViewModel tvm, ProjectViewModel pvm, WebApplication1.Models.Entities.User uvm,DifficulteViewModel d)
        {
            var p = Ps.GetAll();
            foreach (var item in p)
            {
                ProjectViewModel Pvm = new ProjectViewModel();
                Pvm.projectId = item.projectId;
                Pvm.projectname = item.projectname;
                Pvm.categoryId = item.categoryId;
                Pvm.description = item.description;
                Pvm.plan = item.plan;
                Pvm.goals = item.goals;
                Pvm.state = (WebApplication1.Models.stat)stat.To_Do;
                

            }
            ViewBag.pro = new SelectList(p, "projectId", "projectname");


            var u = Us.GetAll();
            foreach (var item in u)
            {
                Models.Entities.User Uvm = new Models.Entities.User();
                Uvm.Id = item.Id;

            }
            ViewBag.usr = new SelectList(u, "Id", "Id");

            var D = Ds.GetAll();
            foreach (var item in D)
            {

                DifficulteViewModel df = new DifficulteViewModel();
                df.DifficulteId = item.DifficulteId;

            }
            ViewBag.diff = new SelectList(D, "DifficulteId", "DifficulteId");

            Tasks t = new Tasks();
            t.tasksId = tvm.taskId;
            t.projectId = pvm.projectId;
            t.team_memberId = uvm.Id;
            // p.deadline = pvm.deadline;
            //t.duration = tvm.duration;
            //t.state = (Domain.Entities.stat)stat.To_Do;
            t.DifficulteId = d.DifficulteId;
            t.nomtask = tvm.nomtask;
            Ts.Add(t);
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
        //// GET: Tasks/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}


        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = Ts.GetById(id);


            TasksViewModel cvm = new TasksViewModel();
            cvm.nomtask = cat.nomtask;
            //cvm.categoryname = cat.categoryname;

            var p = Ps.GetAll();
            foreach (var item in p)
            {
                ProjectViewModel Cvm = new ProjectViewModel();
                Cvm.projectId = item.projectId;
                Cvm.projectname = item.projectname;
                Cvm.categoryId = item.categoryId;
                Cvm.description = item.description;
                Cvm.plan = item.plan;
                Cvm.goals = item.goals;

                Cvm.state = (WebApplication1.Models.stat)stat.To_Do;

            }
            ViewBag.pro = new SelectList(p, "projectId", "projectname");



            return View(cvm);

        }



        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TasksViewModel cvm, ProjectViewModel categ)
        {
            var C = Ps.GetAll();

            foreach (var item in C)
            {
                ProjectViewModel Cvm1 = new ProjectViewModel();
                Cvm1.projectId = item.projectId;

            }

            ViewBag.cate = new SelectList(C, "projectId", "projectname");
            Tasks c = Ts.GetById(id);

            c.nomtask = cvm.nomtask;
            c.projectId = categ.projectId;
            
            //c.categoryname = cvm.categoryname;
            Ts.Update(c);
            Ts.Commit();
            return RedirectToAction("Index");

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
