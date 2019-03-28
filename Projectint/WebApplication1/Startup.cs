using System.Data;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Data;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
        }
        private void createRolesandUsers()
        {
            Context context = new Context();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User, int>(new CustomUserStore(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("SPAdmin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SPAdmin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new User();
                user.UserName = "SPAdmin";
                user.Email = "spadmin@esprit-tn.com";

                string userPWD = "*Passw0rd";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "SPAdmin");

                }
            }

            // creating Creating Responsable role    

            if (!roleManager.RoleExists("Client"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);
            }

            // creating Creating Resource role 
            if (!roleManager.RoleExists("Doctor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Doctor";
                roleManager.Create(role);
            }
        }
    }
}