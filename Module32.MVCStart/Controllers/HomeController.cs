using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Module32.MVCStart.Models;
using Module32.MVCStart.Models.Db;
using Module32.MVCStart.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Module32.MVCStart.Controllers
{
    public class HomeController : Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            /*
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Maskim",
                NickName = "-US",
                JoinDate = DateTime.Now
            };

            // Добавим в базу
            await _repo.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} {newUser.NickName} was successfully added on {newUser.JoinDate}");
            */
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
