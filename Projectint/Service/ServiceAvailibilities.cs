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
    public class ServiceAvailibilities : Service<Availability>, IServiceAvalibilities
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);
        public ServiceAvailibilities() : base(ut)
        {

        }
        public List<Availability> ListAvailibilities(int id)
        {
            
            List<Availability> ListAvailibilities = new List<Availability>();


            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                
                using (SqlCommand cmdSelect = new SqlCommand($"SELECT dateDisponobilite  from Availabilities A , Users U where A.DoctorId={id} and U.Id=A.DoctorId", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ListAvailibilities.Add(new Availability
                            {

                                dateDisponobilite = (DateTime)sqlDataReader[0],


                            });

                        }

                    }
                }


            }


            return ListAvailibilities;

        }


    }
}
