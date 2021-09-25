namespace ASP.NET_Core_The_Studio.Data.Entities
{
    public class ElectronicBookGener
    {
        public string ElectronicBookId { get; set; }
        public ElectronicBook ElectronicBook { get; set; }
        public string GenerId { get; set; }
        public Gener Gener { get; set; }
    }
}
