using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class AnalyticsController : Controller
    {
        [HttpGet]
        public ActionResult TauxRA(DateTime? dRdv)
        {
            int userId = User.Identity.GetUserId<int>();
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            double nbrAI, nbrTI, tha, tfa, ta218, ta1935, ta3664, ta65;
            DateTime bRdv = Convert.ToDateTime(dRdv);

            string cRdv = bRdv.ToString("yyyy-MM-dd");
            if (cRdv == "0001-01-01")
            {
                cRdv = "2013-02-13";
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string status = "SELECT count(appointmentId) FROM Appointments where state='canceled' and doctor_Id='" + userId + "' and dateAppointment='" + cRdv + "'";
                    SqlCommand sqlComm1 = new SqlCommand(status, con);
                    string status2 = "SELECT count(appointmentId) FROM Appointments where state<>'canceled' and doctor_Id='" + userId + "' and dateappointment='" + cRdv + "'";
                    SqlCommand sqlComm2 = new SqlCommand(status2, con);

                    string nbrTS = sqlComm2.ExecuteScalar().ToString();
                    nbrTI = Convert.ToDouble(nbrTS);

                    string nbrAS = sqlComm1.ExecuteScalar().ToString();
                    nbrAI = Convert.ToDouble(nbrAS);

                    string status3 = "SELECT count(appointmentId) FROM Appointments a inner join Users u on a.patient_Id=u.Id where state='canceled' and gender='homme' and doctor_Id='" + userId + "' and dateAppointment='" + cRdv + "'";
                    SqlCommand sqlComm3 = new SqlCommand(status3, con);
                    string t3 = sqlComm3.ExecuteScalar().ToString();
                    tha = Convert.ToDouble(t3);

                    string status4 = "SELECT count(appointmentId) FROM Appointments a inner join Users u on a.patient_Id=u.Id where state='canceled' and gender='femme' and doctor_Id='" + userId + "' and dateappointment='" + cRdv + "'";
                    SqlCommand sqlComm4 = new SqlCommand(status4, con);

                    string t4 = sqlComm4.ExecuteScalar().ToString();
                    tfa = Convert.ToDouble(t4);

                    string status5 = "SELECT count(appointmentId) FROM Appointments a inner join Users u on a.patient_Id=u.Id where state='canceled' and age between '2' and '18' and doctor_Id='" + userId + "' and dateAppointment='" + cRdv + "'";
                    SqlCommand sqlComm5 = new SqlCommand(status5, con);
                    string t5 = sqlComm5.ExecuteScalar().ToString();
                    ta218 = Convert.ToDouble(t5);

                    string status6 = "SELECT count(appointmentId) FROM Appointments a inner join Users u on a.patient_Id=u.Id where state='canceled' and age between '19' and '35' and doctor_Id='" + userId + "' and dateAppointment='" + cRdv + "'";
                    SqlCommand sqlComm6 = new SqlCommand(status6, con);
                    string t6 = sqlComm6.ExecuteScalar().ToString();
                    ta1935 = Convert.ToDouble(t6);

                    string status7 = "SELECT count(appointmentId) FROM Appointments a inner join Users u on a.patient_Id=u.Id where state='canceled' and age between '36' and '64' and doctor_Id='" + userId + "' and dateAppointment='" + cRdv + "'";
                    SqlCommand sqlComm7 = new SqlCommand(status7, con);
                    string t7 = sqlComm7.ExecuteScalar().ToString();
                    ta3664 = Convert.ToDouble(t7);

                    string status8 = "SELECT count(appointmentId) FROM Appointments a inner join Users u on a.patient_Id=u.Id where state='canceled' and age>'64' and doctor_Id='" + userId + "' and dateAppointment='" + cRdv + "'";
                    SqlCommand sqlComm8 = new SqlCommand(status8, con);
                    string t8 = sqlComm8.ExecuteScalar().ToString();
                    ta65 = Convert.ToDouble(t8);





                }
                ViewBag.tha = tha;
                ViewBag.tfa = tfa;
                ViewBag.ta218 = ta218;
                ViewBag.ta1935 = ta1935;
                ViewBag.ta3664 = ta3664;
                ViewBag.ta65 = ta65;
                ViewBag.anu = nbrAI;
                ViewBag.tot = nbrTI;
            }


            return View();

        }
        [HttpGet]
        public ActionResult TauxRVpj(DateTime? dVac)
        {
            int userId = User.Identity.GetUserId<int>();
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            double diffm;
            double tai;
            DateTime bVac = Convert.ToDateTime(dVac);

            string cVac = bVac.ToString("yyyy-MM-dd");
            if (cVac == "0001-01-01")
            {
                cVac = "2013-02-13";
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string status = "SELECT startHour from Availabilities where Day='" + cVac + "' and doctor_Id='" + userId + "'";
                    SqlCommand sqlComm1 = new SqlCommand(status, con);
                    string hd = sqlComm1.ExecuteScalar().ToString();
                    string status2 = "SELECT EndHour from Availabilities where Day='" + cVac + "' and doctor_Id='" + userId + "'";
                    SqlCommand sqlComm2 = new SqlCommand(status2, con);
                    string hf = sqlComm2.ExecuteScalar().ToString();
                    DateTime time = DateTime.Parse(hd);
                    DateTime time2 = DateTime.Parse(hf);
                    double diff = (time2 - time).TotalMinutes;
                    diffm = diff / 15;


                    string status3 = "SELECT count(appointmentId) from Appointments where dateAppointment='" + cVac + "'and doctor_Id='" + userId + "'";
                    SqlCommand sqlComm3 = new SqlCommand(status3, con);
                    string ta = sqlComm3.ExecuteScalar().ToString();
                    tai = Convert.ToDouble(ta);
                    diffm = diffm - tai;
                }
                ViewBag.diffm = diffm;
                ViewBag.tai = tai;
            }


            return View();
        }
        [HttpGet]
        public ActionResult NbrPTPJ(DateTime? a)
        {

            double tai;
            double tf;
            double th;
            double t218;
            double t1935;
            double t3664;
            double t65;

            int userId = User.Identity.GetUserId<int>();
            DateTime b = Convert.ToDateTime(a);

            string c = b.ToString("yyyy-MM-dd");

            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            if (c == "0001-01-01")
            {
                c = "2013-02-13";
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string status3 = "SELECT count(DISTINCT(patient_Id)) from Appointments where dateAppointment='" + c + "' and doctor_Id='" + userId + "'and state='confirmed'";
                    SqlCommand sqlComm3 = new SqlCommand(status3, con);
                    string ta = sqlComm3.ExecuteScalar().ToString();
                    tai = Convert.ToDouble(ta);

                    string status2 = "SELECT count(DISTINCT(patient_Id)) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment='" + c + "' and doctor_Id='" + userId + "' and state='confirmed' and gender='femme'";
                    SqlCommand sqlComm2 = new SqlCommand(status2, con);
                    string t1 = sqlComm2.ExecuteScalar().ToString();


                    string status1 = "SELECT count(DISTINCT(patient_Id)) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment='" + c + "' and doctor_Id='" + userId + "'and state='confirmed' and gender='homme'";
                    SqlCommand sqlComm1 = new SqlCommand(status1, con);
                    string t2 = sqlComm1.ExecuteScalar().ToString();
                    tf = Convert.ToDouble(t1);
                    th = Convert.ToDouble(t2);



                    string status4 = "SELECT count(DISTINCT(patient_Id)) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment='" + c + "' and doctor_Id='" + userId + "'and state='confirmed' and age between '2' and '18'";
                    SqlCommand sqlComm4 = new SqlCommand(status4, con);
                    string t4 = sqlComm4.ExecuteScalar().ToString();
                    t218 = Convert.ToDouble(t4);


                    string status5 = "SELECT count(DISTINCT(patient_Id)) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment='" + c + "' and doctor_Id='" + userId + "'and state='confirmed' and age between '19' and '35'";
                    SqlCommand sqlComm5 = new SqlCommand(status5, con);
                    string t5 = sqlComm1.ExecuteScalar().ToString();
                    t1935 = Convert.ToDouble(t5);


                    string status6 = "SELECT count(DISTINCT(patient_Id)) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment='" + c + "' and doctor_Id='" + userId + "'and state='confirmed' and age between '36' and '64'";
                    SqlCommand sqlComm6 = new SqlCommand(status6, con);
                    string t6 = sqlComm6.ExecuteScalar().ToString();
                    t3664 = Convert.ToDouble(t6);


                    string status7 = "SELECT count(DISTINCT(patient_Id)) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment='" + c + "' and doctor_Id='" + userId + "'and state='confirmed' and age>'64'";
                    SqlCommand sqlComm7 = new SqlCommand(status7, con);
                    string t7 = sqlComm7.ExecuteScalar().ToString();
                    t65 = Convert.ToDouble(t7);

                }
                ViewBag.th = th;
                ViewBag.tf = tf;
                ViewBag.t218 = t218;
                ViewBag.t1935 = t1935;
                ViewBag.t3664 = t3664;
                ViewBag.t65 = t65;
                ViewBag.tai = tai;


            }
            return View();
        }

        [HttpGet]
        public ActionResult NbrTPT(DateTime? dbt, DateTime? dft)
        {
            int userId = User.Identity.GetUserId<int>();
            DateTime b = Convert.ToDateTime(dbt);
            DateTime c = Convert.ToDateTime(dft);
            double tht;
            double tft;
            double t218;
            double t1935;
            double t3664;
            double t65;
            string d = b.ToString("yyyy-MM-dd");
            string f = c.ToString("yyyy-MM-dd");
            List<string> NbrTPT = new List<string>();
            List<string> DatePRV = new List<string>();

            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            if (d == "0001-01-01" && f == "0001-01-01")
            {
                d = "2013-02-13";
                f = "2013-05-20";
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("SELECT count(DISTINCT(patient_Id)),dateAppointment from Appointments where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed' group by dateAppointment", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NbrTPT.Add(reader.GetInt32(0).ToString());
                            DatePRV.Add(reader.GetDateTime(1).ToString("dd/MM"));


                        }
                    }
                    string status1 = "SELECT count(patient_Id) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='confirmed' and gender='femme'";
                    SqlCommand sqlComm1 = new SqlCommand(status1, con);
                    string t1 = sqlComm1.ExecuteScalar().ToString();
                    tft = Convert.ToDouble(t1);

                    string status2 = "SELECT count(patient_Id) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='confirmed' and gender='homme'";
                    SqlCommand sqlComm2 = new SqlCommand(status2, con);
                    string t2 = sqlComm2.ExecuteScalar().ToString();
                    tht = Convert.ToDouble(t2);

                    string status4 = "SELECT count(patient_Id) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and  doctor_Id='" + userId + "'and state='confirmed' and age between '2' and '18'";
                    SqlCommand sqlComm4 = new SqlCommand(status4, con);
                    string t4 = sqlComm4.ExecuteScalar().ToString();
                    t218 = Convert.ToDouble(t4);


                    string status5 = "SELECT count(patient_Id) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between'" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='confirmed' and age between '19' and '35'";
                    SqlCommand sqlComm5 = new SqlCommand(status5, con);
                    string t5 = sqlComm1.ExecuteScalar().ToString();
                    t1935 = Convert.ToDouble(t5);


                    string status6 = "SELECT count(patient_Id) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='confirmed' and age between '36' and '64'";
                    SqlCommand sqlComm6 = new SqlCommand(status6, con);
                    string t6 = sqlComm6.ExecuteScalar().ToString();
                    t3664 = Convert.ToDouble(t6);


                    string status7 = "SELECT count(patient_Id) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='confirmed' and age>'64'";
                    SqlCommand sqlComm7 = new SqlCommand(status7, con);
                    string t7 = sqlComm7.ExecuteScalar().ToString();
                    t65 = Convert.ToDouble(t7);

                }
                ViewBag.t218 = t218;
                ViewBag.t1935 = t1935;
                ViewBag.t3664 = t3664;
                ViewBag.t65 = t65;
                ViewBag.tht = tht;
                ViewBag.tft = tft;
            }

            ViewBag.NbrTPt = NbrTPT;
            ViewBag.DatePRV = DatePRV;
            return View();
        }
        [HttpGet]
        public ActionResult TauxRAT(DateTime? dbt, DateTime? dft)
        {
            double tai, raft, raht, tat218, tat1935, tat3664, tat65;
            DateTime b = Convert.ToDateTime(dbt);
            DateTime c = Convert.ToDateTime(dft);
            string d = b.ToString("yyyy-MM-dd");
            string f = c.ToString("yyyy-MM-dd");
            int userId = User.Identity.GetUserId<int>();
            List<string> NbrState = new List<string>();
            List<string> DateRAT = new List<string>();
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            if (d == "0001-01-01" && f == "0001-01-01")
            {
                d = "2013-02-13";
                f = "2013-05-20";
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string status3 = "SELECT count(appointmentId)  FROM Appointments where doctor_Id='" + userId + "' and dateAppointment between '" + d + "' and '" + f + "'";
                    SqlCommand sqlComm3 = new SqlCommand(status3, con);
                    string ta = sqlComm3.ExecuteScalar().ToString();
                    tai = Convert.ToDouble(ta);


                    using (SqlCommand command = new SqlCommand("SELECT count(appointmentId),dateAppointment FROM Appointments where doctor_Id='" + userId + "' and dateAppointment between '" + d + "' and '" + f + "' and  state='canceled' group by dateAppointment", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NbrState.Add((Math.Round(((reader.GetInt32(0)) / tai) * 100)).ToString());
                            DateRAT.Add(reader.GetDateTime(1).ToString("dd/MM"));


                        }
                    }

                    string status4 = "SELECT count(appointmentId)  FROM Appointments a inner join Users u on patient_Id=Id  where gender='femme' and state='canceled' and doctor_Id='" + userId + "' and dateAppointment between '" + d + "' and '" + f + "'";
                    SqlCommand sqlComm4 = new SqlCommand(status4, con);
                    string t4 = sqlComm4.ExecuteScalar().ToString();
                    raft = Convert.ToDouble(t4);

                    string status5 = "SELECT count(appointmentId)  FROM Appointments a inner join Users u on patient_Id=Id  where gender='homme' and state='canceled' and doctor_Id='" + userId + "' and dateAppointment between '" + d + "' and '" + f + "'";
                    SqlCommand sqlComm5 = new SqlCommand(status5, con);
                    string t5 = sqlComm5.ExecuteScalar().ToString();
                    raht = Convert.ToDouble(t5);

                    string status9 = "SELECT count(appointmentId) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and  doctor_Id='" + userId + "'and state='canceled' and age between '2' and '18'";
                    SqlCommand sqlComm9 = new SqlCommand(status9, con);
                    string t9 = sqlComm9.ExecuteScalar().ToString();
                    tat218 = Convert.ToDouble(t9);


                    string status10 = "SELECT count(appointmentId) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between'" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='canceled' and age between '19' and '35'";
                    SqlCommand sqlComm10 = new SqlCommand(status10, con);
                    string t10 = sqlComm10.ExecuteScalar().ToString();
                    tat1935 = Convert.ToDouble(t10);


                    string status6 = "SELECT count(appointmentId) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='canceled' and age between '36' and '64'";
                    SqlCommand sqlComm6 = new SqlCommand(status6, con);
                    string t6 = sqlComm6.ExecuteScalar().ToString();
                    tat3664 = Convert.ToDouble(t6);


                    string status7 = "SELECT count(appointmentId) from Appointments a inner join Users u on a.patient_Id=u.Id where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "'and state='canceled' and age>'64'";
                    SqlCommand sqlComm7 = new SqlCommand(status7, con);
                    string t7 = sqlComm7.ExecuteScalar().ToString();
                    tat65 = Convert.ToDouble(t7);


                }
                ViewBag.tat218 = tat218;
                ViewBag.tat1935 = tat1935;
                ViewBag.tat3664 = tat3664;
                ViewBag.tat65 = tat65;
                ViewBag.tai = tai;
                ViewBag.raft = raft;
                ViewBag.raht = raht;
            }

            ViewBag.NbrState = NbrState;
            ViewBag.DateRAT = DateRAT;



            return View();
        }
        [HttpGet]
        public ActionResult TauxRVT(DateTime? dbt, DateTime? dft)
        {
            DateTime b = Convert.ToDateTime(dbt);
            DateTime c = Convert.ToDateTime(dft);
            string d = b.ToString("yyyy-MM-dd");
            string f = c.ToString("yyyy-MM-dd");
            List<string> TauxVac = new List<string>();
            List<string> DateVac = new List<string>();
            int userId = User.Identity.GetUserId<int>();
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            double tai;
            if (d == "0001-01-01" && f == "0001-01-01")
            {
                d = "2013-02-13";
                f = "2013-05-20";
            }
            else
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string status3 = "SELECT count(appointmentId)  FROM Appointments where doctor_Id='" + userId + "' and dateAppointment between '" + d + "' and '" + f + "'";
                    SqlCommand sqlComm3 = new SqlCommand(status3, con);
                    string ta = sqlComm3.ExecuteScalar().ToString();
                    tai = Convert.ToDouble(ta);


                    using (SqlCommand command = new SqlCommand("SELECT DATEDIFF(minute,startHour,endHour)/15,day from Availabilities where Day between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' order by day", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TauxVac.Add((Math.Round(((tai / (reader.GetInt32(0))) * 100))).ToString());
                            DateVac.Add(reader.GetDateTime(1).ToString("dd/MM"));


                        }
                    }


                }
                ViewBag.tai = tai;
            }
            ViewBag.TauxVac = TauxVac;
            ViewBag.DateVac = DateVac;

            return View();
        }
        [HttpGet]
        public ActionResult ChAfpj(DateTime? dca)
        {
            double tai, btf, bth, bt218, bt1935, bt3664, bt65;
            int userId = User.Identity.GetUserId<int>();
            DateTime b = Convert.ToDateTime(dca);
            string c = b.ToString("yyyy-MM-dd");
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            if (c == "0001-01-01")
            {
                c = "2013-02-13";
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string status7 = "SELECT Sum(price) from Appointments where dateAppointment='" + c + "' and doctor_Id='" + userId + "'and state='confirmed'";
                    SqlCommand sqlComm7 = new SqlCommand(status7, con);
                    string ta = sqlComm7.ExecuteScalar().ToString();
                    if (ta == "")
                    {
                        ta = "0";
                    }
                    tai = Math.Round(Convert.ToDouble(ta));

                    string status1 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where gender='femme' and dateAppointment='" + c + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm1 = new SqlCommand(status1, con);
                    string t1 = sqlComm1.ExecuteScalar().ToString();
                    if (t1 == "")
                    {
                        t1 = "0";
                    }
                    btf = Math.Round(Convert.ToDouble(t1));

                    string status2 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where gender='homme' and dateAppointment='" + c + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm2 = new SqlCommand(status2, con);
                    string t2 = sqlComm2.ExecuteScalar().ToString();
                    if (t2 == "")
                    {
                        t2 = "0";
                    }
                    bth = Math.Round(Convert.ToDouble(t2));

                    string status3 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age between '2' and '18' and dateAppointment='" + c + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm3 = new SqlCommand(status3, con);
                    string t3 = sqlComm3.ExecuteScalar().ToString();
                    if (t3 == "")
                    {
                        t3 = "0";
                    }
                    bt218 = Math.Round(Convert.ToDouble(t3));


                    string status4 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age between '19' and '35' and dateAppointment= '" + c + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm4 = new SqlCommand(status4, con);
                    string t4 = sqlComm4.ExecuteScalar().ToString();
                    if (t4 == "")
                    {
                        t4 = "0";
                    }
                    bt1935 = Math.Round(Convert.ToDouble(t4));


                    string status5 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age between '36' and '64' and dateAppointment= '" + c + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm5 = new SqlCommand(status5, con);
                    string t5 = sqlComm5.ExecuteScalar().ToString();
                    if (t5 == "")
                    {
                        t5 = "0";
                    }
                    bt3664 = Math.Round(Convert.ToDouble(t5));

                    string status6 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age>64 and dateAppointment= '" + c + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm6 = new SqlCommand(status6, con);
                    string t6 = sqlComm6.ExecuteScalar().ToString();
                    if (t6 == "")
                    {
                        t6 = "0";
                    }
                    bt65 = Math.Round(Convert.ToDouble(t6));




                }
                ViewBag.bt218 = bt218;
                ViewBag.bt1935 = bt1935;
                ViewBag.bt3664 = bt3664;
                ViewBag.bt65 = bt65;
                ViewBag.btf = btf;
                ViewBag.bth = bth;
                ViewBag.tai = tai;
            }

            return View();
        }
        [HttpGet]
        public ActionResult ChAfT(DateTime? dbt, DateTime? dft)
        {
            int userId = User.Identity.GetUserId<int>();
            double btf, bth, bt218, bt1935, bt3664, bt65;
            DateTime b = Convert.ToDateTime(dbt);
            DateTime c = Convert.ToDateTime(dft);
            string d = b.ToString("yyyy-MM-dd");
            string f = c.ToString("yyyy-MM-dd");
            List<string> TotB = new List<string>();
            List<string> DateB = new List<string>();
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            if (d == "0001-01-01" && f == "0001-01-01")
            {
                d = "2013-02-13";
                f = "2013-05-20";
            }
            else
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string status1 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where gender='femme' and dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm1 = new SqlCommand(status1, con);
                    string t1 = sqlComm1.ExecuteScalar().ToString();
                    if (t1 == "")
                    {
                        t1 = "0";
                    }
                    btf = Math.Round(Convert.ToDouble(t1));

                    string status2 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where gender='homme' and dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm2 = new SqlCommand(status2, con);
                    string t2 = sqlComm2.ExecuteScalar().ToString();
                    if (t2 == "")
                    {
                        t2 = "0";
                    }
                    bth = Math.Round(Convert.ToDouble(t2));

                    string status3 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age between '2' and '18' and dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm3 = new SqlCommand(status3, con);
                    string t3 = sqlComm3.ExecuteScalar().ToString();
                    if (t3 == "")
                    {
                        t3 = "0";
                    }
                    bt218 = Math.Round(Convert.ToDouble(t3));


                    string status4 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age between '19' and '35' and dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm4 = new SqlCommand(status4, con);
                    string t4 = sqlComm4.ExecuteScalar().ToString();
                    if (t4 == "")
                    {
                        t4 = "0";
                    }
                    bt1935 = Math.Round(Convert.ToDouble(t4));


                    string status5 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age between '36' and '64' and dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm5 = new SqlCommand(status5, con);
                    string t5 = sqlComm5.ExecuteScalar().ToString();
                    if (t5 == "")
                    {
                        t5 = "0";
                    }
                    bt3664 = Math.Round(Convert.ToDouble(t5));

                    string status6 = "SELECT Sum(price) from Appointments a inner join Users u on patient_Id=Id where age>64 and dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed'";
                    SqlCommand sqlComm6 = new SqlCommand(status6, con);
                    string t6 = sqlComm6.ExecuteScalar().ToString();
                    if (t6 == "")
                    {
                        t6 = "0";
                    }
                    bt65 = Math.Round(Convert.ToDouble(t6));



                    using (SqlCommand command = new SqlCommand("SELECT Sum(price),dateAppointment from Appointments where dateAppointment between '" + d + "' and '" + f + "' and doctor_Id='" + userId + "' and state='confirmed' group by dateAppointment", con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TotB.Add(Math.Round((reader.GetDouble(0))).ToString());
                            DateB.Add(reader.GetDateTime(1).ToString("dd/MM"));


                        }
                    }


                }
                ViewBag.bt218 = bt218;
                ViewBag.bt1935 = bt1935;
                ViewBag.bt3664 = bt3664;
                ViewBag.bt65 = bt65;
                ViewBag.btf = btf;
                ViewBag.bth = bth;
                ViewBag.TotB = TotB;
                ViewBag.DateB = DateB;
            }

            return View();
        }
        public ActionResult testpdf()
        {
            return View();
        }




        public class PatientP
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string phoneNumber { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string age { get; set; }
            public string nbr { get; set; }

        }
        [HttpGet]
        public ActionResult ListP()
        {
            List<PatientP> ListP = new List<PatientP>();
            int userId = User.Identity.GetUserId<int>();
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select firstName,lastName,phoneNumber,email,gender,age,count(appointmentId) as nbr from users u inner join appointments a on u.Id=a.patient_Id where doctor_id='" + userId + "'  group by firstName,lastName,phoneNumber,email,gender,age", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListP.Add(new PatientP { firstName = reader.GetString(0), lastName = reader.GetString(1), phoneNumber = reader.GetString(2), email = reader.GetString(3), gender = reader.GetString(4), age = reader.GetInt32(5).ToString(), nbr = reader.GetInt32(6).ToString() });
                    }
                }
            }
            ViewBag.ListP = ListP;
            return View();
        }
        public ActionResult DashboardD()
        {
            List<PatientP> ListP = new List<PatientP>();
            double revenues,totalpatients,nbrPTA,nbrPT,TauxAnu,TauxRempVac,SomV,tph,tpf,tp218,tp1935,tp3664,tp65;
            int userId = User.Identity.GetUserId<int>();
            List<string> TotR = new List<string>();
            List<string> DateR = new List<string>();
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EpionneDb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //revenus
                string status1 = "SELECT Sum(price) from Appointments where DATEDIFF(day,dateAppointment,getdate()) < 31 and doctor_Id='" + userId + "'and state='confirmed'";
                SqlCommand sqlComm1 = new SqlCommand(status1, con);
                string t1 = sqlComm1.ExecuteScalar().ToString();
                if (t1 == "")
                {
                    t1 = "0";
                }
                revenues = Math.Round(Convert.ToDouble(t1));

                //nombre de patients traités

                string status2 = "SELECT count(DISTINCT(patient_Id)) from Appointments where DATEDIFF(day,dateAppointment,getdate()) < 31 and doctor_Id='" + userId + "'and state='confirmed'";
                SqlCommand sqlComm2 = new SqlCommand(status2, con);
                string t2 = sqlComm2.ExecuteScalar().ToString();
                totalpatients = Convert.ToDouble(t2);

                //taux de rendez vous annulés
                
                string status3 = "SELECT count(appointmentId) FROM Appointments where state='canceled' and doctor_Id='" + userId + "' and DATEDIFF(day,dateAppointment,getdate()) < 31";
                SqlCommand sqlComm3 = new SqlCommand(status3, con);
                string t3 = sqlComm3.ExecuteScalar().ToString();
                nbrPTA = Convert.ToDouble(t3);


                string status4 = "SELECT count(appointmentId) FROM Appointments where  doctor_Id='" + userId + "' and DATEDIFF(day,dateAppointment,getdate()) < 31";
                SqlCommand sqlComm4 = new SqlCommand(status4, con);
                string t4 = sqlComm4.ExecuteScalar().ToString();
                nbrPT = Convert.ToDouble(t4);
                TauxAnu = Math.Round((nbrPTA / nbrPT) * 100);

                //taux de remplissage des vacations

                string status5 = "SELECT sum(DATEDIFF(minute,startHour,endHour)/15) from Availabilities where doctor_Id='" + userId + "' and DATEDIFF(day,Day,getdate()) < 31";
                SqlCommand sqlComm5 = new SqlCommand(status5, con);
                string t5 = sqlComm5.ExecuteScalar().ToString();
                SomV = Convert.ToDouble(t5);

                TauxRempVac = Math.Round((nbrPT / SomV) * 100);

                //revenues par jour de travail
                using (SqlCommand command = new SqlCommand("SELECT Sum(price),dateAppointment from Appointments where DATEDIFF(day,dateAppointment,getdate()) < 31 and doctor_Id='" + userId + "' and state='confirmed' group by dateAppointment", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TotR.Add(Math.Round((reader.GetDouble(0))).ToString());
                        DateR.Add(reader.GetDateTime(1).ToString("dd/MM"));


                    }
                }
                //liste des patients lors des 30 derniers jours
                using (SqlCommand command = new SqlCommand("select firstName,lastName,phoneNumber,email,gender,age,count(appointmentId) as nbr from users u inner join appointments a on u.Id=a.patient_Id where doctor_id='" + userId + "' and DATEDIFF(day,dateAppointment,getdate()) < 31  group by firstName,lastName,phoneNumber,email,gender,age", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListP.Add(new PatientP { firstName = reader.GetString(0), lastName = reader.GetString(1), phoneNumber = reader.GetString(2), email = reader.GetString(3), gender = reader.GetString(4), age = reader.GetInt32(5).ToString(), nbr = reader.GetInt32(6).ToString() });
                    }
                }
                //nombre patients par sexe
                string status6= "select count(distinct(patient_Id)) from users u inner join appointments a on u.Id=a.patient_Id where doctor_id='"+userId+"'  and DATEDIFF(day,dateAppointment,getdate()) < 31 and gender='femme'";
                SqlCommand sqlComm6 = new SqlCommand(status6, con);
                string t6 = sqlComm6.ExecuteScalar().ToString();
                tpf = Convert.ToDouble(t6);

                string status7 = "select count(distinct(patient_Id)) from users u inner join appointments a on u.Id=a.patient_Id where doctor_id='"+userId+"'  and DATEDIFF(day,dateAppointment,getdate()) < 31 and gender='homme'";
                SqlCommand sqlComm7 = new SqlCommand(status7, con);
                string t7 = sqlComm7.ExecuteScalar().ToString();
                tph = Convert.ToDouble(t7);

                //nombre de patients par age

                string status8 = "SELECT count(distinct(patient_id)) from Appointments a inner join Users u on a.patient_Id=u.Id where DATEDIFF(day,dateAppointment,getdate()) < 31 and  doctor_Id='" + userId + "' and age between '2' and '18'";
                SqlCommand sqlComm8 = new SqlCommand(status8, con);
                string t8 = sqlComm8.ExecuteScalar().ToString();
                tp218 = Convert.ToDouble(t8);


                string status9 = "SELECT count(distinct(patient_id)) from Appointments a inner join Users u on a.patient_Id=u.Id where DATEDIFF(day,dateAppointment,getdate()) < 31 and  doctor_Id='" + userId + "' and age between '19' and '35'";
                SqlCommand sqlComm9 = new SqlCommand(status9, con);
                string t9 = sqlComm9.ExecuteScalar().ToString();
                tp1935 = Convert.ToDouble(t9);


                string status10 = "SELECT count(distinct(patient_id)) from Appointments a inner join Users u on a.patient_Id=u.Id where DATEDIFF(day,dateAppointment,getdate()) < 31 and  doctor_Id='" + userId + "' and age between '36' and '64'";
                SqlCommand sqlComm10 = new SqlCommand(status10, con);
                string t10 = sqlComm10.ExecuteScalar().ToString();
                tp3664 = Convert.ToDouble(t10);


                string status11 = "SELECT count(distinct(patient_id)) from Appointments a inner join Users u on a.patient_Id=u.Id where DATEDIFF(day,dateAppointment,getdate()) < 31 and  doctor_Id='" + userId + "' and age>64";
                SqlCommand sqlComm11 = new SqlCommand(status11, con);
                string t11 = sqlComm11.ExecuteScalar().ToString();
                tp65 = Convert.ToDouble(t11);
            }
            ViewBag.tp218 = tp218;
            ViewBag.tp1935 = tp1935;
            ViewBag.tp3664 = tp3664;
            ViewBag.tp65 = tp65;
            ViewBag.tph = tph;
            ViewBag.tpf = tpf;
            ViewBag.ListP = ListP;
            ViewBag.TotR = TotR;
            ViewBag.DateR = DateR;
            ViewBag.TauxRempVac = TauxRempVac;
            ViewBag.TauxAnu = TauxAnu;
            ViewBag.revenues = revenues;
            ViewBag.totalpatients = totalpatients;
            return View();
        }




    }
}