namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Contracts;
    using Exceptions;

    internal class Smartphone : ISmartphone
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }

        public string BrowseUrl(string url)
        {
            if (!ValidateUrl(url))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        private bool ValidatePhoneNumber(string phoneNumber) => phoneNumber.All(ch => Char.IsDigit(ch));

        private bool ValidateUrl(string url) => url.All(ch => !Char.IsDigit(ch));
    }
}
