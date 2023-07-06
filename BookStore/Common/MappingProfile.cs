using System;
using AutoMapper;
using BookStore.Data.Enums;
using BookStore.Data.Models;
using BookStore.ViewModel;

namespace BookStore.Common
{
	public class MappingProfile : Profile
	{
        
        public MappingProfile()
		{
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
	}
}

