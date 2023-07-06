using System;
using AutoMapper;
using BookStore.Data.Models;

namespace BookStore.Common
{
	public class BookModel : Profile
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public string CallNumber { get; set; }
        public BookModel()
		{
            CreateMap<Book, BookModel>();
		}
	}
}

