using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace silliconValley.Integration.jsonplaceholder
{
    public class JsonplaceholderApiIntegration
    {
        private readonly ILogger<JsonplaceholderApiIntegration> _logger;
        private const string API_URL="https://jsonplaceholder.typicode.com/usuario/";

        public JsonplaceholderApiIntegration(ILogger<JsonplaceholderApiIntegration> logger){
            _logger=logger;
        }

       
    }
}