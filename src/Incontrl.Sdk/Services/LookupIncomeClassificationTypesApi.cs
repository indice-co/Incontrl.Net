using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    class LookupIncomeClassificationTypesApi : ILookupIncomeClassificationTypesApi
    {
        private readonly ClientBase _clientBase;

        public LookupIncomeClassificationTypesApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            _clientBase.GetAsync<ResultSet<Classification>>("classifications/income/types");     
    }
}
