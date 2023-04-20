
using Dapper;
using Desafio_NO.Models;
using Npgsql;

namespace Desafio_NO.Repository;

public class CepRepository : ICepRepository
{
  private readonly IConfiguration _configuration;
  private readonly string? connectionString;

  public CepRepository(IConfiguration configuration)
  {
    _configuration = configuration;
    connectionString = _configuration.GetConnectionString("SqlConnection");
  }
  public async Task<bool> CreateCepAsync(Adress cep)
  {
    string sql = @"INSERT INTO adress_rl (cep, logradouro, complemento, bairro, localidade, uf, ibge, gia, ddd, siafi)
    VALUES (@cep, @logradouro,@complemento, @bairro, @localidade, @uf, @ibge, @gia, @ddd, @siafi)";

    using var con = new NpgsqlConnection(connectionString);
    await con.OpenAsync();
    return await con.ExecuteAsync(sql, cep) > 0;
  }

  public async Task<Adress> GetCepAsync(string cep)
  {
    string sql = @"SELECT * FROM adress_rl 
                    WHERE cep = @Cep;";
    using var con = new NpgsqlConnection(connectionString);
    await con.OpenAsync();
    return await con.QueryFirstOrDefaultAsync<Adress>(sql, new { Cep = cep });
  }
}
