using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using sacraldotnetdemo.DTO;

namespace sacraldotnetdemo
{
    public class OtpValidationModelRepository : IOtpValidationModelRepository
    {
        private readonly string connectionString;

        public OtpValidationModelRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<OtpValidationModel>> GetAllAsync()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<OtpValidationModel>("SELECT * FROM OtpValidationModel");
            }
        }

        public async Task<OtpValidationModel> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<OtpValidationModel>("SELECT * FROM OtpValidationModel WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<int> AddAsync(OtpValidationModel otpValidationModel)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteScalarAsync<int>("INSERT INTO OtpValidationModel (Otp, InsuranceCover) VALUES (@Otp, @InsuranceCover) RETURNING Id",
                    new { Otp = otpValidationModel.Otp, InsuranceCover = otpValidationModel.InsuranceCover });
            }
        }

        public async Task<bool> UpdateAsync(OtpValidationModel otpValidationModel)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                int rowsAffected = await connection.ExecuteAsync("UPDATE OtpValidationModel SET Otp = @Otp, InsuranceCover = @InsuranceCover WHERE Id = @Id",
                    new { Id = otpValidationModel.Id, Otp = otpValidationModel.Otp, InsuranceCover = otpValidationModel.InsuranceCover });
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                int rowsAffected = await connection.ExecuteAsync("DELETE FROM OtpValidationModel WHERE Id = @Id", new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}