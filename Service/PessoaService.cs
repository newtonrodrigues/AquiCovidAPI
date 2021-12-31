using AquiCovidAPI.Entity;
using AquiCovidAPI.Interface;
using AquiCovidAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Service
{
    public class PessoaService : IPessoaService { 

        public int Id = 0;
        public string Nome = "";
        public string CPF = "";
    
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

                /* PessoaResponse response = new PessoaResponse();
            response.Id = entity.Id;
            response.Nome = entity.Nome;
            response.CPF = entity.CPF;* transmutação
           response.Add(pessoaResponse);*/

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

            return new PessoaResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                CPF = entity.CPF
            };

        }

        public BaseResponse Inserir(PessoaRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido"};

            if (request.CPF == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "CPF precisa ser preenchido" };

            var entidade = _pessoaRepository.ObterPorCpf(request.CPF);

            if(entidade != null)
                return new BaseResponse() { StatusCode = 400, Mensagem = "CPF já cadastrado" };

           
            Pessoa pessoa = new Pessoa();
            pessoa.CPF = request.CPF;
            pessoa.Id = request.Id;
            pessoa.Nome = request.Nome;

            _pessoaRepository.Inserir(pessoa);

            return new BaseResponse() { StatusCode = 201, Mensagem = "Pessoa inserida no sistema" };

        }

        public BaseResponse Atualizar( PessoaRequest request)
        {
            if (request.Nome == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "Nome precisa ser preenchido" };

            if (request.CPF == "")
                return new BaseResponse() { StatusCode = 400, Mensagem = "CPF precisa ser preenchido" };

            var entidade = _pessoaRepository.ObterPorCpf(request.CPF);

            if (entidade != null)
            {
               if (entidade.Id != request.Id )
                    return new BaseResponse() { StatusCode = 400, Mensagem = "CPF já cadastrado" };
            }

            Pessoa pessoa = new Pessoa();
            pessoa.CPF = request.CPF;
            pessoa.Id = request.Id;
            pessoa.Nome = request.Nome;

            _pessoaRepository.Atualizar(pessoa);

            return new BaseResponse() { StatusCode = 200, Mensagem = "Pessoa atualizada no sistema" };

         }

        public BaseResponse Deletar(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Mensagem = "Id precisa ser preenchido" };

            _pessoaRepository.Deletar(id);
            return new BaseResponse() { StatusCode = 200, Mensagem = "Objeto deletado com sucesso"};
        }
    }

}
