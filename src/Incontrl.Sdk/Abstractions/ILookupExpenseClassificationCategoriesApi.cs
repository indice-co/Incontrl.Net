using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface ILookupExpenseClassificationCategoriesApi
    {
        Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default);
    }
}
