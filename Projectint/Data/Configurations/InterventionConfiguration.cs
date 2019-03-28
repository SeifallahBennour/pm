using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class InterventionConfiguration : EntityTypeConfiguration<Intervention>
    {
        public InterventionConfiguration()
        {
           // HasRequired<Doctor>(s => s.doctor).WithMany(s => s.listeIntervention).HasForeignKey(s => s.interventionId);

        }
    }
}
