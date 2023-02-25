using alifwallet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Domain.Entity;

public class Recharge:Auditable
{
    public double Amount { get; set; }

    public long WalletId { get; set; }
    public virtual Wallet Wallet { get; set; } = default!;
}
