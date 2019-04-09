using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public enum stat { To_Do, In_Progress, Done }
    public class ProjectController : Controller
    {
        ProjectService Ps = new ProjectService();
        CategoryService Cs = new CategoryService();
        UserService Us = new UserService();
        // GET: Project
        public ActionResult Index()
        {
            List<ProjectViewModel> List = new List<ProjectViewModel>();
            foreach (var item in Ps.GetAll())
            {
                ProjectViewModel Pvm = new ProjectViewModel();
                Pvm.projectId = item.projectId;
                Pvm.projectname = item.projectname;
                Pvm.plan = item.plan;
                Pvm.description = item.description;
                Pvm.goals = item.goals;
                Pvm.state = (Models.stat)item.state;
                
               Pvm.categoryId = item.categoryId;
                Pvm.team_leaderId = item.team_leaderId;
                //  Pvm.teamleadername = item.team_leader.Email;
                Pvm.teamleadername = item.team_leader.Email;
                //Pvm.ListTask = (ICollection<TasksViewModel>)item.ListTask;
                List.Add(Pvm);
            }
            return View(List);
        }

        // GET: Project
        public ActionResult Indexetat()
        {
            List<ProjectViewModel> List = new List<ProjectViewModel>();
            foreach (var item in Ps.GetAll())
            {
                ProjectViewModel Pvm = new ProjectViewModel();
                Pvm.projectId = item.projectId;
                Pvm.projectname = item.projectname;
                Pvm.plan = item.plan;
                Pvm.description = item.description;
                Pvm.goals = item.goals;
                Pvm.state = (Models.stat)item.state;

                Pvm.categoryId = item.categoryId;
                Pvm.team_leaderId = item.team_leaderId;
                //  Pvm.teamleadername = item.team_leader.Email;
                Pvm.teamleadername = item.team_leader.Email;
                //Pvm.ListTask = (ICollection<TasksViewModel>)item.ListTask;
                List.Add(Pvm);
            }
            return View(List);
        }

        public ActionResult Estimation()
        {
            List<ProjectViewModel> List = new List<ProjectViewModel>();
            foreach (var item in Ps.ListProject())
            {
                ProjectViewModel Pvm = new ProjectViewModel();
                Pvm.Somme = item.Somme;
                Pvm.projectname = item.projectname;
               
                List.Add(Pvm);
            }
            return View(List);
        }

        public ActionResult Estimationproject()
        {
            List<ProjectViewModel> List = new List<ProjectViewModel>();
            foreach (var item in Ps.ListProject())
            {
                ProjectViewModel Pvm = new ProjectViewModel();
                //Pvm.Somme = DateTime.Now.-item.Somme;
                Pvm.Somme = item.Somme;
                int x = item.Somme * 7;
                DateTime y = item.DateDebut.AddDays(x-1);
                //DateTime j = item.DateDebut.AddDays(-DateTime.Now.DayOfYear);


                DateTime deb = DateTime.Parse(item.DateDebut.ToString("yyyy-MM-dd"));
                DateTime fin =DateTime.Now;
                TimeSpan Diff = fin - deb;

                



               
                Pvm.projectname = item.projectname;
               
                Pvm.dt = "Date now" + DateTime.Now.ToShortDateString(); /*item.DateDebut.ToShortDateString();*/
                Pvm.dtf = "DatDebut " + item.DateDebut.ToShortDateString();
                Pvm.a =  item.DateDebut.AddDays(x);
                Pvm.difference = Pvm.a- DateTime.Now.Date ;
                Pvm.v = Pvm.difference.TotalDays;
                Pvm.jr = Convert.ToInt32(Pvm.v)-1;

               







                List.Add(Pvm);
            }
            return View(List);
        }





        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var pro = Ps.GetById(id);


            ProjectViewModel pvm = new ProjectViewModel();
           // pvm.categoryId = pro.categoryId;
            pvm.description = pro.description;
            pvm.projectname = pro.projectname;
            pvm.projectId = pro.projectId;
            pvm.state = (WebApplication1.Models.stat)pro.state;
            pvm.goals = pro.goals;
            pvm.plan = pro.plan;
            //pvm.ListTask = (ICollection<WebApplication1.Models.TasksViewModel>)pro.ListTask;
            
            return View(pvm);

        }

        // GET: Project/Create
        public ActionResult Create()
        {
            var c = Us.GetAll();

          List<WebApplication1.Models.Entities.User> vm = new List<WebApplication1.Models.Entities.User>();

            foreach (var item in c)
            {


                
                    WebApplication1.Models.Entities.User Cvm = new WebApplication1.Models.Entities.User();

                if (item.RoleUser == "TeamLeader")
                {
                    Cvm.Id = item.Id;
                    Cvm.Email = item.Email;

                    vm.Add(Cvm);
                    
                }
                

            }

            
            ViewBag.cat = new SelectList(vm, "Id", "Email");

            var C = Cs.GetAll();

            foreach (var item in C)
            {
                CategoryViewModel Cvm = new CategoryViewModel();
                Cvm.categoryId = item.categoryId;

            }


            ViewBag.cate = new SelectList(C, "categoryId", "categoryname");




            return View();
        }

        //POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel pvm, WebApplication1.Models.Entities.User uvm , CategoryViewModel categ)
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
                CategoryViewModel Cvm = new CategoryViewModel();
                Cvm.categoryId = item.categoryId;

            }


            ViewBag.cate = new SelectList(C, "categoryId", "categoryname");

            //ViewBag.cat = new SelectList(c, "categoryId", "categoryname");

            var c = Us.GetAll();

            foreach (var item in c)
            {
                if (item.RoleUser == "TeamLeader")
                {
                    WebApplication1.Models.Entities.User Cvm = new WebApplication1.Models.Entities.User();
                //Cvm.categoryId = item.categoryId;
                
                    Cvm.Id = item.Id;
                }
            }


            ViewBag.cat = new SelectList(c, "Id", "Email");

            Project p = new Project();
            p.projectId = pvm.projectId;
            p.categoryId = categ.categoryId;
            p.projectname = pvm.projectname;
            p.description = pvm.description;
            p.plan = pvm.plan;
            p.goals = pvm.goals;
            p.DateDebut = DateTime.Now;

            p.state = (Domain.Entities.stat)stat.To_Do;
            p.team_leaderId = uvm.Id;
            //p.ListTask = (ICollection<Domain.Entities.Task>)pvm.ListTask;
            Ps.Add(p);
            Ps.Commit();

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
        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            var pro = Ps.GetById(id);


            ProjectViewModel pvm = new ProjectViewModel();
            pvm.projectId = pro.projectId;
            pvm.projectname = pro.projectname;
            pvm.state = (Models.stat)pro.state; 
            pvm.goals = pro.goals;
            pvm.plan = pro.plan;
            pvm.description = pro.description;

            var cat = Cs.GetAll();
            List<CategoryViewModel> cvm = new List<CategoryViewModel>();
            foreach (var item in cat)
            {
                CategoryViewModel cvm1= new CategoryViewModel();
                cvm1.categoryId = cvm1.categoryId;
                cvm1.categoryname = cvm1.categoryname;
                cvm.Add(cvm1);

            }



            ViewData["cat"] = new SelectList(cvm, "categoryId", "categoryname");

            return View(pvm);

        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectViewModel pvm)
        {
            Project p = Ps.GetById(id);

            p.state = (Domain.Entities.stat)pvm.state;
            p.projectId = pvm.projectId;
            p.projectname = pvm.projectname;
            p.goals = pvm.goals;
            p.plan = pvm.plan;
            p.state = (Domain.Entities.stat)pvm.state;
            p.description = pvm.description;
            
            //Category c = Cs.GetById(id);

            //c = new Category { categoryId = c.categoryId,categoryname=c.categoryname };


            Ps.Update(p);
            Ps.Commit();
            return RedirectToAction("Index");

        }


        // GET: Project/Edit/5
        public ActionResult Editetat(int id)
        {
            var pro = Ps.GetById(id);


            ProjectViewModel pvm = new ProjectViewModel();
           
            pvm.state = (Models.stat)pro.state;

            return View(pvm);

        }


        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Editetat(int id, ProjectViewModel pvm)
        {
            Project p = Ps.GetById(id);

          
            p.state = (Domain.Entities.stat)pvm.state;
           

            Ps.Update(p);
            Ps.Commit();
            return RedirectToAction("Index");

        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            var pro = Ps.GetById(id);


            ProjectViewModel pvm = new ProjectViewModel();
            pvm.projectId = pro.projectId;
            pvm.projectname = pro.projectname;
            pvm.state.Equals(pro.state);
            pvm.goals = pro.goals;
            pvm.plan = pro.plan;
            pvm.description = pro.description;
                
                return View(pvm);

        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProjectViewModel pvm)
        {
            Project p = Ps.GetById(id);
            pvm.projectId = p.projectId;
            pvm.state.Equals(p.state);
            pvm.projectname = p.projectname;
            pvm.goals = p.goals;
            pvm.plan = p.plan;
            pvm.description = p.description;
         //   Category c = Cs.GetById(id);

          //  pvm.categoryId = p.categoryId;

            Ps.Delete(p);
            Ps.Commit();
            return RedirectToAction("Index");

        }
    }
}
