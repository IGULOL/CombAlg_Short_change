using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 3. Сдача. Из имеющегося набора монет выдать сдачу наименьшим количеством. 
 * b) используются монеты продавца и покупателя. Например, для сдачи в 98 коп, 
 * покупатель дает 1 рубль, а продавец возвращает 2 коп. 
 */
namespace ShortChange
{
    /*
     * 
     */
    public partial class MainForm : Form
    {
        int[] coinsSeller; //монеты продавца
        int[] coinsBuyers; //монеты покупателя


        public MainForm()
        {
            InitializeComponent();
        }

        //доступность компонентов
        private void EnabledComponents(bool value)
        {
            btnFix.Enabled = value;
            textBoxCoinsBuyers.ReadOnly = !value;
            textBoxCoinsSeller.ReadOnly = !value;
            textBoxPurchasePrice.Enabled = !value;
            btnGiveShortChange.Enabled = false;
        }

        //нажатие клавиш в textBox 
        private void textBoxCoinsSeller_KeyPress(object sender, KeyPressEventArgs e)
        {
            //обрабатываем только числа, пробел и backspace
            if ((e.KeyChar != 32) && (e.KeyChar != 8) && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        //зафиксировать
        private void btnFix_Click(object sender, EventArgs e)
        {
            //изменяем доступность компонентов
            EnabledComponents(false);

            try
            {
                //считываем информацию из полей
                coinsSeller = textBoxCoinsSeller.Text.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(x => int.Parse(x)).ToArray();
                coinsBuyers = textBoxCoinsBuyers.Text.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(x => int.Parse(x)).ToArray();

                //сортируем по возрастанию
                Array.Sort(coinsSeller);
                Array.Sort(coinsBuyers);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при вводе чисел.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //изменяем доступность компонентов
                EnabledComponents(true);
            }
        }

        //очистить
        private void btnClear_Click(object sender, EventArgs e)
        {
            //очищаем поля
            textBoxCoinsBuyers.Clear();
            textBoxCoinsSeller.Clear();
            textBoxPurchasePrice.Clear();
            textBoxShortChange.Clear();

            //изменяем доступность компонентов
            EnabledComponents(true);
        }

        //изменение поля для сдачи
        private void textBoxSumShortChange_TextChanged(object sender, EventArgs e)
        {
            btnGiveShortChange.Enabled = true;
        }

        /*
         * 
         */
        private int GiveChange(int[] masValue, int change, int[] minCoins, int[] coinsUsed)
        {
            //рассматриваем все возможные сочетания монет, дающие сумму rubles
            for (int rubles = 0; rubles <= change; rubles++)
            {
                int coinCount = rubles; //количество монет
                int newCoin = 1;
                foreach (int i in masValue)
                {
                    if (i <= rubles)
                    {
                        if (minCoins[rubles - i] + 1 < coinCount)
                        {
                            coinCount = minCoins[rubles - i] + 1;
                            newCoin = i;
                        }
                    }
                }
                minCoins[rubles] = coinCount;
                coinsUsed[rubles] = newCoin;
            }
            //минимальное количество монет
            return minCoins[change];        
        }

        private void PrintCoins(int[] coinsUsed, int change)
        {
            int coin = change;
            while (coin > 0)
            {
                int thisCoin = coinsUsed[coin];
                textBoxShortChange.Text += thisCoin + " ";
                coin = coin - thisCoin;
            }
        }

        private void btnGiveShortChange_Click(object sender, EventArgs e)
        {
            textBoxShortChange.Clear();

            //получаем стоимость покупки
            int purchasePrice = int.Parse(textBoxPurchasePrice.Text);

            //список из минимальных количеств монет, необходимых для выдачи каждого значения
            int[] coinCount = new int[purchasePrice * purchasePrice];
            //использованные монеты
            int[] coinsUsed = new int[purchasePrice * purchasePrice];

            //высчитываем сдачу
            int change = -1;
            //смотрим, сколько даст покупатель
            //предположим, что сдача не потребуется
            int pay = purchasePrice;
            GiveChange(coinsBuyers, pay, coinCount, coinsUsed);
            //набираем монеты покупателя
            while (coinsUsed[pay] == coinsBuyers[coinsBuyers.Length-1])
            {
                pay++;
                GiveChange(coinsBuyers, pay, coinCount, coinsUsed);
            }

            //высчитываем сдачу
            change = pay - purchasePrice;

            coinCount = new int[purchasePrice];
            coinsUsed = new int[purchasePrice];

            GiveChange(coinsSeller, change, coinCount, coinsUsed);
            PrintCoins(coinsUsed, change);
        }
    }
}
