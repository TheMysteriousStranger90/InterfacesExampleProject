using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class BaseDeposit : Deposit
    {
        public readonly decimal amount;
        public readonly int period;

        public BaseDeposit(decimal amount, int period) : base(amount, period)
        {
            this.amount = amount;
            this.period = period;
        }

        public override decimal Income()
        {
            return Calc(amount, 5m, period);
        }

        decimal Calc(decimal amount, decimal percent, int period)
        {
            return amount * Power((1m + percent / 100m), period)
                   - amount;
        }

        decimal Power(decimal x, int pow)
        {
            var r = 1m;
            for (var i = 0; i < pow; i++)
                r *= x;
            return r;
        }
    }
}