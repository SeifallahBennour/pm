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
    public class ProjectWSController : ApiController
    {
        
        ProjectService serviceprojects = new ProjectService();


        // GET: api/ProjectWS
        public IEnumerable<Project> Getpro()
        {
            return serviceprojects.GetAll();

        }

        //

        // GET: api/ProjectWS/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProjectWS
        //public void Post([FromBody]string value)
        //{
        //}

        ProjectService p = new ProjectService();
        
        [HttpPost]
        public HttpResponseMessage Project([FromBody] Project a)
        {

            //return p.findByName(a.Name);
            //return p.findByEmail(a.email);

            try
            {
                p.AddProjectWS(a);

                var message = Request.CreateErrorResponse(HttpStatusCode.Created, p.ToString());
                message.Headers.Location = new Uri(Request.RequestUri + p.ToString());

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/ProjectWS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProjectWS/5
        public void Delete(int id)
        {
        }
    }
}
