using System.IO;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Incontrl.Sdk.Tests
{
    public class IncontrlAppsApiTests
    {
        private static IncontrlAppsApi _api;
        private IConfigurationRoot _configuration;

        public IncontrlAppsApiTests() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                // Configure your user secrets in the following location. You may need to create the directory first.
                // %APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json
                .AddUserSecrets<IncontrlApiTests>();

            _configuration = builder.Build();
            _api = new IncontrlAppsApi(_configuration["AppId"], _configuration["ApiKey"]);
        }

        [Fact]
        public async Task CanRetrieveApps() {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.Apps | ScopeFlags.Membership);
            var apps = await _api.Apps().ListAsync();
            Assert.True(apps.Items != null);
        }
    }
}
