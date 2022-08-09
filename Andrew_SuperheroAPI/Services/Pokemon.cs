using Andrew_SuperheroAPI.Contracts;
using Newtonsoft.Json;

namespace Andrew_SuperheroAPI.Services
{
    public class Pokemon : IPokemon
    {
        private readonly HttpClient _client;

        public Pokemon(IHttpClientFactory httpFactory)
        {
            if (httpFactory is null)
            {
                throw new ArgumentNullException(nameof(httpFactory));
            }
            _client = httpFactory.CreateClient("pokeapi");
        }

        public async Task<Models.Pokemon> GetPokemon(string pokemonName)
        {
            var apiResponse = await _client.GetAsync($"pokemon/{pokemonName.ToLower()}");
            if (apiResponse.IsSuccessStatusCode == true)
            {
                var content = await apiResponse.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<Models.Pokemon>(content);
                return pokemon;
            }
            return null;
        }
    }
}
