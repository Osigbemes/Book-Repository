using System;
using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories
{
	public class AppDbContext: IdentityDbContext<User>, IAppDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
		{

		}

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed Books Table
            modelBuilder.Entity<Book>().HasData(
                new Book {Id=1, Author = "Emmanuel Iren", CallNumber="149", IsAvailable=true, PublicationYear=2019, Title="Saving Grace" });

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 2, Author = "Emmanuel Iren", CallNumber = "169", IsAvailable = true, PublicationYear = 2019, Title = "Leading Seeks You" });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }

	
}

