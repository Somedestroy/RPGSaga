namespace WebAPI.MockFactory.Tests.Factory
{
    using System;
    using Microsoft.Extensions.Logging;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;
    using WebAPI.MockFactory.Tests.Utils;

    public sealed class TestDataFactory : ITestDataFactory
    {
        private const string DatabaseConnectionString = "DataSource=:memory:";
        private readonly IRepositoryContextFactory _repositoryContextFactory;
        private readonly ILoggerFactory _loggerFactory;
        private bool _disposed = false;

        public TestDataFactory()
        {
            _loggerFactory = new LoggerFactory();
            _repositoryContextFactory = new RepositoryContextFactory(DatabaseConnectionString);
        }

        public IControllerFactory CreateControllerFactory()
        {
            IRepositoryFactory repositoryFactory = new RepositoryFactory(_repositoryContextFactory);
            IServiceFactory serviceFactory = new ServiceFactory(repositoryFactory);
            return new ControllerFactory(serviceFactory, _loggerFactory);
        }

        public IDatabaseInitializer CreateDatabaseInitializer()
        {
            return new DatabaseInitializer(_loggerFactory, _repositoryContextFactory);
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!_disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    _repositoryContextFactory.Dispose();
                }

                // Note disposing has been done.
                _disposed = true;
            }
        }
    }
}
