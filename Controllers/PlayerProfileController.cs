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

        [HttpPost]
        public async Task<ActionResult<PlayerProfile>> GetOrCreateProfile(PlayerProfileDTO profile)
        {
            PlayerProfile newOrExistingProfile = await m_profileService.GetOrCreateProfile(profile.Name, profile.Password);
            return Ok(newOrExistingProfile.ToDTO());
        }
    }
}