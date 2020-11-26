using System;

namespace PShopSolution.ViewModels.System.Users
{
    public class DeleteUserRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}