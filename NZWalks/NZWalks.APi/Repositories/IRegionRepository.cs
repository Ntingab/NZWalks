using NZWalks.APi.Models.Domain;

namespace NZWalks.APi.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionAsync();

        Task<Region> GetRegionAsync(Guid id);

        Task<Region> AddAsync(Region region);

        Task<Region> DeleteAsync(Guid id);

        Task<Region> UpdateAsync(Guid id, Region region);

    }
}
