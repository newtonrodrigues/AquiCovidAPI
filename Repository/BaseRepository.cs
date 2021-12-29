using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiCovidAPI.Repository
{
    public class BaseRepository
    {
        //  public string _connectionsString = "Server=Newton-PC\\;Database=AquiCovid;Trusted_Connection=True;";
        public string _connectionString;
        
        private IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            this._connectionString = _configuration.GetConnectionString("AquiCovid");
        }
    }
}
