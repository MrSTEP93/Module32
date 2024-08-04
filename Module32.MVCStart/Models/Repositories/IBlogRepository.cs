using Module32.MVCStart.Models.Db;
using System.Threading.Tasks;

namespace Module32.MVCStart.Models.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
