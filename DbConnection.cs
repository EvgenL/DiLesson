namespace Scripts
{
    public class DbConnection : IDbConnector
    {
        private readonly AnalyticsService _analyticsService;

        public DbConnection(AnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
    }

    public interface IDbConnector
    {
    }
}