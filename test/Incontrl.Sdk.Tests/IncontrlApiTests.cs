using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace Incontrl.Sdk.Tests
{
    public class IncontrlApiTests
    {
        private static IncontrlApi _api;
        private IConfigurationRoot _configuration;
        private const string subscriptionId = "a4ab1442-b568-4817-87c3-63fb71ddea71";
        private const string documentTypeId = "8C1A6FD6-37C1-414B-AC57-1BC5D6011C51";
        private const string paymentOptionId = "5B6C0CAE-C4BB-4084-AB9C-66D8491839F0";
        private const string userId = "ab9769f1-d532-4b7d-9922-3da003157ebd";
        private const string transactionId = "9300C9FF-5AFA-45AC-6B8D-08D529A5F249";
        private const string documentId = "D5BE6763-D4D0-404B-46DE-08D529A58B8E";
        private const string productId = "3193F130-1539-4E4D-AF41-EA2667CD3467";

        public IncontrlApiTests() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                // Configure your user secrets in the following location. You may need to create the directory first.
                // %APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json
                .AddUserSecrets<IncontrlApiTests>();
            _configuration = builder.Build();
            _api = new IncontrlApi(_configuration["AppId"], _configuration["ApiKey"], new Uri("http://localhost:20202"), new Uri("https://identity.incontrl.io"));
        }

        [Theory]
        [InlineData(subscriptionId, paymentOptionId, transactionId, documentId)]
        public async Task CanCreatePayment(string subscriptionId, string paymentOptionId, string transactionId, string documentId) {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.CoreMembers | ScopeFlags.IdentityApps | ScopeFlags.Identity | ScopeFlags.CoreBanking);
            var newPayment = await _api.Subscriptions(subscriptionId)
                                       .PaymentOptions(Guid.Parse(paymentOptionId))
                                       .Transactions(Guid.Parse(transactionId))
                                       .Payments()
                                       .CreateAsync(new Payment {
                                           Approval = ApprovalStatus.Approved,
                                           Comments = "A description",
                                           Value = new Money {
                                               Amount = 123m,
                                               Currency = "EUR"
                                           },
                                           Document = new Document {
                                               Id = Guid.Parse(documentId)
                                           }
                                       });
            Assert.True(newPayment != null);
        }

        [Theory]
        [InlineData(subscriptionId, paymentOptionId)]
        public async Task CanRetrieveDocumentTypesForPaymentOption(string subscriptionId, string paymentOptionId) {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.CoreMembers | ScopeFlags.IdentityApps | ScopeFlags.Identity | ScopeFlags.CoreBanking);
            var documentTypes = await _api.Subscriptions(subscriptionId)
                                          .PaymentOptions(Guid.Parse(paymentOptionId))
                                          .DocumentTypes()
                                          .ListAsync(new ListOptions {
                                              Search = "AccountsReceivable"
                                          });
            Assert.True(documentTypes.Items.Length > 0);
        }

        [Fact]
        public async Task CanCreateSubscription() {
            var createSubscriptionJsonPath = Path.Combine(Environment.CurrentDirectory, @"Payloads\create_subscription.json");
            if (File.Exists(createSubscriptionJsonPath)) {
                var createSubscriptionJson = File.ReadAllText(createSubscriptionJsonPath);
                var newSubscription = JsonConvert.DeserializeObject<CreateSubscriptionRequest>(createSubscriptionJson);
                await _api.LoginAsync(ScopeFlags.Core);
                var createdSubscription = await _api.Subscriptions().CreateAsync(newSubscription);
                Assert.True(createdSubscription != null, $"A subscription was created with id: {createdSubscription.Id}");
            } else {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(subscriptionId, documentId)]
        public async Task CanChangeDocumentStatus(string subscriptionId, string documentId) {
            await _api.LoginAsync(ScopeFlags.Core);
            var document = await _api.Subscriptions(Guid.Parse(subscriptionId)).Documents(Guid.Parse(documentId)).GetAsync();
            if (document == null) {
                Assert.True(false);
            }
            var result = await _api.Subscriptions(Guid.Parse(subscriptionId))
                                   .Documents(Guid.Parse(documentId))
                                   .Status()
                                   .UpdateAsync(new UpdateDocumentStatusRequest { Status = DocumentStatus.Paid });
            Assert.True(document.Status.Value != result.Status);
        }

        [Fact]
        public async Task CanRetrieveLicense() {
            var licenseText = await _api.License().GetAsync();
            Assert.True(!string.IsNullOrEmpty(licenseText));
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveSubscription(string subscriptionId) {
            await _api.LoginAsync();
            var subscription = await _api.Subscriptions(subscriptionId).GetAsync();
            Assert.True(subscription != null);
        }

        [Theory]
        [InlineData(userId)]
        public async Task CanRetrieveGlobalSubscriptions(string userId) {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.CoreMembers);
            var subscriptions = await _api.Subscriptions(globalAccess: true)
                                          .ListAsync(new ListOptions<SubscriptionListFilter> {
                                              Filter = new SubscriptionListFilter {
                                                  MemberId = userId
                                              },
                                              Page = 1,
                                              Size = 3
                                          });
            Assert.True(subscriptions.Items.Length > 0);
        }

        [Theory]
        [InlineData(subscriptionId)]
        public async Task CanRetrieveSubscriptionCompany(string subscriptionId) {
            await _api.LoginAsync(_configuration["UserName"], _configuration["Password"]);
            var company = await _api.Subscriptions(Guid.Parse(subscriptionId)).Company().GetAsync();
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
                var newContact = JsonConvert.DeserializeObject<Contact>(createContactJson);
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
                newDocument.CustomData = new { Nikos = "Discoveroom", Age = 36, city = "London" };
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
        public async Task CanRetrieveWebHooks() {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.IdentityApps);
            var subscription = await _api.Subscriptions(subscriptionId).GetAsync();
            var contact = await _api.Subscriptions(subscriptionId).Contact().GetAsync();
            var hooks = await _api.Apps().WebHooks().ListAsync(new ListOptions<WebhookFilter> {
                Filter = new WebhookFilter {
                    AppIds = new[] { "nlg-wordpress-client" },
                    Event = EventType.DocumentVoid
                }
            });
            Assert.True(hooks.Items != null);
        }

        [Fact]
        public async Task CanRetrieveAppMembers() {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.IdentityApps | ScopeFlags.Identity);
            var members = await _api.Apps().Members().ListAsync(new MemberRequest {
                Ids = new string[] { "id1", "id2" }
            });
            Assert.True(members.Items != null);
        }

        [Fact]
        public async Task CanRetrieveGlobalPaymentOptions() {
            await _api.LoginAsync(ScopeFlags.Core | ScopeFlags.CoreMembers);
            var paymentOptions = await _api.Subscriptions(globalAccess: true)
                                           .PaymentOptions()
                                           .ListAsync();
            Assert.True(paymentOptions.Count > 0);
        }

        [Fact]
        public async Task CanRetrieveLookups() {
            await _api.LoginAsync();
            var currencies = await _api.Lookups()
                                       .Currencies()
                                       .ListAsync(new ListOptions {
                                           Page = 1,
                                           Size = 500
                                       });
            var countries = await _api.Lookups()
                                      .Countries()
                                      .ListAsync(new ListOptions {
                                          Page = 1,
                                          Size = 500
                                      });
            var timeZones = await _api.Lookups()
                                      .TimeZones()
                                      .ListAsync(new ListOptions {
                                          Page = 1,
                                          Size = 500
                                      });
            var plans = await _api.Lookups()
                                  .Plans()
                                  .ListAsync(new ListOptions {
                                      Page = 1,
                                      Size = 500
                                  });
            var countryDefaults = await _api.Lookups()
                                            .Countries("JP")
                                            .GetAsync();
            Assert.True(currencies.Count > 0 && countries.Count > 0 && timeZones.Count > 0 && plans.Count > 0);
        }

        [Fact]
        public async Task CanRetrieveDocuments() {
            await _api.LoginAsync(ScopeFlags.Core);
            var documents = await _api.Subscriptions(subscriptionId)
                                      .Documents()
                                      .ListAsync(new ListOptions<DocumentListFilter> {
                                          Page = 1,
                                          Size = 50,
                                          Filter = new DocumentListFilter {
                                              IsMarked = true,
                                              Status = new[] { DocumentStatus.Issued, DocumentStatus.Paid }
                                          }
                                      }, summary: true);
            Assert.True(documents.Count > 0 && documents.Summary != null);
        }

        [Fact]
        public async Task CanDeleteProduct() {
            await _api.LoginAsync(ScopeFlags.Core);
            await _api.Subscriptions(subscriptionId)
                      .Products(Guid.Parse(productId))
                      .DeleteAsync();
        }

        [Fact]
        public void QuerySerialization() {
            var options = new ListOptions {
                Page = 1,
                Size = 10,
                Sort = "DisplayName-"
            };
            var query = new QueryStringParams(options);
            Assert.Equal("page=1&size=10&sort=DisplayName-", query.ToFormUrlEncodedString());
        }

        [Fact]
        public void QuerySerializationDocumentList() {
            var options = new ListOptions<DocumentListFilter> {
                Filter = new DocumentListFilter {
                    From = new DateTime(2018, 07, 20),
                    To = new DateTime(2018, 07, 24)
                },
                Page = 1,
                Size = 10,
                Sort = "DisplayName-"
            };
            var query = new QueryStringParams(options);
            Assert.Equal("page=1&size=10&sort=DisplayName-&Filter.From=2018-07-20&Filter.To=2018-07-24", query.ToFormUrlEncodedString());
        }

        [Fact]
        public async Task CanUpdateTracker() {
            await _api.LoginAsync(ScopeFlags.Core);
            await _api.Subscriptions("f58e804b-00a8-42d8-b7d5-5d859bedc669")
                      .Documents(Guid.Parse("b38ea8a4-55e2-427d-72ea-08d5c61de889"))
                      .Trackings("f58e804b-00a8-42d8-b7d5-5d859bedc669")
                      .UpdateAsync(new UpdateDocumentTrackingRequest {
                          LastRead = DateTime.Now,
                          Reads = 1
                      });
        }

        [Fact]
        public async Task CanRetrieveSummary() {
            await _api.LoginAsync(ScopeFlags.Core);
            var result = await _api.Subscriptions("bf845529-f5d7-43b5-af69-16296568deb5")
                                   .Documents()
                                   .ListAsync(new ListOptions<DocumentListFilter> {
                                       Page = 1,
                                       Size = 150
                                   }, summary: true);
        }

        [Fact]
        public async Task CanUpdateService() {
            await _api.LoginAsync(ScopeFlags.Core);
            var request = new UpdateServiceRequest {
                Enabled = true,
                Settings = new AadeMyDataSettings {
                    BaseUrl = "https://mydata-dev.azure-api.net",
                    UserId = "XXX",
                    SubscriptionKey = "XXX",
                    TransmissionOptions = new List<TransmissionOption> { 
                        new TransmissionOption { DocumentTypeId = Guid.Parse("949b1031-11e0-4641-2fa9-08d57d183663"), Type = TransmissionType.Manual }
                    }
                }
            };
            var updatedService = await _api.Subscriptions("a4ab1442-b568-4817-87c3-63fb71ddea71")
                                           .Plan()
                                           .Services(Guid.Parse("904971a4-ded2-4b32-a408-343adbd7522e"))
                                           .UpdateAsync(request);
        }

        [Fact]
        public async Task CanRetrieveDocumentTypesLookup() {
            var result = await _api.Lookups().DocumentTypeClassifications().ListAsync();
            Assert.True(result?.Items.Length == 13);
        }
    }
}
