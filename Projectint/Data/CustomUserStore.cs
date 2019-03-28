
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Data
{
    public class CustomUserStore : UserStore<User, CustomRole, int, CustomLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(Context context) : base(context)
        {
        }
    }
}