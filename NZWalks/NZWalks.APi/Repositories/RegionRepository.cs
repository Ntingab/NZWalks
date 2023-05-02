using NZWalks.APi.Data;
using NZWalks.APi.Models.Domain;

namespace NZWalks.APi.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;
        public RegionRepository(NZWalksDBContext nZWalksDBContext)
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }

        public IEnumerable<Region> GetAll()
        {
           return nZWalksDBContext.Regions.ToList();
        }
    }
}
