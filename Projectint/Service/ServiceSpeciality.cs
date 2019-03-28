using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceSpeciality : Service<Speciality>, IServiceSpeciality
    {

        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);

        public ServiceSpeciality() : base(ut)
        {

        }
        public Speciality getSpeciality(int? id)
        {
            Speciality Specialite = new Speciality();
            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("select * from Specialities where SpecialityId = " + id + "", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Specialite.SpecialityId = (int)reader[1];

                    }


                }
            }

            return Specialite;
        }

    }
    }

