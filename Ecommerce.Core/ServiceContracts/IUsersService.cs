using Ecommerce.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.ServiceContracts
{
    /// <summary>
    ///  Contract for users service that contains use case 
    ///  and returns an AuthenticationResponse object that
    ///  contains status of login
    ///  cases for users 
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        ///  Method to handle user login use case 
        ///  and returns an AuthenticationResponse object that
        ///  contains status of login
        ///  cases for users 
        /// </summary>
        /// <summary>
        /// <param name="loginRequest"></param>
        /// </summary>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        /// <summary>
        ///  Method of handle user registration 
        ///  and returns an AuthenticationResponse object that
        ///  contains status of Register
        ///  cases for users 
        /// </summary>
        /// <summary>
        /// <param name="RegisterRequest"></param>
        /// </summary>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
