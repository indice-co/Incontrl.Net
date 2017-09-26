using System;
using System.IO;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Newtonsoft.Json;
using Xunit;

namespace Incontrl.Net.Tests
{
    public class IncontrlApiTests
    {
        private static IncontrlApi _incontrlClient;
        private const string subscriptionId = "F6BE5093-5E7A-43E0-BBA0-0601D68A9302";
        private const string invoiceTypeId = "ed72da36-d08e-4b2a-6ff4-08d4ce74911e";

        public IncontrlApiTests() {
            _incontrlClient = new IncontrlApi("{your-client-name}", "{your-client-password}", "{your-username}", "{your-password}");
        }

        [Fact]
        public async Task CanCreateSubscription() {
            var createSubscriptionJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_subscription.json");

            if (File.Exists(createSubscriptionJsonPath)) {
                var createSubscriptionJson = File.ReadAllText(createSubscriptionJsonPath);
                var newSubscription = JsonConvert.DeserializeObject<CreateSubscriptionRequest>(createSubscriptionJson);
                var createdSubscription = await _incontrlClient.Subscriptions.CreateAsync(newSubscription);
                Assert.True(createdSubscription.Data != null);
            } else {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveSubscription(string subscriptionId) {
            var subscription = await _incontrlClient.Subscriptions.GetByIdAsync(Guid.Parse(subscriptionId));
            Assert.True(subscription.Data != null);
        }

        [Theory]
        [InlineData(subscriptionId, invoiceTypeId)]
        public async Task CanDownloadInvoiceTypeTemplate(string subscriptionId, string invoiceTypeId) {
            var fileResult = await _incontrlClient.InvoiceTypes.GetTemplateAsync(Guid.Parse(subscriptionId), Guid.Parse(invoiceTypeId));

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

            var invoiceType = await _incontrlClient.InvoiceTypes.GetByIdAsync(Guid.Parse(subscriptionId), Guid.Parse(invoiceTypeId));

            if (invoiceType.IsHttpError || invoiceType.Data == null) {
                Assert.True(false, $"The invoice type with id {invoiceTypeId} could not be found.");
            }

            var stream = File.ReadAllBytes(templateFilePath);
            await _incontrlClient.InvoiceTypes.UpdateTemplateAsync(Guid.Parse(subscriptionId), invoiceType.Data.Id, stream, invoiceType.Data.Template.Name);
            Assert.True(true);
        }

        [Theory]
        [InlineData(subscriptionId, invoiceTypeId)]
        public async Task CanCreateInvoice(string subscriptionId) {
            var createInvoiceJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_invoice.json");

            if (File.Exists(createInvoiceJsonPath)) {
                var createInvoiceJson = File.ReadAllText(createInvoiceJsonPath);
                var newInvoice = JsonConvert.DeserializeObject<CreateInvoiceRequest>(createInvoiceJson);
                var createdInvoice = await _incontrlClient.Invoices.CreateAsync(Guid.Parse(subscriptionId), newInvoice);
                Assert.True(createdInvoice.Data != null);
            } else {
                Assert.True(false);
            }
        }
    }
}
