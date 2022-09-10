namespace Andrew_SuperheroAPI.Contracts
{
    public interface ICharacterRepository
    {
        Task<IList<CharacterDTO>> GetCharactersFromContext();
    }
}
