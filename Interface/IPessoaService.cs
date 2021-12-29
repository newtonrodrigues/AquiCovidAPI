using AquiCovidAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Interface
{
    public interface IPessoaService
    {
        List<PessoaResponse> Listar();

        PessoaResponse Obter(int id);

        BaseResponse Inserir(PessoaRequest request);

        BaseResponse Atualizar(PessoaRequest request);

        BaseResponse Deletar(int Id);
    }
}
