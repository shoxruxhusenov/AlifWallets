using alifwallet.Service.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alifwallet.Service.Helpers;

public class TimeHelper
{
    public static DateTime GetCurrentServerTime()
    {
        return DateTime.UtcNow.AddHours(TimeConstants.UTC);
    }
}
