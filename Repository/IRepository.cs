namespace TodoApi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsnyc(T entity);
        Task<IEnumerable<T>> GetAllAsnyc();
        Task<T> FindByIdAsnyc(int id);
        Task UpdateAsnyc(T entity);
        Task DeleteAsnyc(int id);
    }
}
