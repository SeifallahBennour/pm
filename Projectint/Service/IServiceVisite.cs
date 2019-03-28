using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceVisite : IService<Visite>
    {
        List<Visite> MesVisite(string email);
    }
}
