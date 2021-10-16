using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public interface IEnumerable
        {
            IEnumerator Deposit();
        }


        public void SortDeposits()
        {
            Array.Sort(deposits, (x, y) => Comparer<Deposit>.Default.Compare(y, x));
        }

        public int CountPossibleToProlongDeposit()
        {
            var count = 0;
            foreach (var item in deposits)
            {
                if (item is IProlongable ip && ip.CanToProlong())
                {
                    count++;
                }
            }

            return count;
        }

        public decimal TotalIncome()
        {
            decimal sum = 0m;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null)
                {
                    sum += deposits[i].Income();
                }
            }

            return sum;
        }

        public decimal MaxIncome()
        {
            decimal max = 0;

            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null && deposits[i].Income() > max)
                {
                    max = deposits[i].Income();
                }
            }

            return max;
        }

        public decimal GetIncomeByNumber(int number)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    return 0;
                }
                else if (deposits[i].Income() != number)
                {
                    return deposits[i + 1].Income();
                }
                else
                {
                    return deposits[i].Income();
                }
            }

            throw new InvalidOperationException();
        }

        public bool AddDeposit(Deposit deposit)
        {
            bool answear = false;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    answear = true;
                    break;
                }
            }

            return answear;
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return deposits.GetEnumerator();
        }
    }
}