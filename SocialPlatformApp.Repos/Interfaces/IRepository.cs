namespace SocialPlatformApp.Repos.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task Delete(int id);
    }
}
