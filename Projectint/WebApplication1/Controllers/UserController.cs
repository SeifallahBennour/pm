using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {

        UserService Cs = new UserService();

        //// GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: User
        public ActionResult IndexTL()
        {
             List<User> List = new List<User>();
            foreach (var item in Cs.GetAll())
            {
                User Cvm = new User();
                Cvm.Id = item.Id;
                Cvm.firstName = item.firstName;
                Cvm.Email = item.Email;
              //  Cvm.Address = item.Address;
                Cvm.lastName = item.lastName;
                Cvm.RoleUser = item.RoleUser;

                if (Cvm.RoleUser == "TeamLeader")
                {
                    List.Add(Cvm);
                }
            }

            return View(List);
        }

        public ActionResult IndexTM()
        {
            List<User> List = new List<User>();
            foreach (var item in Cs.GetAll())
            {

                // var userId = User.Identity.GetUserId();

                //Cvm.Id = Convert.ToInt32(userId);



                User Cvm = new User();
                Cvm.Id = item.Id;
              
                Cvm.firstName = item.firstName;
                Cvm.Email = item.Email;
                //  Cvm.Address = item.Address;
                Cvm.lastName = item.lastName;
                Cvm.RoleUser = item.RoleUser;

                if (Cvm.RoleUser == "Member")
                {
                    List.Add(Cvm);
                }
            }

            return View(List);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var cat = Cs.GetById(id);


            
            User cvm = new Models.Entities.User();
            cvm.firstName = cat.firstName;
            cvm.lastName = cat.lastName;
            cvm.imagePath = cat.imagePath;
            cvm.Email = cat.Email;
            cvm.Address = cat.Address;
            cvm.gender = cat.gender;
            return View(cvm);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        //// GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = Cs.GetById(id);



            User cvm = new Models.Entities.User();
            cvm.firstName = cat.firstName;
            cvm.lastName = cat.lastName;
            cvm.imagePath = cat.imagePath;
            cvm.Email = cat.Email;
            cvm.Address = cat.Address;
            cvm.gender = cat.gender;
            return View(cvm);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User cvm)
        {
            Domain.Entities.User cat = Cs.GetById(id);



           // Domain.Entities.User  cvm = new Domain.Entities.User();
            cvm.firstName = cat.firstName;
            cvm.lastName = cat.lastName;
            cvm.imagePath = cat.imagePath;
            cvm.Email = cat.Email;
            cvm.Address = cat.Address;
            cvm.gender = cat.gender;

            Cs.Delete(cat);
            Cs.Commit();
             
            return RedirectToAction("IndexTM");
            
        }

        // GET: User/Delete/5
        public ActionResult DeleteT(int id)
        {
            var cat = Cs.GetById(id);
           

            User cvm = new Models.Entities.User();
            cvm.firstName = cat.firstName;
            cvm.lastName = cat.lastName;
            cvm.imagePath = cat.imagePath;
            cvm.Email = cat.Email;
            cvm.Address = cat.Address;
            cvm.gender = cat.gender;
            return View(cvm);
        }

        public ActionResult listuser()
        {
            var userId = User.Identity.GetUserId();
            

            int ide = Convert.ToInt32(userId);
            
            //project
            List<User> List = new List<User>();
            foreach (var item in Cs.User_Con((int)ide))
            {
                User Pvm = new User();
                Pvm.firstName = item.firstName;
                Pvm.lastName = item.lastName;
                Pvm.imagePath = item.imagePath;
                Pvm.Email = item.Email;
                Pvm.Id = item.Id;


                List.Add(Pvm);


            }
            return View(List);
        }


        public ActionResult Edit(int id)
        {
            var cat = Cs.GetById(id);


            User cvm = new User();
            var userId = User.Identity.GetUserId();

            cvm.Id = Convert.ToInt32(userId);
            cvm.Email = cat.Email;
            cvm.firstName = cat.firstName;
            cvm.lastName = cat.lastName;
            cvm.imagePath = cat.imagePath;


            return View(cvm);

        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User Cvm)
        {
            User cvm = new User();
            var userId = User.Identity.GetUserId();
            Domain.Entities.User c = Cs.GetById(id);

            c.Id = Convert.ToInt32(userId);
            c.Email = Cvm.Email;
            c.firstName = Cvm.firstName;
            c.lastName = Cvm.lastName;
            c.imagePath = Cvm.imagePath;
            Cs.Update(c);
            Cs.Commit();
            return RedirectToAction("listuser");

        }




    //    // POST: Category/Edit/5
    //    [HttpPost]
    //public ActionResult Edit(int id, User Cvm)
    //{
    //    User cvm = new User();
    //    var userId = User.Identity.GetUserId();
    //    Domain.Entities.User c = Cs.GetById(id);

    //    c.Id = Convert.ToInt32(userId);
    //    c.Email = Cvm.Email;
    //    c.firstName = Cvm.firstName;
    //    Cs.Update(c);
    //    Cs.Commit();
    //    return RedirectToAction("Index");

    //}





    // POST: User/Delete/5
    [HttpPost]
        public ActionResult DeleteT(int id, User cvm)
        {
            Domain.Entities.User cat = Cs.GetById(id);



            // Domain.Entities.User  cvm = new Domain.Entities.User();
            cvm.firstName = cat.firstName;
            cvm.lastName = cat.lastName;
            cvm.imagePath = cat.imagePath;
            cvm.Email = cat.Email;
            cvm.Address = cat.Address;
            cvm.gender = cat.gender;

            Cs.Delete(cat);
            Cs.Commit();

            return RedirectToAction("IndexTL");

        }
    }
}
