using AquiCovidAPI.Entity;
using AquiCovidAPI.Interface;
using AquiCovidAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Service
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public List<PessoaResponse> Listar()
        {
            var entity = _pessoaRepository.Listar();

            List<PessoaResponse> response = new List<PessoaResponse>();

            entity.ForEach(p =>
            {

                response.Add(new PessoaResponse()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    CPF = p.CPF
                }); ;
            });

            return response;
        }

        public PessoaResponse Obter(int id)
        {
            var entity = _pessoaRepository.Obter(id);

            /* PessoaResponse response = new PessoaResponse();
             response.Id = entity.Id;
             response.Nome = entity.Nome;
             response.CPF = entity.CPF;* transmutação */

            return new PessoaResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                CPF = entity.CPF
            };

        }
    }

}
