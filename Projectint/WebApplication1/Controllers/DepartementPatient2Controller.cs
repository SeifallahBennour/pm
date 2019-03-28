using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class DepartementPatient2Controller : Controller
    {
        IServiceDepartement serviceDepartement = null;
        IServiceAppointement ServiceRDV = null;
        ServiceReason servicereason;
        ServiceAvailibilities serviceAvail;
        ServiceIntervantion serviceInter;
        IservicePatient servicePatient = null;
        IServiceAvalibilities serviceAvailibal = null;
        IServiceUser serviceUser = null;
        IServiceDoctor MyServiceDoctor = null;
        public DepartementPatient2Controller()
        {
            ServiceRDV = new ServiceAppointement();
            MyServiceDoctor = new ServiceDoctor();
            servicereason = new ServiceReason();
            servicePatient = new ServicePatient();
            serviceUser = new ServiceUser();
            serviceAvail = new ServiceAvailibilities();
            serviceInter = new ServiceIntervantion();
            serviceDepartement = new ServiceDepartement();

        }
        //Get
        public ActionResult Create(int id)
        {

            List<Availability> Dispo = new List<Availability>();

            List<Intervention> motifs = new List<Intervention>();


            IEnumerable<SelectListItem> reasons = serviceInter.ListIntervention(id).ToSelectListItems();
            ViewBag.reasons = reasons;
            ViewBag.motifa = "choose a skill";

            List<SelectListItem> disponibilite = new List<SelectListItem>();
            disponibilite.Add(new SelectListItem { Text = "9h:15", Value = "9h:15" });
            disponibilite.Add(new SelectListItem { Text = "9h:30", Value = "9h:30" });
            disponibilite.Add(new SelectListItem { Text = "9h:45", Value = "9h:45" });
            disponibilite.Add(new SelectListItem { Text = "11h", Value = "10" });

            disponibilite.Add(new SelectListItem { Text = "10h:15", Value = "10h:15" });
            disponibilite.Add(new SelectListItem { Text = "10h:30", Value = "10h:30" });
            disponibilite.Add(new SelectListItem { Text = "10h:45", Value = "10h:45" });
            disponibilite.Add(new SelectListItem { Text = "12h", Value = "11h" });

            disponibilite.Add(new SelectListItem { Text = "12h:15", Value = "12h:15" });
            disponibilite.Add(new SelectListItem { Text = "12h:30", Value = "12h:30" });
            disponibilite.Add(new SelectListItem { Text = "12h:45", Value = "12h:45" });
            disponibilite.Add(new SelectListItem { Text = "13h", Value = "13h" });

            disponibilite.Add(new SelectListItem { Text = "13h:15", Value = "13h:15" });
            disponibilite.Add(new SelectListItem { Text = "13h:30", Value = "13h:30" });
            disponibilite.Add(new SelectListItem { Text = "13h:45", Value = "13h:45" });
            disponibilite.Add(new SelectListItem { Text = "14h", Value = "14h" });

            disponibilite.Add(new SelectListItem { Text = "14h:15", Value = "14h:15" });
            disponibilite.Add(new SelectListItem { Text = "14h:30", Value = "14h:30" });
            disponibilite.Add(new SelectListItem { Text = "14h:45", Value = "14h:45" });
            disponibilite.Add(new SelectListItem { Text = "15h", Value = "15h" });

            disponibilite.Add(new SelectListItem { Text = "15h:15", Value = "15h:15" });
            disponibilite.Add(new SelectListItem { Text = "15h:30", Value = "15h:30" });
            disponibilite.Add(new SelectListItem { Text = "15h:45", Value = "15h:45" });
            disponibilite.Add(new SelectListItem { Text = "16h", Value = "16h" });

            disponibilite.Add(new SelectListItem { Text = "16h:15", Value = "16h:15" });
            disponibilite.Add(new SelectListItem { Text = "16h:30", Value = "16h:30" });
            disponibilite.Add(new SelectListItem { Text = "16h:45", Value = "16h:45" });
            disponibilite.Add(new SelectListItem { Text = "17h", Value = "17h" });

            disponibilite.Add(new SelectListItem { Text = "17h:15", Value = "17h:15" });
            disponibilite.Add(new SelectListItem { Text = "17h:30", Value = "17h:30" });
            disponibilite.Add(new SelectListItem { Text = "17h:45", Value = "17h:45" });
            disponibilite.Add(new SelectListItem { Text = "18h", Value = "18h" });

            disponibilite.Add(new SelectListItem { Text = "18h:15", Value = "18h:15" });
            disponibilite.Add(new SelectListItem { Text = "18h:30", Value = "18h:30" });
            disponibilite.Add(new SelectListItem { Text = "18h:45", Value = "18h:45" });


            ViewBag.SelectedItem = "9h";
            ViewBag.Dispos = disponibilite;



            



            return View();
        }

        // POST: PatientAppointement/Create
        [HttpPost]
        public ActionResult Create(Appointment AppointmentVM, int id)
        {
            var patientEmail = User.Identity.Name;
            var listpatient = serviceUser.GetMany();
            var patient = listpatient.SingleOrDefault(pt => pt.Email == patientEmail);


            Domain.Entities.Appointment App = new Domain.Entities.Appointment()
            {

                message = AppointmentVM.message,
                HourAppointment = AppointmentVM.HourAppointment,
                state = "Invalide",

                datePriseRDV = System.DateTime.Now,
                reason = AppointmentVM.reason,
                dateAppointmentJEE = AppointmentVM.dateAppointmentJEE,
                IdPatient = patient.Id,
                Iddoctor = id

            };
            ServiceRDV.Add(App);
            ServiceRDV.Commit();


            return RedirectToAction("Index", "PatientAppointement");


        }


        // GET: Departement
        public ActionResult hematologie()
        {
            List<Departement> Departements = new List<Departement>();
            Departements = serviceDepartement.hematologie();
            ViewBag.DoctorsVB = Departements;



            return View();

        }

        // GET: Departement
        public ActionResult anesthesiologie()
        {

            List<Departement> Departements = new List<Departement>();
            Departements = serviceDepartement.anesthesiologie();
            ViewBag.DoctorsVB = Departements;

            return View();

        }
        // GET: Doctor
        public ActionResult radio()
        {

            List<Departement> Departements = new List<Departement>();
            Departements = serviceDepartement.radio();
            ViewBag.DoctorsVB = Departements;




            return View();


        }


        // GET: Departement
        public ActionResult ophtalmo()
        {


            List<Departement> Departements = new List<Departement>();
            Departements = serviceDepartement.ophtalmo();
            ViewBag.DoctorsVB = Departements;

            return View();


        }
        // GET: Departement
        public ActionResult Chirurigie()
        {


            List<Departement> Departements = new List<Departement>();
            Departements = serviceDepartement.Chirurigie();
            ViewBag.DoctorsVB = Departements;

            return View();

        }
        // GET: Departement
        public ActionResult dentaire()
        {

            List<Departement> Departements = new List<Departement>();
            Departements = serviceDepartement.dentaire();
            ViewBag.DoctorsVB = Departements;

            return View();


        }
        // GET: Departement
        public ActionResult dermatology()
        {

            List<Departement> Departements = new List<Departement>();
            Departements = serviceDepartement.dermatology();
            ViewBag.DoctorsVB = Departements;

            return View();


        }
        public ActionResult Departement()
            {
                return View();
            }
            public ActionResult Departement2()
            {
                return View();
            }
            public ActionResult Departement3()
            {
                return View();
            }
            public ActionResult Departement4()
            {
                return View();
            }
            public ActionResult Departement5()
            {
                return View();
            }
            public ActionResult Departement6()
            {
                return View();
            }
            public ActionResult Departement7()
            {
                return View();
            }



        }
    }
