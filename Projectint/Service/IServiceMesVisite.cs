using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Service
{
    public interface IServiceMesVisite : IService<Appointment>
    {
 

        List<Appointment> MesVisiteJEE(int a);

       
    }
}
