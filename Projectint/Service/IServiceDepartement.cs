using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IServiceDepartement : IService<Departement>
    {
         List<Departement> hematologie();
        List<Departement> anesthesiologie();
        List<Departement> radio();
        List<Departement> ophtalmo();
        List<Departement> dentaire();
        List<Departement> Chirurigie();
        List<Departement> dermatology();
        List<Doctor> Doctors();


    }
}
