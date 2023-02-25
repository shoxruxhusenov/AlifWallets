using alifwallet.DataAccess.Interfaces.Recharges;
using alifwallet.DataAccess.Interfaces.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IRechargeRepository Recharges { get; }
        public IWalletRepository Wallets { get; }
        public Task<int> SaveChangesAsync();
    }
}
