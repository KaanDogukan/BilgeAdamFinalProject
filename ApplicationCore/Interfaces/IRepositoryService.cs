using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepositoryService<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();

        Task<List<TResult>> GetFilteredListAsync<TResult>(Expression<Func<T, TResult>> select = null,
                                                     Expression<Func<T, bool>> where = null,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);

        Task<List<T>> GetByDefaultsAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
