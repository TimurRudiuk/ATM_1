using ATMCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATMApp
{
    public partial class Main : Form
    {
        private Bank _bank;
        private AutomatedTellerMachine _atm;
        private Account _account;

        public Main(Bank bank, AutomatedTellerMachine atm, Account account)
        {
            InitializeComponent();
            _bank = bank;
            _atm = atm;
            _account = account;
            UserNameLabel.Text = _account.FullName;
            UpdateBalance();
        }

        public void UpdateBalance()
        {
            BalanceLabel.Text = $"Баланс: {_account.Balance} грн";
        }
        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var withdrawForm = new WithdrawForm(_account, _atm);
            withdrawForm.ShowDialog();
            var mainForm = new Main(_bank, _atm, _account);
            mainForm.Show();
        }
        private void DepositButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DepositForm depositForm = new DepositForm(_account, _atm);
            depositForm.ShowDialog();
            this.Show();
            UpdateBalance();
        }
        private void TransferButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var transferForm = new TransferForm(_bank, _account);
            transferForm.ShowDialog();
            this.Show();
            UpdateBalance();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var authForm = new Authentication(_bank, _atm);
            authForm.Show();

        }
    }
}
