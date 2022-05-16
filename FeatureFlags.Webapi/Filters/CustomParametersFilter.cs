using Microsoft.FeatureManagement;

namespace FeatureFlag.Api.Filters
{
    [FilterAlias("CustomParametersFilter")]
    public class CustomParametersFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CustomParametersFilter(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {

            CustomParametersFilterSettings settings = context.Parameters.Get<CustomParametersFilterSettings>();
            var useragent = httpContextAccessor.HttpContext.Request.Headers.UserAgent.ToString();
            var result = useragent.ToLower().Contains(settings.Target.ToLower());

            if (result)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);

        }
    }

    public class CustomParametersFilterSettings
    {
        public string Target { get; set; }
    }
}