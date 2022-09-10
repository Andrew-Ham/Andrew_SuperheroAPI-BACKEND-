using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Models;

namespace Andrew_SuperheroAPI.Service
{
    public class CharacterAssemble : ICharacterAssemble
    {
        //private IPokemon _pokemon;
        //private ISuperHero _superHero;
        private ICharacterRepository _characterRepository;

        public CharacterAssemble(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<IList<Character>> GetCharacters()
        {
            var result = new List<Character>();
            var characterDTOList = await _characterRepository.GetCharactersFromContext();
            foreach (var element in characterDTOList)
            {
                var character = new Character() { Id = element.Id, Age = element.Age, Name = $"{element.Name}", BirthYear = element.BirthYear };
                result.Add(character);
            }
            return result;
        }

        //public List<CharacterDTO> DeleteCharacter(int id)
        //{
        //    return _superHero.DeleteSuperHero(id);
        //}

        //public List<CharacterDTO> UpdateSuperHero(CharacterDTO requestCharacter)
        //{
        //    return _superHero.UpdateSuperHero(requestCharacter);
        //}

        //public List<CharacterDTO> PostSuperHero(CharacterDTO requestCharacter)
        //{
        //    return _superHero.PostSuperHero(requestCharacter);
        //}

        //public async Task<string> PokemonBattle(string pokemonName)
        //{
        //    var superHeroes = _superHero.GetSuperHeroes();
        //    var randomHeroesToSelect = new Random().Next(1, superHeroes.Count);
        //    var heroToFightAgainstPokemon = superHeroes[randomHeroesToSelect];

        //    var pokemon = await _pokemon.GetPokemon(pokemonName); //await for api response for data
        //    if (pokemon == null)
        //    {
        //        return $"No Pokemon Found!, {heroToFightAgainstPokemon.Name} has won!";
        //    }
        //    else
        //    {
        //        var rangeOfMoves = pokemon.Abilities.Count;
        //        var randomNum = new Random().Next(0,rangeOfMoves);
        //        return $"Wild {pokemonName} used {pokemon.Abilities[randomNum].Ability.Name} move! {heroToFightAgainstPokemon.Name} took 5 damage from it";
        //    }
        //}


    }
}
