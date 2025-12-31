using AutoMapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionString = _configuration.GetConnectionString("PostgresConnection");

            // Create a new NpgsqlConnection with the retrieved connection string
            _connection = new NpgsqlConnection(connectionString);

        }

        public IDbConnection DbConnection => _connection;
        //public IDbConnection DbConnection
        //{
        //    get
        //    {
        //        return _connection;
        //    }
        //}
        /// <summary>
        /// connection is a private variable when it tries to access private variable it does not give that
        /// 
        /// So when someone writes: _context.DbConnection C# actually runs:  return _connection;

        /// 
        /// </summary>
        /// 
        ///

    }
}
