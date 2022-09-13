using Andrew_SuperheroAPI.Models;

namespace Andrew_SuperheroAPI.Contracts
{
    public interface ICharacterAssemble
    {
        //Task<string> PokemonBattle(string pokemonName);
        Task<IList<Character>> GetCharacters();
        Task<Character> GetHighestSalaryChracter();
        Task<IList<CharacterDTO>> PostCharacter(CharacterDTO character);

        Task<IList<CharacterDTO>> UpdateCharacter(Character character);

        Task<IList<CharacterDTO>> DeleteCharacter(CharacterDTO character);

        Task<CharacterDTO>  GetCharacterByName(string name);

        Task<IList<CharacterPay>> GetCharacterPays();
        Task<string> PokemonBattle(string pokemonName);
        //List<CharacterDTO>  DeleteCharacter(int id);
        //List<CharacterDTO> UpdateSuperHero(CharacterDTO requestCharacter);
        //List<CharacterDTO> PostSuperHero(CharacterDTO requestCharacter);
    }
}
