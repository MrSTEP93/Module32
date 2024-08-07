using Microsoft.EntityFrameworkCore;
using Module32.MVCStart.Models.Db;
using System.Linq;
using System.Threading.Tasks;

namespace Module32.MVCStart.Models.Repositories
{
    public class LoggingRepository : ILoggingRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public LoggingRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Log(Request request)
        {
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests.OrderByDescending(r => r.Date).ToArrayAsync();
        }
    }
}

