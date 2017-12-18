using System;
using System.Collections.Generic;
using System.Text;

namespace HitBtcApi.Core.Entities
{
    public class SymbolEntity
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        public string symbol { get; set; }
        /// <summary>
        /// Price step parameter
        /// </summary>
        public string step { get; set; }
        /// <summary>
        /// Lot size parameter
        /// </summary>
        public string lot { get; set; }
        /// <summary>
        /// Value of this symbol
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Second value of this symbol
        /// </summary>
        public string commodity { get; set; }
        /// <summary>
        /// Liquidity taker fee
        /// </summary>
        public string takeLiquidityRate { get; set; }
        /// <summary>
        /// Liquidity provider rebate
        /// </summary>
        public string provideLiquidityRate { get; set; }
    }
}
