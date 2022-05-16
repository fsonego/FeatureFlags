using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlag.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeWindowsController : ControllerBase
    {
        [HttpGet(Name = "GetTimeWindows")]
        [FeatureGate("Feature4")]
        public string Index()
        {
            return "Activado";
        }
    }
}