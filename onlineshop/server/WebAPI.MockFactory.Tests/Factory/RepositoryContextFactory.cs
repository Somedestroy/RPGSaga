namespace WebAPI.MockFactory.Tests.Factory
{
    using System;
    using System.Data.Common;
    using Infrastructure.EF;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;

    public class RepositoryContextFactory : IRepositoryContextFactory
    {
        private readonly string _connectionString;
        private DbConnection _connection;
        private bool _disposed = false;

        public RepositoryContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DatabaseContext CreateDatabaseContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection(_connectionString);
                _connection.Open();

                var options = CreateOptions();
                using (var context = new DatabaseContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new DatabaseContext(CreateOptions());
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
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!_disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    _connection.Dispose();
                    _connection = null;
                }

                // Note disposing has been done.
                _disposed = true;
            }
        }

        private DbContextOptions<DatabaseContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(_connection).Options;
        }
    }
}
