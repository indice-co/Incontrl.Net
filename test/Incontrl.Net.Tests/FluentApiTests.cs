using System;
using System.Collections.Generic;
using System.Text;
using Incontrl.Net.Experimental;
using Incontrl.Net.Types;
using Xunit;

namespace Incontrl.Net.Tests
{
    public class FluentApiTests
    {
        [Fact]
        public void StructureTest() {
            var api = default(ICoreApi);

            var options = new ListOptions();
                options.GetSortings()
            //api.LoginAsync(authorizationCode); // client credentials
            //api.LoginAsync(); // client credentials
            //api.LoginAsync(refreshToken); // with refresh token
            //api.LoginAsync(username, password); //resource owner

            var result = api.Subscriptions().ListAsync();
            var result2 = api.Subscriptions().CreateAsync(new Models.CreateSubscriptionRequest());
            var result3 = api.Subscriptions(new Guid()).GetAsync();
            //api.Subscriptions(new Guid()).Organisations(new Guid()).
        }
    }
}
