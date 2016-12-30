using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Data.Repositories
{
    public interface IIpRepository
    {
        int Increment(DateTime dateTime, string ip);
        int GetRequestsByIpAndHourQuery(DateTime dateTime, string ip);
    }

    public class IpRepository : IIpRepository
    {
        public int GetRequestsByIpAndHourQuery(DateTime dateTime, string ip)
        {
            return 0;
        }

        public int Increment(DateTime dateTime, string ip)
        {
            return 0;
        }
    }
}
