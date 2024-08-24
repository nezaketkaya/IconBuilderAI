﻿using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Application.Common.Models.Emails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler : IRequestHandler<UserAuthRegisterCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;

        public UserAuthRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService, IEmailService emailService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
            _emailService = emailService;
        }


        public async Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.RegisterAsync(request, cancellationToken);

            var jwtDtoTask = _jwtService.GenerateTokenAsync(response.Id, response.Email, cancellationToken);

            var sendEmailTask = SendEmailVerificationAsync(response.Email, response.FirstName, response.EmailToken, cancellationToken);

            await Task.WhenAll(jwtDtoTask ,sendEmailTask);

            return new ResponseDto<JwtDto>(await jwtDtoTask, "Welcome to our application!");
        }

        private Task SendEmailVerificationAsync(string email, string firstName, string emailToken, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendEmailVerificationDto(email, firstName, emailToken);

            return _emailService.SendEmailVerificationAsync(emailDto, cancellationToken);
        }
    }
}
