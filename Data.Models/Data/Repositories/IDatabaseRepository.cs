namespace Data.Models.Data.Repositories
{
    public interface IDatabaseRepository<T> where T : class
    {
        void Create(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
