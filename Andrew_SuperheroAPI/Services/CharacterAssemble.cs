using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Models;

namespace Andrew_SuperheroAPI.Service
{
    public class CharacterAssemble : ICharacterAssemble
    {
        private IPokemon _pokemon;
        private ISuperHero _superHero;

        public CharacterAssemble(IPokemon pokemon, ISuperHero superHero)
        {
            _pokemon = pokemon;
            _superHero = superHero;
        }

        public List<Character> GetCharacters()
        {
            return _superHero.GetSuperHeroes();
        }

        public List<Character> DeleteCharacter(int id)
        {
            return _superHero.DeleteSuperHero(id);
        }

        public List<Character> UpdateSuperHero(Character requestCharacter)
        {
            return _superHero.UpdateSuperHero(requestCharacter);
        }

        public List<Character> PostSuperHero(Character requestCharacter)
        {
            return _superHero.PostSuperHero(requestCharacter);
        }

        public async Task<string> PokemonBattle(string pokemonName)
        {
            var superHeroes = _superHero.GetSuperHeroes();
            var randomHeroesToSelect = new Random().Next(1, superHeroes.Count);
            var heroToFightAgainstPokemon = superHeroes[randomHeroesToSelect];

            var pokemon = await _pokemon.GetPokemon(pokemonName); //await for api response for data
            if (pokemon == null)
            {
                return $"No Pokemon Found!, {heroToFightAgainstPokemon.Name} has won!";
            }
            else
            {
                var rangeOfMoves = pokemon.Abilities.Count;
                var randomNum = new Random().Next(0,rangeOfMoves);
                return $"Wild {pokemonName} used {pokemon.Abilities[randomNum].Ability.Name} move! {heroToFightAgainstPokemon.Name} took 5 damage from it";
            }
        }


    }
}
