﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data.Interfaces;
using BookStore.Data.Repositories;
using BookStore.Data.Models;

namespace BookStore.Controllers
{
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        //private BookRepository books = new BookRepository();
        private readonly IBookRepository _bookRepository;
        private readonly IIdentityService _identityService;
        public UsersController(IBookRepository bookRepository, IIdentityService identityService)
        {
            _bookRepository = bookRepository;
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Result>> Add([FromBody] User user)
        {
            try
            {
                var result = await _identityService.CreateUser(user);

                return result;
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure creaing user {ex}");
            }
        }

        [HttpGet("getuserbyid/{id}")]
        public async Task<ActionResult<Result>> GetById(string id)
        {
            try
            {
                var user = await _identityService.GetUser(id);
                if (user.Entity == null)
                {
                    return NotFound(user);
                }
                return user;
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure retrieving user by id {ex}");
            }
        }

        [HttpGet("getbyemail/{email}")]
        public async Task<ActionResult<Result>> GetByEmail(string email)
        {
            try
            {
                var user = await _identityService.GetUserByEmail(email);
                if (user.Entity == null)
                {
                    return NotFound(user);
                }
                return user;
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure retrieving user by email {ex}");
            }
        }

        [HttpGet("getallusers")]
        public async Task<ActionResult<Result>> GetAllUsers()
        {
            try
            {
                var users = await _identityService.GetUsers();
                if (users.Entity == null || users.Count <= 0)
                {
                    return NotFound(users);
                }
                return users;
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure retrieving users {ex}");
            }
        }

        [HttpPut("updateuser/{id}")]
        public async Task<ActionResult<Result>> Update(string id, [FromBody] User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest("Id mismatch");
                }

                var result = await _identityService.UpdateUser(id, user);
                if (result.Entity == null)
                {
                    return NoContent();
                }
                return result;
            }
            catch (Exception ex)
            {
                return Result.Failure($"{ex}");
            }
        }

        [HttpDelete("deleteuser/{id}")]
        public async Task<ActionResult<Result>> Delete(string id)
        {
            try
            {
                await _identityService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failure deleting user {ex}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }
    }
}

