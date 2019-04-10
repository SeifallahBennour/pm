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
    public class BlogService : Service<Blog>, IBlogService
    {
        private static IDataBaseFactory databaseFactory = new DataBaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public BlogService() : base(unit)
        {

        }

        public List<Blog> ListBlog()
        {
            List<Blog> ListBlog = new List<Blog>();


            string connectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=pm;Integrated Security=true";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                using (SqlCommand cmdSelect = new SqlCommand($"SELECT  Blogs.blogId,Blogs.titreblog, Blogs.contenu ,Blogs.dateblog,Blogs.imagePath, Users.Email, Users.imagePath From Blogs, Users WHERE Blogs.userblogId = Users.Id  ; ", s))
                {
                    cmdSelect.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ListBlog.Add(new Blog
                            {
                                blogId = (int)sqlDataReader[0],
                                titreblog = sqlDataReader[1].ToString(),
                                contenu = sqlDataReader[2].ToString(),
                                username = sqlDataReader[5].ToString(),
                                dateblog = DateTime.Parse(sqlDataReader[3].ToString()),
                                imagePath = sqlDataReader[4].ToString()





                            });

                        }

                    }
                }


            }


            return ListBlog;


        }




    }
}
