using AutoMapper;
using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Request.Method;
using Recipes.Models.Entity.Response.Method;

namespace recipes.models.Profiles
{
    public class MethodProfiles : Profile
    {
        public MethodProfiles()
        {
            RecognizePrefixes("rme_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            // Insert
            CreateMap<MethodRequestDto, sp_Insert_RME_Method_Parameters>()
               .ForMember(d => d.rme_Description, opt => opt.MapFrom(s => s.Description))
               .ForMember(d => d.rco_Id, opt => opt.MapFrom(s => s.RecipeId))
           .ReverseMap();

            // Update
            CreateMap<MethodRequestDto, sp_Update_RME_Method_Parameters>()
              .ForMember(d => d.rme_Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.rme_Description, opt => opt.MapFrom(s => s.Description))
              .ForMember(d => d.rco_Id, opt => opt.MapFrom(s => s.RecipeId))
            .ReverseMap();

            // Get
            CreateMap<MethodResponseDto, sp_Select_RME_MethodById_Results>()
              .ForMember(d => d.rme_Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.rme_Description, opt => opt.MapFrom(s => s.Description))
            .ReverseMap();
        }
    }
}
