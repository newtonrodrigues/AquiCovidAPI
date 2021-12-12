using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AquiCovidAPI.Entity;
using AquiCovidAPI.Interface;
using Dapper;

namespace AquiCovidAPI.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
    
        public string _connectionsString = "Server=Newton-PC\\;Database=AquiCovid;Trusted_Connection=True;";
        
        public List<Pessoa> Listar()
        {
            string query = @"SELECT [Id]
                                  ,[Nome]
                                  ,[CPF]
                              FROM[dbo].[Pessoa]";

            SqlConnection conn = new SqlConnection(_connectionsString);
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

            SqlConnection conn = new SqlConnection(_connectionsString);
            conn.Open();
            return conn.QueryFirstOrDefault<Pessoa>(query, new { Id });

        }

    }
}
