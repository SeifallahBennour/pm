using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class PatientController : Controller
    {
        IservicePatient IServicePatient = null;
        IServiceUser serviceUser = null;
        IServiceRDV serviceRDV = null;
        IServiceVisite serviceVisite = null;
        ServicePatient servicePatient;
        public PatientController()
        {
            servicePatient = new ServicePatient();
            serviceUser = new ServiceUser();
            serviceRDV = new ServiceRDV();
            serviceVisite = new ServiceVisite();


        }
        // GET: Patient/MesRendezVous
        public ActionResult MesRendezVous()
        {

            List<RDV> RDVs = new List<RDV>();
            RDVs = serviceRDV.MesRendezVous(User.Identity.Name);
            ViewBag.RDV = RDVs;



            return View();

        }

        // GET: Patient
        public ActionResult Visite()
        {
        

            List<Visite> Visites = new List<Visite>();
            Visites = serviceVisite.MesVisite(User.Identity.Name);
            ViewBag.RDV = Visites;



           

            return View();
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
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

        // GET: Patient/Edit/1
        public ActionResult Edit(double id)
        {

          return View(servicePatient.GetByIdF(id));
        }

       
        
        // POST: Patient/Edit/1
        [HttpPost]
        public ActionResult Edit(double id ,FormCollection formvalues)
        {
            try
            {
                // TODO: Add update logic here
                Domain.Entities.Patient r = null;
                r = servicePatient.GetByIdF(id);
                r.PhoneNumber = formvalues["PhoneNumber"];
                r.UserName = formvalues["Email"];
                r.firstName = formvalues["FirstName"];
                r.lastName = formvalues["LastName"];
                r.Address = formvalues["Adresse"];

                servicePatient.Update(r);
                servicePatient.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
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
