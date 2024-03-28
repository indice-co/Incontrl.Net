﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IMembersApi
    {
        Task<ResultSet<MemberInfo>> ListAsync(MemberRequest request, CancellationToken cancellationToken = default);
    }
}
