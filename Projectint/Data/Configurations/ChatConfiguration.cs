﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class ChatConfiguration : EntityTypeConfiguration<Appointment>
    {
        public ChatConfiguration()
        {

            HasOptional(s => s.path).WithMany(s => s.listeAppointment).HasForeignKey(s => s.appointmentId);
            HasOptional(s => s.Doctor).WithMany(s => s.Appointment).HasForeignKey(s => s.appointmentId);
            HasOptional(s => s.Patient).WithMany(s => s.Appointment).HasForeignKey(s => s.appointmentId);




        }

    }
}

