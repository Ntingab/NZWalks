using Microsoft.AspNetCore.Mvc;
using NZWalks.APi.Models.Domain;
using NZWalks.APi.Repositories;

namespace NZWalks.APi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : Controller
    {

        public readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {

            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = regionRepository.GetAll();

            // return DTO regions

            var regionsDTO = new List<Models.DTO.Region>();

            regions.ToList().ForEach(region =>
            {
                var regionDTO = new Models.DTO.Region()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Population = region.Population
                };

                regionsDTO.Add(regionDTO);
            });

            return Ok(regionsDTO);
        }

    }
}
