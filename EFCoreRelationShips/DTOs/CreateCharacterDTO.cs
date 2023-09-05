

using EFCoreRelationShips.Entities;

namespace EFCoreRelationShips.DTOs
{
    public record struct CreateCharacterDTO(string name, CreateBackPackDTO backPackDTO, List<CreateWeaponDTO> weapons,List<CreateFactionDTO> factions);
}
