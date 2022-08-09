using Andrew_SuperheroAPI.Contracts;
using Newtonsoft.Json;

namespace Andrew_SuperheroAPI.Services
{
    public class SuperHero : ISuperHero
    {
        //MockDatabase is a json file where we are keeping our records. As the name suggests, this is intended to work as a database.
        private const string _fileName = "MockDatabase.json";

        public List<Character> GetSuperHeroes()
        {
            var data = File.ReadAllText(_fileName);
            if (string.IsNullOrEmpty(data))
                return new List<Character>();
            var heroList = JsonConvert.DeserializeObject<List<Character>>(data); //Deserialize the JSON to .net type. Turn string into object

            return heroList.OrderBy(x=>x.Id).ToList();
            //return null;
        }

        public List<Character> PostSuperHero(Character requestCharacter)
        {
            var originalHeroes = GetSuperHeroes();
            originalHeroes.Add(requestCharacter);
            var stringData = JsonConvert.SerializeObject(originalHeroes, Formatting.Indented); //Serrialised change object into string
            File.WriteAllText(_fileName, stringData);
            return GetSuperHeroes();
        }

        public List<Character> DeleteSuperHero(int id)
        {
            var superHeroes = GetSuperHeroes();
            superHeroes.Remove(superHeroes.Where(x => x.Id == id).FirstOrDefault());
            var stringData = JsonConvert.SerializeObject(superHeroes, Formatting.Indented);
            File.WriteAllText(_fileName, stringData);
            return GetSuperHeroes();
        }

        public List<Character> UpdateSuperHero(Character requestCharacter)
        {
            var originalHeroes = GetSuperHeroes();
            var superHero = originalHeroes.Where(x => x.Id == requestCharacter.Id).FirstOrDefault();
            superHero.Name = requestCharacter.Name;
            superHero.FirstName = requestCharacter.FirstName;
            superHero.LastName = requestCharacter.LastName;
            superHero.Age = requestCharacter.Age;
            var stringData = JsonConvert.SerializeObject(originalHeroes, Formatting.Indented);
            File.WriteAllText(_fileName, stringData);
            return GetSuperHeroes();
        }


        //public List<Character> DeleteSuperHero(int id)
        //{
        //    var data = File.ReadAllText(_fileName);
        //    if (string.IsNullOrEmpty(data))
        //        return new List<Character>();
        //    var userListData = JsonConvert.DeserializeObject<List<Character>>(data);

        //    return userListData;
        //    //return null;
        //}

        //private readonly HttpClient _client;

        //public SuperHero(IHttpClientFactory httpFactory)
        //{
        //    if (httpFactory is null)
        //    {
        //        throw new ArgumentNullException(nameof(httpFactory));
        //    }
        //    _client = httpFactory.CreateClient("superHeroapi");
        //}

        //public async Task<Character> GetSuperHero(int id)
        //{
        //    var apiResponse = await _client.GetAsync($"character/{id}");
        //    if (apiResponse.IsSuccessStatusCode == true)
        //    {
        //        var content = await apiResponse.Content.ReadAsStringAsync();
        //        var character = JsonConvert.DeserializeObject<Character>(content);
        //        return character;
        //    }
        //    return null;
        //}
    }
}
