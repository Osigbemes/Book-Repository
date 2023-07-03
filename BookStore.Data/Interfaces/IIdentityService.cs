﻿using System;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Data.Interfaces
{
	public interface IIdentityService
	{
		Task<Results> CreateUser(User user);
        Task<Results> GetUser(User user);
        Task<Results> GetUsers(User user);
    }
}
