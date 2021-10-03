namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ICollection<ElectronicBookApplicationUser> ElectronicBooks { get; init; }
    }
}
