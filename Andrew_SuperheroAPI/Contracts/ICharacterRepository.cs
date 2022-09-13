namespace Andrew_SuperheroAPI.Contracts
{
    public interface ICharacterRepository
    {
        Task<IList<CharacterDTO>> GetCharactersFromContext();
        Task<IList<CharacterDTO>> GetCharacterByLocationFromContext(string location);
        Task<CharacterDTO> GetCharacterByNameFromContext(string name);
        Task<IList<CharacterDTO>> PostCharacter(CharacterDTO character);
        Task<IList<CharacterDTO>> UpdateCharacter(CharacterDTO character);
        Task<IList<CharacterDTO>> DeleteCharacter(CharacterDTO character);

    }
}
