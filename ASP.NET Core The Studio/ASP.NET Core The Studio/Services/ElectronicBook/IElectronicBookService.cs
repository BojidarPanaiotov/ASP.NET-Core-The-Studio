namespace ASP.NET_Core_The_Studio.Services.ElectronicBook
{
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IElectronicBookService
    {
        //TODO: Consider if this is the best way to built the interface (is there too many generic methods and is it a problem)
        Task<IEnumerable<T>> GetAll<T>();
        Task<IEnumerable<T>> GetAllByAuthor<T>(string authorName);
        Task<IEnumerable<T>> GetAllByCategory<T>();
        IEnumerable<T> GetAllCategoires<T>();
        ElectronicBookServiceModel GetById(string id);
        ElectronicBookServiceModel GetByTitle(string title);
        ElectronicBookServiceModel GetByAuthor(string authorName);
        Task Create(string title,
            string author,
            decimal price,
            byte[] coverImage,
            byte[] data,
            string bookRarityId,
            string description,
            string userId);
        Task Update(ElectronicBookServiceModel eBookModel, string eBookId);
        Task Delete(string id);
        ElectronicBookDetailsServiceModel Details(string id);
    }
}
