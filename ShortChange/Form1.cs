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


        public MainForm()
        {
            InitializeComponent();
        }

        private void EnabledComponents(bool value)
        {
            btnFix.Enabled = value;
            textBoxCoinsBuyers.ReadOnly = !value;
            textBoxCoinsSeller.ReadOnly = !value;
            textBoxSumShortChange.Enabled = !value;
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

            //считываем информацию из полей
            String[] coins_seller = textBoxCoinsSeller.Text.Split(new String[] { " " }, StringSplitOptions.None);
            String[] coins_buyers = textBoxCoinsBuyers.Text.Split(new String[] { " " }, StringSplitOptions.None);


        }

        //очистить
        private void btnClear_Click(object sender, EventArgs e)
        {
            //очищаем поля
            textBoxCoinsBuyers.Clear();
            textBoxCoinsSeller.Clear();
            textBoxSumShortChange.Clear();


            //изменяем доступность компонентов
            EnabledComponents(true);
        }

        //изменение поля для сдачи
        private void textBoxSumShortChange_TextChanged(object sender, EventArgs e)
        {
            btnGiveShortChange.Enabled = true;
        }
    }
}
