using Data;
using Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApllication1;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class CalenderController : Controller
    {
        IServiceIntervention MyService = null;
   
        public CalenderController()
        {
            MyService = new ServiceIntervantion();
         
     
        }










        [HttpPost]
        public  ActionResult Create(allahmed inter)
        {
           User u = Getcurrentuser();
                Domain.Entities.Intervention App = new Domain.Entities.Intervention()
                {
                 
                    Description =  inter.myintervention.Description,
              idU=u.Id

            };


                MyService.Add(App);
                MyService.Commit();

            





            return RedirectToAction("DoctorProfile", "Calender");




        }



        public ActionResult TestBing()
        {
            return View();
        }





        // GET: Calender
        public ActionResult Calender()
        {
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            Domain.Entities.Intervention r = MyService.GetById(id);

            MyService.Delete(r);
            MyService.Commit();
            return RedirectToAction("DoctorProfile", "Calender");

        }






        public ActionResult DoctorProfile()
        {

            Models.Entities.User u = Getcurrentuser();

            SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=EpionneDb;Persist Security Info=True;User ID=;Password=");

            //SqlConnection conn = new SqlConnection("Data Source = ; AttachDbFilename =| DataDirectory |\aspnet - Epione.Presentation - 20181027124435.mdf; Initial Catalog = Epione; Integrated Security = True  providerName=System.Data.SqlClient");
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from [Users] where id=@zip", conn);

            //SqlCommand command = new SqlCommand("Select id from [Users] where name=@zip", conn);
            command.Parameters.AddWithValue("@zip", u.Id);

            Doctor D = new Models.Entities.Doctor();
            using (SqlDataReader reader = command.ExecuteReader())
            {


                while (reader.Read())

                {
                    int Id = Int32.Parse(String.Format("{0}", reader["Id"]));
                    string name = String.Format("{0}",reader["firstName"]);

                    string Adress = String.Format("{0}", reader["Address"]);
                    string Email = String.Format("{0}", reader["Email"]);
                    string Lname = String.Format("{0}", reader["lastName"]);
                    string imagePath = String.Format("{0}", reader["imagePath"]);

                    D = new Doctor { Id=Id,firstName=name,Address=Adress,Email=Email,lastName=Lname,imagePath=imagePath};

                    

                }

                reader.NextResult();
            }


            conn.Close();







            conn.Open();
            List<Intervention> Linter = new List<Intervention>();
            
            SqlCommand command2 = new SqlCommand("Select * from [Interventions] where idU=@zip", conn);

            //SqlCommand command = new SqlCommand("Select id from [Users] where name=@zip", conn);
            command2.Parameters.AddWithValue("@zip", u.Id);

            using (SqlDataReader reader = command2.ExecuteReader())
            {


                while (reader.Read())

                {
                    int Id = Int32.Parse(String.Format("{0}", reader["interventionId"]));
                    string name = String.Format("{0}", reader["Description"]);

                    Intervention Int = new Intervention {Description=name,interventionId=Id};
                    Linter.Add(Int);

                }

                reader.NextResult();  
            }


            conn.Close();
            
            allahmed ahmed = new allahmed { mydoctor = D, interventionList =Linter };


            return View(ahmed);
        }









        public JsonResult GetAvai()
        {
            User u = Getcurrentuser();
            // dc.Availabilitys.Where(e => e.doctor.Id == 1).ToList();
            using (Context dc = new Context())
            {
                var events = dc.Availabilitys.Where(a => a.idU == u.Id).ToList();
               // var events = dc.Availabilitys.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
        }









      


        public User Getcurrentuser()
        {

            SqlConnection conn = new SqlConnection("Data Source=AMAL;Initial Catalog=Epione;Integrated Security=True");

            //SqlConnection conn = new SqlConnection("Data Source = ; AttachDbFilename =| DataDirectory |\aspnet - Epione.Presentation - 20181027124435.mdf; Initial Catalog = Epione; Integrated Security = True  providerName=System.Data.SqlClient");
            conn.Open();

            string zip = User.Identity.Name;

            SqlCommand command = new SqlCommand("Select Id from [Users] where Email=@zip", conn);

            //SqlCommand command = new SqlCommand("Select id from [Users] where name=@zip", conn);
            command.Parameters.AddWithValue("@zip", zip);

            User userConnec = new User();

            using (SqlDataReader reader = command.ExecuteReader())
            {


                while (reader.Read())

                {
                    userConnec.Id = Int32.Parse(String.Format("{0}", reader["Id"]));





                }

                reader.NextResult();
            }


            conn.Close();


            return userConnec;
        }









        [HttpPost]
        public JsonResult SaveEvent(Domain.Entities.Availability e)
        {
            User u = Getcurrentuser();
            var status = false;
            using (Context dc = new Context())
            {
                if (e.id > 0)
                {
                    //Update the appointement 
                    var v = dc.Availabilitys.Where(a => a.id == e.id).FirstOrDefault();

                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.startHour = e.startHour;
                        v.endHour = e.endHour;
                        v.Description = e.Description;
                        v.IsfullDay = e.IsfullDay;
                        v.ThemeColor = e.ThemeColor;

                    }
                }
                else
                {
                    e.idU = u.Id;
                    dc.Availabilitys.Add(e);

                }
                try
                {
                    dc.SaveChanges();
                    status = true;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }



            }
            return new JsonResult { Data = new { status = status } };
        }






        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = false;
            using (Context dc = new Context())
            {
                var v = dc.Availabilitys.Where(a => a.id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Availabilitys.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }











    }
}