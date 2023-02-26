using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WinDS.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameServices _gameService;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
            _gameService = new GameServices();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CombinationsPartial(string inputLetters, int inputLength)
        {
            ViewBag.Combinations = _gameService.GetCombinations(inputLetters.ToLower(), inputLength);
            return PartialView("Combinations");
        }

    }
}
