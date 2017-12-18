using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtcApi.Core.JsonEnvelopes
{
    public class MarketDataEnvelope
    {
        [JsonProperty("MarketDataIncrementalRefresh")]
        public HitBtcApi.Core.Entities.MarketDataIncrementalRefreshEntity MarketDataIncrementalRefresh { get; set; }
        [JsonProperty("MarketDataSnapshotFullRefresh")]
        public HitBtcApi.Core.Entities.MarketDataSnapshotFullRefreshEntity MarketDataSnapshotFullRefresh { get; set; }
    }
}
