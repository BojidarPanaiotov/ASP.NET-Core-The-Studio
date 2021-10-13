namespace ASP.NET_Core_The_Studio.Services.ElectronicBook
{
    using System.Collections.Generic;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models.Enums;
    using ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models;

    public interface IElectronicBookService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllWithGeners<T>();

        IEnumerable<T> GetAllByAuthor<T>(string authorName);

        T GetById<T>(string id);

        T GetByTitle<T>(string title);

        T GetByAuthor<T>(string authorName);

        void Create(string title,
            string author,
            decimal price,
            byte[] coverImage,
            byte[] data,
            string bookRarityId,
            string description,
            string userId);

        void Update(
            ElectronicBookServiceModel electronicBook,
            string id);

        void Delete(string id);

        void Details(string id);

        ListingElectronicBooksServiceModel GetElectronicBooksByFilters(
            BookSort sorting = BookSort.None,
            string searchTermTitle = null,
            string[] rarities = null,
            string[] geners = null,
            int currentPage = 1);

        bool IsExist(string id);
    }
}
