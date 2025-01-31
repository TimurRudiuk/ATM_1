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
    public partial class WithdrawForm : Form
    {
        private Account _account;
        private AutomatedTellerMachine _atm;

        public WithdrawForm(Account account, AutomatedTellerMachine atm)
        {
            InitializeComponent();
            _account = account;
            _atm = atm;
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            // Перевірка та зняття коштів
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount) && amount > 0)
            {
                if (amount > _account.Balance)
                {
                    MessageBox.Show("Недостатньо коштів на рахунку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (amount > _atm.CashAvailable)
                {
                    MessageBox.Show("В банкоматі недостатньо готівки!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Виконуємо зняття
                    _account.Balance -= amount;
                    _atm.CashAvailable -= amount;
                    MessageBox.Show("Кошти успішно знято.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Введено некоректну суму!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
