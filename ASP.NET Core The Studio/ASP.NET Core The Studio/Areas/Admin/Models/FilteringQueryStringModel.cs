namespace ASP.NET_Core_The_Studio.Areas.Admin.Models
{
    public class FilteringQueryStringModel
    {
        //Search Term
        public string SearchTerm { get; set; }
        //Geners
        public string Criminal { get; set; }
        public string Drama { get; set; }
        public string Fantasy { get; set; }
        public string Historical { get; set; }
        public string Horror { get; set; }
        public string Mystery { get; set; }
        public string Romance { get; set; }
        public string Thriller { get; set; }
        //Rarity
        public string Common { get; set; }
        public string Rare { get; set; }
        public string Antique { get; set; }
        public string Event { get; set; }
        public string Limited { get; set; }
    }
}
