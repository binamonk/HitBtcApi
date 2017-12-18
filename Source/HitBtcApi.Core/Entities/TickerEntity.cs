using System;
using Newtonsoft.Json;
namespace HitBtcApi.Core.Entities
{
    public class TickerEntity
    {
        /// <summary>
        /// Last price.
        /// </summary>
        public float Last { get; set; }
        /// <summary>
        /// Highest buy order
        /// </summary>
        public float Bid { get; set; }
        /// <summary>
        /// Lowest sell order.
        /// </summary>
        public float Ask { get; set; }
        /// <summary>
        /// Highest trade price per last 24h + last incomplete minute.
        /// </summary>
        public float High { get; set; }
        /// <summary>
        /// Lowest trade price per last 24h + last incomplete minute.
        /// </summary>
        public float Low { get; set; }
        /// <summary>
        /// Volume per last 24h + last incomplete minute.
        /// </summary>
        public float Volume { get; set; }
        /// <summary>
        /// Price in which instrument open.
        /// </summary>
        public float Open { get; set; }
        /// <summary>
        /// Volume in second currency per last 24h + last incomplete minute.
        /// </summary>
        [JsonProperty("volume_quote")]
        public float VolumeQuote { get; set; }
        /// <summary>
        /// Server time in UNIX timestamp format.
        /// </summary>
        public double Timestamp { get; set; } 

        public DateTime LocalTimeStamp {
            get {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddMilliseconds(Timestamp).ToLocalTime();
                return dtDateTime;
            }
        }
    }
}
