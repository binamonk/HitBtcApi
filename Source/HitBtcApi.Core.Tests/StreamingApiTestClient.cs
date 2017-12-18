using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HitBtcApi.Core.Tests
{
    public class StreamingApiTestClient
    {
        [Fact]
        public async Task SocketTest()
        {
            var client = new StreamingApiClient();
            var x = await client.StartAsync();
            Assert.Equal(x, true);
        }
    }
}
