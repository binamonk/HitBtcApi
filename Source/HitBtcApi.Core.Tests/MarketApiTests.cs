using System;
using System.Linq;
using Xunit;

namespace HitBtcApi.Core.Tests
{
    public class MarketApiTests
    {
        public MarketApiClient _client;

        public MarketApiTests()
        {
            _client = MarketApiClient.Instance;
        }

        [Fact]
        public void GetTimeStamp()
        {
            var timestamp = _client.GetTimeStampAsync().Result;
            Assert.True(timestamp != 0);
        }

        [Fact]
        public void GetPublicSymbols()
        {
            var symbols = _client.GetListOfSymbols().Result;
            Assert.True(symbols.Count() > 0);
        }

        [Fact]
        public void GetTickerForSymbol()
        {
            var ticker = _client.GetTickerForSymbol("BTCUSD").Result;
            Assert.True(ticker != null);
        }

        [Fact]
        public void GetAllTickers()
        {
            var tickers = _client.GetAllTickers().Result;
            Assert.True(tickers.Count() > 0);
        }

        [Fact]
        public void GetOrderBookForSymbol()
        {
            var orderBook = _client.GetOrderBookForSymbol("BTCUSD").Result;
            Assert.True(orderBook != null);
        }

    }
}
