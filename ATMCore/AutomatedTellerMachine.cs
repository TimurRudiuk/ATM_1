using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ATMCore
{
    public class AutomatedTellerMachine
    {
        public string ATMId { get; set; }
        public string Location { get; set; }
        public decimal CashAvailable { get; set; }

        public event EventHandler<string> OperationPerformed;

        public AutomatedTellerMachine(string atmId, string location, decimal initialCash)
        {
            ATMId = atmId;
            Location = location;
            CashAvailable = initialCash;
        }

        private void LogTransaction(string message)
        {
            using (StreamWriter writer = new StreamWriter("transactions.log", true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        private string HashPin(string pinCode)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pinCode));
                return Convert.ToBase64String(hashBytes);
            }
        }


        public bool Authenticate(string cardNumber, string pinCode, Account account)
        {
            if (account.CardNumber == cardNumber && account.PinHash == HashPin(pinCode))  // Перевіряємо хеш
            {
                OperationPerformed?.Invoke(this, "Authentication successful.");
                return true;
            }
            else
            {
                OperationPerformed?.Invoke(this, "Authentication failed.");
                return false;
            }
        }

        public void ViewBalance(Account account)
        {
            OperationPerformed?.Invoke(this, $"Balance: {account.Balance:C}");
        }

        public void WithdrawFunds(Account account, decimal amount)
        {
            if (amount > account.Balance)
            {
                OperationPerformed?.Invoke(this, "Insufficient funds.");
                LogTransaction($"Failed withdrawal attempt: {account.CardNumber}, insufficient funds.");
            }
            else if (amount > CashAvailable)
            {
                OperationPerformed?.Invoke(this, "ATM has insufficient cash.");
                LogTransaction($"Failed withdrawal attempt: {account.CardNumber}, ATM cash insufficient.");
            }
            else
            {
                account.Balance -= amount;
                CashAvailable -= amount;
                OperationPerformed?.Invoke(this, $"Withdrawal successful. New balance: {account.Balance:C}");
                LogTransaction($"Successful withdrawal: {account.CardNumber}, Amount: {amount:C}");
            }
        }
        public void DepositFunds(Account account, decimal amount)
        {
            account.Balance += amount;
            CashAvailable += amount;
            OperationPerformed?.Invoke(this, $"Deposit successful. New balance: {account.Balance:C}");
        }

        public void TransferFunds(Account fromAccount, Account toAccount, decimal amount)
        {
            if (amount > fromAccount.Balance)
            {
                OperationPerformed?.Invoke(this, "Insufficient funds for transfer.");
            }
            else
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
                OperationPerformed?.Invoke(this, $"Transfer successful. {amount:C} transferred to {toAccount.CardNumber}.");
            }
        }
    }

}
