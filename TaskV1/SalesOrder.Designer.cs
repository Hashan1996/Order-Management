
namespace TaskV1
{
    partial class SalesOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimeInvoice = new System.Windows.Forms.DateTimePicker();
            this.textBoxTotalIncl = new System.Windows.Forms.TextBox();
            this.textBoxTotalTax = new System.Windows.Forms.TextBox();
            this.textBoxTotalExcl = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.textBoxRefNo = new System.Windows.Forms.TextBox();
            this.textBoxInvoiceNo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Description_1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExclAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InclAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_CustomerName = new System.Windows.Forms.ComboBox();
            this.textBoxPC = new System.Windows.Forms.TextBox();
            this.textBoxStates = new System.Windows.Forms.TextBox();
            this.textBoxSubrb = new System.Windows.Forms.TextBox();
            this.textBoxAddress3 = new System.Windows.Forms.TextBox();
            this.textBoxAddress2 = new System.Windows.Forms.TextBox();
            this.textBoxAddress1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stkItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stkItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Address3";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.buttonUpdate);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 49);
            this.panel1.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(18, 11);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(141, 31);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save Order";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Location = new System.Drawing.Point(779, 10);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 32);
            this.buttonPrint.TabIndex = 4;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(870, 10);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 32);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(172, 10);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(131, 31);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dateTimeInvoice);
            this.panel2.Controls.Add(this.textBoxTotalIncl);
            this.panel2.Controls.Add(this.textBoxTotalTax);
            this.panel2.Controls.Add(this.textBoxTotalExcl);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxNote);
            this.panel2.Controls.Add(this.textBoxRefNo);
            this.panel2.Controls.Add(this.textBoxInvoiceNo);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.comboBox_CustomerName);
            this.panel2.Controls.Add(this.textBoxPC);
            this.panel2.Controls.Add(this.textBoxStates);
            this.panel2.Controls.Add(this.textBoxSubrb);
            this.panel2.Controls.Add(this.textBoxAddress3);
            this.panel2.Controls.Add(this.textBoxAddress2);
            this.panel2.Controls.Add(this.textBoxAddress1);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 607);
            this.panel2.TabIndex = 6;
            // 
            // dateTimeInvoice
            // 
            this.dateTimeInvoice.Location = new System.Drawing.Point(678, 72);
            this.dateTimeInvoice.Name = "dateTimeInvoice";
            this.dateTimeInvoice.Size = new System.Drawing.Size(200, 21);
            this.dateTimeInvoice.TabIndex = 35;
            // 
            // textBoxTotalIncl
            // 
            this.textBoxTotalIncl.Location = new System.Drawing.Point(702, 561);
            this.textBoxTotalIncl.Name = "textBoxTotalIncl";
            this.textBoxTotalIncl.Size = new System.Drawing.Size(181, 21);
            this.textBoxTotalIncl.TabIndex = 34;
            // 
            // textBoxTotalTax
            // 
            this.textBoxTotalTax.Location = new System.Drawing.Point(702, 527);
            this.textBoxTotalTax.Name = "textBoxTotalTax";
            this.textBoxTotalTax.Size = new System.Drawing.Size(181, 21);
            this.textBoxTotalTax.TabIndex = 33;
            // 
            // textBoxTotalExcl
            // 
            this.textBoxTotalExcl.Location = new System.Drawing.Point(702, 486);
            this.textBoxTotalExcl.Name = "textBoxTotalExcl";
            this.textBoxTotalExcl.Size = new System.Drawing.Size(181, 21);
            this.textBoxTotalExcl.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(597, 561);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 15);
            this.label14.TabIndex = 31;
            this.label14.Text = "Total Incl";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(597, 527);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 15);
            this.label13.TabIndex = 30;
            this.label13.Text = "Total Tax";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(597, 489);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Total Excl";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(678, 138);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(205, 108);
            this.textBoxNote.TabIndex = 28;
            // 
            // textBoxRefNo
            // 
            this.textBoxRefNo.Location = new System.Drawing.Point(678, 106);
            this.textBoxRefNo.Name = "textBoxRefNo";
            this.textBoxRefNo.Size = new System.Drawing.Size(205, 21);
            this.textBoxRefNo.TabIndex = 27;
            // 
            // textBoxInvoiceNo
            // 
            this.textBoxInvoiceNo.Location = new System.Drawing.Point(678, 40);
            this.textBoxInvoiceNo.Name = "textBoxInvoiceNo";
            this.textBoxInvoiceNo.Size = new System.Drawing.Size(205, 21);
            this.textBoxInvoiceNo.TabIndex = 25;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Description_1,
            this.Note,
            this.Quantity,
            this.Price,
            this.Tax,
            this.ExclAmount,
            this.TaxAmount,
            this.InclAmount});
            this.dataGridView1.Location = new System.Drawing.Point(17, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(940, 150);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Code
            // 
            this.Code.HeaderText = "Item Code";
            this.Code.Name = "Code";
            // 
            // Description_1
            // 
            this.Description_1.HeaderText = "Description";
            this.Description_1.Name = "Description_1";
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Tax
            // 
            this.Tax.HeaderText = "Tax";
            this.Tax.Name = "Tax";
            // 
            // ExclAmount
            // 
            this.ExclAmount.HeaderText = "Excl Amount";
            this.ExclAmount.Name = "ExclAmount";
            // 
            // TaxAmount
            // 
            this.TaxAmount.HeaderText = "Tax Amount";
            this.TaxAmount.Name = "TaxAmount";
            // 
            // InclAmount
            // 
            this.InclAmount.HeaderText = "Incl Amount";
            this.InclAmount.Name = "InclAmount";
            // 
            // comboBox_CustomerName
            // 
            this.comboBox_CustomerName.FormattingEnabled = true;
            this.comboBox_CustomerName.Location = new System.Drawing.Point(232, 38);
            this.comboBox_CustomerName.Name = "comboBox_CustomerName";
            this.comboBox_CustomerName.Size = new System.Drawing.Size(205, 23);
            this.comboBox_CustomerName.TabIndex = 23;
            this.comboBox_CustomerName.SelectedIndexChanged += new System.EventHandler(this.comboBox_CustomerName_SelectedIndexChanged);
            // 
            // textBoxPC
            // 
            this.textBoxPC.Location = new System.Drawing.Point(232, 225);
            this.textBoxPC.Name = "textBoxPC";
            this.textBoxPC.Size = new System.Drawing.Size(205, 21);
            this.textBoxPC.TabIndex = 18;
            // 
            // textBoxStates
            // 
            this.textBoxStates.Location = new System.Drawing.Point(232, 196);
            this.textBoxStates.Name = "textBoxStates";
            this.textBoxStates.Size = new System.Drawing.Size(205, 21);
            this.textBoxStates.TabIndex = 17;
            // 
            // textBoxSubrb
            // 
            this.textBoxSubrb.Location = new System.Drawing.Point(232, 165);
            this.textBoxSubrb.Name = "textBoxSubrb";
            this.textBoxSubrb.Size = new System.Drawing.Size(205, 21);
            this.textBoxSubrb.TabIndex = 16;
            // 
            // textBoxAddress3
            // 
            this.textBoxAddress3.Location = new System.Drawing.Point(232, 135);
            this.textBoxAddress3.Name = "textBoxAddress3";
            this.textBoxAddress3.Size = new System.Drawing.Size(205, 21);
            this.textBoxAddress3.TabIndex = 15;
            // 
            // textBoxAddress2
            // 
            this.textBoxAddress2.Location = new System.Drawing.Point(232, 103);
            this.textBoxAddress2.Name = "textBoxAddress2";
            this.textBoxAddress2.Size = new System.Drawing.Size(205, 21);
            this.textBoxAddress2.TabIndex = 14;
            // 
            // textBoxAddress1
            // 
            this.textBoxAddress1.Location = new System.Drawing.Point(232, 72);
            this.textBoxAddress1.Name = "textBoxAddress1";
            this.textBoxAddress1.Size = new System.Drawing.Size(205, 21);
            this.textBoxAddress1.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(565, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "Note";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(565, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Reference no";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(565, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Invoice Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(565, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Invoice No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(86, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Post Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(86, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "States";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Suburb";
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(TaskV1.Model.Client);
            // 
            // stkItemBindingSource
            // 
            this.stkItemBindingSource.DataSource = typeof(TaskV1.Model.StkItem);
            // 
            // SalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 656);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SalesOrder";
            this.Text = "SalesOrder";
            this.Load += new System.EventHandler(this.SalesOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stkItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource stkItemBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn Code;
        private System.Windows.Forms.DataGridViewComboBoxColumn Description_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExclAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InclAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource clientBindingSource;
        public System.Windows.Forms.TextBox textBoxPC;
        public System.Windows.Forms.TextBox textBoxStates;
        public System.Windows.Forms.TextBox textBoxSubrb;
        public System.Windows.Forms.TextBox textBoxAddress3;
        public System.Windows.Forms.TextBox textBoxAddress2;
        public System.Windows.Forms.TextBox textBoxAddress1;
        public System.Windows.Forms.ComboBox comboBox_CustomerName;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox textBoxNote;
        public System.Windows.Forms.TextBox textBoxRefNo;
        public System.Windows.Forms.TextBox textBoxInvoiceNo;
        public System.Windows.Forms.DateTimePicker dateTimeInvoice;
        public System.Windows.Forms.TextBox textBoxTotalIncl;
        public System.Windows.Forms.TextBox textBoxTotalTax;
        public System.Windows.Forms.TextBox textBoxTotalExcl;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonSave;
    }
}