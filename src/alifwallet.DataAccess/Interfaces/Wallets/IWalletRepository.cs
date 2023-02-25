using alifwallet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.DataAccess.Interfaces.Wallets;

public interface IWalletRepository : IGenericRepository<Wallet>
{
}
