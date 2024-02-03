namespace DataAccess.Access
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parameters, string connId = "Default");
        Task SaveData<T>(string procedure, T parameters, string connId = "Default");
    }
}