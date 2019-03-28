using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IServiceAppointement : IService<Appointment>
    {
        List<Appointment> AnnulerAppointment(string email);
        List<Appointment> GetAppointmentsByID(int a);
        List<Appointment> AnnulerAppointmentJEE(int id);
          List<Appointment> GetVisitByID(int a);
        List<Appointment> AnnulerRDV(int id);
        List<Appointment> AnnulerToutRDV(int id);

    }
}
