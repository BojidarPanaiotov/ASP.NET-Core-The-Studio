namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System.Collections.Generic;
    using ASP.NET_Core_The_Studio.Data.Data.Entities;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ICollection<ElectronicBookApplicationUser> ElectronicBooks { get; init; } = new HashSet<ElectronicBookApplicationUser>();

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();
    }
}
