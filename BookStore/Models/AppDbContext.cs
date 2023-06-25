﻿using System;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
	public class AppDbContext:DbContext
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
    }

	
}

