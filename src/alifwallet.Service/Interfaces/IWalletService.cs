using alifwallet.Service.Dtos;
using alifwallet.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Service.Interfaces;

public interface IWalletService
{
    public Task<bool> ExistsAsync(long Id);
    public Task<RechargeViewModel> GetRechargesAsync(long Id);
    public Task<bool> ReplashementAsync(ReplashementDto addDto);
    public Task<WalletViewModel> GetBalanceAsync(long Id);

}
