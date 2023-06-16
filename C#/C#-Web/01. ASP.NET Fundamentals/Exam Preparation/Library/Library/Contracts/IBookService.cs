namespace Library.Contracts
{
    using Models;

    public interface IBookService
    {
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        
        Task RemoveFromCollectionAsync(string userId, BookViewModel book);
        
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        
        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId);
        
        Task<AddBookViewModel> GetNewAddBookModelAsync();
        
        Task AddBookAsync(AddBookViewModel model);
    }
}
