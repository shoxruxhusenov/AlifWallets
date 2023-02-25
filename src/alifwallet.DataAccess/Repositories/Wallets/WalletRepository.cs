using alifwallet.DataAccess.DbContexts;
using alifwallet.DataAccess.Interfaces.Wallets;
using alifwallet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.DataAccess.Repositories.Wallets;

public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
{
    public WalletRepository(AppDbContext app) : base(app)
    {
    }
}
