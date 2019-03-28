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
    public class ServiceDepartement : Service<Departement>, IServiceDepartement
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);

        public ServiceDepartement() : base(ut)
        {




        }


        public List<Doctor> Doctors()
        {
            List<Doctor> departements = new List<Doctor>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , nom ,Id FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Doctor
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                specialite = new Speciality
                                {
                                    nom = sqlDataReader[5].ToString(),

                                 
                                }
                              

                            });

                        }

                    }
                }

            }

            return departements;


        }




        public List<Departement> hematologie()
        {
            List<Departement> departements = new List<Departement>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , nom ,Id FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor' and s.nom Like 'hémato%'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Departement
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                nom = sqlDataReader[5].ToString(),

                            });

                        }

                    }
                }

            }

            return departements;


        }




        public List<Departement> anesthesiologie()
        {
            List<Departement> departements = new List<Departement>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , nom ,Id FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor' and s.nom Like 'anesthési%'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Departement
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                nom = sqlDataReader[5].ToString(),

                            });

                        }

                    }
                }

            }

            return departements;


        }
        public List<Departement> radio()
        {
            List<Departement> departements = new List<Departement>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , nom ,Id FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor' and s.nom Like '%radio%'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Departement
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                nom = sqlDataReader[5].ToString(),

                            });

                        }

                    }
                }

            }

            return departements;


        }
        public List<Departement> ophtalmo()
        {
            List<Departement> departements = new List<Departement>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , Id nom  FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor' and s.nom Like '%ophtalmo%'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Departement
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                nom = sqlDataReader[5].ToString(),

                            });

                        }

                    }
                }

            }

            return departements;


        }
        public List<Departement> dentaire()
        {
            List<Departement> departements = new List<Departement>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , nom ,Id FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor' and s.nom Like '%dentaire%'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Departement
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                nom = sqlDataReader[5].ToString(),

                            });

                        }

                    }
                }

            }

            return departements;


        }

        public List<Departement> Chirurigie()
        {
            List<Departement> departements = new List<Departement>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , nom , Id FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor' and s.nom Like '%chirurgie%'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Departement
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                nom = sqlDataReader[5].ToString(),

                            });

                        }

                    }
                }

            }

            return departements;
        }
        public List<Departement> dermatology()
        {
            List<Departement> departements = new List<Departement>();



            string connectionString = @"Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand("SELECT  firstName , lastName , UserName , PhoneNumber , Address , nom ,Id  FROM Users u JOIN Specialities s on s.SpecialityId = u.SpecialityId  where u.RoleUser = 'Doctor'  and s.nom Like '%dermato%'", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            departements.Add(new Departement
                            {
                                Id = (int)sqlDataReader[6],

                                firstName = sqlDataReader[0].ToString(),
                                lastName = sqlDataReader[1].ToString(),
                                Email = sqlDataReader[2].ToString(),
                                PhoneNumber = sqlDataReader[3].ToString(),
                                Address = sqlDataReader[4].ToString(),
                                nom = sqlDataReader[5].ToString(),

                            });

                        }

                    }
                }

            }

            return departements;


        }

      
    }
}
