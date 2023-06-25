using System;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Interfaces
{
	public interface IAppDbContext
	{
        public DbSet<Book> Books { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

