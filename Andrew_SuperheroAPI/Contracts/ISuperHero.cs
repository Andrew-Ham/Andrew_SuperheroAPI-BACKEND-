namespace Andrew_SuperheroAPI.Contracts
{
    public interface ISuperHero 
    {
        //Task<Character> GetSuperHero(int id);
        List<Character> GetSuperHeroes();
        List<Character> DeleteSuperHero(int id);
        List<Character> UpdateSuperHero(Character requestCharacter);
        List<Character> PostSuperHero(Character requestCharacter);
    }
}
