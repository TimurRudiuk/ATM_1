using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ATMCore
{
    public class Account
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string PinCode { get; set; }
        public decimal Balance { get; set; }
        public string PinHash { get; set; }

        public Account(string cardNumber, string fullName, string pinCode, decimal balance)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            SetPinCode(pinCode);  // Використовуємо метод для хешування
            Balance = balance;
        }
        public void SetPinCode(string pinCode)
        {
            PinHash = HashPin(pinCode);  // Замість збереження PIN, зберігаємо його хеш
        }

        private string HashPin(string pinCode)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pinCode));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
