using AutoMapper;
using Recipes.Models.Dto.Request;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Request.Ingredient;
using Recipes.Models.Entity.Response.Ingredient;

namespace recipes.models.Profiles
{
    public class IngredientProfiles : Profile
    {
        public IngredientProfiles()
        {
            RecognizePrefixes("rin_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            // Insert
            CreateMap<IngredientRequestDto, sp_Insert_RIN_Ingredient_Parameters>()
               .ForMember(d => d.rin_Description, opt => opt.MapFrom(s => s.Description))
               .ForMember(d => d.rco_Id, opt => opt.MapFrom(s => s.RecipeId))
           .ReverseMap();

            // Update
            CreateMap<IngredientRequestDto, sp_Update_RIN_IngredientById_Parameters>()
              .ForMember(d => d.rin_Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.rin_Description, opt => opt.MapFrom(s => s.Description))
              .ForMember(d => d.rco_Id, opt => opt.MapFrom(s => s.RecipeId))
            .ReverseMap();

            // Get
            CreateMap<IngredientResponseDto, sp_Select_RIN_All_Ingredients_Results>()
              .ForMember(d => d.rin_Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.rin_Description, opt => opt.MapFrom(s => s.Description))
           .ReverseMap();
        }
    }
}
