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
    public class UserWSController : ApiController
    {
       
        UserService serviceusers = new UserService();


        // GET: api/UserWS       
        public IEnumerable<User> Getuse()
        {
            return serviceusers.GetAll();

        }

        // GET: api/UserWS/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserWS
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserWS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserWS/5
        public void Delete(int id)
        {
        }
    }
}
