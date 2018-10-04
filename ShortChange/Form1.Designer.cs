namespace ShortChange
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPurchasePrice = new System.Windows.Forms.TextBox();
            this.lbPurchasePrice = new System.Windows.Forms.Label();
            this.lbCoinsSeller = new System.Windows.Forms.Label();
            this.lbCoinsBuyers = new System.Windows.Forms.Label();
            this.textBoxCoinsSeller = new System.Windows.Forms.TextBox();
            this.textBoxCoinsBuyers = new System.Windows.Forms.TextBox();
            this.btnGiveShortChange = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbShortChange = new System.Windows.Forms.Label();
            this.textBoxShortChange = new System.Windows.Forms.TextBox();
            this.lbNull = new System.Windows.Forms.Label();
            this.lbNull2 = new System.Windows.Forms.Label();
            this.lbBuyers = new System.Windows.Forms.Label();
            this.textBoxPay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxPurchasePrice
            // 
            this.textBoxPurchasePrice.Enabled = false;
            this.textBoxPurchasePrice.Location = new System.Drawing.Point(280, 159);
            this.textBoxPurchasePrice.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPurchasePrice.Name = "textBoxPurchasePrice";
            this.textBoxPurchasePrice.Size = new System.Drawing.Size(175, 26);
            this.textBoxPurchasePrice.TabIndex = 3;
            this.textBoxPurchasePrice.TextChanged += new System.EventHandler(this.textBoxSumShortChange_TextChanged);
            this.textBoxPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCoinsSeller_KeyPress);
            // 
            // lbPurchasePrice
            // 
            this.lbPurchasePrice.AutoSize = true;
            this.lbPurchasePrice.Location = new System.Drawing.Point(92, 159);
            this.lbPurchasePrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPurchasePrice.Name = "lbPurchasePrice";
            this.lbPurchasePrice.Size = new System.Drawing.Size(178, 20);
            this.lbPurchasePrice.TabIndex = 1;
            this.lbPurchasePrice.Text = "Стоимость покупки:";
            // 
            // lbCoinsSeller
            // 
            this.lbCoinsSeller.AutoSize = true;
            this.lbCoinsSeller.Location = new System.Drawing.Point(92, 57);
            this.lbCoinsSeller.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCoinsSeller.Name = "lbCoinsSeller";
            this.lbCoinsSeller.Size = new System.Drawing.Size(167, 20);
            this.lbCoinsSeller.TabIndex = 2;
            this.lbCoinsSeller.Text = "Монеты продавца:";
            // 
            // lbCoinsBuyers
            // 
            this.lbCoinsBuyers.AutoSize = true;
            this.lbCoinsBuyers.Location = new System.Drawing.Point(92, 95);
            this.lbCoinsBuyers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCoinsBuyers.Name = "lbCoinsBuyers";
            this.lbCoinsBuyers.Size = new System.Drawing.Size(182, 20);
            this.lbCoinsBuyers.TabIndex = 3;
            this.lbCoinsBuyers.Text = "Монеты покупателя:";
            // 
            // textBoxCoinsSeller
            // 
            this.textBoxCoinsSeller.Location = new System.Drawing.Point(280, 54);
            this.textBoxCoinsSeller.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCoinsSeller.Name = "textBoxCoinsSeller";
            this.textBoxCoinsSeller.Size = new System.Drawing.Size(175, 26);
            this.textBoxCoinsSeller.TabIndex = 0;
            this.textBoxCoinsSeller.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCoinsSeller_KeyPress);
            // 
            // textBoxCoinsBuyers
            // 
            this.textBoxCoinsBuyers.Location = new System.Drawing.Point(280, 93);
            this.textBoxCoinsBuyers.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCoinsBuyers.Name = "textBoxCoinsBuyers";
            this.textBoxCoinsBuyers.Size = new System.Drawing.Size(175, 26);
            this.textBoxCoinsBuyers.TabIndex = 1;
            this.textBoxCoinsBuyers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCoinsSeller_KeyPress);
            // 
            // btnGiveShortChange
            // 
            this.btnGiveShortChange.Enabled = false;
            this.btnGiveShortChange.Location = new System.Drawing.Point(480, 159);
            this.btnGiveShortChange.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiveShortChange.Name = "btnGiveShortChange";
            this.btnGiveShortChange.Size = new System.Drawing.Size(157, 26);
            this.btnGiveShortChange.TabIndex = 4;
            this.btnGiveShortChange.Text = "Выдать сдачу";
            this.btnGiveShortChange.UseVisualStyleBackColor = true;
            this.btnGiveShortChange.Click += new System.EventHandler(this.btnGiveShortChange_Click);
            // 
            // btnFix
            // 
            this.btnFix.Location = new System.Drawing.Point(480, 54);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(157, 26);
            this.btnFix.TabIndex = 2;
            this.btnFix.Text = "Зафиксировать";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(480, 93);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(157, 26);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbShortChange
            // 
            this.lbShortChange.AutoSize = true;
            this.lbShortChange.Location = new System.Drawing.Point(92, 276);
            this.lbShortChange.Name = "lbShortChange";
            this.lbShortChange.Size = new System.Drawing.Size(73, 20);
            this.lbShortChange.TabIndex = 9;
            this.lbShortChange.Text = "Сдача :";
            // 
            // textBoxShortChange
            // 
            this.textBoxShortChange.Location = new System.Drawing.Point(192, 273);
            this.textBoxShortChange.Name = "textBoxShortChange";
            this.textBoxShortChange.ReadOnly = true;
            this.textBoxShortChange.Size = new System.Drawing.Size(445, 26);
            this.textBoxShortChange.TabIndex = 7;
            // 
            // lbNull
            // 
            this.lbNull.AutoSize = true;
            this.lbNull.Location = new System.Drawing.Point(92, 121);
            this.lbNull.Name = "lbNull";
            this.lbNull.Size = new System.Drawing.Size(612, 20);
            this.lbNull.TabIndex = 11;
            this.lbNull.Text = "___________________________________________________________________";
            // 
            // lbNull2
            // 
            this.lbNull2.AutoSize = true;
            this.lbNull2.Location = new System.Drawing.Point(92, 187);
            this.lbNull2.Name = "lbNull2";
            this.lbNull2.Size = new System.Drawing.Size(612, 20);
            this.lbNull2.TabIndex = 12;
            this.lbNull2.Text = "___________________________________________________________________";
            // 
            // lbBuyers
            // 
            this.lbBuyers.AutoSize = true;
            this.lbBuyers.Location = new System.Drawing.Point(92, 229);
            this.lbBuyers.Name = "lbBuyers";
            this.lbBuyers.Size = new System.Drawing.Size(151, 20);
            this.lbBuyers.TabIndex = 13;
            this.lbBuyers.Text = "Покупатель дал:";
            // 
            // textBoxPay
            // 
            this.textBoxPay.Location = new System.Drawing.Point(263, 229);
            this.textBoxPay.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPay.Name = "textBoxPay";
            this.textBoxPay.ReadOnly = true;
            this.textBoxPay.Size = new System.Drawing.Size(374, 26);
            this.textBoxPay.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(736, 362);
            this.Controls.Add(this.textBoxPay);
            this.Controls.Add(this.lbBuyers);
            this.Controls.Add(this.lbNull2);
            this.Controls.Add(this.lbNull);
            this.Controls.Add(this.textBoxShortChange);
            this.Controls.Add(this.lbShortChange);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.btnGiveShortChange);
            this.Controls.Add(this.textBoxCoinsBuyers);
            this.Controls.Add(this.textBoxCoinsSeller);
            this.Controls.Add(this.lbCoinsBuyers);
            this.Controls.Add(this.lbCoinsSeller);
            this.Controls.Add(this.lbPurchasePrice);
            this.Controls.Add(this.textBoxPurchasePrice);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Сдача";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPurchasePrice;
        private System.Windows.Forms.Label lbPurchasePrice;
        private System.Windows.Forms.Label lbCoinsSeller;
        private System.Windows.Forms.Label lbCoinsBuyers;
        private System.Windows.Forms.TextBox textBoxCoinsSeller;
        private System.Windows.Forms.TextBox textBoxCoinsBuyers;
        private System.Windows.Forms.Button btnGiveShortChange;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbShortChange;
        private System.Windows.Forms.TextBox textBoxShortChange;
        private System.Windows.Forms.Label lbNull;
        private System.Windows.Forms.Label lbNull2;
        private System.Windows.Forms.Label lbBuyers;
        private System.Windows.Forms.TextBox textBoxPay;
    }
}

