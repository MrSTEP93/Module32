using Microsoft.AspNetCore.Mvc;
using Module32.MVCStart.Models.Repositories;

namespace Module32.MVCStart.Controllers
{
    public class LogsController : Controller
    {
        ILoggingRepository _loggingRepo;
        
        public LogsController(ILoggingRepository repository) 
        {
            _loggingRepo = repository;
        }

        public IActionResult Index()
        {
            var requests = _loggingRepo.GetRequests();
            return View(requests);
        }
    }
}
