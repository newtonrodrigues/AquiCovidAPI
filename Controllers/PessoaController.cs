using AquiCovidAPI.Interface;
using AquiCovidAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Controllers
{
    [Route("[controller]")]
    public class PessoaController
    {
        private IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var response = _pessoaService.Listar();
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpGet("obter")]
        public IActionResult Obter([FromQuery] int id)
        {
            var response = _pessoaService.Obter(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPost("inserir")]
        public IActionResult Inserir([FromBody] PessoaRequest request)
        {
            var response = _pessoaService.Inserir(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] PessoaRequest request)
        {
            var response = _pessoaService.Atualizar(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };

        }

        [HttpDelete("deletar")]
        public IActionResult Deletar([FromQuery] int id)
        {
            var response = _pessoaService.Deletar(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode};

        }

    }
}
