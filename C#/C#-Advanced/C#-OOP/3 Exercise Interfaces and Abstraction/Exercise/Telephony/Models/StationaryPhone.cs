namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Contracts;
    using Exceptions;

    internal class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber) => phoneNumber.All(ch => Char.IsDigit(ch));
    }
}
