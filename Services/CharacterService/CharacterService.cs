using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 2,Name = "Apple"},
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto data)
        {
            var rsp = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(data);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            rsp.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            return rsp;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var rsp = new ServiceResponse<List<GetCharacterDto>>();
            rsp.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            return rsp;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var rsp = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            rsp.Data = _mapper.Map<GetCharacterDto>(character);
            return rsp;
        }
    }
}