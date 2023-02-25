using alifwallet.Service.Common;
using alifwallet.Service.Dtos;
using alifwallet.Service.Dtos.RequestDtos;
using alifwallet.Service.Interfaces;
using alifwallet.Service.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace alifwallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RechargeController : ControllerBase
    {
        private readonly IWalletService _wallet;
        private readonly IXAuthorize _auth;

        public RechargeController(IWalletService walletService, IXAuthorize authorize)
        {
            _wallet = walletService;
            _auth = authorize;
        }

        [HttpPost("IsExists")]
        public async Task<IActionResult> IsExists([FromBody] GetIdDto dto)
        {
            await Authorize(JsonConvert.SerializeObject(dto));
            return Ok(await _wallet.ExistsAsync(dto.Id));

        }

        [HttpPost("Replanish")]
        public async Task<IActionResult> ReplanishAsync([FromBody] ReplashementDto dto)
        {
            await Authorize(JsonConvert.SerializeObject(dto));
            return Ok(await _wallet.ReplashementAsync(dto));
        }
       

        [HttpPost("Transactions")]
        public async Task<IActionResult> GetRechargesAsync([FromBody] GetIdDto dto)
        {
            await Authorize(JsonConvert.SerializeObject(dto));
            return Ok(await _wallet.GetRechargesAsync(dto.Id));
        }

        [HttpPost("Wallet")]
        public async Task<IActionResult> GetBalanceAsync([FromBody] GetIdDto dto)
        {
            await Authorize(JsonConvert.SerializeObject(dto));
            return Ok(await _wallet.GetBalanceAsync(dto.Id));
        }
        private async Task Authorize(string body)
        {
            string userId = HttpContext.Request.Headers["X-UserId"];
            string digest = HttpContext.Request.Headers["X-Digest"];
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(digest))
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "Missing X-UserId or X-Digest");
            if (!await _auth.Authenticate(userId, body, digest))
                throw new StatusCodeException(System.Net.HttpStatusCode.Unauthorized, "Unauthorized");
        }
    }
}
