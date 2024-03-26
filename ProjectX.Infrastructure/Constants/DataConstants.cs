namespace ProjectX.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class User
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;
            public const string FirstNameErrorMessage = "{0} must be between {2} and {1} characters long.";

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;
            public const string LastNameErrorMessage = "{0} must be between {2} and {1} characters long.";

            public const int CityMinLength = 2;
            public const int CityMaxLength = 50;
            public const string CityErrorMessage = "{0} must be between {2} and {1} characters long.";

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
            public const string PhoneNumberErrorMessage = "{0} must be between {2} and {1} characters long.";
        }

        public static class Salon
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;
            public const string NameErrorMessage = "{0} must be between {2} and {1} characters long.";

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;
            public const string AddressErrorMessage = "{0} must be between {2} and {1} characters long.";

            public const int CityMinLength = 2;
            public const int CityMaxLength = 50;
            public const string CityErrorMessage = "{0} must be between {2} and {1} characters long.";

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
            public const string PhoneNumberErrorMessage = "{0} must be between {2} and {1} characters long.";

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 8000;
            public const string DescriptionErrorMessage = "{0} must be between {2} and {1} characters long.";
        }
    }
}

