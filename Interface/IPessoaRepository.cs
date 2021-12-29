using AquiCovidAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Interface
{
    public interface IPessoaRepository
    {
        List<Pessoa> Listar();

        Pessoa Obter(int Id);

        public void Inserir(Pessoa pessoa);

        public Pessoa ObterPorCpf(string CPF);

        void Atualizar(Pessoa pessoa);

        void Deletar(int Id);
    }
}
