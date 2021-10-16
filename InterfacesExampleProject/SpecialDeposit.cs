using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal Amount, int Period) : base(Amount, Period)
        {
        }

        public override decimal Income()
        {
            decimal amountAfterPeriod = 0;
            decimal tempAmount = Amount;
            decimal tempValue = Amount;
            decimal percent = 1.01M;
            for (int i = 0; i < Period; i++)
            {
                tempValue *= percent;
                amountAfterPeriod = tempValue - tempAmount;
                percent += 0.01M;
            }

            return amountAfterPeriod;
        }

        public bool CanToProlong()
        {
            return (Amount > 1000M);
        }
    }
}