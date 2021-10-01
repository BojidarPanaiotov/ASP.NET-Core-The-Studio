namespace ASP.NET_Core_The_Studio.Services.ElectronicBook
{
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models.Enums;
    using System.Collections.Generic;

    public interface IElectronicBookService
    {
        //Done
        IEnumerable<T> GetAllElectronicBooks<T>();
        //Done
        IEnumerable<T> GetElectronicBooksWithGeners<T>();
        //Done
        IEnumerable<T> GetAllElectronicBooksByAuthor<T>(string authorName);
        //Done
        IEnumerable<T> GetAllRarities<T>();
        //Done
        IEnumerable<T> GetAllGeners<T>();
        //Done
        ElectronicBookServiceModel GetById(string id);
        //Done
        ElectronicBookServiceModel GetByTitle(string title);
        //Done
        ElectronicBookServiceModel GetByAuthor(string authorName);
        void Create(string title,
            string author,
            decimal price,
            byte[] coverImage,
            byte[] data,
            string bookRarityId,
            string description,
            string userId);
        void Update(ElectronicBookServiceModel eBookModel,
            string eBookId);
        void Delete(string id);
        void Details(string id);
        IEnumerable<ElectronicBookServiceModel> GetElectronicBooksByFilters(BookSort sorting,
             string searchTermTitle,
             string[] rarities,
             string[] geners);
    }
}
