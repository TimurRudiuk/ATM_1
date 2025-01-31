using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCore
{
    public class Account
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string PinCode { get; set; }
        public decimal Balance { get; set; }

        public Account(string cardNumber, string fullName, string pinCode, decimal balance)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            PinCode = pinCode;
            Balance = balance;
        }
    }
}
