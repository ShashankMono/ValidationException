namespace ValidationExample.Repository
{
    public interface IRepository<T>
    {
        public T GetById(Guid id);
        public IQueryable<T> GetAll();
        public Task<T> Add(T entity);
    }
}
