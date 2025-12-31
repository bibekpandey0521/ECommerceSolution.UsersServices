using Ecommerce.Core.Dto;
using Ecommerce.Core.Entites;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Infrastructure.DbContext;
using Dapper;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;
        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            // Generate a new unique user Id for the user
            user.UserId = Guid.NewGuid();

            // SQL Query to insert user data into the 
            // "Users" table.
      
           
            string query = "INSERT INTO public.\"Users\"(\"UserId\",\"Email\",\"PersonName\",\"Gender\"," +
                "\"Password\") VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";
            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query,user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new {Email = email, Password = password};
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameters);
            //return new ApplicationUser()
            //{
            //    UserId = Guid.NewGuid(),
            //    Email = email,
            //    Password = password,
            //    PersonName = "Person Name",
            //    Gender = GenderOptions.Male.ToString()
            //};

            return user;
        }
    }
}
