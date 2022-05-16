using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlag.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomController : ControllerBase
    {
        [HttpGet(Name = "GetCustom")]
        [FeatureGate("Feature6")]
        public string Index()
        {
            return "Activado con parametros";
        }
    }
}