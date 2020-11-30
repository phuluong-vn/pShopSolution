﻿using PShopSolution.ViewModels.Common;
using PShopSolution.ViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}