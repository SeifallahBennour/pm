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
    public class CategoryWSController : ApiController
    {
        CategoryService servicecategory = new CategoryService();


        // GET: api/CategoryWA
        public IEnumerable<Category> GetCat()
        {
            return servicecategory.GetAll();

        }





        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/CategoryWS/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CategoryWS
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CategoryWS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CategoryWS/5
        public void Delete(int id)
        {
        }
    }
}
