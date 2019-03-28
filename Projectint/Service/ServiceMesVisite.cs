using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceMesVisite : Service<Appointment>, IServiceMesVisite
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);
        IServiceUser serviceUser = null;

        public ServiceMesVisite() : base(ut)
        {
            serviceUser = new ServiceUser();

        }

        public virtual List<Appointment> MesVisiteJEE(int a)
        {


            List<Appointment> Appointments = new List<Appointment>();

            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand($"SELECT dateAppointmentJEE ,reason,HourAppointment, Users.firstName ,appointmentId ,state ,Users.lastName from Appointments ,Users  where Appointments.IdPatient={ a } and Appointments.Iddoctor=Users.Id and Appointments.state='valider'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Appointments.Add(new Appointment
                            {

                                dateAppointmentJEE = sqlDataReader[0].ToString(),
                                reason = sqlDataReader[1].ToString(),
                                HourAppointment = (int)sqlDataReader[2],
                                appointmentId = (int)sqlDataReader[4],
                                state = sqlDataReader[5].ToString(),
                                Doctor = new Doctor
                                {

                                    firstName = sqlDataReader[3].ToString(),
                                    lastName = sqlDataReader[6].ToString(),
                                }
                            });
                        }
                    }
                }
            }
            return Appointments;
        }


    }
}
