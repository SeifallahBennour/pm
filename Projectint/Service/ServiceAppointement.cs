using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Service
{
    public class ServiceAppointement : Service<Appointment>, IServiceAppointement
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);
        IServiceUser serviceUser = null;
        public ServiceAppointement() : base(ut)
        {
            serviceUser = new ServiceUser();

        }
        public List<Appointment> AnnulerAppointment(string email)
        {
            var listpatient = serviceUser.GetMany();
            var patient = listpatient.SingleOrDefault(pt => pt.Email == email);
            Domain.Entities.Appointment App = new Domain.Entities.Appointment();
            var p = patient.Id;
            var Rdvs = new List<Appointment>();
            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM Appointments WHERE CONVERT(VARCHAR(10), datePriseRDV, 101) = CONVERT(VARCHAR(10), GETDATE(), 101)and appointmentId = (SELECT MAX(appointmentId) FROM Appointments where IdPatient = {p})", con))
                using (SqlDataReader reader = command.ExecuteReader()) { };

            }

            return Rdvs;




        }
        public List<Appointment> AnnulerAppointmentJEE(int id)
        {
            List<Appointment> Appointments = new List<Appointment>();

            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM Appointments WHERE CONVERT(VARCHAR(10), datePriseRDV, 101) = CONVERT(VARCHAR(10), GETDATE(), 101)and appointmentId = (SELECT MAX(appointmentId) FROM Appointments where IdPatient = {id})", con))
                using (SqlDataReader reader = command.ExecuteReader()) { };

            }

            return Appointments;




        }
        public List<Appointment> AnnulerRDV(int id)
        {
            List<Appointment> Appointments = new List<Appointment>();

            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM Appointments WHERE appointmentId = {id}", con))
                using (SqlDataReader reader = command.ExecuteReader()) { };

            }

            return Appointments;




        }

        public List<Appointment> AnnulerToutRDV(int id)
        {
            List<Appointment> Appointments = new List<Appointment>();

            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM Appointments WHERE IdPatient = {id}", con))
                using (SqlDataReader reader = command.ExecuteReader()) { };

            }

            return Appointments;




        }




        public virtual List<Appointment> GetAppointmentsByID(int a)
        {


            List<Appointment> Appointments = new List<Appointment>();

            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                using (SqlCommand cmdSelect = new SqlCommand($"SELECT dateAppointmentJEE ,reason,HourAppointment, Users.firstName , appointmentId ,state , Specialities.nom ,Users.lastName from Appointments ,Users ,Specialities where (Appointments.IdPatient={ a }) and (Appointments.Iddoctor=Users.Id) and (Specialities.SpecialityId=Users.SpecialityId) and (Appointments.state='Invalide')", s))
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
                                    lastName = sqlDataReader[7].ToString(),
                                    specialite = new Speciality
                                    {
                                        nom = sqlDataReader[6].ToString(),
                                    }
                                }
                                
                            });
                        }
                    }
                }
            }
            return Appointments;
        }

        public virtual List<Appointment> GetVisitByID(int a)
        {


            List<Appointment> Appointments = new List<Appointment>();

            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                using (SqlCommand cmdSelect = new SqlCommand($"SELECT dateAppointmentJEE ,reason,HourAppointment, Users.firstName , appointmentId ,state , Specialities.nom ,Users.lastName from Appointments ,Users ,Specialities where Appointments.IdPatient={ a } and Appointments.Iddoctor=Users.Id and Specialities.SpecialityId=Users.SpecialityId and Appointments.state='valide'", s))
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
                                    lastName = sqlDataReader[7].ToString(),
                                    specialite = new Speciality
                                    {
                                        nom = sqlDataReader[6].ToString(),
                                    }
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
