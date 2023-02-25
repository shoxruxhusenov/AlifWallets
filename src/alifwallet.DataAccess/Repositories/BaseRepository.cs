using alifwallet.DataAccess.DbContexts;
using alifwallet.DataAccess.Interfaces;
using alifwallet.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.DataAccess.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected AppDbContext _dbContext { get; set; }
    protected DbSet<T> _dbset { get; set; }

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbset = dbContext.Set<T>();
    }

    public void CreateAsync(T entity) => _dbset.Add(entity);

    public async Task<T?> FindByIdAsync(long id)
    {
        return await _dbset.FindAsync(id);
    }

    public async Task<T?> FirstOrDefaoultAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbset.FirstOrDefaultAsync(expression);
    }
}