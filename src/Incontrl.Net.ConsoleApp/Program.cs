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
            var subscriptionId = Guid.Parse("EFBB4655-27C1-47C8-8840-F65FE58A4793");

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
            CreateInvoice(subscriptionId);

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
    }
}
