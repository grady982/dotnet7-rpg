using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();

        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto data);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto data);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}