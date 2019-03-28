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
    public class ServiceVisite : Service<Visite>, IServiceVisite
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);
        IServiceUser serviceUser = null;

        public ServiceVisite() : base(ut)
        {
            serviceUser = new ServiceUser();

        }
        public List<Visite> MesVisite(string email)
        {


            var listpatient = serviceUser.GetMany();
            var patient = listpatient.SingleOrDefault(pt => pt.Email == email);
            Domain.Entities.Appointment App = new Domain.Entities.Appointment();
            var p = patient.Id;
            List<Visite> visites = new List<Visite>();

            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                using (SqlCommand cmdSelect = new SqlCommand($"SELECT dateAppointment , datePriseRDV , reason , firstName ,lastName , Email , PhoneNumber , Address , note  from Appointments a JOIN  Users u on a.Iddoctor = u.Id where a.IdPatient={p} and a.state='valider' ", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            visites.Add(new Visite
                            {
                                dateAppointment = (DateTime)sqlDataReader[0],
                                datePriseRDV = (DateTime)sqlDataReader[1],
                                reason = sqlDataReader[2].ToString(),

                                firstName = sqlDataReader[3].ToString(),
                                lastName = sqlDataReader[4].ToString(),
                                Email = sqlDataReader[5].ToString(),
                                PhoneNumber = sqlDataReader[6].ToString(),
                                Address = sqlDataReader[7].ToString(),
                                note = (int)sqlDataReader[8],

                            });
                        }
                    }
                }
            }


            return visites;

        }
    }
}
