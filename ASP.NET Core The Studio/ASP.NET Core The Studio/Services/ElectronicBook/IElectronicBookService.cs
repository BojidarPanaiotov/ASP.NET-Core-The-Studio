namespace ASP.NET_Core_The_Studio.Services.ElectronicBook
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IElectronicBookService
    {
        IEnumerable<T> GetAllElectronicBooks<T>();
        IEnumerable<T> GetAllElectronicBooksWithGeners<T>();
        Task<IEnumerable<T>> GetAllElectronicBooksByAuthor<T>(string authorName);
        Task<IEnumerable<T>> GetAllByCategory<T>();
        IEnumerable<T> GetAllRarities<T>();
        IEnumerable<T> GetAllGeners<T>();
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
        List<ElectronicBookViewModel> GetElectronicBooksByFilters(BookSort sorting,
             string searchTermTitle,
             string[] rarities,
             string[] geners);
    }
}
