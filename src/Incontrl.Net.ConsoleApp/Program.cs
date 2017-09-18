using System;
using System.IO;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Services;
using Newtonsoft.Json;

namespace Incontrl.Net.ConsoleApp
{
    public class Program
    {
        private static IncontrlClient _incontrlClient;

        static Program() {
            _incontrlClient = new IncontrlClient("{your-client-name}", "{your-client-secret}");
        }

        public static void Main(string[] args) {
            // Remember to change these when you create new items.
            var subscriptionId = Guid.Parse("570B8D08-7F9E-4E04-86B8-7CBFD3817F99");
            var invoiceId = Guid.Parse("C1B9A211-E61C-4192-BCE2-08D4FE7A289C");
            var invoiceTypeId = Guid.Parse("5F06D184-FBED-4AAE-D3BB-08D4FE79D1C5");

            // Example 01 - Create a new subscription.
            //CreateSubscription();

            // Example 02 - Get a subscription and it's status by id.
            //var subscription = Task.Run(() => _incontrlClient.GetSubscriptionByIdAsync(subscriptionId)).Result;
            //var subscriptionStatus = Task.Run(() => _incontrlClient.GetSubscriptionStatusAsync(subscriptionId)).Result;

            // Example 03 - Update a subscription's company information.
            //UpdateSubscription(subscriptionId);

            // Example 04 - Get contacts for a subscription.
            //var contacts = Task.Run(() => _incontrlClient.GetContactsAsync(subscriptionId, new ListOptions<ContactFilter> {
            //    Page = 1,
            //    Size = 10
            //})).Result;

            // Example 05 - Create a new invoice.
            //CreateInvoice(subscriptionId);

            // Example 06 - Get an invoice by id.
            //var invoice = Task.Run(() => _incontrlClient.GetInvoiceByIdAsync(subscriptionId, invoiceId, InvoiceFormat.Pdf)).Result;

            // Example 07 - Get invoice type template.
            //var template = Task.Run(() => _incontrlClient.GetInvoiceTypeTemplateAsync(subscriptionId, invoiceTypeId)).Result;

            // Example 08 - Update invoice type template
            UpdateInvoiceTemplate(subscriptionId, invoiceTypeId);

            Console.ReadLine();
        }

        private static void CreateSubscription() {
            var createSubscriptionJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_subscription.json");

            if (File.Exists(createSubscriptionJsonPath)) {
                var createSubscriptionJson = File.ReadAllText(createSubscriptionJsonPath);
                var newSubscription = JsonConvert.DeserializeObject<CreateSubscriptionRequest>(createSubscriptionJson);
                var createdSubscription = Task.Run(() => _incontrlClient.CreateSubscriptionAsync(newSubscription)).Result;
            }
        }

        private static void UpdateSubscription(Guid subscriptionId) {
            var updateSubscriptionJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\update_subscription_company.json");

            if (File.Exists(updateSubscriptionJsonPath)) {
                var updateSubscriptionJson = File.ReadAllText(updateSubscriptionJsonPath);
                var updatedCompany = JsonConvert.DeserializeObject<UpdateCompanyRequest>(updateSubscriptionJson);
                var updatedSubscription = Task.Run(() => _incontrlClient.UpdateSubscriptionCompanyAsync(subscriptionId, updatedCompany)).Result;
            }
        }

        private static void CreateInvoice(Guid subscriptionId) {
            var createInvoiceJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_invoice.json");

            if (File.Exists(createInvoiceJsonPath)) {
                var createInvoiceJson = File.ReadAllText(createInvoiceJsonPath);
                var newInvoice = JsonConvert.DeserializeObject<CreateInvoiceRequest>(createInvoiceJson);
                var createdInvoice = Task.Run(() => _incontrlClient.CreateInvoiceAsync(subscriptionId, newInvoice)).Result;
            }
        }

        private static void UpdateInvoiceTemplate(Guid subscriptionId, Guid InvoiceTypeId) {
            var newTemplateFilePath = Path.Combine(Environment.CurrentDirectory, @"Templates\new-invoice-template.docx");

            if (File.Exists(newTemplateFilePath)) {
                var fileContent = File.ReadAllBytes(newTemplateFilePath);
                var fileName = Path.GetFileName(newTemplateFilePath);
                var isSuccessful = Task.Run(() => _incontrlClient.UpdateInvoiceTypeTemplateAsync(subscriptionId, InvoiceTypeId, fileContent, fileName)).Result;
            }
        }
    }
}
