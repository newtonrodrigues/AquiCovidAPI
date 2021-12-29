using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Model
{
    public class PessoaRequest
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }
    }
}
