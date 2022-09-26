using Microsoft.AspNetCore.Mvc.Testing;
using Paycore.FinalProject.API.TestingNeeds;

namespace Paycore.FinalProject.Tests
{
    public class FakeApplication : WebApplicationFactory<Program>
    {
        public FakeApplication()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        }
    }
}
