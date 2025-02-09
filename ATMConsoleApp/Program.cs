using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ATMCore;

namespace ATMConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var bank = new Bank("MyBank");
            var atm = new AutomatedTellerMachine("ATM1", "Main Street", 10000);
            bank.ATMs.Add(atm);

            // Завантажуємо акаунти з файлу, якщо файл існує
            var accountsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "accounts.json");
            if (File.Exists(accountsFilePath))
            {
                var accountsJson = File.ReadAllText(accountsFilePath);
                var accounts = JsonConvert.DeserializeObject<List<Account>>(accountsJson);
                foreach (var account in accounts)
                {
                    bank.Accounts.Add(account);
                }
            }
            else
            {
                // Створюємо акаунти, якщо файл не знайдений
                var account1 = new Account("1234567890", "Рудюк Тимур", "1234", 5000);
                var account2 = new Account("9876543210", "Класний Руслан", "5678", 3000);
                bank.Accounts.Add(account1);
                bank.Accounts.Add(account2);
            }

            atm.OperationPerformed += (sender, message) => Console.WriteLine($"[ATM Message]: {message}");

            Account currentAccount = null;

            while (currentAccount == null)
            {
                Console.WriteLine("Ласкаво просимо до банкомата");
                Console.Write("Введіть номер картки: ");
                var cardNumber = ReadValidatedInput();

                Console.Write("Введіть PIN-код: ");
                var pin = ReadValidatedInput();

                currentAccount = AuthenticateUser(bank, atm, cardNumber, pin);

                if (currentAccount == null)
                {
                    Console.WriteLine("Невірний номер картки або PIN-код. Спробуйте ще раз.\n");
                }
            }

            while (true)
            {
                Console.WriteLine("\nДоступні операції:");
                Console.WriteLine("1. Перегляд балансу");
                Console.WriteLine("2. Зняття коштів");
                Console.WriteLine("3. Поповнення рахунку");
                Console.WriteLine("4. Переказ коштів");
                Console.WriteLine("0. Вихід");

                Console.Write("Оберіть опцію: ");
                var choice = ReadValidatedInput();

                switch (choice)
                {
                    case "1":
                        atm.ViewBalance(currentAccount);
                        break;

                    case "2":
                        Console.Write("Введіть суму для зняття: ");
                        if (decimal.TryParse(ReadValidatedInput(), out var withdrawAmount))
                        {
                            atm.WithdrawFunds(currentAccount, withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Невірна сума.");
                        }
                        break;

                    case "3":
                        Console.Write("Введіть суму для поповнення: ");
                        if (decimal.TryParse(ReadValidatedInput(), out var depositAmount))
                        {
                            atm.DepositFunds(currentAccount, depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Невірна сума.");
                        }
                        break;

                    case "4":
                        Console.Write("Введіть номер картки отримувача: ");
                        var toCardNumber = ReadValidatedInput();
                        var toAccount = bank.GetAccountByCardNumber(toCardNumber);
                        if (toAccount != null)
                        {
                            Console.Write("Введіть суму для переказу: ");
                            if (decimal.TryParse(ReadValidatedInput(), out var transferAmount))
                            {
                                atm.TransferFunds(currentAccount, toAccount, transferAmount);
                            }
                            else
                            {
                                Console.WriteLine("Невірна сума.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Рахунок отримувача не знайдено.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("До побачення!");
                        // Зберігаємо акаунти в файл перед виходом
                        var accountsToSave = bank.Accounts;
                        var accountsJson = JsonConvert.SerializeObject(accountsToSave, Formatting.Indented);
                        File.WriteAllText(accountsFilePath, accountsJson);
                        return;

                    default:
                        Console.WriteLine("Невірна опція.");
                        break;
                }
            }
        }

        static Account AuthenticateUser(Bank bank, AutomatedTellerMachine atm, string cardNumber, string pin)
        {
            var account = bank.GetAccountByCardNumber(cardNumber);
            if (account != null && atm.Authenticate(cardNumber, pin, account))  // Тепер перевіряємо хешований PIN
            {
                Console.WriteLine($"Authentication successful. Welcome, {account.FullName}!");
                return account;
            }

            return null;
        }

        static string ReadValidatedInput()
        {
            string input;
            do
            {
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Введене значення не може бути порожнім. Спробуйте ще раз.");
                }
            } while (string.IsNullOrEmpty(input));
            return input;
        }
    }
}
