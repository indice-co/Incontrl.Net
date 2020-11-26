using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    class LookupTaxClassificationApi : ILookupTaxClassificationApi
    {
        private readonly ClientBase _clientBase;

        public LookupTaxClassificationApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Classification>>("classifications/taxes");
    }
}
