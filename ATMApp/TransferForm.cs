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
    public partial class TransferForm : Form
    {
        private Bank _bank;
        private Account _account;

        public TransferForm(Bank bank, Account account)
        {
            InitializeComponent();
            _bank = bank;
            _account = account;
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            // Пошук отримувача та переказ коштів
            var recipientAccount = _bank.GetAccountByCardNumber(RecipientCardTextBox.Text);
            if (recipientAccount == null)
            {
                MessageBox.Show("Користувача з такою карткою не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (decimal.TryParse(AmountTextBox.Text, out decimal amount) && amount > 0)
            {
                if (amount > _account.Balance)
                {
                    MessageBox.Show("Недостатньо коштів на рахунку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Виконуємо переказ
                    _account.Balance -= amount;
                    recipientAccount.Balance += amount;
                    MessageBox.Show($"Кошти успішно переведено на рахунок {recipientAccount.FullName}.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
