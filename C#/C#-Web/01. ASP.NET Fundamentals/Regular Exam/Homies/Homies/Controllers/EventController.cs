namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Models.Event;
    using Models.Type;
    using Services.Contracts;
    using System.Globalization;

    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        private readonly ITypeService typeService;

        public EventController(IEventService eventService,
            ITypeService typeService)
        {
            this.eventService = eventService;
            this.typeService = typeService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            IEnumerable<AllEventViewModel> model = await eventService.GetJoinedEventsByUserIdAsync(GetUserId()!);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ICollection<TypeAllDataModel> allTypes = await typeService.GetAllTypesAsync();

            EventFormModel formModel = new EventFormModel()
            {
                Types = allTypes,
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel formModel)
        {
            bool isStartDateValid = DateTime.TryParseExact(formModel.Start, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            bool isEndDateValid = DateTime.TryParseExact(formModel.End, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (!isStartDateValid)
            {
                ModelState.AddModelError("", "Invalid start date.");
            }

            if (!isEndDateValid)
            {
                ModelState.AddModelError("", "Invalid end date.");
            }

            if (startDate > endDate)
            {
                ModelState.AddModelError("", "Start date cannot be later than end date!");
            }

            if (!ModelState.IsValid)
            {
                ICollection<TypeAllDataModel> allTypes = await typeService.GetAllTypesAsync();

                formModel.Types = allTypes;

                return View(formModel);
            }

            await eventService.CreateAsync(GetUserId()!, formModel);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = GetUserId()!;

            bool eventExists = await eventService.ExistsByIdAsync(id);

            if (!eventExists)
            {
                return RedirectToAction("All");
            }

            bool isUserCreator = await eventService.IsUserCreatorAsync(userId, id);

            if (!isUserCreator)
            {
                return RedirectToAction("All");
            }

            EventFormModel formModel = await eventService.GetEventForEditAsync(id);

            ICollection<TypeAllDataModel> allTypes = await typeService.GetAllTypesAsync();

            formModel.Types = allTypes;

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormModel formModel, int id)
        {
            bool isStartDateValid = DateTime.TryParseExact(formModel.Start, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

            bool isEndDateValid = DateTime.TryParseExact(formModel.End, "dd-MM-yyyy H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

            if (!isStartDateValid)
            {
                ModelState.AddModelError("", "Invalid start date.");
            }

            if (!isEndDateValid)
            {
                ModelState.AddModelError("", "Invalid end date.");
            }

            if (startDate > endDate)
            {
                ModelState.AddModelError("", "Start date cannot be later than end date!");
            }

            string userId = GetUserId()!;

            bool eventExists = await eventService.ExistsByIdAsync(id);

            if (!eventExists)
            {
                return RedirectToAction("All");
            }

            bool isUserCreator = await eventService.IsUserCreatorAsync(userId, id);

            if (!isUserCreator)
            {
                return RedirectToAction("All");
            }

            if (!ModelState.IsValid)
            {
                ICollection<TypeAllDataModel> allTypes = await typeService.GetAllTypesAsync();

                formModel.Types = allTypes;

                return View(formModel);
            }

            await eventService.EditAsync(formModel, id);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Join(int id)
        {
            string userId = GetUserId()!;

            bool eventExists = await eventService.ExistsByIdAsync(id);

            if (!eventExists)
            {
                return RedirectToAction("All");
            }

            bool isJoined = await eventService.IsEventAlreadyJoinedByUserAsync(userId, id);

            if (isJoined)
            {
                return RedirectToAction("All");
            }

            try
            {
                await eventService.JoinEventAsync(userId, id);
            }
            catch (Exception)
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("Joined");
        }

        public async Task<IActionResult> Leave(int id)
        {
            string userId = GetUserId()!;

            bool eventExists = await eventService.ExistsByIdAsync(id);

            if (!eventExists)
            {
                return RedirectToAction("All");
            }

            bool isJoined = await eventService.IsEventAlreadyJoinedByUserAsync(userId, id);

            if (!isJoined)
            {
                return RedirectToAction("All");
            }

            try
            {
                await eventService.LeaveEventAsync(userId, id);
            }
            catch (Exception)
            {
                return RedirectToAction("Joined");
            }

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            bool eventExists = await eventService.ExistsByIdAsync(id);

            if (!eventExists)
            {
                return RedirectToAction("All");
            }

            //bool isUserCreator = await eventService.IsUserCreatorAsync(userId, id);

            //if (!isUserCreator)
            //{
            //    return RedirectToAction("All");
            //}

            EventDetailsViewModel model = await eventService.GetEventDetailsAsync(id);

            return View(model);
        }
    }
}
