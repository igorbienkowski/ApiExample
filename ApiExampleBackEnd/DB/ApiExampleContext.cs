using ApiExampleBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiExampleBackEnd.DB
{
    public class ApiExampleContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApiExampleContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        public DbSet<CalculateRequest> CalculateRequests { get; set; }
        public DbSet<CalculationsResult> CalculationsResult { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (options.IsConfigured == false)
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}