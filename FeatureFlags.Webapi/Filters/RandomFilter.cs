using Microsoft.FeatureManagement;

namespace FeatureFlag.Api.Filters
{
    [FilterAlias("RandomFilter")]
    public class RandomFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            bool isEnabled = DateTime.Now.Ticks % 2 == 0;
            return Task.FromResult(isEnabled);

        }
    }
}