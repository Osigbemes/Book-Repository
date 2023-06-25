using System;
using BookStore.Data.Models;

namespace BookStore.Data.Interfaces
{
	public interface IBookRepository
	{
		Task<List<Book>> GetBooks();
		Task<Book> Get(int id);
		Task<Book> Add(Book book);
        Task<Book> Update(int id, Book book);
        Task Delete(int id);
    }
}

