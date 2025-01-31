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

            bank.LoadAccountsFromJson("accounts.json");
            bank.LoadAccountsFromJson("accounts.json");

            Application.Run(new Authentication(bank, atm));
        }
    }
}
