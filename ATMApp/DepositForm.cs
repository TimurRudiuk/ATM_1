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
    public partial class DepositForm : Form
    {
        private Account _account;
        private AutomatedTellerMachine _atm;

        public DepositForm(Account account, AutomatedTellerMachine atm)
        {
            InitializeComponent();
            _account = account;
            _atm = atm;
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            // Перевірка та зарахування коштів
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount) && amount > 0)
            {
                // Виконуємо зарахування
                _account.Balance += amount;
                _atm.CashAvailable += amount;
                MessageBox.Show("Кошти успішно зараховано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Введено некоректну суму!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
