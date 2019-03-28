using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entities
{
    public class User : IdentityUser<int, CustomLogin, CustomUserRole, CustomUserClaim>
    {

       
      
        public int cin { get; set; }
        
        public string firstName { get; set; }
      
        public string lastName { get; set; }
       
        public string gender { get; set; }
        
        public string Address { get; set; }
      
        public virtual VilleModel villes { get; set; }

        public int? VilleId { get; set; }
        public int age { get; set; }

        public string RoleUser { get; set; }

        public virtual ICollection<ProjectViewModel> listprojet { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }



    }


    public class CustomLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
    public class CustomUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
    }
    public class CustomUserClaim : IdentityUserClaim<int>
    {

    }
    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

}

