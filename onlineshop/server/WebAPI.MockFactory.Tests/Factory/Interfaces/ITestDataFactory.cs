namespace WebAPI.MockFactory.Tests.Factory
{
    using System;

    using WebAPI.MockFactory.Tests.Factory.Interfaces;
    using WebAPI.MockFactory.Tests.Utils;

    public interface ITestDataFactory : IDisposable
    {
        IControllerFactory CreateControllerFactory();

        IDatabaseInitializer CreateDatabaseInitializer();
    }
}