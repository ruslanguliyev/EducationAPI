using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResult;
using Core.Helpers.Results.Concrete.SuccessResult;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IUserManager _userManager;

        public AuthManager(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IDataResult<User> Login(LoginDTO loginDTO)
        {
            var user = _userManager.GetUser(loginDTO.Email);
            if (user == null)
                return new ErrorDataResult<User>(Message.UserNotFound);
            HashingHelper.VerifyPassword(loginDTO.Password, user.PasswordHash, user.PasswordHash);
            bool checkPassword = HashingHelper.VerifyPassword(loginDTO.Password, user.PasswordHash, user.PasswordSalt);
            if (checkPassword)
            {
                string token = TokenGenerator.Token(user, "Admin");
                return new SuccessDataResult<User>(token);
            }
            return new ErrorDataResult<User>(Message.EmailOrPassword);
        }

        public IDataResult<User> Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.HashPassword(registerDTO.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                Email = registerDTO.Email,
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userManager.AddUser(user);
            return new SuccessDataResult<User>(user, Message.UserRegistered);
        }
    }
}
