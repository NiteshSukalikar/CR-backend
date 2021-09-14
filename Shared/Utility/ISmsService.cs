using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utility
{
    public interface ISmsService
    {
        bool ProcessSms(string ToNumber, string message);
    }
}
