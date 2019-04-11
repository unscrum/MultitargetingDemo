using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MultitargetingDemo.Data
{
    class EnvironmentAwareConnectionStringBuilder
    {
        private readonly IConfiguration _configuration;

        public string DbName => _configuration.GetValue<string>("DB_NAME");
        public string DbHostName => _configuration.GetValue<string>("DB_HOSTNAME");
        public string DbUserName => _configuration.GetValue<string>("DB_USERNAME");
        public string DbPassword => _configuration.GetValue<string>("DB_PASSWORD");
        public int DbPort => _configuration.GetValue<int>("DB_PORT");

        public EnvironmentAwareConnectionStringBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string fallbackConnectionStringName)
        {
            if (string.IsNullOrWhiteSpace(DbName))
                return _configuration.GetConnectionString(fallbackConnectionStringName);
            return $"Servers=tcp:{DbHostName},{DbPort};Database={DbName};UserName={DbUserName};Password={DbPassword};MultipleActiveResultSets=True";
        }
    }
}