using ATMCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bank bank = new Bank("Your Bank Name");
            AutomatedTellerMachine atm = new AutomatedTellerMachine("ATM1", "Downtown", 10000);

            bank.Accounts.Add(new Account("1234567890", "Рудюк Тимур", "1234", 5000));
            bank.Accounts.Add(new Account("9876543210", "Класний Руслан", "5678", 3000));

            Application.Run(new Authentication(bank, atm));
        }
    }
}
