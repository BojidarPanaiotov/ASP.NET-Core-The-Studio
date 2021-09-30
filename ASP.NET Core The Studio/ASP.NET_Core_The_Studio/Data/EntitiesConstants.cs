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

        public class ApplicationUser
        {
            public const int UsernameMinLength = 3;
            public const int UsernameMaxLength = 40;
        }

        public class Feedback
        {
            public const int SubjectMinLength = 8;
            public const int SubjectMaxLength = 75;

            public const int ContentMinLength = 10;
            public const int ContentMaxLength = 1000;
        }
    }
}
