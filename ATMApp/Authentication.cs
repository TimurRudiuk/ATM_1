using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using ATMCore;

namespace ATMApp
{
    public partial class Authentication : Form
    {
        private Bank _bank;
        private AutomatedTellerMachine _atm;

        public Authentication(Bank bank, AutomatedTellerMachine atm)
        {
            InitializeComponent();
            _bank = bank; // Передаємо банк через конструктор
            _atm = atm;   // Передаємо банкомат через конструктор
        }

        private void Verification_Click(object sender, EventArgs e)
        {
            // Зчитуємо введені дані
            string cardNumber = CardNumberTextBox.Text.Trim();
            string pinCode = PinCodeTextBox.Text.Trim();

            // Перевірка на порожнє поле
            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(pinCode))
            {
                MessageBox.Show("Будь ласка, введіть всі дані.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Пошук акаунта
            var account = _bank.GetAccountByCardNumber(cardNumber);
            if (account == null)
            {
                MessageBox.Show("Картка не знайдена.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Аутентифікація
            if (account.PinCode == pinCode)
            {
                MessageBox.Show("Аутентифікація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Переходимо до наступного кроку (наприклад, нова форма)
                Main mainForm = new Main(_bank, _atm, account);
                mainForm.Show();
                this.Hide(); // Ховаємо поточну форму
            }
            else
            {
                MessageBox.Show("Невірний PIN-код.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
