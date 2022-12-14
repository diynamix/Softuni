namespace Telephony.Core
{
    using System;

    using Interfaces;
    using Telephony.Exceptions;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    using Telephony.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;

        private Engine()
        {
            stationaryPhone = new StationaryPhone();
            smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] urls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    writer.WriteLine(ipne.Message);
                }
                catch (Exception)
                {
                    // Unexpected error occured and the program stoped working!
                    throw;
                }

            }

            foreach (string url in urls)
            {
                try
                {
                    writer.WriteLine(smartphone.BrowseUrl(url));
                }
                catch (InvalidURLException iue)
                {
                    writer.WriteLine(iue.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}