using DataAccess.Access;
using DataAccess.Data;
using DataAccess.Models;

namespace DataAccessTests
{
    public class UserDataTests
    {
        [Fact]
        public async void GetUser_ValidInput_ReturnUser()
        {
            var dataAccess = new Mock<ISqlDataAccess>();
            dataAccess.Setup(p => p.LoadData<User, object>("dbo.spUser_GetById", It.IsAny<object>(), It.IsAny<string>()))
                .Returns(() => Task.FromResult(GetOneUserList()));
            UserData userData = new UserData(dataAccess.Object);
            var result = await userData.GetUser(1);
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(1, result.Id);
        }
        private IEnumerable<User> GetOneUserList()
        {
            IEnumerable<User> users = new List<User>()
            { GetNewUser() };
            return users;
        }
        private IEnumerable<User> GetManyUserList()
        {
            IEnumerable<User> users = new List<User>()
            { 
                GetNewUser(),
                new User() { Id = 2, FirstName = "FN2", LastName = "LN2" }
            };
            return users;
        }

        private static User GetNewUser()
        {
            return new User() { Id = 1, FirstName = "FN", LastName = "LN" };
        }

        [Fact]
        public async void GetAllUsers_ValidInput_ReturnUsers()
        {
            var dataAccess = new Mock<ISqlDataAccess>();
            dataAccess.Setup(p => p.LoadData<User, object>("dbo.spUser_GetAll", It.IsAny<object>(), It.IsAny<string>()))
                .Returns(() => Task.FromResult(GetManyUserList()));
            UserData userData = new UserData(dataAccess.Object);
            var result = await userData.GetAllUsers();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async void InsertUser_ValidInput_SavesData()
        {
            var dataAccess = new Mock<ISqlDataAccess>();
            dataAccess.Setup(p => p.SaveData("dbo.spUser_Insert", It.IsAny<object>(), It.IsAny<string>()));
            UserData userData = new UserData(dataAccess.Object);
            await userData.InsertUser(GetNewUser());
            dataAccess.Verify(p => p.SaveData("dbo.spUser_Insert", It.IsAny<object>(), It.IsAny<string>()), Times.Once);
        }
        [Fact]
        public async void UpdateUser_ValidInput_SavesData()
        {
            var dataAccess = new Mock<ISqlDataAccess>();
            dataAccess.Setup(p => p.SaveData("dbo.spUser_Update", It.IsAny<object>(), It.IsAny<string>()));
            UserData userData = new UserData(dataAccess.Object);
            await userData.UpdateUser(GetNewUser());
            dataAccess.Verify(p => p.SaveData("dbo.spUser_Update", It.IsAny<object>(), It.IsAny<string>()), Times.Once);
        }
        [Fact]
        public async void DaleteUser_ValidInput_SavesData()
        {
            var dataAccess = new Mock<ISqlDataAccess>();
            dataAccess.Setup(p => p.SaveData("dbo.spUser_DeleteById", It.IsAny<object>(), It.IsAny<string>()));
            UserData userData = new UserData(dataAccess.Object);
            await userData.DeleteUser(1);
            dataAccess.Verify(p => p.SaveData("dbo.spUser_DeleteById", It.IsAny<object>(), It.IsAny<string>()), Times.Once);
        }
    }
}