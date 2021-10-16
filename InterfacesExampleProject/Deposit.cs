using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }

        public int CompareTo(Deposit other)
        {
            return TotalAmount().CompareTo(other.TotalAmount());
        }

        public Deposit(decimal depositAmount, int depositPeriod)
        {
            Amount = depositAmount;
            Period = depositPeriod;
        }

        public abstract decimal Income();

        public decimal TotalAmount()
        {
            return Amount + Income();
        }
        
    }
}