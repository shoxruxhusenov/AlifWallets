using alifwallet.Service.Dtos;
using alifwallet.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alifwallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RechargeController : ControllerBase
    {
        private readonly IWalletService _wallet;
        public RechargeController(IWalletService walletService)
        {
            _wallet = walletService;
        }

        [HttpPost("IsExists")]
        public async Task<IActionResult> IsExists([FromForm] long id)
            => Ok(await _wallet.ExistsAsync(id));

        [HttpPost("Replanish")]
        public async Task<IActionResult> ReplanishAsync([FromForm] ReplashementDto dto)
            => Ok(await _wallet.ReplashementAsync(dto));


        [HttpPost("Transactions")]
        public async Task<IActionResult> ReplanishAsync([FromForm] long id)
            => Ok(await _wallet.GetRechargesAsync(id));

        [HttpPost("Wallet")]
        public async Task<IActionResult> GetBalanceAsync([FromForm] long Id)
            => Ok(await _wallet.GetBalanceAsync(Id));
    }
}
