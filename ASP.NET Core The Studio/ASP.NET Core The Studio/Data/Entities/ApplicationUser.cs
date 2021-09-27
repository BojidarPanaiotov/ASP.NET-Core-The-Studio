using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ASP.NET_Core_The_Studio.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ElectronicBookApplicationUser> ElectronicBooks { get; init; }
    }
}
