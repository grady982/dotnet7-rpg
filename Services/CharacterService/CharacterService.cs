using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 2,Name = "Apple"},
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto data)
        {
            var rsp = new ServiceResponse<List<GetCharacterDto>>();
            characters.Add(data);
            rsp.Data = characters;
            return rsp;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var rsp = new ServiceResponse<List<GetCharacterDto>>();
            rsp.Data = characters;
            return rsp;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var rsp = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            rsp.Data = character;
            // if (character is not null)
            //     return rsp;
            // throw new Exception("Character was not found");
            return rsp;
        }
    }
}