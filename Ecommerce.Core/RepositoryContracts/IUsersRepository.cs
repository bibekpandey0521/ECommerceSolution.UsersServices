using Ecommerce.Core.Entites;

namespace Ecommerce.Core.RepositoryContracts
{
    /// <summary>
    /// Contract to be implemented by UsersRepository
    /// that contains data access logic of Users data
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add a user to the data store and
        /// return the added user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);


        /// <summary>
        /// Method to retrieve existing user  by their email and password
        /// return the added user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ApplicationUser?>
                GetUserByEmailAndPassword(string? email,
            string? password);
    }
}
