using Module32.MVCStart.Models.Db;
using System.Threading.Tasks;

namespace Module32.MVCStart.Models.Repositories
{
    public interface ILoggingRepository
    {
        Task Log(Request request);

        Task<Request[]> GetRequests();
    }
}
