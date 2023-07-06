using System;
using BookStore.Data.Enums;

namespace BookStore.ViewModel
{
	public class UserViewModel
	{
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Status Status { get; set; }
        public string StatusDesc { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed{ get; set; }
    }
}

