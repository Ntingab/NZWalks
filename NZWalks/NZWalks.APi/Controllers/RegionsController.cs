using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.APi.Models.Domain;
using NZWalks.APi.Models.DTO;
using NZWalks.APi.Repositories;

namespace NZWalks.APi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : Controller
    {

        public readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {

            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllRegionAsync();

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync (Guid id)
        {
            var regions = await regionRepository.GetRegionAsync(id);

            if(regions == null)
            {
                return NotFound();
            }

            var regionsDTO = mapper.Map<Models.DTO.Region>(regions);

            return Ok(regionsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            // Request(DTO) to domain model
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population

            };

            // pass details to repository

            await regionRepository.AddAsync(region);

            // Convert back to DTO

            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync), new {id=regionDTO.Id}, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            // get region from databsee
            var region = await regionRepository.DeleteAsync(id);

            // send not found back if not found 
            if(region == null)
            {
                return NotFound();
            }

            // convert response to DTO

            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
               
            };

            // give response to client 

            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            // get region from databsee
            var region = new Models.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population
            };

           var regionResult =  await regionRepository.UpdateAsync(id, region);

            // send not found back if not found 
            if (regionResult == null)
            {
                return NotFound();
            }

            var regionDTO = new Models.DTO.Region
            {
                Id = regionResult.Id,
                Code = regionResult.Code,
                Area = regionResult.Area,
                Lat = regionResult.Lat,
                Long = regionResult.Long,
                Name = regionResult.Name,
                Population = regionResult.Population

            };

            return Ok(regionDTO);
        }
    }
}
