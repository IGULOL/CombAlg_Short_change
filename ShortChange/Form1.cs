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

        //массив, в котором хранится сочетание монет
        int[] combination;

        //найденная комбинация монеток
        int[] necessaryCombination;

        //проверка того, что сдача готова
        bool ok;

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
            if ((textBoxCoinsSeller.Text == "") || (textBoxCoinsBuyers.Text == ""))
            {
                MessageBox.Show("Введите монеты.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
        }

        //очистить
        private void btnClear_Click(object sender, EventArgs e)
        {
            //очищаем поля
            textBoxCoinsBuyers.Clear();
            textBoxCoinsSeller.Clear();
            textBoxPurchasePrice.Clear();
            textBoxShortChange.Clear();
            textBoxPay.Clear();

            //изменяем доступность компонентов
            EnabledComponents(true);
        }

        //изменение поля для сдачи
        private void textBoxSumShortChange_TextChanged(object sender, EventArgs e)
        {
            btnGiveShortChange.Enabled = true;
        }

        //сумма монеток в комбинации
        private int Sum(int[] arr)
        {
            int sum = 0;
            foreach (int item in arr)
            {
                sum += item;
            }
            return sum;
        }

        //необходимо разделить в сочетании сравнение текущей суммы без сдачи
        //и сравнение текущей суммы со сдачей
        delegate bool Compare(int x, int y);
        Compare myFuncForCompare;
        private bool CompareForBuyerWithChange(int sum, int value) => sum >= value;
        private bool CompareForBuyerWithoutChange(int sum, int value) => sum == value;
        

        //поиск необходимого сочетания для покупателя
        private void SearchForTheNecessaryCombinationBuyers(int pos, int k, int maxUsed, int price)
        {
            //если выбрали достаточное количество элементов
            if (pos == k)
            {
                //пока не нашли нужное сочетание 
                //и сумма элементов в сочетании не больше или не равна нужной
                if (!ok && myFuncForCompare(Sum(combination), price))
                {
                    necessaryCombination = (from elem in combination select elem).ToArray();
                    ok = true;
                }
            }
            else
            {
                //формирование сочетания с повторениями
                for (int i = maxUsed; i < coinsBuyers.Length; i++)
                {
                    combination[pos] = coinsBuyers[i];
                    SearchForTheNecessaryCombinationBuyers(pos + 1, k, i, price);
                }
            }
        }

        //поиск необходимого сочетания для продавца
        private void SearchForTheNecessaryCombinationSeller(int pos, int k, int maxUsed, int change)
        {
            //если выбрали достаточное количество элементов
            if (pos == k)
            {
                //пока не нашли нужное сочетание и сумма элементов в сочетании не равна нужной
                if (!ok && (Sum(combination) == change))
                {
                    necessaryCombination = (from elem in combination select elem).ToArray();
                    ok = true;
                }
            }
            else
            {
                //формирование сочетания с повторениями
                for (int i = maxUsed; i < coinsSeller.Length; i++)
                {
                    combination[pos] = coinsSeller[i];
                    SearchForTheNecessaryCombinationSeller(pos + 1, k, i, change);
                }
            }
        }

        //количество elem в arr
        private int CountElem<T>(T[] arr, T elem)
        {
            int count = 0;
            foreach (T item in arr)
            {
                if (item.Equals(elem))
                {
                    count++;
                }
            }
            return count;
        }

        //преобразование массива монеток в строку
        private string ArrayCoinsToString(int[] arr, int[] coins)
        {
            string str = "";
            int count = 0;
            foreach (int item in coins)
            {
                count = CountElem<int>(arr, item);
                if (count != 0)
                {
                    str = str + item.ToString() + " - " + count.ToString() + "шт.  ";
                }
            }
            return str;
        }

        //выдать сдачу
        private void btnGiveShortChange_Click(object sender, EventArgs e)
        {
            textBoxShortChange.Clear();
            textBoxPay.Clear();

            //получаем стоимость покупки
            int purchasePrice = int.Parse(textBoxPurchasePrice.Text);

            //считаем, сколько дает покупатель
            //предположим, что он может дать заданную сумму без сдачи
            int pay = purchasePrice;

            //будем проверять все сочетания из заданного количества элементов
            //начиная с размера = 1
            int i = 1;

            //переменная, которая хранит окончательный размер сочетания
            //при котором возможно найдется нужное
            int stop = 0;

            ok = false;
            myFuncForCompare = CompareForBuyerWithoutChange;

            //будем считать, что это худший вариант: 
            //сочетание, состоящее только из наименьшей монеты           
            stop = pay / coinsBuyers[0] + 1;
            
            //проверяем, может ли покупатель выдать деньги без сдачи
            while (!ok && (i <= stop))
            {
                combination = new int[i];
                SearchForTheNecessaryCombinationBuyers(0, i, 0, pay);
                if (!ok)
                {
                    i++;
                }
            }
            //если можем дать без сдачи
            if (i <= stop)
            {
                textBoxPay.Text = textBoxPay.Text + pay.ToString() + ". Используемые монеты:  "
                    + ArrayCoinsToString(necessaryCombination, coinsBuyers);
            }
            else
            {
                i = 1;
                ok = false;

                myFuncForCompare = CompareForBuyerWithChange;

                //теперь ищем сочетание монет, больших чем заданная стоимость
                while (!ok && (i != stop))
                {
                    combination = new int[i];
                    SearchForTheNecessaryCombinationBuyers(0, i, 0, pay);
                    i++;
                }

                pay = necessaryCombination.Sum();
                textBoxPay.Text = textBoxPay.Text + pay.ToString() + ". Используемые монеты:  "
                    + ArrayCoinsToString(necessaryCombination, coinsBuyers);
            }

            //высчитываем сдачу
            int change = pay - purchasePrice;
            //если сдачи нет
            if (change == 0)
            {
                textBoxShortChange.Text = "0.";
            }
            else
            {
                i = 1;
                ok = false;

                myFuncForCompare = CompareForBuyerWithoutChange;

                //такой же худший вариант
                //только для продавца
                stop = pay / coinsSeller[0] + 1;

                while (!ok && (i <= stop))
                {
                    combination = new int[i];
                    SearchForTheNecessaryCombinationSeller(0, i, 0, change);
                    if (!ok)
                    {
                        i++;
                    }
                }

                //если не нашли комбинацию
                if (i <= stop)
                {
                    textBoxShortChange.Text = textBoxShortChange.Text 
                        + "С такими монетами далеко не уйдешь.";
                }
                else
                {
                    textBoxShortChange.Text = textBoxShortChange.Text 
                        + change.ToString() + ". Используемые монеты:  " 
                            + ArrayCoinsToString(necessaryCombination, coinsSeller);
                }
            }
        }
    }
}
