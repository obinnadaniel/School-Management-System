using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolManagement.Models;
using System;

[assembly: OwinStartupAttribute(typeof(SchoolManagement.Startup))]
namespace SchoolManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        public void createRolesandUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@school.com",
                BirthDate = DateTime.Now
            };
            var password = "password";

            var usr = userManager.Create(user, password);

            if (usr.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, "Admin");
            }


            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

               
            }
            if (!roleManager.RoleExists("Lecturer"))
            {

                var role = new IdentityRole();
                    role.Name = "Lecturer";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Supervisor"))
            {

                var role = new IdentityRole();
                role.Name = "Supervisor";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("Student"))
            {

                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);

            }
        }
    }
}
