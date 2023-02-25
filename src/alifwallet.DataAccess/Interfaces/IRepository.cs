using alifwallet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.DataAccess.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> FindByIdAsync(long id);

    public void CreateAsync(T entity);

    public Task<T?> FirstOrDefaoultAsync(Expression<Func<T, bool>> expression);
}
