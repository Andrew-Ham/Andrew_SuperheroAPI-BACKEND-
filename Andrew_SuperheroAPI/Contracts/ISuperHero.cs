namespace Andrew_SuperheroAPI.Contracts
{
    public interface ISuperHero 
    {
        //Task<Character> GetSuperHero(int id);
        Task<IList<CharacterDTO>> GetSuperHeroes();
        //List<CharacterDTO> DeleteSuperHero(int id);
        //List<CharacterDTO> UpdateSuperHero(CharacterDTO requestCharacter);
        //List<CharacterDTO> PostSuperHero(CharacterDTO requestCharacter);
    }
}
