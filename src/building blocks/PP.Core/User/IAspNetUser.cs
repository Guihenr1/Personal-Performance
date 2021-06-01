﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace PP.Core.User
{
    public interface IAspNetUser {
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterTipo();
        string ObterUserToken();
        string ObterUserRefreshToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }
}