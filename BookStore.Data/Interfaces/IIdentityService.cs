using System;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Data.Interfaces
{
	public interface IIdentityService
	{
		Task<Result> CreateUser(User user);
        Task<Result> UpdateUser(string userId, User user);
        Task<Result> GetUser(string userId);
        Task<Result> DeleteUser(string userId);
        Task<Result> GetUserByEmail(string email);
        Task<Result> GetUsers();
    }
}

