namespace ASP.NET_Core_The_Studio.Data
{
    public class EntitiesConstants
    {
        public class Product
        {
            public const int DescriptionMaxLength = 1000;
            public const int TitleMaxLength = 110;
            public const int FileTypeMaxLength = 100;
        }
        public class ElectronicBook
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 150;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const int AuthorNameMinLength = 3;
            public const int AuthorNameMaxLength = 100;

            public const string MaxPrice = "100";
            public const string MinPrice = "1.59";

            public const int MaxPage = 5;
            public const int MinPage = 2000;
        }
    }
}
