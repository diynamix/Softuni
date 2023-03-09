namespace BookShop
{
    using System.Text;

    using Data;
    using Initializer;
    using Models;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //int result = RemoveBooks(db);

            //Console.WriteLine(result);
        }

        // Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //bool hasParsed = Enum.TryParse(typeof(AgeRestriction), command, true, out object? ageRestrictionObj);
            //AgeRestriction ageRestriction;

            //if (hasParsed)
            //{
            //    ageRestriction = (AgeRestriction)ageRestrictionObj;

            //    string[] books = context.Books
            //        .Where(b => b.AgeRestriction == ageRestriction)
            //        .OrderBy(b => b.Title)
            //        .Select(b => b.Title)
            //        .ToArray();

            //    return String.Join(Environment.NewLine, books);
            //}

            //return null;

            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                string[] books = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return String.Join(Environment.NewLine, books);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            string[] books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        // Ptoblem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            string[] books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            string[] books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                //.OrderBy(a => a) // NOT WORKING
                .ToArray();

            return String.Join(Environment.NewLine, authors);
        }

        // Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string[] booksAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return String.Join(Environment.NewLine, booksAuthors);
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
            => context.Books.Count(b => b.Title.Length > lengthCheck);

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authorsWithBookCopies = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies),
                })
                //.OrderByDescending(b => b.TotalCopies)
                .ToArray()
                .OrderByDescending(b => b.TotalCopies); // This is optimization

            foreach (var a in authorsWithBookCopies)
            {
                sb.AppendLine($"{a.FullName} - {a.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesWithProfit = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .ToArray()
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName);
            //.ToArray();

            foreach (var c in categoriesWithProfit)
            {
                sb.AppendLine($"{c.CategoryName} ${c.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesWithMostRecentBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3) // This can lower network load
                        .Select(cb => $"{cb.Book.Title} ({cb.Book.ReleaseDate.Value.Year})")
                        .ToArray(),
                })
                .ToArray();
                //.OrderBy(c => c.CategoryName);

            foreach (var c in categoriesWithMostRecentBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (string book in c.MostRecentBooks/*.Take(3) This is lowering query complexity*/)
                {
                    sb.AppendLine(book);
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            // Materializing the query does not detach entities from Change Tracker
            Book[] booksReleasedBefore2010 = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            // Using BatchUpdate from EFCore.Extensions
            //context.Books
            //    .Where(b => b.ReleaseDate.HasValue &&
            //                b.ReleaseDate.Value.Year < 2010)
            //    .UpdateFromQuery(b => new Book() { Price = b.Price + 5 });

            foreach (var book in booksReleasedBefore2010)
            {
                book.Price += 5;
            }

            //context.SaveChanges();
            context.BulkUpdate(booksReleasedBefore2010);
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(booksToDelete);
            context.SaveChanges();

            return booksToDelete.Count();
        }
    }
}
