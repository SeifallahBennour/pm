using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Service
{
    public class ProjectService : Service<Project>, IProjectService
    {

        private static IDataBaseFactory databaseFactory = new DataBaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public String s2  { get; set; }

        public ProjectService() : base(unit)
        {

        }


        //APICONTROLLER

        public void AddProjectWS(Project project)
        {

            Project p = new Project();

            p.projectId = project.projectId;
            p.projectname = project.projectname;
            p.team_leaderId = project.team_leaderId;
            p.categoryId = project.categoryId;
            p.DateDebut = DateTime.Now;
           //

           
            // p.datepost = DateTime.Now;

            Add(p);
            Commit();




        }




        public virtual List<Project> ListProject()
        {
            //Appointment AppModel = new Appointment();
            //Intervention InterModel = new Intervention();

            List<Project> ListProject = new List<Project>();


            string connectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=pm;Integrated Security=true";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect = new SqlCommand($"SELECT Sum (Difficultes.Valeur) As Duree,Projects.projectname,Projects.DateDebut From Tasks, Projects, Difficultes WHERE Tasks.projectId = Projects.projectId AND Tasks.DifficulteId = Difficultes.DifficulteId GROUP BY Projects.projectname,Projects.DateDebut ; ", s))

                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ListProject.Add(new Project
                            {

                                Somme = (int)sqlDataReader[0],
                                projectname = sqlDataReader[1].ToString(),
                              
                            DateDebut = DateTime.Parse(sqlDataReader[2].ToString())


                        });

                        }

                    }
                }


            }


            return ListProject;



        }
    }
}
