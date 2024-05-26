using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using silliconValley.Integration.jsonplaceholder.dto;

namespace silliconValley.Integration.jsonplaceholder
{
    public class JsonplaceholderApiIntegration
    {
        private readonly ILogger<JsonplaceholderApiIntegration> _logger;
        private const string API_URL="https://jsonplaceholder.typicode.com/todos/";

        public JsonplaceholderApiIntegration(ILogger<JsonplaceholderApiIntegration> logger){
            _logger=logger;
        }

        public async Task<List<Usuario>> GetAll(){
            string requestUrl = $"{API_URL}";
            List<Usuario> listTodos = new List<Usuario>();
            using (HttpClient client = new HttpClient())
            {
                try{
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        listTodos =  await response.Content.ReadFromJsonAsync<List<Usuario>>() ??
                                        new List<Usuario>();
                    }
                }catch (HttpRequestException ex)
                {
                    _logger.LogDebug($"Error al llamar a la API: {ex.Message}");
                }
            }
            return listTodos;
        }
    }
}