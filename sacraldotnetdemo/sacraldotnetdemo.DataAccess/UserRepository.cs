using System.Threading.Tasks;
using Npgsql;
using Dapper;

namespace sacraldotnetdemo
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserModel> GetById(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<UserModel>(query, new { Id = id });
            }
        }

        public async Task<int> Create(UserModel user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO Users (Name, AnnualIncome) VALUES (@Name, @AnnualIncome) RETURNING Id";
                return await connection.ExecuteScalarAsync<int>(query, user);
            }
        }

        public async Task Update(UserModel user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE Users SET Name = @Name, AnnualIncome = @AnnualIncome WHERE Id = @Id";
                await connection.ExecuteAsync(query, user);
            }
        }

        public async Task Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "DELETE FROM Users WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<bool> IsAnnualIncomeLessThan40K(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT AnnualIncome FROM Users WHERE Id = @Id";
                var annualIncome = await connection.ExecuteScalarAsync<decimal>(query, new { Id = id });
                return annualIncome < 40000;
            }
        }

        public async Task<bool> IsEligibleForInsuranceCover(int id)
        {
            var isAnnualIncomeLessThan40K = await IsAnnualIncomeLessThan40K(id);
            return isAnnualIncomeLessThan40K;
        }
    }
}