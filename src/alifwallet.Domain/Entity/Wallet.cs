using alifwallet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Domain.Entity;

public class Wallet:BaseEntity
{
    public double Balance { get; set; }

    public bool IsVerified { get; set; }

    public string SecretKey { get; set; } = string.Empty;
}
