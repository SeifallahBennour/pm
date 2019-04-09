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
    public class PostComWSController : ApiController
    {
       
        PostCommmService servicepostcom = new PostCommmService();


        // GET: api/PostComWS
        public IEnumerable<PostComm> GetPostCom()
        {
            return servicepostcom.GetAll();

        }

        // GET: api/PostComWS/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PostComWS
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PostComWS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PostComWS/5
        public void Delete(int id)
        {
        }
    }
}
