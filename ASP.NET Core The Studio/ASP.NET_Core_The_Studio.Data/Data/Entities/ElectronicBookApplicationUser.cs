namespace ASP.NET_Core_The_Studio.Data.Entities
{
    public class ElectronicBookApplicationUser
    {
        public string ElectronicBookId { get; set; }

        public ElectronicBook ElectronicBook { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
