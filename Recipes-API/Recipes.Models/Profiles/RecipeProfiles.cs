using AutoMapper;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Response.Recipe;

namespace Recipes.Models.Profiles
{
    public class RecipeProfiles : Profile
    {
        public RecipeProfiles()
        {
            RecognizePrefixes("rco_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<RecipeResponseDto, sp_Select_RCO_AllRecipes_Results>()
               .ForMember(d => d.rco_Id, opt => opt.MapFrom(s => s.Id))
               .ForMember(d => d.rco_RecipeName, opt => opt.MapFrom(s => s.RecipeName))
               .ForMember(d => d.rco_Image, opt => opt.MapFrom(s => s.Image))
               .ForMember(d => d.rco_Description, opt => opt.MapFrom(s => s.Description))
               .ForMember(d => d.rco_Author, opt => opt.MapFrom(s => s.Author))
               .ForMember(d => d.rco_CreatedOn, opt => opt.MapFrom(s => s.Created))
            .ReverseMap();
        }
    }
}
