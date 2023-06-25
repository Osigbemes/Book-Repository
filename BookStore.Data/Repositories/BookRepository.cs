using System;
using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IAppDbContext _appDbContext;
        public BookRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Book> books = new List<Book>()
        {
            new Book {Id = 1, Title="The boy on the train", Author="Hwakins Paula", CallNumber="1234", IsAvailable=false, PublicationYear=2021},

        };

        public async Task<Book> Add(Book book)
        {
            try
            {
                var result = await _appDbContext.Books.AddAsync(book);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<List<Book>> IBookRepository.GetBooks()
        {
            try
            {
                var books = await _appDbContext.Books.ToListAsync();
                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Book> IBookRepository.Get(int id)
        {
            var book = await _appDbContext.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public async Task<Book> Update(int id, Book book)
        {
            try
            {
                var result = await _appDbContext.Books.FirstOrDefaultAsync(a => a.Id == id);
                if (result==null)
                {
                    return null;
                }
                result.Author = book.Author;
                result.CallNumber = book.CallNumber;
                result.IsAvailable = book.IsAvailable;
                result.PublicationYear = book.PublicationYear;
                result.Title = book.Title;

                _appDbContext.Books.Update(result);
                await _appDbContext.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            var result = await _appDbContext.Books.FirstOrDefaultAsync(a => a.Id == id);
            if (result != null)
            {
                _appDbContext.Books.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            
        }
    }
}

