﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Experimental;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class ContactApi : IContactApi
    {
        private ClientBase _clientBase;
        private Lazy<IContactCompaniesApi> _contactCompaniesApi;

        public ContactApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _contactCompaniesApi = new Lazy<IContactCompaniesApi>(() => new ContactCompaniesApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string ContactId { get; set; }

        public IContactCompaniesApi Companies() {
            var contactCompaniesApi = _contactCompaniesApi.Value;
            contactCompaniesApi.SubscriptionId = SubscriptionId;
            contactCompaniesApi.ContactId = ContactId;

            return contactCompaniesApi;
        }

        public async Task<JsonResponse<Contact>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/contacts/{ContactId}", cancellationToken);

        public async Task<JsonResponse<Contact>> UpdateAsync(UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateContactRequest, Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/contacts/{ContactId}", contact, cancellationToken);
    }
}