using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epione.Data.Configuration
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {

        public UserConfiguration()
        {
            Map<Admin>(c => c.Requires("Role").HasValue("Admin"));
            Map<Manager>(c => c.Requires("Role").HasValue("Manager"));
            Map<Member>(c => c.Requires("Role").HasValue("Member"));
            Map<Patient>(c => c.Requires("Role").HasValue("Patient"));
            Map<Doctor>(c => c.Requires("Role").HasValue("Doctor"));
            Map<TeamLeader>(c => c.Requires("Role").HasValue("TeamLeader"));
            
        }

    }


    }
