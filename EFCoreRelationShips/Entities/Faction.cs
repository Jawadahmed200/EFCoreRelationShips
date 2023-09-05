using System.Text.Json.Serialization;

namespace EFCoreRelationShips.Entities
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}
