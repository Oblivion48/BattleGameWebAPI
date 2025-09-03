using BattleGameWebAPI.Models;
using BattleGameWebAPI.Services.PlayerProfiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleGameWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerProfileController : ControllerBase
    {
        private IProfileService m_profileService;

        public PlayerProfileController(IProfileService profileService)
        {
            m_profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlayerProfile>>> GetProfiles()
        {
            List<PlayerProfile> profiles = new List<PlayerProfile>();
            profiles.Add(await m_profileService.GetOrCreateProfile("Michael", "1234"));
            return Ok(profiles);
        }
    }
}