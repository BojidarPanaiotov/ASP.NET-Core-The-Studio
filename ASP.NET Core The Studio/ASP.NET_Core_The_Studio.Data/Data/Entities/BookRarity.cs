namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System;

    public class BookRarity
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
    }
}
