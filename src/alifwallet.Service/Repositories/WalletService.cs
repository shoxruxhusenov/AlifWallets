using alifwallet.DataAccess.Interfaces;
using alifwallet.Domain.Entity;
using alifwallet.Service.Common;
using alifwallet.Service.Constants;
using alifwallet.Service.Dtos;
using alifwallet.Service.Helpers;
using alifwallet.Service.Interfaces;
using alifwallet.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Service.Repositories;

public class WalletService:IWalletService
{
    private readonly IUnitOfWork _work;

    public WalletService(IUnitOfWork repository)
    {
        _work = repository;
    }
    public async Task<bool> ReplashementAsync(ReplashementDto addDto)
    {
        var replashAccount = await _work.Wallets.FindByIdAsync(addDto.WalledId);
        var recharge = new Recharge
        {
            Amount = addDto.Amount,
            CreatedAt = TimeHelper.GetCurrentServerTime(),
            WalletId = addDto.WalledId
        };
        if (replashAccount != null)
        {
            var thinkedReplanish = replashAccount.Balance + addDto.Amount;
            if (replashAccount.IsVerified)
            {
                if (thinkedReplanish <= LimitConstant.identifiedLimit)
                {
                    replashAccount.Balance = thinkedReplanish;
                    _work.Recharges.CreateAsync(recharge);
                }
                else
                    throw new StatusCodeException(HttpStatusCode.Forbidden, "Amount under the limit for Authorized E-Wallets");
            }
            else
            {
                if (thinkedReplanish <= LimitConstant.UnIdentifiedLimit)
                {
                    replashAccount.Balance = thinkedReplanish;
                    _work.Recharges.CreateAsync(recharge);
                }
                else
                    throw new StatusCodeException(HttpStatusCode.Forbidden, "Amount under the limit for unauthorized E-Wallets");
            }
            if (await _work.SaveChangesAsync() != 0)
                return true;
        }
        throw new StatusCodeException(HttpStatusCode.Forbidden, "E-Wallet not found");
    }

    public async Task<bool> ExistsAsync(long Id)
    {
        if (await _work.Wallets.FindByIdAsync(Id) != null)
            return true;
        return false;
    }

    public async Task<WalletViewModel> GetBalanceAsync(long Id)
    {
        var wallet = await _work.Wallets.FindByIdAsync(Id);
        if (wallet != null)
        {
            WalletViewModel walletViewModel = new WalletViewModel()
            {
                Balance = wallet.Balance,
                IsVerified = wallet.IsVerified,
            };
            return walletViewModel;
        }
        else throw new StatusCodeException(HttpStatusCode.Forbidden, "E-Wallet not found");
    }

    public async Task<RechargeViewModel> GetRechargesAsync(long Id)
    {
        if (await _work.Wallets.FindByIdAsync(Id) == null)
            throw new StatusCodeException(HttpStatusCode.Forbidden, "E-Wallet not found");
        var recharges = _work.Recharges.GetAll().AsNoTracking()
                .Where(x => x.WalletId == Id && x.CreatedAt >= TimeHelper.GetCurrentServerTime().AddDays(-30)).ToList();
        if (recharges.Count != 0)
        {
            return new RechargeViewModel()
            {
                numberOfTransactions = recharges.Count,
                RechargesAmount = recharges.Sum(x => x.Amount)
            };
        }
        throw new StatusCodeException(HttpStatusCode.Forbidden, "There are any transactions in this month");
    }

}
