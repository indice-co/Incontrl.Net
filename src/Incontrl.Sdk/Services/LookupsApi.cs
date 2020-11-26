using System;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class LookupsApi : ILookupsApi
    {
        private readonly Lazy<ILookupTimeZonesApi> _lookupTimeZonesApi;
        private readonly Lazy<ILookupCountriesApi> _lookupCountriesApi;
        private readonly Lazy<ILookupCurrenciesApi> _lookupCurrenciesApi;
        private readonly Lazy<ILookupPlansApi> _lookupPlansApi;
        private readonly Lazy<ILookupCountriesDefaultsApi> _lookupCountriesDefaultsApi;
        private readonly Lazy<ILookupPaymentMethodClassificationApi> _lookupPaymentMethodClassificationsApi;
        private readonly Lazy<ILookupTaxClassificationApi> _lookupTaxClassificationsApi;
        private readonly Lazy<ILookupExpenseClassificationCategoriesApi> _lookupExpenseCategoriesApi;
        private readonly Lazy<ILookupExpenseClassificationTypesApi> _lookupExpenseTypesApi;
        private readonly Lazy<ILookupIncomeClassificationCategoriesApi> _lookupIncomeCategoriesApi;
        private readonly Lazy<ILookupIncomeClassificationTypesApi> _lookupIncomeTypesApi;
        private readonly Lazy<ILookupDocumentTypeClassificationApi> _lookupDocumentTypeClassificationsApi;

        public LookupsApi(Func<ClientBase> clientBaseFactory) {
            var clientBase = clientBaseFactory();
            _lookupTimeZonesApi = new Lazy<ILookupTimeZonesApi>(() => new LookupTimeZonesApi(clientBase));
            _lookupCountriesApi = new Lazy<ILookupCountriesApi>(() => new LookupCountriesApi(clientBase));
            _lookupCurrenciesApi = new Lazy<ILookupCurrenciesApi>(() => new LookupCurrenciesApi(clientBase));
            _lookupPlansApi = new Lazy<ILookupPlansApi>(() => new LookupPlansApi(clientBase));
            _lookupCountriesDefaultsApi = new Lazy<ILookupCountriesDefaultsApi>(() => new LookupCountriesDefaultsApi(clientBase));
            _lookupDocumentTypeClassificationsApi = new Lazy<ILookupDocumentTypeClassificationApi>(() => new LookupDocumentTypeClassificationApi(clientBase));
            _lookupTaxClassificationsApi = new Lazy<ILookupTaxClassificationApi>(() => new LookupTaxClassificationApi(clientBase));
            _lookupExpenseCategoriesApi = new Lazy<ILookupExpenseClassificationCategoriesApi>(() => new LookupExpenseClassificationCategoriesApi(clientBase));
            _lookupExpenseTypesApi = new Lazy<ILookupExpenseClassificationTypesApi>(() => new LookupExpenseClassificationTypesApi(clientBase));
            _lookupIncomeCategoriesApi = new Lazy<ILookupIncomeClassificationCategoriesApi>(() => new LookupIncomeClassificationCategoriesApi(clientBase));
            _lookupIncomeTypesApi = new Lazy<ILookupIncomeClassificationTypesApi>(() => new LookupIncomeClassificationTypesApi(clientBase));
            _lookupPaymentMethodClassificationsApi = new Lazy<ILookupPaymentMethodClassificationApi>(() => new LookupPaymentMethodClassificationApi(clientBase));
        }

        public ILookupCountriesApi Countries() => _lookupCountriesApi.Value;

        public ILookupCountriesDefaultsApi Countries(string countryIso) {
            var lookupCountriesDefaultsApi = _lookupCountriesDefaultsApi.Value;
            lookupCountriesDefaultsApi.CountryIso = countryIso;
            return lookupCountriesDefaultsApi;
        }

        public ILookupCurrenciesApi Currencies() => _lookupCurrenciesApi.Value;

        public ILookupDocumentTypeClassificationApi DocumentTypeClassifications() => _lookupDocumentTypeClassificationsApi.Value;

        public ILookupExpenseClassificationCategoriesApi ExpenseCategories() => _lookupExpenseCategoriesApi.Value;

        public ILookupExpenseClassificationTypesApi ExpenseTypes() => _lookupExpenseTypesApi.Value;

        public ILookupIncomeClassificationCategoriesApi IncomeCategories() => _lookupIncomeCategoriesApi.Value;

        public ILookupIncomeClassificationTypesApi IncomeTypes() => _lookupIncomeTypesApi.Value;

        public ILookupPaymentMethodClassificationApi PaymentMethodClassifications() => _lookupPaymentMethodClassificationsApi.Value;

        public ILookupPlansApi Plans() => _lookupPlansApi.Value;

        public ILookupTaxClassificationApi TaxClassifications() => _lookupTaxClassificationsApi.Value;

        public ILookupTimeZonesApi TimeZones() => _lookupTimeZonesApi.Value;
    }
}
