using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IUserData
    {
        Task DeleteUser(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUser(int id);
        Task InsertUser(User user);
        Task UpdateUser(User user);
    }
}