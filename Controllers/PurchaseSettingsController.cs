using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseSettingsController : Controller
    {
        private readonly IPurchaseSettingsRepository purchasSettingsRepository;
        private readonly IPersonalPickupBranchRepository personalPickupBranchRepository;

        public PurchaseSettingsController(IPurchaseSettingsRepository purchasSettingsRepository, IPersonalPickupBranchRepository personalPickupBranchRepository)
        {
            this.purchasSettingsRepository = purchasSettingsRepository;
            this.personalPickupBranchRepository = personalPickupBranchRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetPurchaseSettingViewModel>> GetPurchaseSettings()
        {
            var purchaseSettings = await purchasSettingsRepository.GetAsync();
            var personalPickupBranches = await personalPickupBranchRepository.GetAllAsync();

            return Ok(new GetPurchaseSettingViewModel(purchaseSettings, personalPickupBranches));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> UpdatePurchaseSettings(UpdatePurchaseSettingsViewModel updatePurchaseSettingsViewModel)
        {
            var purchaseSettings = await purchasSettingsRepository.GetAsync();
            await purchasSettingsRepository.UpdateAsync(purchaseSettings, updatePurchaseSettingsViewModel);

            return NoContent();
        }

        [HttpPost("branch")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> CreatePersonalPickupBranch(CreatePersonalPickupBranchViewModel createPersonalPickupBranch)
        {
            await personalPickupBranchRepository.CreateAsync(createPersonalPickupBranch);
            return NoContent();
        }

        [HttpPut("branch/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> UpdatePersonalPickupBranch(int id, UpdatePersonalPickupBranchViewModel updatePersonalPickupBranchViewModel)
        {
            var branch = await personalPickupBranchRepository.GetByIdAsync(id);
            if (branch == null)
                return NotFound();

            await personalPickupBranchRepository.UpdateAsync(branch, updatePersonalPickupBranchViewModel);
            return NoContent();
        }

        [HttpDelete("branch/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> DeletePersonalPickupBranch(int id)
        {
            var branch = await personalPickupBranchRepository.GetByIdAsync(id);
            if (branch == null)
                return NotFound();

            await personalPickupBranchRepository.DeleteAsync(branch);
            return NoContent();
        }
    }
}
