using Andrew_SuperheroAPI.Contracts;

namespace Andrew_SuperheroAPI.Repositories
{

    //ALl DB Context Related Logic 
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

        public async Task<IList<CharacterDTO>> GetCharacterByLocationFromContext(string location)
        {
            return await _context.characters.Where(x => x.Location == location).ToListAsync();
        }

        public async Task<CharacterDTO> GetCharacterByNameFromContext(string characterName)
        {
            return await _context.characters.FirstOrDefaultAsync(x => x.Name == characterName);
        }

        public async Task<IList<CharacterDTO>> DeleteCharacter(CharacterDTO character)
        {
            _context.Remove(character);
            await _context.SaveChangesAsync();
            return await GetCharactersFromContext();
        }

        public async Task<IList<CharacterDTO>> PostCharacter(CharacterDTO character)
        {
            _context.Add(character);
            await _context.SaveChangesAsync();
            return await GetCharactersFromContext();
        }

        public async Task<IList<CharacterDTO>> UpdateCharacter(CharacterDTO character)
        {
            var dto = _context.characters.Where(x=>x.Name == character.Name).FirstOrDefault();
            dto.Age = character.Age;
            dto.Strength = character.Strength;
            dto.FirstName = character.FirstName; 
            dto.LastName = character.LastName;
            dto.HoursWorked = character.HoursWorked;
            dto.HourlyRate = character.HourlyRate;
            dto.Location = character.Location;
            _context.SaveChanges();
            return await GetCharactersFromContext();
        }
    }
}
