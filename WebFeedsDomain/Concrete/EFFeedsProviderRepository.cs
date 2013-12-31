using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFeedsDomain.DAL;
using WebFeedsDomain.Interfaces;

namespace WebFeedsDomain.Concrete
{
    public class EFFeedsProviderRepository : IFeedsProviderRepository
    {
        private dbFeedsEntities _dbFeed;
        private List<FeedsProvider> _providers = null;
        
        public IEnumerable<Domain.FeedsProvider> Providers
        {
            get
            {
                if (_providers == null)
                {
                    _providers = _dbFeed.FeedsProviders.ToList();
                }
                                
                if (_providers != null)
                {
                    var result = _providers.ConvertAll<Domain.FeedsProvider>(f => f.ToFeedsProvider());
                    return result;
                }

                return null;
            }            
        }

        public EFFeedsProviderRepository()
        {
            _dbFeed = new dbFeedsEntities();            
        }

        public Domain.FeedsProvider GetByID(int id)
        {
            if (Providers == null)
                return null;

            return Providers.ToList().Find(f => f.ID == id);
        }        

    }
}
