
using Desafio_NO.Models;

namespace Desafio_NO.Repository;
public interface ICepRepository
{
  Task<bool> CreateCepAsync(Adress adress);
  Task<Adress> GetCepAsync(string cep);
}