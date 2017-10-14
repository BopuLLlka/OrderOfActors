using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext() : base("name=OrderOfStarsBaseContext") { }

    public static ApplicationContext Create()
    {
        return new ApplicationContext();
    }
}