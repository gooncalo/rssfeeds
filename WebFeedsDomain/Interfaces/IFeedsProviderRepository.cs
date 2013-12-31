using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFeedsDomain.Domain;

namespace WebFeedsDomain.Interfaces
{
    public interface IFeedsProviderRepository
    {
        IEnumerable<FeedsProvider> Providers { get; }

        FeedsProvider GetByID(int id);        
    }
}
