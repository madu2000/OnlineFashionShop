﻿using OS.Entities;
using OS.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Services.Serivices.Abstracts
{
    public interface IUserService
    {
        MembershipContext ValidateUser(string username, string password);
        AccountUser CreateUser(AccountUser accountUser);
        // AccountUser GetUser(int userId);
        // List<Role> GetUserRoles(string username);
    }
}
