using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class JsonController : ApiController
    {
        IServiceAppointement serviceApp = new ServiceAppointement();

        IServiceAvalibilities serviceAvailibility = new ServiceAvailibilities();
        IServiceIntervention serviceIntervention = new ServiceIntervantion();
        IServiceRDV serviceRdv = new ServiceRDV();
        IServiceSpeciality servicespecialite = new ServiceSpeciality();
        IServiceVisite servicesVisite = new ServiceVisite();
        IServiceUser servicesUser = new ServiceUser();
        IServiceDepartement serviceAppointement = new ServiceDepartement();

        // GET: api/Json

        public IEnumerable<User> Getusers()
        {
            return servicesUser.getUsers();
        }

        // GET: api/Json
        public IQueryable<Appointment> GetAppointment(int id)

        {

            List<Appointment> applicationApp = serviceApp.GetAppointmentsByID(id).ToList();
            List<Appointment> applicationAppToXml = new List<Appointment>();
            foreach (Appointment i in applicationApp)
            {
                applicationAppToXml.Add(new Appointment
                {

                   // dateAppointment = i.dateAppointment,
                    reason = i.reason,
                    HourAppointment = i.HourAppointment,
                    appointmentId = i.appointmentId,
                    state = i.state,
                    Iddoctor = i.Iddoctor

                });
            }
            return applicationApp.AsQueryable();
        }



        // GET: api/Json

        public IEnumerable<Doctor> GetDoctors()
        {
            return serviceAppointement.Doctors();
        }



        // GET: api/Json

        public IEnumerable<Departement> GetDentaire()
        {
            return serviceAppointement.dentaire();
        }
        // GET: api/Json
        public IEnumerable<Departement> GetChirurigie()
        {
            return serviceAppointement.Chirurigie();
        }
        // GET: api/Json
        public IEnumerable<Departement> Getdermatology()
        {
            return serviceAppointement.dermatology();
        }
        public IEnumerable<Departement> Gethematologie()
        {
            return serviceAppointement.hematologie();
        }
        public IEnumerable<Departement> Getophtalmo()
        {
            return serviceAppointement.ophtalmo();
        }
        // GET: api/Json
        public IEnumerable<Departement> GetAnestesie()
        {
            return serviceAppointement.anesthesiologie();
        }
        // GET: api/Json
        public IEnumerable<Appointment> GetDelete(int id)
        {
            return serviceApp.AnnulerAppointmentJEE(id);
        }
        // GET: api/Json
        public IEnumerable<Appointment> GetDeleteRDVJ(int id)
        {
            return serviceApp.AnnulerRDV(id);
        }
        [Route("api/radio")]
        public IEnumerable<Departement> Getradio()
        {
            return serviceAppointement.radio();
        }
        // GET api/<controller>
        [Route("api/ListAvailibilities")]
        public List<Availability> GetListAvailibilities(int id)
        {

            return serviceAvailibility.ListAvailibilities(id);

        }

        // GET api/<controller>
        [Route("api/MesRendezVous")]
        public IEnumerable<RDV> GetMesRendezVous(string email)
        {
            return serviceRdv.MesRendezVous(email);
        }




        // GET api/<controller>

        public IEnumerable<Visite> GetMesVisite(string email)
        {
            return servicesVisite.MesVisite(email);
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }


    }
    // GET: api/Json/5

}
