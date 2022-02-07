namespace WebApi.Tests
{
    using System;
    using WebAPI.MockFactory.Tests.Factory;

    public abstract class BaseTest : IDisposable
    {
        protected BaseTest()
        {
            // Do "global" initialization here; Called before every test method.
            TestDataFactory = new TestDataFactory();
        }

        protected ITestDataFactory TestDataFactory { get; private set; }

        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
            TestDataFactory?.Dispose();
        }
    }
}
