using System;
using System.IO;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace Incontrl.Sdk.Tests
{
    public class IncontrlApiTests
    {
        private static IncontrlApi _api;
        private IConfigurationRoot _configuration;
        private const string subscriptionId = "bf56fc6d-6936-4c4e-8461-716e9ebaa1f9";
        private const string documentTypeId = "3F9EE6D7-C0D4-4E0A-0EBC-08D50F1E7DBA";
        private const string documentId = "646eef13-072d-42f1-6c57-08d518b9565b";

        public IncontrlApiTests() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                // Configure your user secrets in the following location. You may need to create the directory first.
                // %APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json
                .AddUserSecrets<IncontrlApiTests>();

            _configuration = builder.Build();

            _api = new IncontrlApi(_configuration["AppId"], _configuration["ApiKey"]) {
                ApiAddress = new Uri("https://api-vnext.incontrl.io/swagger/ui"),
                AuthorityAddress = new Uri("https://incontrl.io")
            };
        }

        [Fact]
        public async Task CanCreateSubscription() {
            var createSubscriptionJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_subscription.json");

            if (File.Exists(createSubscriptionJsonPath)) {
                var createSubscriptionJson = File.ReadAllText(createSubscriptionJsonPath);
                var newSubscription = JsonConvert.DeserializeObject<CreateSubscriptionRequest>(createSubscriptionJson);
                await _api.LoginAsync(ScopeFlags.Core);

                var createdSubscription = await _api.Subscriptions()
                                                    .CreateAsync(newSubscription);

                Assert.True(createdSubscription != null, $"A subscription was created with id: {createdSubscription.Id}");
            } else {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(subscriptionId, documentId)]
        public async Task CanChangeDocumentStatus(string subscriptionId, string documentId) {
            await _api.LoginAsync(ScopeFlags.Core);

            var document = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                     .Documents(Guid.Parse(documentId))
                                     .GetAsync();

            if (document == null) {
                Assert.True(false);
            }

            var result = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                   .Documents(Guid.Parse(documentId))
                                   .Status()
                                   .UpdateAsync(DocumentStatus.Paid);
            
            Assert.True(document.Status.Value != result);
        }

        [Fact]
        public async Task CanRetrieveLicense() {
            var licenseText = await _api.License()
                                        .GetAsync();

            Assert.True(!string.IsNullOrEmpty(licenseText));
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveSubscription(string subscriptionId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var subscription = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                         .GetAsync();

            Assert.True(subscription != null);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveSubscriptionCompany(string subscriptionId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var company = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                    .Company()
                                    .GetAsync();

            Assert.True(company != null);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveContacts(string subscriptionId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var contacts = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                     .Contacts()
                                     .ListAsync(new ListOptions<ContactFilter> {
                                         Page = 1,
                                         Size = 25
                                     });

            Assert.True(contacts != null);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanCreateContact(string subscriptionId) {
            var createContactJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_contact.json");

            if (File.Exists(createContactJsonPath)) {
                var createContactJson = File.ReadAllText(createContactJsonPath);
                var newContact = JsonConvert.DeserializeObject<CreateContactRequest>(createContactJson);
                await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

                var createdContact = await _api.Subscriptions(subscriptionId)
                                               .Contacts()
                                               .CreateAsync(newContact);

                Assert.True(createdContact != null);
            } else {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(subscriptionId, documentTypeId)]
        public async Task CanDownloadDocumentTypeTemplate(string subscriptionId, string documentTypeId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var fileResult = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                       .DocumentTypes(Guid.Parse(documentTypeId))
                                       .Template()
                                       .DownloadAsync();

            if (fileResult == null) {
                Assert.True(false);
            }

            var templatesSaveDirectory = Path.Combine(Environment.CurrentDirectory, @"downloaded-templates");
            var templateFilePath = Path.Combine(templatesSaveDirectory, fileResult.FileName);

            if (!Directory.Exists(templatesSaveDirectory)) {
                Directory.CreateDirectory(templatesSaveDirectory);
            }

            using (var fileStream = File.OpenWrite(templateFilePath)) {
                await fileResult.Stream.CopyToAsync(fileStream);
            }

            Assert.True(File.Exists(templateFilePath));
        }

        [Theory]
        [InlineData(subscriptionId, documentTypeId)]
        public async Task CanUploadDocumentTypeTemplate(string subscriptionId, string documentTypeId) {
            var templateFilePath = Path.Combine(Environment.CurrentDirectory, @"Templates\new-document-template.docx");

            if (!File.Exists(templateFilePath)) {
                Assert.True(false, $"The file {templateFilePath} could not be found.");
            }

            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var documentType = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                         .DocumentTypes(Guid.Parse(documentTypeId))
                                         .GetAsync();

            if (documentType == null) {
                Assert.True(false, $"The document type with id {documentTypeId} could not be found.");
            }

            var stream = File.OpenRead(templateFilePath);

            await _api.Subscriptions(Guid.Parse(subscriptionId))
                      .DocumentTypes(documentType.Id)
                      .Template()
                      .UploadAsync(stream, documentType.Template.Name);

            Assert.True(true);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanCreateDocument(string subscriptionId) {
            var createDocumentJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_document.json");

            if (File.Exists(createDocumentJsonPath)) {
                var createDocumentJson = File.ReadAllText(createDocumentJsonPath);
                var newDocument = JsonConvert.DeserializeObject<CreateDocumentRequest>(createDocumentJson);
                await _api.LoginAsync(ScopeFlags.Core);

                var createdDocument = await _api.Subscriptions(subscriptionId)
                                               .Documents()
                                               .CreateAsync(newDocument);

                Assert.True(createdDocument != null, $"An document was created with id: {createdDocument.Id}");
            } else {
                Assert.True(false);
            }
        }

        [Fact]
        public async Task CanRetrieveApps() {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.Apps | ScopeFlags.Membership);
            var apps = await _api.Apps().ListAsync();
            Assert.True(apps.Items != null);
        }
    }
}
