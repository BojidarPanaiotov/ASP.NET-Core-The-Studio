namespace ASP.NET_Core_The_Studio.Services.Services.Rarity
{
    using System.Collections.Generic;
    public interface IRarityService
    {
        IEnumerable<T> GetAll<T>();
        T GetByName<T>(string name);
        T GetById<T>(string id);
    }
}
