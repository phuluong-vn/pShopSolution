using PShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace PShopSolution.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectedItem> Roles { get; set; } = new List<SelectedItem>();
    }
}