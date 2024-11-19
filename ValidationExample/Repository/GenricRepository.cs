
using Microsoft.EntityFrameworkCore;
using ValidationExample.Data;

namespace ValidationExample.Repository
{
    public class GenricRepository<T> : IRepository<T> where T : class
    {
        private readonly StudentContext _context;
        private readonly DbSet<T> _table;
        public GenricRepository(StudentContext context)
        {
            _context = context;
            _table =  _context.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }
    }
}
