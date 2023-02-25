using alifwallet.DataAccess.DbContexts;
using alifwallet.DataAccess.Interfaces.Recharges;
using alifwallet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.DataAccess.Repositories.Recharges;

public class RechargeRepository : GenericRepository<Recharge>, IRechargeRepository
{
    public RechargeRepository(AppDbContext app) : base(app)
    {
    }
}
