using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCore
{
    public class Bank
    {
        public string Name { get; set; }
        public List<AutomatedTellerMachine> ATMs { get; set; }
        public List<Account> Accounts { get; set; }

        public Bank(string name)
        {
            Name = name;
            ATMs = new List<AutomatedTellerMachine>();
            Accounts = new List<Account>();
        }

        public Account GetAccountByCardNumber(string cardNumber)
        {
            return Accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
        }
    }
}
