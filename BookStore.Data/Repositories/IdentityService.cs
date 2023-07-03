using System;
using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories
{
	public class IdentityService:IIdentityService
	{
        private readonly UserManager<User> _userManager;
        private readonly IAppDbContext _appDbContext;
        public IdentityService(UserManager<User> userManager, IAppDbContext appDbContext)
		{
            _userManager = userManager;
            _appDbContext = appDbContext;
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

        public async Task<Results> GetUser(string userId)
        {
            try
            {
                var userObject = await _userManager.FindByIdAsync(userId);
                if (userObject==null)
                {
                    return Results.Failure("No user found");
                }
                return Results.Success("User retrieved successfully!", userObject);
            }
            catch (Exception ex)
            {
                return Results.Failure($"Failure retrieving user. {ex}");
            }
        }

        public async Task<Results> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user==null)
                {
                    return Results.Failure($"User with email {email} does not exist.");
                }
                return Results.Success(user);
            }
            catch (Exception ex)
            {
                return Results.Failure($"Failure retrieving user. {ex}");
            }
        }

        public async Task<Results> GetUsers(User user)
        {
            try
            {
                var usersObject = await _userManager.Users.ToListAsync();
                if (usersObject.Count<=0 || usersObject==null)
                {
                    return Results.Failure("No user found.");
                }
                return Results.Success("User retrieved successfully!", usersObject.Count, usersObject);
            }
            catch (Exception ex)
            {
                return Results.Failure($"Failure creating user. {ex}");
            }
        }
    }
}

