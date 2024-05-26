using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using silliconValley.Models;
using silliconValley.Data;

namespace silliconValley.Integration
{
    public class listarUsuario
    {
         
        private readonly ILogger<listarUsuario> _logger;

        private const string API_URL = "https://reqres.in/api/todos/";
        private readonly HttpClient httpClient;

        public listarUsuario(ILogger<listarUsuario> logger)
        {
            _logger = logger;
            httpClient = new HttpClient();

        }

         public async Task<List<ApiUser>> GetAll(){
            string requestUrl = $"{API_URL}";
            List<ApiUser> listTodos = new List<ApiUser>();
            using (HttpClient client = new HttpClient())
            {
                try{
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        listTodos =  await response.Content.ReadFromJsonAsync<List<ApiUser>>() ??
                                        new List<ApiUser>();
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