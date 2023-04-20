using System.ComponentModel.DataAnnotations;
// formato da tabela para migration
namespace Desafio_NO.Models.Entities
{
  public class AdressTable
  {
    [Key]
    public string cep { get; set; }
    public string? logradouro { get; set; }
    public string? complemento { get; set; }
    public string? bairro { get; set; }
    public string? localidade { get; set; }
    public string? uf { get; set; }
    public string? ibge { get; set; }
    public string? gia { get; set; }
    public string? ddd { get; set; }
    public string? siafi { get; set; }
  }
}