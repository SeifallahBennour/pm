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
   public  class ServiceUser : Service<Domain.Entities.User>, IServiceUser
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);
        public ServiceUser() : base(ut)
        {

        }
        //public List<User> Listeuser()
        //{
        //    List<User> Users = new List<User>();



        //    string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
        //    using (System.Data.SqlClient.SqlConnection s = new SqlConnection(connectionString))
        //    {
        //        s.Open();
        //        using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName  FROM Users u ", s))
        //        {
        //            cmdSelect.CommandType = CommandType.Text;
        //            using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
        //            {
        //                while (sqlDataReader.Read())
        //                {
        //                    Users.Add(new User
        //                    {
                              

        //                        firstName = sqlDataReader[0].ToString(),
        //                        lastName = sqlDataReader[1].ToString(),
        //                        UserName = sqlDataReader[3].ToString(),
                                

        //                    });

        //                }

        //            }
        //        }

        //    }

        //    return Users;


        //}





        public List<Domain.Entities.User> getUsers()
        {
            IEnumerable<Domain.Entities.User> u = (from user in ut.GetRepository<Domain.Entities.User>().GetMany() select user);
            List<Domain.Entities.User> list = u.ToList<User>();
            return list; 
     
        }
    }

}


