using backend_lab_b90617.Models;
using Dapper;
using System.Data.SqlClient;

namespace backend_lab_b90617.Repositories
{
    public class CountryRepository
    {
        private readonly string _connectionString;

        public CountryRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public List<CountryModel> GetCountries()
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM dbo.Country";
            return connection.Query<CountryModel>(query).ToList();
        }
        public bool CreateCountry(CountryModel country)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"INSERT INTO [dbo].[Country] ([Name],[Language],[Continent])
                                VALUES(@Name, @Language, @Continent)";
            var affectedRows = connection.Execute(query, new
            {
                Name = country.Name,
                Language = country.Language,
                Continent = country.Continent
            });
            return affectedRows >= 1;
        }
    }
}