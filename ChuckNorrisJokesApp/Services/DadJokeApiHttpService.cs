using ChuckNorrisJokesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ChuckNorrisJokesApp.Models;
using System.Net.Http.Headers;


namespace ChuckNorrisJokesApp.Services
{
    public class DadJokeApiHttpService : IDadJokeApiService
    {
        private HttpClient _httpClient;
        private IConfigurationService _configurationService;

        public DadJokeApiHttpService(IConfigurationService service)
        {
            _configurationService = service;

            _httpClient = new HttpClient();


            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<string> GetJokeAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_configurationService.DadJokeApiUrl);

            if(response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();

                DadJoke joke = JsonSerializer.Deserialize<DadJoke>(jsonContent);

                if(joke != null)
                {
                    return joke.joke;
                }
            }

            return null;
        }
    }
}
