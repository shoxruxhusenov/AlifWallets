using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Service.Interfaces;

public interface IXAuthorize
{
    public Task<bool> Authenticate(string userId, string body, string digest);

}
