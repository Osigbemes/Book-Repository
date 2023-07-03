using System;
using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Data.Repositories
{
	public class IdentityService:IIdentityService
	{
        private readonly UserManager<User> _userManager;
        public IdentityService(UserManager<User> userManager)
		{
            _userManager = userManager;
		}

        public async Task<Results> CreateUser(User user)
        {
            try
            {
                var createdUser = await _userManager.CreateAsync(user, user.Password);
                if (!createdUser.Succeeded)
                {
                    return Results.Failure("Unable to create user.");
                }
                return Results.Success("User created successfully!", createdUser);
            }
            catch (Exception ex)
            {
                return Results.Failure($"Failure creating user. {ex}");
            }
        }

        public Task<Results> GetUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Results> GetUsers(User user)
        {
            throw new NotImplementedException();
        }
    }
}

