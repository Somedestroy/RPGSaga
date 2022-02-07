namespace WebAPI.MockFactory.Tests.Utils
{
    using System;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;

    public sealed class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly DatabaseContext _databaseContext;

        public DatabaseInitializer(ILoggerFactory loggerFactory, IRepositoryContextFactory repositoryContextFactory)
        {
            _logger = loggerFactory.CreateLogger<DatabaseInitializer>();
            _databaseContext = repositoryContextFactory.CreateDatabaseContext();
        }

        public void InitializeDatabase(Action<ILogger<DatabaseInitializer>, DatabaseContext> initializeAction)
        {
            try
            {
                _databaseContext.Database.OpenConnection();
                _databaseContext.Database.EnsureCreated();
                _logger.LogInformation("Database initialization started.");
                initializeAction?.Invoke(_logger, _databaseContext);
                _logger.LogInformation("Database initialization finished.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _logger.LogInformation("Database initialization failed.");
            }
        }
    }
}
