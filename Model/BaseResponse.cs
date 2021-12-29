using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Model
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }

        public string Mensagem { get; set; }
    }
}
