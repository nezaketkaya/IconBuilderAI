﻿using IconBuilderAI.Application.Common.Interfaces;
using System.Security.Claims;

namespace IconBuilderAI.WebApi.Services
{
    public class CurrentUserManager : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid UserId => Guid.Parse("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93");

        // public Guid UserId => GetUserId();
        private Guid GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");

            return userId is null ? Guid.Empty : Guid.Parse(userId);
        }
    }
}
