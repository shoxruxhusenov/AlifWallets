using alifwallet.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.DataAccess.Configuration;

public class WalletConfiguration: IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasData(new Wallet()
        {
            Id = 1,
            Balance = 75_000,
            IsVerified = true,

        },
        new Wallet
        {
            Id = 2,
            Balance = 8_000,
            IsVerified = false,
        },
        new Wallet
        {
            Id = 3,
            Balance = 80_000,
            IsVerified = true,
        },
        new Wallet
        {
            Id = 4,
            Balance = 10_000,
            IsVerified = false,
        },
        new Wallet
        {
            Id = 5,
            Balance = 50_000,
            IsVerified = true,
        },
        new Wallet
        {
            Id = 6,
            Balance = 10_000,
            IsVerified = false,
        }
        );
    }
}

