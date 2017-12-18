using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HitBtcApi.Core
{
    public class MarketApiClient
    {
        private HttpClient _client;

        private static MarketApiClient _instance;
        public static MarketApiClient Instance {
            get {
                _instance = _instance ?? new MarketApiClient();
                return _instance;
            }
        }

        private MarketApiClient() {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.hitbtc.com/");
        }
        /// <summary>
        /// Returns the server time in UNIX timestamp format
        /// </summary>
        /// <returns></returns>
        public async Task<long> GetTimeStampAsync() {
            var response = await _client.GetStringAsync("/api/1/public/time");
            dynamic obj = JsonConvert.DeserializeObject(response);
            return (long)Convert.ToInt64(obj.timestamp);
        }

        /// <summary>
        /// Simbols returns the actual list of currency symbols traded on HitBTC exchange with their characteristics
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Entities.SymbolEntity>> GetListOfSymbols() {
            var response = await _client.GetStringAsync("/api/1/public/symbols");
            dynamic obj =  JsonConvert.DeserializeObject(response);
            var list = new List<Entities.SymbolEntity>();
            foreach (var itm in obj.symbols){
                var newItm = new Entities.SymbolEntity
                {
                    symbol = itm.symbol,
                    step = itm.step,
                    lot = itm.lot,
                    currency = itm.currency,
                    commodity = itm.commodity,
                    takeLiquidityRate = itm.takeLiquidityRate,
                    provideLiquidityRate = itm.provideLiquidityRate
                };
                list.Add(newItm);
            }
            return list;
        }

        /// <summary>
        /// Returns the actual data on exchange rates of the specified cryptocurrency.
        /// </summary>
        /// <param name="symbol">Specified cryptocurrency.</param>
        /// <returns>Exchange rates.</returns>
        public async Task<Entities.TickerEntity> GetTickerForSymbol(string symbol) {
            var response = await _client.GetStringAsync($"/api/1/public/{symbol}/ticker");
            return JsonConvert.DeserializeObject<Entities.TickerEntity>(response);
        }

        /// <summary>
        /// Returns the actual data on exchange rates for all traded cryptocurrencies - all tickers.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, Entities.TickerEntity>> GetAllTickers() {
            var response = await _client.GetStringAsync($"/api/1/public/ticker");
            return JsonConvert.DeserializeObject<Dictionary<string,Entities.TickerEntity>>(response);
        }

        /// <summary>
        /// Returns a list of open orders for specified currency symbol: their prices and sizes.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<Entities.OrderBookEntity> GetOrderBookForSymbol(string symbol) {
            var response = await _client.GetStringAsync($"/api/1/public/{symbol}/orderbook");
            return JsonConvert.DeserializeObject<Entities.OrderBookEntity>(response);
        }

        public async Task<string> GetIndividualTradesForSymbol(string symbol) {
            throw new NotImplementedException();
        }

        public async Task<string> GetRecentTradesForSymbol(string symbol) {
            throw new NotImplementedException();
        }
    }
}
