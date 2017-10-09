using System;
using System.IO;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace Incontrl.Net.Tests
{
    public class IncontrlApiTests
    {
        private static IncontrlApi _api;
        private IConfigurationRoot _configuration;
        private const string subscriptionId = "98b09f36-d170-4ecd-973b-c103f081442c";
        private const string invoiceTypeId = "ed72da36-d08e-4b2a-6ff4-08d4ce74911e";

        public IncontrlApiTests() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                // Configure your user secrets in the following location. You may need to create the directory first.
                // %APPDATA%\microsoft\UserSecrets\77780817-305E-4CDC-8256-635C6538D2F3\secrets.json
                .AddUserSecrets<IncontrlApiTests>();

            _configuration = builder.Build();
            _api = new IncontrlApi(_configuration["AppId"], _configuration["ApiKey"]);
        }

        [Fact]
        public async Task CanCreateSubscription() {
            var createSubscriptionJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_subscription.json");

            if (File.Exists(createSubscriptionJsonPath)) {
                var createSubscriptionJson = File.ReadAllText(createSubscriptionJsonPath);
                var newSubscription = JsonConvert.DeserializeObject<CreateSubscriptionRequest>(createSubscriptionJson);
                await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

                var createdSubscription = await _api.Subscriptions()
                                                    .CreateAsync(newSubscription);

                Assert.True(createdSubscription.Data != null);
            } else {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveSubscription(string subscriptionId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var subscription = await _api.Subscription(Guid.Parse(subscriptionId))
                                         .GetAsync();

            Assert.True(subscription.Data != null);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveSubscriptionCompany(string subscriptionId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var company = await _api.Subscription(Guid.Parse(subscriptionId))
                                    .Company()
                                    .GetAsync();

            Assert.True(company.Data != null);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveContacts(string subscriptionId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var contacts = await _api.Subscription(Guid.Parse(subscriptionId))
                                     .Contacts()
                                     .ListAsync(new ListOptions<ContactFilter> {
                                         Page = 1,
                                         Size = 25
                                     });

            Assert.True(contacts.Data != null);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanCreateContact(string subscriptionId) {
            var createContactJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_contact.json");

            if (File.Exists(createContactJsonPath)) {
                var createContactJson = File.ReadAllText(createContactJsonPath);
                var newContact = JsonConvert.DeserializeObject<CreateContactRequest>(createContactJson);
                await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

                var createdContact = await _api.Subscription(subscriptionId)
                                               .Contacts()
                                               .CreateAsync(newContact);

                Assert.True(createdContact.Data != null);
            } else {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(subscriptionId, invoiceTypeId)]
        public async Task CanDownloadInvoiceTypeTemplate(string subscriptionId, string invoiceTypeId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var fileResult = await _api.Subscription(Guid.Parse(subscriptionId))
                                       .InvoiceType(Guid.Parse(invoiceTypeId))
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
        [InlineData(subscriptionId, invoiceTypeId)]
        public async Task CanUploadInvoiceTypeTemplate(string subscriptionId, string invoiceTypeId) {
            var templateFilePath = Path.Combine(Environment.CurrentDirectory, @"Templates\new-invoice-template.docx");

            if (!File.Exists(templateFilePath)) {
                Assert.True(false, $"The file {templateFilePath} could not be found.");
            }

            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);

            var invoiceType = await _api.Subscription(Guid.Parse(subscriptionId))
                                        .InvoiceType(Guid.Parse(invoiceTypeId))
                                        .GetAsync();

            if (invoiceType.IsHttpError || invoiceType.Data == null) {
                Assert.True(false, $"The invoice type with id {invoiceTypeId} could not be found.");
            }

            var stream = File.ReadAllBytes(templateFilePath);

            await _api.Subscription(Guid.Parse(subscriptionId))
                      .InvoiceType(invoiceType.Data.Id)
                      .Template()
                      .UploadAsync(stream, invoiceType.Data.Template.Name);

            Assert.True(true);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanCreateInvoice(string subscriptionId) {
            var createInvoiceJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_invoice.json");

            if (File.Exists(createInvoiceJsonPath)) {
                var createInvoiceJson = File.ReadAllText(createInvoiceJsonPath);
                var newInvoice = JsonConvert.DeserializeObject<CreateInvoiceRequest>(createInvoiceJson);
                await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);
                
                var createdInvoice = await _api.Subscription(subscriptionId)
                                               .Invoices()
                                               .CreateAsync(newInvoice);

                Assert.True(createdInvoice.Data != null);
            } else {
                Assert.True(false);
            }
        }
    }
}
