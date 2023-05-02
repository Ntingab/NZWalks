using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
           return await nZWalksDBContext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionAsync(Guid id)
        {
            return await nZWalksDBContext.Regions.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDBContext.AddAsync(region);

            await nZWalksDBContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            nZWalksDBContext.Regions.Remove(region);
            await nZWalksDBContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var regionResult = await nZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionResult == null)
            {
                return null;
            }

            regionResult.Code = region.Code;
            regionResult.Name = region.Name;
            regionResult.Walks = region.Walks;
            regionResult.Lat = region.Lat;
            regionResult.Area = region.Area;
            regionResult.Population = region.Population;

            await nZWalksDBContext.SaveChangesAsync();

            return regionResult;
        }
    }
}
