namespace ChristmasPastryShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Booths;
    using Models.Booths.Contracts;
    using Models.Cocktails;
    using Models.Cocktails.Contracts;
    using Models.Delicacies;
    using Models.Delicacies.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail;

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth booth = FindBooth(boothId);

            List<ICocktail> cocktailList = GetCocktailMenu(booth);
            if (cocktailList.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = FindBooth(boothId);

            List<IDelicacy> delicacyList = GetDelicacyMenu(booth);
            if (delicacyList.Any(d => d.Name == delicacyName))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = FindBooth(boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = FindBooth(boothId);

            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            //sb.AppendLine(String.Format(OutputMessages.GetBill, $"{currentBill:f2}"));
            sb.AppendLine($"Bill {currentBill:f2} lv");

            sb.AppendLine(String.Format(OutputMessages.BoothIsAvailable, boothId));

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models.ToList()
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderArgs = order.Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = orderArgs[0];
            string itemName = orderArgs[1];
            int countOfOrderedPieces = int.Parse(orderArgs[2]);

            IBooth booth = FindBooth(boothId);

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string size = orderArgs[3];
                List<ICocktail> cocktailList = GetCocktailMenu(booth);

                if (cocktailList.Any(c => c.Name == itemName) == false)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                ICocktail cocktail = cocktailList.FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == size);

                if (cocktail == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                booth.UpdateCurrentBill(countOfOrderedPieces * cocktail.Price);

                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                List<IDelicacy> delicacyList = GetDelicacyMenu(booth);

                if (delicacyList.Any(d => d.Name == itemName) == false)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                IDelicacy delicacy = delicacyList.FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName);

                if (delicacy == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(countOfOrderedPieces * delicacy.Price);

                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            else
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
        }

        private IBooth FindBooth(int boothId)
        {
            List<IBooth> boothsList = booths.Models.ToList();
            IBooth booth = boothsList.FirstOrDefault(b => b.BoothId == boothId);
            return booth;
        }

        private List<IDelicacy> GetDelicacyMenu(IBooth booth) =>
            booth.DelicacyMenu.Models.ToList();

        private List<ICocktail> GetCocktailMenu(IBooth booth) =>
            booth.CocktailMenu.Models.ToList();
    }
}
