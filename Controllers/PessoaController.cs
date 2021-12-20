using AquiCovidAPI.Interface;
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

    }
}
