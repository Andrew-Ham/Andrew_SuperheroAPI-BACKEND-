using Andrew_SuperheroAPI.Models;

namespace Andrew_SuperheroAPI.Contracts
{
    public interface ICharacterAssemble
    {
        Task<string> PokemonBattle(string pokemonName);
        List<Character> GetCharacters();
        List<Character>  DeleteCharacter(int id);
        List<Character> UpdateSuperHero(Character requestCharacter);
        List<Character> PostSuperHero(Character requestCharacter);
    }
}
