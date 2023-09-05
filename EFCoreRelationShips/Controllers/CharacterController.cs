using EFCoreRelationShips.Data;
using EFCoreRelationShips.DTOs;
using EFCoreRelationShips.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationShips.Controllers
{
    [ApiController]
    [Route("api/character")]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("characters")]
        public async Task<ActionResult<List<Character>>> Get()
        {
            return await _context.Characters.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CreateCharacterDTO model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Something went wrong");
            }
            var character = new Character(){Name = model.name};
            var backPack = new BackPack() { Description = model.backPackDTO.description,Character=character };
            var weapons = model.weapons.Select(c => new Weapon() { Name = c.name, Character = character }).ToList();
            var factions = model.factions.Select(c => new Faction() { Name = c.name, Characters = new List<Character>() { character } }).ToList();

            character.BackPack = backPack;
            character.Weapons = new List<Weapon>();
            character.Weapons = weapons;
            character.Factions = factions;
            _context.Add(character);
            await _context.SaveChangesAsync();
            return Ok(await _context.Characters.Include(c=>c.BackPack).Include(c=>c.Weapons).Include(f=>f.Factions).ToListAsync());
        }

    }
}
