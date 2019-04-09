using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PostService  : Service<Post>, IPostService
    {
        private static IDataBaseFactory databaseFactory = new DataBaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public PostService() : base(unit)
        {

        }
       // PostService Ts = new PostService();
        public void AddPostWS(Post post)
        {
            
            Post p = new Post();

            p.postId = post.postId;
            p.posttitre = post.posttitre;
            p.userId = post.userId;
            p.categorypostId = post.categorypostId;
           // p.datepost = DateTime.Now;

            Add(p);
            Commit();


            

        }
    }
}
