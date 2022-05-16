using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlags.Webapi.Handlers
{
    public class CustomDisabledFeatures : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            context.Result = new ContentResult
            {
                ContentType = "text/plain",
                Content = "La funcionalidad se encuentra desactivada.",
                StatusCode = 404
            };

            return Task.CompletedTask;
        }
    }
}
