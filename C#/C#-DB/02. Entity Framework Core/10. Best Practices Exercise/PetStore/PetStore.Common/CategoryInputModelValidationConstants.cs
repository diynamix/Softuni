﻿namespace PetStore.Common
{
    public static class CategoryInputModelValidationConstants
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 30;

        public const string InvalidNameErrorMessage = "Category name must be between 3 and 30 characters!";
    }
}
