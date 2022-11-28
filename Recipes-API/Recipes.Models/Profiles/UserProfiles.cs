using AutoMapper;
using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Request.UserLogin;
using Recipes.Models.Entity.Response.UserLogin;

namespace recipes.models.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            RecognizePrefixes("usr_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            // Login
            CreateMap<UserLoginRequestDto, sp_Select_USR_UserLogin_Parameters>()
                  .ForMember(d => d.usr_email, opt => opt.MapFrom(s => s.email))
                  .ForMember(d => d.usr_password, opt => opt.MapFrom(s => s.password))
              .ReverseMap();

            // Get
            CreateMap<UserResponseDto, sp_Select_USR_UserLogin_Results>()
                .ForMember(d => d.usr_Id, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.usr_Name, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.rol_Id, opt => opt.MapFrom(s => s.RoleId))
                .ForMember(d => d.rol_Name, opt => opt.MapFrom(s => s.RoleName))
                .ForMember(d => d.rol_ViewSharedEntries, opt => opt.MapFrom(s => s.ViewSharedEntries))
                .ForMember(d => d.rol_AddEditDeleteSharedEntries, opt => opt.MapFrom(s => s.AddEditDeleteSharedEntries))
                .ForMember(d => d.rol_ApproveSharingMyGroups, opt => opt.MapFrom(s => s.ApproveSharingMyGroups))
                .ForMember(d => d.rol_ApproveSharingAllGroups, opt => opt.MapFrom(s => s.ApproveSharingAllGroups))
                .ForMember(d => d.rol_ManageUsers, opt => opt.MapFrom(s => s.ManageUsers))
                .ForMember(d => d.rol_ManageAllEntries, opt => opt.MapFrom(s => s.ManageAllEntries))
                .ForMember(d => d.rol_ManageForms, opt => opt.MapFrom(s => s.ManageForms))
            .ReverseMap();


        }
    }
}
