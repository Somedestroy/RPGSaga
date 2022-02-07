namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    using System;
    using Infrastructure.EF;

    public interface IRepositoryContextFactory : IDisposable
    {
        DatabaseContext CreateDatabaseContext();
    }
}