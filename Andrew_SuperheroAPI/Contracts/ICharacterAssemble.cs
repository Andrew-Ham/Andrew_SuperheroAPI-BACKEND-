using Andrew_SuperheroAPI.Models;

namespace Andrew_SuperheroAPI.Contracts
{
    public interface ICharacterAssemble
    {
        //Task<string> PokemonBattle(string pokemonName);
        Task<IList<Character>> GetCharacters();
        //List<CharacterDTO>  DeleteCharacter(int id);
        //List<CharacterDTO> UpdateSuperHero(CharacterDTO requestCharacter);
        //List<CharacterDTO> PostSuperHero(CharacterDTO requestCharacter);
    }
}
