using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtcApi.Core.Entities
{
    public class OrderBookEntity
    {
        public List<List<string>> asks { get; set; }
        public List<List<string>> bids { get; set; }
    }
}
