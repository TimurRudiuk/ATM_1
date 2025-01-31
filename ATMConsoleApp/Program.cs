using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
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

            var account1 = new Account("1234567890", "Рудюк Тимур", "1234", 5000);
            var account2 = new Account("9876543210", "Класний Руслан", "5678", 3000);
            bank.Accounts.Add(account1);
            bank.Accounts.Add(account2);

            atm.OperationPerformed += (sender, message) => Console.WriteLine($"[ATM Message]: {message}");

            Account currentAccount = null;

            while (currentAccount == null)
            {
                Console.WriteLine("Ласкаво просимо до банкомата");
                Console.Write("Введіть номер картки: ");
                var cardNumber = Console.ReadLine();

                Console.Write("Введіть PIN-код: ");
                var pin = Console.ReadLine();

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
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        atm.ViewBalance(currentAccount);
                        break;

                    case "2":
                        Console.Write("Введіть суму для зняття: ");
                        if (decimal.TryParse(Console.ReadLine(), out var withdrawAmount))
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
                        if (decimal.TryParse(Console.ReadLine(), out var depositAmount))
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
                        var toCardNumber = Console.ReadLine();
                        var toAccount = bank.GetAccountByCardNumber(toCardNumber);
                        if (toAccount != null)
                        {
                            Console.Write("Введіть суму для переказу: ");
                            if (decimal.TryParse(Console.ReadLine(), out var transferAmount))
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
            if (account != null && atm.Authenticate(cardNumber, pin, account))
            {
                Console.WriteLine($"Авторизація успішна. Вітаємо, {account.FullName}!");
                return account;
            }

            return null;
        }
    }
}
