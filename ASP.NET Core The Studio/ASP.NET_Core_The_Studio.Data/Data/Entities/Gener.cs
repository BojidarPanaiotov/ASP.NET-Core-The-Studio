namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Gener
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Name { get; init; }

        public ICollection<ElectronicBookGener> ElectronicBookGener { get; init; }
    }
}
