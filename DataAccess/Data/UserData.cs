using DataAccess.Access;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _dataAccess;
        public UserData(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<IEnumerable<User>> GetAllUsers() => _dataAccess.LoadData<User, dynamic>("dbo.spUser_GetAll", new { });
        public async Task<User?> GetUser(int id)
        {
            var users = await _dataAccess.LoadData<User, dynamic>("dbo.spUser_GetById", new { Id = id });
            return users.FirstOrDefault();
        }
        public Task InsertUser(User user) => _dataAccess.SaveData("dbo.spUser_Insert",
            new { user.FirstName, user.LastName, user.Age });
        public Task UpdateUser(User user) => _dataAccess.SaveData("dbo.spUser_Update", user);
        public Task DeleteUser(int id) => _dataAccess.SaveData("dbo.spUser_DeleteById", new { Id = id });
    }
}
