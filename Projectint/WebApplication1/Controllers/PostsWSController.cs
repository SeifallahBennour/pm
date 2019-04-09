using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class PostsWSController : ApiController
    {
        
        PostService serviceposts = new PostService();


        // GET: api/PostsWS
        public IEnumerable<Post> Getpost()
        {
            return serviceposts.GetAll();

        }

        // GET: api/PostsWS/5
        public Post Getpost(int id)
        {
            return serviceposts.GetById(id);
        }

        // POST: api/PostsWS
        //public void Post([FromBody]string value)
        //{
        //}
        PostService p = new PostService();
        // POST: api/PostsWS
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Post a)
        {

            //return p.findByName(a.Name);
            //return p.findByEmail(a.email);

            try
            {
                p.AddPostWS(a);

                var message = Request.CreateErrorResponse(HttpStatusCode.Created, p.ToString());
                message.Headers.Location = new Uri(Request.RequestUri + p.ToString());

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/PostsWS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PostsWS/5
        public void Delete(int id)
        {
        }
    }
}
