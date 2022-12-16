using Microsoft.AspNet.Identity.EntityFramework;

namespace LearnPortal.DAL.Entities.UserType
{
    public class ApplicationUser : IdentityUser
    {
        public virtual User User { get; set; }
    }
}
