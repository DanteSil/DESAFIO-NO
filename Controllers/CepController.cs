
using Newtonsoft.Json;
using Desafio_NO.Repository;
using Microsoft.AspNetCore.Mvc;
using Desafio_NO.Models;

namespace Desafio_NO.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CepController : ControllerBase
{
  private readonly ICepRepository _repository;

  public CepController(ICepRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> Get(string cep)
  {
    try
    {
      //Verificando se o formato da entrada CEP é compatível com o formato do campo CEP no banco de dados
      if (cep.Length != 8)
      {
        return BadRequest("Formato inválido! O CEP deve conter 8 caracteres, tente o formato: 12345678");
      }
      // Buscando dados banco de dados
      var adress = await _repository.GetCepAsync(cep);
      return adress != null ? Ok(adress) : NotFound("Cep não encontrado");
    }
    catch (System.Exception exception)
    {
      return BadRequest($"Erro: {exception}");
    }

  }

  [HttpPost]
  public async Task<IActionResult> Post(string cep)
  {
    var correiosUrl = $"https://viacep.com.br/ws/{cep}/json/";
    var client = new HttpClient();
    try
    {
      //Verificando se o formato da entrada CEP é compatível com o formato do campo CEP no banco de dados
      if (cep.Length != 8)
      {
        return BadRequest("Formato inválido! O CEP deve conter 8 caracteres, tente o formato: 12345678");
      }
      //obtendo e tratando dados da API dos correios
      HttpResponseMessage? response = await client.GetAsync(correiosUrl);
      response.EnsureSuccessStatusCode();
      string responseBody = await response.Content.ReadAsStringAsync();
      Adress adress = JsonConvert.DeserializeObject<Adress>(responseBody);
      // Verificando se há retorno de dados  
      if (adress.cep == null)
      {
        return BadRequest("Cep não encontrado / Cep inválido");
      }
      //removendo a barra e padronizando o formato do CEP
      string treatedCeps = adress.cep.Remove(5, 1);
      adress.cep = treatedCeps;
      // adicionando dados no bando de dados
      var added = await _repository.CreateCepAsync(adress);
      return added ? Ok("Endereço cadastrado com sucesso!") : BadRequest("Erro ao adicionar endereço");
    }
    catch (System.Exception exception)
    {
      return BadRequest($"Erro: {exception.StackTrace}");
    }

  }
}
