using Andrew_SuperheroAPI.Contracts;

namespace Andrew_SuperheroAPI.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DataContext _context;

        public CharacterRepository(DataContext context)
        {
            _context = context; 
        }

        public async Task<IList<CharacterDTO>> GetCharactersFromContext()
        {
            return await _context.characters.ToListAsync();
        }

    }
}
