using BookStore.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net.NetworkInformation;

namespace BookStore.Data.Models
{
	public class User: IdentityUser
	{
		public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Status Status { get; set; }
        public string StatusDesc { get; set; }
    }
}

