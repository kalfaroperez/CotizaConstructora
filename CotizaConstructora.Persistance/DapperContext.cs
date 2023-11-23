using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace CotizaConstructora.Persistance
{
    public class DapperContext
    {
        private IConfiguration _configuration { get; set; }
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:LocalConnection"];
        }

        public IDbConnection Connect()
            => new MySqlConnection(_connectionString);
    }
}