using System;
using System.IO;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace Incontrl.Net.Tests
{
    public class IncontrlApiTests
    {
        private static IncontrlApi _api;
        private const string subscriptionId = "B85CDF3A-750F-4FED-8E26-E420AA71D0D3";
        private const string invoiceTypeId = "ed72da36-d08e-4b2a-6ff4-08d4ce74911e";

        public IncontrlApiTests() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                // Configure your user secrets in the following location. You may need to create the directory first.
                // %APPDATA%\microsoft\UserSecrets\77780817-305E-4CDC-8256-635C6538D2F3\secrets.json
                .AddUserSecrets<IncontrlApiTests>();

            var configuration = builder.Build();
            _api = new IncontrlApi(configuration["AppId"], configuration["ApiKey"]);
        }

        [Fact]
        public async Task CanCreateSubscription() {
            var createSubscriptionJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_subscription.json");

            if (File.Exists(createSubscriptionJsonPath)) {
                var createSubscriptionJson = File.ReadAllText(createSubscriptionJsonPath);
                var newSubscription = JsonConvert.DeserializeObject<CreateSubscriptionRequest>(createSubscriptionJson);

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
            var subscription = await _api.Subscription(Guid.Parse(subscriptionId))
                                         .GetAsync();

            Assert.True(subscription.Data != null);
        }

        //[Theory]
        //[InlineData(subscriptionId, invoiceTypeId)]
        //public async Task CanDownloadInvoiceTypeTemplate(string subscriptionId, string invoiceTypeId) {
        //    var fileResult = await _incontrlClient.InvoiceTypes.GetTemplateAsync(Guid.Parse(subscriptionId), Guid.Parse(invoiceTypeId));

        //    if (fileResult == null) {
        //        Assert.True(false);
        //    }

        //    var templatesSaveDirectory = Path.Combine(Environment.CurrentDirectory, @"downloaded-templates");
        //    var templateFilePath = Path.Combine(templatesSaveDirectory, fileResult.FileName);

        //    if (!Directory.Exists(templatesSaveDirectory)) {
        //        Directory.CreateDirectory(templatesSaveDirectory);
        //    }

        //    using (var fileStream = File.OpenWrite(templateFilePath)) {
        //        await fileResult.Stream.CopyToAsync(fileStream);
        //    }

        //    Assert.True(File.Exists(templateFilePath));
        //}

        //[Theory]
        //[InlineData(subscriptionId, invoiceTypeId)]
        //public async Task CanUploadInvoiceTypeTemplate(string subscriptionId, string invoiceTypeId) {
        //    var templateFilePath = Path.Combine(Environment.CurrentDirectory, @"Templates\new-invoice-template.docx");

        //    if (!File.Exists(templateFilePath)) {
        //        Assert.True(false, $"The file {templateFilePath} could not be found.");
        //    }

        //    var invoiceType = await _incontrlClient.InvoiceTypes.GetByIdAsync(Guid.Parse(subscriptionId), Guid.Parse(invoiceTypeId));

        //    if (invoiceType.IsHttpError || invoiceType.Data == null) {
        //        Assert.True(false, $"The invoice type with id {invoiceTypeId} could not be found.");
        //    }

        //    var stream = File.ReadAllBytes(templateFilePath);
        //    await _incontrlClient.InvoiceTypes.UpdateTemplateAsync(Guid.Parse(subscriptionId), invoiceType.Data.Id, stream, invoiceType.Data.Template.Name);
        //    Assert.True(true);
        //}

        //[Theory]
        //[InlineData(subscriptionId, invoiceTypeId)]
        //public async Task CanCreateInvoice(string subscriptionId) {
        //    var createInvoiceJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_invoice.json");

        //    if (File.Exists(createInvoiceJsonPath)) {
        //        var createInvoiceJson = File.ReadAllText(createInvoiceJsonPath);
        //        var newInvoice = JsonConvert.DeserializeObject<CreateInvoiceRequest>(createInvoiceJson);
        //        var createdInvoice = await _incontrlClient.Invoices.CreateAsync(Guid.Parse(subscriptionId), newInvoice);
        //        Assert.True(createdInvoice.Data != null);
        //    } else {
        //        Assert.True(false);
        //    }
        //}
    }
}
