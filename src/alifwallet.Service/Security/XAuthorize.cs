using alifwallet.DataAccess.Interfaces;
using alifwallet.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Service.Security
{
    public class XAuthorize:IXAuthorize
    {
        private readonly IUnitOfWork _work;
        public XAuthorize(IUnitOfWork unitOfWork)
        {
            _work = unitOfWork;
        }
        public async Task<bool> Authenticate(string userId, string body, string digest)
        {
            string secretKey = string.Empty;
            var ewallet = await _work.Wallets.FindByIdAsync(long.Parse(userId));
            if (ewallet != null)
                secretKey = ewallet.SecretKey;
            byte[] keyBytes = Encoding.UTF8.GetBytes(secretKey);
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            using (var hmac = new HMACSHA1(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(bodyBytes);
                string expectedDigest = Convert.ToBase64String(hashBytes);
                if (digest != expectedDigest)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
