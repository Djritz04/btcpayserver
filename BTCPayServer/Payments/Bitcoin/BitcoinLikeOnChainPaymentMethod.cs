﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCPayServer.Services.Invoices;
using NBitcoin;
using Newtonsoft.Json;

namespace BTCPayServer.Payments.Bitcoin
{
    public class BitcoinLikeOnChainPaymentMethod : IPaymentMethod
    {
        public PaymentTypes GetPaymentType()
        {
            return PaymentTypes.BTCLike;
        }

        public string GetPaymentDestination()
        {
            return DepositAddress?.ToString();
        }

        public Money GetTxFee()
        {
            return TxFee;
        }

        public void SetPaymentDestination(string newPaymentDestination)
        {
            if (newPaymentDestination == null)
                DepositAddress = null;
            else
                DepositAddress = BitcoinAddress.Create(newPaymentDestination, DepositAddress.Network);
        }

        [JsonIgnore]
        public FeeRate FeeRate { get; set; }
        [JsonIgnore]
        public Money TxFee { get; set; }
        [JsonIgnore]
        public BitcoinAddress DepositAddress { get; set; }
    }
}
