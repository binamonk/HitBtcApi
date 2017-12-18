using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtcApi.Core.Entities
{
    public class MarketDataIncrementalRefreshEntity
    {
        public int seqNo { get; set; }
        public long timestamp { get; set; }
        public string symbol { get; set; }
        public string exchangeStatus { get; set; }
        public List<Transaction> ask { get; set; }
        public List<Transaction> bid { get; set; }
        public List<Trade> trade { get; set; }
    }

    public class Transaction
    {
        public double price { get; set; }
        public long size { get; set; }
    }

    public class Trade
    {
        public double price { get; set; }
        public long size { get; set; }
        public long timestamp { get; set; }
    }
}
