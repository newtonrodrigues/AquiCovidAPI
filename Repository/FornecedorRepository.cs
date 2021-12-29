using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Repository
{
    public class FornecedorRepository : BaseRepository
    {

        public FornecedorRepository(IConfiguration configuration) : base(configuration) { }
    }
}
