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
    class LookupIncomeClassificationCategoriesApi(ClientBase clientBase) : ILookupIncomeClassificationCategoriesApi
    {
        public Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<Classification>>("classifications/income/categories");
    }
}
