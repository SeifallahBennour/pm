using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Helpers;
using System.Data.SqlClient;
using System.Data;
using Domain.Entities;

namespace WebApplication1.Controllers
{


    public class PatientAppointementController : Controller
    {
        IServiceAppointement ServiceRDV = null;
        ServiceReason servicereason;
        ServiceAvailibilities serviceAvail;
        ServiceIntervantion serviceInter;
        IservicePatient servicePatient = null;
        IServiceAvalibilities serviceAvailibal = null;

        IServiceUser serviceUser = null;
        IServiceDoctor MyServiceDoctor = null;

        public PatientAppointementController()
        {
            ServiceRDV = new ServiceAppointement();
            MyServiceDoctor = new ServiceDoctor();
            servicereason = new ServiceReason();
            servicePatient = new ServicePatient();
            serviceUser = new ServiceUser();
            serviceAvail = new ServiceAvailibilities();
            serviceInter = new ServiceIntervantion();


        }


        // GET: PatientAppointement
        public ActionResult Index()
        {
            
            return View();
        }

       

        // GET: PatientAppointement/Details/5

        public ActionResult Details()
        {
            AppointmentModels app1 = new AppointmentModels();
            string strDateStarted = Request.Form["dateAppointment"];
            DateTime datDateStarted;
            DateTime.TryParseExact(strDateStarted, new string[] { "ddd MMM dd HH:mm:ss yyyy" }, 
                System.Globalization.CultureInfo.InvariantCulture, 
                System.Globalization.DateTimeStyles.None, out datDateStarted);

            app1.dateAppointmentJEE = datDateStarted.ToString();

            app1.message = Request.Form["message"];


            return View("Affiche", app1);
        }

        // GET: PatientAppointement/Affiche
        public ActionResult Affiche()
        {
            


            return View();
        }
       
        public ActionResult RechercheMesRDVPatient(string searchStringspecialite, string searchStringville)
        {
            var DoctorDomain = MyServiceDoctor.GetMany();

            if (!String.IsNullOrEmpty(searchStringspecialite) || (String.IsNullOrEmpty(searchStringville)))
            {
                DoctorDomain = MyServiceDoctor.GetMany(m => m.specialite.nom.Contains(searchStringspecialite)).ToList();
            }
            if (!String.IsNullOrEmpty(searchStringville) || (String.IsNullOrEmpty(searchStringspecialite)))
            {
                DoctorDomain = MyServiceDoctor.GetMany(m => m.Address.Contains(searchStringville)).ToList();
            }
            List<Models.Entities.Doctor> ListViewModels = new List<Models.Entities.Doctor>();
            foreach (var f in DoctorDomain)
            {
                ListViewModels.Add(new Models.Entities.Doctor
                {
                    firstName = f.firstName,
                    lastName = f.lastName,
                    Address = f.Address,
                    Email = f.Email,
                    PhoneNumber = f.PhoneNumber,
                    Id =f.Id,


                });
            }
            return View(ListViewModels);
        }
       
        public ActionResult mail()
        {
           // var message = new MimeMessage();
           //message.From.Add(new MailboxAddress("Your Appointment Has been confirmed", "yahmadighofrane@gmail.com"));
           //message.To.Add(new MailboxAddress(User.Identity.Name));
           //message.Subject = "Your Appointment Has been confirmed";
           //message.Body = new TextPart("plain")
           //{
           //    Text = "hello  "
           //};
           //using (var resource = new SmtpClient())
           //{
           //    resource.Connect("smtp.gmail.com", 587, false);
           //    resource.Authenticate("youthvision.soukmedina@gmail.com", "SOUK2018");
           //    resource.Send(message);
           //    resource.Disconnect(true);
           //}



           //   return RedirectToAction("Success", "MakeAppointment");
           return View();
        }

        public ActionResult Confirmation()
        {
            return View();
        }
        public ActionResult RechercheMesRDV(string searchStringspecialite , string searchStringville)
        {
              var DoctorDomain = MyServiceDoctor.GetMany();

          if (!String.IsNullOrEmpty(searchStringspecialite) || (String.IsNullOrEmpty(searchStringville)))
          {
                DoctorDomain = MyServiceDoctor.GetMany(m => m.specialite.nom.Contains(searchStringspecialite)).ToList();
          } 
            if (!String.IsNullOrEmpty(searchStringville) || (String.IsNullOrEmpty(searchStringspecialite)))
            {
                DoctorDomain = MyServiceDoctor.GetMany(m => m.Address.Contains(searchStringville)).ToList();
            }
            List<Models.Entities.Doctor> ListViewModels = new List<Models.Entities.Doctor>();
          foreach (var f in DoctorDomain)
          {
              ListViewModels.Add(new Models.Entities.Doctor
              {
                  firstName=f.firstName,
                  lastName=f.lastName,
                  Address=f.Address,
                   Email=f.Email,
                  PhoneNumber=f.PhoneNumber,


              });
          }
            return View(ListViewModels);
        }
        
        

        public ActionResult calender()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DetailRDV()
        {
            ViewBag.Reasons = servicereason.GetMany().ToSelectListItems();
            return View();
        }

        //Get
        public ActionResult Create(int id)
        {

            List<Domain.Entities.Availability> Dispo = new List<Domain.Entities.Availability>();

            List<Domain.Entities.Intervention> motifs = new List<Domain.Entities.Intervention>();


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
                state = "Invalider",

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



        //GET :Delete
        [HttpGet]
        public ActionResult AnnulerAppointment()
        {
            var Rdvs = new List<Domain.Entities.Appointment>();
            Rdvs = ServiceRDV.AnnulerAppointment(User.Identity.Name);
            ViewBag.DoctorsVB = Rdvs;

            return View();

           
        }


        // GET: PatientAppointement/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: PatientAppointement/Edit/5
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

        // GET: PatientAppointement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientAppointement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DateTime datePrise ,FormCollection collection)
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
