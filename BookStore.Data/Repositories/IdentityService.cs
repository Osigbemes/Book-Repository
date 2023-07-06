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

        public async Task<Result> CreateUser(User user)
        {
            try
            {
                var password = user.Password;

                var createdUser = await _userManager.CreateAsync(user, user.Password);
                await _appDbContext.SaveChangesAsync();
                if (!createdUser.Succeeded)
                {
                    return Result.Failure($"Unable to create user.{createdUser.Errors.First().Code+ createdUser.Errors.First().Description}");
                }
                return Result.Success("User created successfully!", user);
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure creating user. {ex}");
            }
        }

        public async Task<Result> DeleteUser(string userId)
        {
            try
            {
                var userObject = await _userManager.FindByIdAsync(userId);
                if (userObject == null)
                {
                    return Result.Failure($"No user found");
                }
                await _userManager.DeleteAsync(userObject);
                return Result.Success("User deleted successfully!");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure deleting user. {ex}");
            }
        }

        public async Task<Result> GetUser(string userId)
        {
            try
            {
                var userObject = await _userManager.FindByIdAsync(userId);
                if (userObject==null)
                {
                    return Result.Failure("No user found");
                }
                return Result.Success("User retrieved successfully!", userObject);
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure retrieving user. {ex}");
            }
        }

        public async Task<Result> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user==null)
                {
                    return Result.Failure($"User with email {email} does not exist.");
                }
                return Result.Success(user);
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure retrieving user. {ex}");
            }
        }

        public async Task<Result> GetUsers()
        {
            try
            {
                var usersObject = await _userManager.Users.ToListAsync();
                if (usersObject.Count<=0 || usersObject==null)
                {
                    return Result.Failure("No user found.");
                }
                return Result.Success("User retrieved successfully!", usersObject.Count, usersObject);
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure creating user. {ex}");
            }
        }

        public async Task<Result> UpdateUser(string userId, User user)
        {
            try
            {
                var getUserObject = await _userManager.FindByIdAsync(userId);
                if (getUserObject==null)
                {
                    return Result.Failure("User does not exist");
                }
                getUserObject.UserName = user.UserName;
                getUserObject.PhoneNumber = user.PhoneNumber;
                getUserObject.LastModifiedDate = DateTime.Now;
                await _userManager.UpdateAsync(getUserObject);
                await _appDbContext.SaveChangesAsync();
                return Result.Success("User updated successfully!", getUserObject);
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure updating user. {ex}");
            }
        }
    }
}

