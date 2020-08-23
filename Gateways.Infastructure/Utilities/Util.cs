using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Infastructure.Utilities
{
    public class Util
    {
        public  static bool ValidateIP(string sIP)
        {
            try { IPAddress ip = IPAddress.Parse(sIP); } catch { return false; }
            return true;
        }
    }
}
