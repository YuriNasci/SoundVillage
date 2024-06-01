﻿using Dapper;
using Microsoft.Extensions.Options;
using SoundVillage.STS.Model;
using System.Data.SqlClient;

namespace SoundVillage.STS.Data
{
    public class IdentityRepository
    {
        private readonly string connectionString;

        public IdentityRepository(IOptions<DatabaseOption> options)
        {
            this.connectionString = options.Value.SoundVillageConnection;
        }

        public async Task<Usuario> FindByIdAsync(Guid id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var user = await connection.QueryFirstAsync<Usuario>(IdentityQuery.FindById(), new
                {
                    id = id
                });

                return user;
            }
        }

        public async Task<Usuario> FindByEmailAndPasswordAsync(string email, string password)
        {
            using (var connection = new SqlConnection(this.connectionString)) {
                var user = await connection.QueryFirstAsync(IdentityQuery.FindByEmailAndPassword(), new
                {
                    email = email,
                    senha = password
                });
                return user;
            }
        }
    }

    public static class IdentityQuery
    {
        public static string FindById() =>
            @"SELECT Id, Nome, Email
                FROM USUARIO
                WHERE Id = @id;
            ";

        public static string FindByEmailAndPassword() =>
            @"SELECT Id, Nome, Email
                FROM USUARIO
                WHERE Email = @email
                AND Senha = @senha
            ";
    }
}