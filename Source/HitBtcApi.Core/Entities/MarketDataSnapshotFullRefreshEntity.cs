using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtcApi.Core.Entities
{
    public class MarketDataSnapshotFullRefreshEntity
    {
        public int snapshotSeqNo { get; set; }
        public string symbol { get; set; }
        public string exchangeStatus { get; set; }
        public List<Trade> ask { get; set; }
        public List<Trade> bid { get; set; }
        public long timestamp { get; set; }
    }
}
