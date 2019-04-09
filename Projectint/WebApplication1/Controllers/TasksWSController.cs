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
    public class TasksWSController : ApiController
    {

        TasksService servicetasks = new TasksService();


        // GET: api/TasksWS
        public IEnumerable<Tasks> Gettach()
        {
            return servicetasks.GetAll();

        }
        

        // GET: api/TasksWS/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TasksWS
        //public void Post([FromBody]string value)
        //{
        //}

        TasksService t = new TasksService();
     
        [HttpPost]
        public HttpResponseMessage Task([FromBody] Tasks a)
        {

            //return p.findByName(a.Name);
            //return p.findByEmail(a.email);

            try
            {
                t.AddTaskWS(a);

                var message = Request.CreateErrorResponse(HttpStatusCode.Created, t.ToString());
                message.Headers.Location = new Uri(Request.RequestUri + t.ToString());

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        // PUT: api/TasksWS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TasksWS/5
        public void Delete(int id)
        {
        }
    }
}
