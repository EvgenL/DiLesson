using VContainer;
using VContainer.Unity;

namespace Scripts
{
    public class GlobalScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            DontDestroyOnLoad(gameObject);
            
            builder.Register<AnalyticsService>(Lifetime.Singleton);
        }
    }

    public class AnalyticsService
    {
    }
}