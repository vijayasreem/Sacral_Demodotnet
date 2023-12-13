using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace sacraldotnetdemo
{
    public class Repository : IRepository
    {
        private readonly string connectionString;

        public Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task CreateAsync<T>(T entity)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    // TODO: Set command parameters and SQL statement for INSERT operation
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<T> GetAsync<T>(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    // TODO: Set command parameters and SQL statement for SELECT operation
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            // TODO: Map reader data to entity object
                            return default(T);
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }

        public async Task UpdateAsync<T>(T entity)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    // TODO: Set command parameters and SQL statement for UPDATE operation
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync<T>(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    // TODO: Set command parameters and SQL statement for DELETE operation
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}