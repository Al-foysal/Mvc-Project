using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M7_Project_05
{
	public class ApplicationUser : IdentityUser
	{
	}
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
		{
			Database.SetInitializer(new DbInitializer());
		}

	}
	public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			var store = new RoleStore<IdentityRole>(context);
			var manager = new RoleManager<IdentityRole>(store);
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			if (!context.Roles.Any(x => x.Name == "Admin"))
			{
				manager.Create(new IdentityRole("Admin"));
			}
			if (!context.Roles.Any(x => x.Name == "Member"))
			{
				manager.Create(new IdentityRole("Member"));
			}
			if (!context.Users.Any(x => x.UserName == "Fahad"))
			{
				var user = new ApplicationUser { UserName = "Fahad" };

				userManager.Create(user, "Onim14040");
				userManager.AddToRole(user.Id, "Admin");
			}
		}
	}
}