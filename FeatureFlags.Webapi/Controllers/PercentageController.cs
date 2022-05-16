using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlag.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PercentageController : ControllerBase
    {
        [HttpGet(Name = "GetPercentage")]
        [FeatureGate("Feature3")]
        public string Index()
        {
            return "Activado";
        }
    }
}