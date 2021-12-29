using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AquiCovidAPI.Entity;
using AquiCovidAPI.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AquiCovidAPI.Repository
{
    public class PessoaRepository : BaseRepository, IPessoaRepository
    {
             public PessoaRepository(IConfiguration configuration) : base(configuration){ }
    
        public List<Pessoa> Listar()
        {
            string query = @"SELECT [Id]
                                  ,[Nome]
                                  ,[CPF]
                              FROM[dbo].[Pessoa]";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.Query<Pessoa>(query).ToList();
           
        }

        public Pessoa Obter(int Id)
        {
            string query = @"SELECT [Id]
                                  ,[Nome]
                                  ,[CPF]
                              FROM[dbo].[Pessoa]
                              WHERE [Id] = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Pessoa>(query, new { Id });

        }


        public Pessoa ObterPorCpf(string CPF)
        {
            string query = @"SELECT [Id]
                                  ,[Nome]
                                  ,[CPF]
                              FROM[dbo].[Pessoa]
                              WHERE [CPF] = @CPF";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Pessoa>(query, new { CPF });

        }


        public void Inserir(Pessoa pessoa)
        {
            string query = @"INSERT INTO [dbo].[Pessoa]
                               ([Nome]
                               ,[CPF])
                                VALUES
                               (@Nome
                               , @CPF)";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, pessoa);

        }

        public void Atualizar(Pessoa pessoa)
        {
            string query = @"UPDATE[dbo].[Pessoa]
                            SET[Nome] = @Nome,
                               [CPF] =  @CPF
                            WHERE Id = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, pessoa);
        }

        public void Deletar( int Id)
        {
            string query = @"DELETE FROM Pessoa WHERE Id = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, new { Id });

        }
            
    }
}
