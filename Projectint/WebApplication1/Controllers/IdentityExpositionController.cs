using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class IdentityExpositionController : ApiController
    {
        IServiceUser servicesUser = new ServiceUser();
        IServiceAppointement serviceApp = new ServiceAppointement();
        IServiceDepartement serviceAppointement = new ServiceDepartement();

        //public IQueryable<User> GetUsers()

        //{

        //    List<User> applicationUsers = servicesUser.GetMany().ToList();
        //    List<User> applicationUsersToXml = new List<User>();
        //    foreach (User i in applicationUsers)
        //    {
        //        applicationUsersToXml.Add(new User
        //        {

        //            lastName = i.lastName,
        //            firstName = i.firstName,
        //            Email = i.Email,
        //            PasswordHash = i.PasswordHash

        //        });
        //    }
        //    return applicationUsersToXml.AsQueryable();
        //}

        public IQueryable<UserWS> GetUsers()
        {
            List<Domain.Entities.User> users = servicesUser.getUsers();
            List<UserWS> usersXml = new List<UserWS>();
            foreach (Domain.Entities.User i in users)
            {
                usersXml.Add(new UserWS
                {
                    id = i.Id,
                    firstName = i.firstName,
                    lastName = i.lastName,
                    role = i.RoleUser,
                    passeword = i.PasswordHash,
                    email = i.Email,
                }
                    );
            }

            return usersXml.AsQueryable();
        }
        // GET: api/IdentityExposition
        public IQueryable<Appointment> GetAppointment(int id)

        {

            List<Appointment> applicationApp = serviceApp.GetAppointmentsByID(id).ToList();
            List<Appointment> applicationAppToXml = new List<Appointment>();
            foreach (Appointment i in applicationApp)
            {
                applicationAppToXml.Add(new Appointment
                {

                    dateAppointmentJEE = i.dateAppointmentJEE,
                    reason = i.reason,
                    HourAppointment = i.HourAppointment,
                    appointmentId = i.appointmentId,
                    state = i.state,
                    Iddoctor = i.Iddoctor

                });
            }
            return applicationApp.AsQueryable();
        }
        // GET: api/IdentityExposition
        public IQueryable<Appointment> GetVisit(int id)

        {

            List<Appointment> applicationApp = serviceApp.GetVisitByID(id).ToList();
            List<Appointment> applicationAppToXml = new List<Appointment>();
            foreach (Appointment i in applicationApp)
            {
                applicationAppToXml.Add(new Appointment
                {

                    dateAppointmentJEE = i.dateAppointmentJEE,
                    reason = i.reason,
                    HourAppointment = i.HourAppointment,
                    appointmentId = i.appointmentId,
                    state = i.state,
                    Iddoctor = i.Iddoctor

                });
            }
            return applicationApp.AsQueryable();
        }
        public IEnumerable<Appointment> GetMyApp(int id)

        {
            return serviceApp.GetAppointmentsByID(id);
            
        }

        // GET: api/IdentityExposition

        public IEnumerable<Domain.Entities.Departement> GetDentaire()
        {
            return serviceAppointement.hematologie();
        }
        // GET: api/IdentityExposition
        public IEnumerable<Appointment> GetDeleteRDV(int id)
        {
            return serviceApp.AnnulerRDV(id);
        }
        public IEnumerable<Appointment> GetDeleteToutRDV(int id)
        {
            return serviceApp.AnnulerToutRDV(id);
        }
    }
}
