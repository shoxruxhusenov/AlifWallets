using alifwallet.DataAccess.Configuration;
using alifwallet.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace alifwallet.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :
        base(dbContextOptions)
    {

    }
    public virtual DbSet<Wallet> Wallets { get; set; } = default!;
    public virtual DbSet<Recharge> Recharges { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        _ = modelBuilder.ApplyConfiguration(new WalletConfiguration());
    }
}
