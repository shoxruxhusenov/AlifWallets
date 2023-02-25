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

public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T>
        where T : BaseEntity
{
    public GenericRepository(AppDbContext app) : base(app)
    {
    }
    public virtual IQueryable<T> GetAll() => _dbset;

    public virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
        => _dbset.Where(expression);
}