using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlag.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RamdomController : ControllerBase
    {
        [HttpGet(Name = "GetRandom")]
        [FeatureGate("Feature5")]
        public string Index()
        {
            return "Activado Random";
        }
    }
}