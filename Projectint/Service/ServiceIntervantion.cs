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
    public class ServiceIntervantion : Service<Intervention>, IServiceIntervention
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);
        public ServiceIntervantion() : base(ut)
        {

        }
        public virtual List<Intervention> ListIntervention(int id)
        {
            Appointment AppModel = new Appointment();
            Intervention InterModel = new Intervention();
        
            List<Intervention> ListIntervention = new List<Intervention>();

           
            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand($"select Description from Interventions I join Users U on I.DoctorId = U.Id where I.DoctorId ={id}", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ListIntervention.Add(new Intervention
                            { 

                                Description = sqlDataReader[0].ToString()
                               
                            });

                        }

                    }
                }


            }


            return ListIntervention;

        }



    }
}
