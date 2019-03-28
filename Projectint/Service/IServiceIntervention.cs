using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceIntervention : IService<Intervention>
    {
        List<Intervention> ListIntervention(int id);
    }
}
