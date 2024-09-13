using Dapper;
using Microsoft.Data.SqlClient;
using UsersApp.Domain.Entities;

namespace UsersApp.Infra.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> InsertUserAsync(User user)
        {
            var sql = "INSERT INTO tb_user (full_name, birth_date, income, CPF) VALUES (@FullName, @BirthDate, @Income, @CPF)";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, user);
            }
        }

        public async Task<int> UpdateUserAsync(string cpf, User user)
        {
            var sql = "UPDATE tb_user SET full_name = @FullName, birth_date = @BirthDate, income = @Income WHERE CPF = @CPF";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, new
                {
                    user.FullName,
                    user.BirthDate,
                    user.Income,
                    CPF = cpf
                });
            }
        }

        public async Task<int> DeleteUserAsync(string cpf)
        {
            var sql = "DELETE FROM tb_user WHERE CPF = @CPF";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, new { CPF = cpf });
            }
        }

        public async Task<User> GetUserByCpfAsync(string cpf)
        {
            var sql = "SELECT full_name AS FullName, birth_date AS BirthDate, income AS Income, CPF FROM tb_user WHERE CPF = @CPF";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<User>(sql, new { CPF = cpf });
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var sql = "SELECT full_name AS FullName, birth_date AS BirthDate, income AS Income, CPF FROM tb_user";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<User>(sql);
            }
        }
    }
}
