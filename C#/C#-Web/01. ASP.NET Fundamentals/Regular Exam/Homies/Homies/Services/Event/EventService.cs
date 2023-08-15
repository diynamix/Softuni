namespace Homies.Services.Event
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Event;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(string userId, EventFormModel formModel)
        {
            Event newEvent = new Event()
            {
                Name = formModel.Name,
                Description = formModel.Description,
                OrganiserId = userId,
                CreatedOn = DateTime.UtcNow,
                Start = DateTime.Parse(formModel.Start),
                End = DateTime.Parse(formModel.End),
                TypeId = formModel.TypeId
            };

            await dbContext.Events.AddAsync(newEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(EventFormModel formModel, int eventId)
        {
            Event eventForEdit = await dbContext.Events
                .FirstAsync(e => e.Id == eventId);

            eventForEdit.Name = formModel.Name;
            eventForEdit.Description = formModel.Description;
            eventForEdit.Start = DateTime.Parse(formModel.Start);
            eventForEdit.End = DateTime.Parse(formModel.End);
            eventForEdit.TypeId = formModel.TypeId;

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int eventId)
        {
            return await dbContext.Events.AnyAsync(e => e.Id == eventId);
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await dbContext.Events
                .Include(e => e.Organiser)
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("dd-MM-yyyy H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                })
                .ToListAsync();
        }

        public async Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId)
        {
            Event eventForDetails = await dbContext.Events
                .Include(e => e.Organiser)
                .Include(e => e.Type)
                .AsNoTracking()
                .FirstAsync(e => e.Id == eventId);

            return new EventDetailsViewModel()
            {
                Id = eventId,
                Name = eventForDetails.Name,
                Description = eventForDetails.Description,
                CreatedOn = eventForDetails.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                Start = eventForDetails.Start.ToString("dd-MM-yyyy H:mm"),
                End = eventForDetails.End.ToString("dd-MM-yyyy H:mm"),
                Organiser = eventForDetails.Organiser.UserName,
                Type = eventForDetails.Type.Name
            };
        }

        public async Task<EventFormModel> GetEventForEditAsync(int eventId)
        {
            Event eventForEdit = await dbContext.Events
                .AsNoTracking()
                .FirstAsync(e => e.Id == eventId);

            return new EventFormModel()
            {
                Description = eventForEdit.Description,
                Name = eventForEdit.Name,
                Start = eventForEdit.Start.ToString("dd-MM-yyyy H:mm"),
                End = eventForEdit.End.ToString("dd-MM-yyyy H:mm"),
                TypeId = eventForEdit.TypeId
            };
        }

        public async Task<IEnumerable<AllEventViewModel>> GetJoinedEventsByUserIdAsync(string userId)
        {
            return await dbContext.EventParticipants
                .Include(ep => ep.Event)
                .ThenInclude(e => e.Organiser)
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new AllEventViewModel()
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString("{yyyy-MM-dd H:mm}"),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName,
                })
                .ToListAsync();
        }

        public async Task<bool> IsEventAlreadyJoinedByUserAsync(string userId, int eventId)
        {
            return await dbContext.EventParticipants
                .AnyAsync(ep => ep.HelperId == userId && ep.EventId == eventId);
        }

        public async Task<bool> IsUserCreatorAsync(string userId, int eventId)
        {
            return await dbContext.Events
                .AnyAsync(e => e.OrganiserId == userId && e.Id == eventId);
        }

        public async Task JoinEventAsync(string userId, int eventId)
        {
            EventParticipant eventParticipant = new EventParticipant()
            {
                HelperId = userId,
                EventId = eventId,
            };

            await dbContext.EventParticipants.AddAsync(eventParticipant);
            await dbContext.SaveChangesAsync();
        }

        public async Task LeaveEventAsync(string userId, int eventId)
        {
            EventParticipant? eventParticipant = await dbContext.EventParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == eventId);

            if (eventParticipant != null)
            {
                dbContext.EventParticipants.Remove(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
