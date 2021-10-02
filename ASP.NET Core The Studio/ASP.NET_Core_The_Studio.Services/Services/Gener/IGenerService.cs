namespace ASP.NET_Core_The_Studio.Services.Services.Gener
{
    using System.Collections.Generic;
    public interface IGenerService
    {
        IEnumerable<T> GetAll<T>();
        T GetByName<T>(string name);
        T GetById<T>(string id);
    }
}
