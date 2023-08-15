namespace Homies.Services.Contracts
{
    using Models.Event;

    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();

        Task<IEnumerable<AllEventViewModel>> GetJoinedEventsByUserIdAsync(string userId);

        Task JoinEventAsync(string userId, int eventId);

        Task LeaveEventAsync(string userId, int eventId);

        Task CreateAsync(string userId, EventFormModel formModel);

        Task<EventFormModel> GetEventForEditAsync(int eventId);

        Task EditAsync(EventFormModel formModel, int eventId);

        Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId);

        Task<bool> IsEventAlreadyJoinedByUserAsync(string userId, int eventId);
        
        Task<bool> IsUserCreatorAsync(string userId, int eventId);

        Task<bool> ExistsByIdAsync(int eventId);
    }
}
