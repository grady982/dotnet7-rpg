using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private IMapper _mapper;
        private DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 2,Name = "Apple"},
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto data)
        {
            var rsp = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(data);
            _context.Character.Add(character);
            // to make actual insert happen, we have to call the save method save changes
            // this method write the changes to the database
            await _context.SaveChangesAsync();
            
            rsp.Data = await _context.Character.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return rsp;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var rsp = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Character.ToListAsync();
            rsp.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return rsp;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var rsp = new ServiceResponse<GetCharacterDto>();
            var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
            rsp.Data = _mapper.Map<GetCharacterDto>(character);
            return rsp;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto data)
        {
            var rsp = new ServiceResponse<GetCharacterDto>();

            try
            {
                var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == data.Id);
                    //characters.FirstOrDefault(c => c.Id == data.Id);
                if (character is null)
                {
                    throw new Exception($"Character with Id ${data.Id} not found");
                }

                character.Name = data.Name;
                character.HitPoints = data.HitPoints;
                character.Strength = data.Strength;
                character.Defense = data.Defense;
                character.Intelligence = data.Intelligence;
                character.Class = data.Class;
                
                // save changes to the database
                await _context.SaveChangesAsync();
                rsp.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (System.Exception ex)
            {
                rsp.Success = false;
                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var rsp = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
                    
                if (character is null)
                {
                    throw new Exception($"Character with Id ${id} not found");
                }

                _context.Character.Remove(character);
                await _context.SaveChangesAsync();

                rsp.Data = await _context.Character.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync(); //characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (System.Exception ex)
            {
                rsp.Success = false;
                rsp.Message = ex.Message;
            }

            return rsp;
        }
    }
}