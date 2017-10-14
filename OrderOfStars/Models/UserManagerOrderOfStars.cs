using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace OrderOfStars.Models
{
    public class UserManagerOrderOfStars : UserManager<Users>
    {
        public UserManagerOrderOfStars(IUserStore<Users> store)
                : base(store)
        {
        }
        public static UserManagerOrderOfStars Create(IdentityFactoryOptions<UserManagerOrderOfStars> options,
                                                IOwinContext context)
        {
            OrderOfStarsBaseContext db = context.Get<OrderOfStarsBaseContext>();
            UserManagerOrderOfStars manager = new UserManagerOrderOfStars(new UserStore<Users>(db));
            return manager;
        }
    }
}