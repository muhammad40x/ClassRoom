﻿using System.Security.Claims;

namespace _3lessonproject.Helpers;

public class UserProvider
{
    private readonly IHttpContextAccessor _contextAccessor;
    private ClaimsPrincipal User => _contextAccessor.HttpContext!.User;

    public UserProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    private Guid? _userId;

    public Guid UserId => _userId ??= Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
}