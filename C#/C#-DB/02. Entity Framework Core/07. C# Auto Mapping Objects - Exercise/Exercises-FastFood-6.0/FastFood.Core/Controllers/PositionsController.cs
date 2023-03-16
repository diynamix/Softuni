namespace FastFood.Web.Controllers
{
    //using System.Linq;

    //using AutoMapper;
    //using AutoMapper.QueryableExtensions;
    //using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    //using Data;
    //using Models;
    using Services.Data;
    using Services.Data.Contracts;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        //private readonly FastFoodContext _context;
        //private readonly IMapper _mapper;

        private readonly IPositionsService positionsService;

        public PositionsController(IPositionsService positionsService)
        //public PositionsController(FastFoodContext context, IMapper mapper)
        {
            //_context = context;
            //_mapper = mapper;
            this.positionsService = positionsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            //var position = _mapper.Map<Position>(model);
            //_context.Positions.Add(position);
            //_context.SaveChanges();

            await positionsService.CreateAsync(model);

            return RedirectToAction("All", "Positions");
        }

        [HttpGet]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> All()
        {
            //var positions = _context.Positions
            //    .ProjectTo<PositionsAllViewModel>(_mapper.ConfigurationProvider)
            //    .ToList();

            IEnumerable<PositionsAllViewModel> positions = await positionsService.GetAllAsync();

            return View(positions.ToList());
        }
    }
}
