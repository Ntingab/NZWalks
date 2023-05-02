using AutoMapper;
using Azure.Identity;

namespace NZWalks.APi.Profiles
{
    public class RegionsProfiles: Profile
    {
        public RegionsProfiles()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>().ReverseMap();
        }
    }
}
