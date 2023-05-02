using NZWalks.APi.Models.Domain;

namespace NZWalks.APi.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region>GetAll();
    }
}
