using BLL.DTO;
using DAL.Models;
using DAL.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly ILogger<AuthorizeService> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _options;
        private readonly ShortenerDbContext _context;
        public AuthorizeService(ShortenerDbContext context,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration options, ILogger<AuthorizeService> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options;
            _logger = logger;
        }

        
        public async Task<ResponseMessage> SignIn(UserAutorize userData)
        {
            bool userExists = await _context.Users.AnyAsync(user => user.Name == userData.Name && user.Password == userData.Password);
            
            if (!userExists)
            {
                return new ResponseMessage() { Status = "Error", Message = "Invalid password!" };
            }
            var entity = _context.Users.FirstOrDefault(item => item.Name == userData.Name);
            int userPermision = entity.Role;
            return new ResponseMessage() { Status = "Ok", Message = userPermision.ToString() };

        }

        public async Task<ResponseMessage> SignUp(UserRegister userData)
        {
            bool userExists = await _context.Users.AnyAsync(user => user.Name == userData.Name && user.Password == userData.Password);
            if (userExists)
            {
                return new ResponseMessage() { Status = "Error", Message = "The user is already registered!" };
            }
            var newUser = new UsersModel() {
                Name = userData.Name, 
                Password = userData.Password, 
                Role = 1 };
            
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return new ResponseMessage() { Status = "Ok", Message = "User Registered!" };
        }
    }
}
