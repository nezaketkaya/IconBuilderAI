using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
using MediatR;

namespace IconBuilderAI.Application.Features.UserAuth.Commands.Login
{
    public class UserAuthLoginCommandHandler : IRequestHandler<UserAuthLoginCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        public UserAuthLoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthLoginCommand request, CancellationToken cancellationToken)
        {
            var jwtDto = await _identityService.LoginAsync(request, cancellationToken);

            return new ResponseDto<JwtDto>(jwtDto, "Welcome back!");
        }
    }
}
