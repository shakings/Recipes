using AutoMapper;
using Recipes.Models.Dtos.Request;
using Recipes.Models.Dtos.Response;
using Recipes.Models.Entity.Request.UserLogin;
using Recipes.Repository.Interfaces.Builders;
using Recipes.Repository.Interfaces.Services;

namespace Recipes.Repository.Implementations.Service
{
    public class UserRepositoryServices : IUserRepositoryService
    {
        private readonly IUserRepositoryBuilder _userRepositoryBuilder;
        private readonly IMapper _mapper;

        public UserRepositoryServices(IUserRepositoryBuilder userRepositoryBuilder,
                                      IMapper mapper)
        {
            this._userRepositoryBuilder = userRepositoryBuilder ?? throw new ArgumentNullException(nameof(userRepositoryBuilder));
            this._mapper = mapper;
        }

        public async Task<UserResponseDto> LoginAsync(UserLoginRequestDto userLogin)
        {
            var parameters = _mapper.Map<sp_Select_USR_UserLogin_Parameters>(userLogin);
            var result = await this._userRepositoryBuilder.LoginAsync(parameters);

            return _mapper.Map<UserResponseDto>(result);
        }


    }
}

