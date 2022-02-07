namespace WebAPI.MockFactory.Tests.Utils
{
    using System;
    using Infrastructure.EF;
    using Microsoft.Extensions.Logging;

    public interface IDatabaseInitializer
    {
        void InitializeDatabase(Action<ILogger<DatabaseInitializer>, DatabaseContext> initializeAction);
    }
}