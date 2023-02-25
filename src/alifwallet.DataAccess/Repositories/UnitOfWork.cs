using alifwallet.DataAccess.DbContexts;
using alifwallet.DataAccess.Interfaces;
using alifwallet.DataAccess.Interfaces.Recharges;
using alifwallet.DataAccess.Interfaces.Wallets;
using alifwallet.DataAccess.Repositories.Recharges;
using alifwallet.DataAccess.Repositories.Wallets;


namespace alifwallet.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IRechargeRepository Recharges { get; }
        public IWalletRepository Wallets { get; }
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Recharges = new RechargeRepository(_dbContext);
            Wallets = new WalletRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

