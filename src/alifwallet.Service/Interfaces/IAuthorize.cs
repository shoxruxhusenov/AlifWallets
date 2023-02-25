using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Service.Interfaces;

public interface IAuthorize
{
    public bool Authorize(long Id, string Digest, string body);

}
