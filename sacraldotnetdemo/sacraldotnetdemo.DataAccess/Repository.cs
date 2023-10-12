using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Npgsql;

namespace sacraldotnetdemo
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<IEnumerable<T>> GetAllAsync(string tableName)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = $"SELECT * FROM {tableName}";

                var command = new NpgsqlCommand(query, connection);

                var dataReader = await command.ExecuteReaderAsync();

                var list = new List<T>();

                while (await dataReader.ReadAsync())
                {
                    var item = MapToEntity(dataReader);
                    list.Add(item);
                }

                return list;
            }
        }

        protected async Task<T> GetByIdAsync(string tableName, int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = $"SELECT * FROM {tableName} WHERE Id = @Id";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                var dataReader = await command.ExecuteReaderAsync();

                if (await dataReader.ReadAsync())
                {
                    return MapToEntity(dataReader);
                }

                return null;
            }
        }

        protected async Task<int> CreateAsync(string tableName, T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = $"INSERT INTO {tableName} VALUES (@Param1, @Param2, @Param3)";

                var command = new NpgsqlCommand(query, connection);
                AddParameters(command, entity);

                return await command.ExecuteNonQueryAsync();
            }
        }

        protected async Task<int> UpdateAsync(string tableName, int id, T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = $"UPDATE {tableName} SET Param1 = @Param1, Param2 = @Param2, Param3 = @Param3 WHERE Id = @Id";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                AddParameters(command, entity);

                return await command.ExecuteNonQueryAsync();
            }
        }

        protected async Task<int> DeleteAsync(string tableName, int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = $"DELETE FROM {tableName} WHERE Id = @Id";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                return await command.ExecuteNonQueryAsync();
            }
        }

        protected abstract T MapToEntity(NpgsqlDataReader dataReader);

        protected abstract void AddParameters(NpgsqlCommand command, T entity);
    }

    public class UserRepository : IUserRepository
    {
        private readonly BaseRepository<User> _baseRepository;

        public UserRepository(string connectionString)
        {
            _baseRepository = new BaseRepository<User>(connectionString);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync("Users");
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _baseRepository.GetByIdAsync("Users", id);
        }

        public async Task<int> CreateAsync(User user)
        {
            return await _baseRepository.CreateAsync("Users", user);
        }

        public async Task<int> UpdateAsync(int id, User user)
        {
            return await _baseRepository.UpdateAsync("Users", id, user);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync("Users", id);
        }
    }

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<int> CreateAsync(User user);
        Task<int> UpdateAsync(int id, User user);
        Task<int> DeleteAsync(int id);
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}