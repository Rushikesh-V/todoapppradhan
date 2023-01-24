using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Todo_Data.Models;
using Microsoft.EntityFrameworkCore;
using Todo_Repository.Accounts;
using System.Net;

namespace Todo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        IAccountMain obj;
        private readonly TodoDbContext _context;

        public AccountController(IAccountMain Obj)
        {
            obj = Obj;
        }

        [HttpGet("AllAccounts")]
        public IActionResult GetAllAccounts()
        {
            return Ok(obj.GetAllAccounts());
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(Account account)
        {
             if (obj.AddNewAccount(account))
           // obj.AddNewAccount(account);
           {
                return Ok();           
            }
            else
           {
                return BadRequest("Username already exists.");
           }           
        }

        [HttpPost("Login")]
        public IActionResult Login(string Email,string Password)
        {
            if (obj.Login(Email, Password))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Account doesnot exists.");
            }
        }

        [HttpPost("DeleteAccount")]
        public IActionResult DeleteAccount(string Email)
        {
            obj.DeleteAccount(Email);
            return Ok();
        }

        //[HttpPost("UpdateAccount")]
        //public IActionResult UpdatePhonenumber(string Phonenumber)
        //{
        //    obj.UpdateAccount(Phonenumber);
        //}
    }
}
