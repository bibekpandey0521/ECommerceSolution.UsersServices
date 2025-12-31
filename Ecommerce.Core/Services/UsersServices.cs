using AutoMapper;
using Ecommerce.Core.Dto;
using Ecommerce.Core.Entites;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Services
{
    public class UsersServices : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersServices(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }
            //return new AuthenticationResponse(
            //        user.UserId,
            //        user.PersonName,
            //        user.Email,
            //        user.Gender,
            //        "token",
            //        Success: true
            //    );

            return _mapper.Map<AuthenticationResponse>(user) with
            {
                Success = true,
                Token = "token"
            };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            // Create a new ApplicationUser object from Authentication object From
            // RegisterRequest

            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString()
            };
            ApplicationUser? registeredUser = await _usersRepository.AddUser(user);
            if (registeredUser == null)
            {
                return null;
            }
            // Return success response 
            //return new AuthenticationResponse(
            //    registeredUser.UserId,
            //    registeredUser.Email,
            //    registeredUser.PersonName,
            //    registeredUser.Gender,
            //    "token",
            //    Success: true
            //);

            return _mapper.Map<AuthenticationResponse>(registeredUser) with
                { Success = true, Token = "token" };

        }
    }
}
