namespace BizCare.View
{
    partial class ProductQtyUpdateUI
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
            this.txtQtyBegin = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblQtyEnd = new System.Windows.Forms.Label();
            this.lblQtyIn = new System.Windows.Forms.Label();
            this.lblQtyOut = new System.Windows.Forms.Label();
            this.lblValueBegin = new System.Windows.Forms.Label();
            this.txtValueBegin = new System.Windows.Forms.TextBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.lblSalesPrice = new System.Windows.Forms.Label();
            this.txtSalesPrice = new System.Windows.Forms.TextBox();
            this.lblValueAverage = new System.Windows.Forms.Label();
            this.txtValueAverage = new System.Windows.Forms.TextBox();
            this.lblValueEnd = new System.Windows.Forms.Label();
            this.lblValueMinusCorrection = new System.Windows.Forms.Label();
            this.lblQtyPlusCorrection = new System.Windows.Forms.Label();
            this.lblQtyMinusCorrection = new System.Windows.Forms.Label();
            this.lblValuePlusCorrection = new System.Windows.Forms.Label();
            this.lblQtyAvailable = new System.Windows.Forms.Label();
            this.lblValueAvailable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtQtyBegin
            // 
            this.txtQtyBegin.Location = new System.Drawing.Point(20, 43);
            this.txtQtyBegin.MaxLength = 13;
            this.txtQtyBegin.Name = "txtQtyBegin";
            this.txtQtyBegin.Size = new System.Drawing.Size(114, 20);
            this.txtQtyBegin.TabIndex = 0;
            this.txtQtyBegin.TextChanged += new System.EventHandler(this.txtQtyBegin_TextChanged);
            this.txtQtyBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyBegin_KeyPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(191, 135);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Qty Awal";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(306, 161);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "Month";
            this.lblMonth.Visible = false;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(306, 148);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year";
            this.lblYear.Visible = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(306, 89);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "ID";
            this.lblID.Visible = false;
            // 
            // lblQtyEnd
            // 
            this.lblQtyEnd.AutoSize = true;
            this.lblQtyEnd.Location = new System.Drawing.Point(304, 135);
            this.lblQtyEnd.Name = "lblQtyEnd";
            this.lblQtyEnd.Size = new System.Drawing.Size(42, 13);
            this.lblQtyEnd.TabIndex = 6;
            this.lblQtyEnd.Text = "QtyEnd";
            // 
            // lblQtyIn
            // 
            this.lblQtyIn.AutoSize = true;
            this.lblQtyIn.Location = new System.Drawing.Point(306, 108);
            this.lblQtyIn.Name = "lblQtyIn";
            this.lblQtyIn.Size = new System.Drawing.Size(32, 13);
            this.lblQtyIn.TabIndex = 7;
            this.lblQtyIn.Text = "QtyIn";
            // 
            // lblQtyOut
            // 
            this.lblQtyOut.AutoSize = true;
            this.lblQtyOut.Location = new System.Drawing.Point(306, 122);
            this.lblQtyOut.Name = "lblQtyOut";
            this.lblQtyOut.Size = new System.Drawing.Size(40, 13);
            this.lblQtyOut.TabIndex = 8;
            this.lblQtyOut.Text = "QtyOut";
            // 
            // lblValueBegin
            // 
            this.lblValueBegin.AutoSize = true;
            this.lblValueBegin.Location = new System.Drawing.Point(151, 26);
            this.lblValueBegin.Name = "lblValueBegin";
            this.lblValueBegin.Size = new System.Drawing.Size(53, 13);
            this.lblValueBegin.TabIndex = 10;
            this.lblValueBegin.Text = "Nilai Awal";
            // 
            // txtValueBegin
            // 
            this.txtValueBegin.Location = new System.Drawing.Point(152, 43);
            this.txtValueBegin.MaxLength = 13;
            this.txtValueBegin.Name = "txtValueBegin";
            this.txtValueBegin.Size = new System.Drawing.Size(114, 20);
            this.txtValueBegin.TabIndex = 3;
            this.txtValueBegin.TextChanged += new System.EventHandler(this.txtValueBegin_TextChanged);
            this.txtValueBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueBegin_KeyPress);
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(19, 72);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(56, 13);
            this.lblPurchasePrice.TabIndex = 12;
            this.lblPurchasePrice.Text = "Harga Beli";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(20, 89);
            this.txtPurchasePrice.MaxLength = 13;
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(114, 20);
            this.txtPurchasePrice.TabIndex = 1;
            this.txtPurchasePrice.TextChanged += new System.EventHandler(this.txtPurchasePrice_TextChanged);
            this.txtPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchasePrice_KeyPress);
            // 
            // lblSalesPrice
            // 
            this.lblSalesPrice.AutoSize = true;
            this.lblSalesPrice.Location = new System.Drawing.Point(153, 72);
            this.lblSalesPrice.Name = "lblSalesPrice";
            this.lblSalesPrice.Size = new System.Drawing.Size(58, 13);
            this.lblSalesPrice.TabIndex = 14;
            this.lblSalesPrice.Text = "Harga Jual";
            // 
            // txtSalesPrice
            // 
            this.txtSalesPrice.Location = new System.Drawing.Point(154, 89);
            this.txtSalesPrice.MaxLength = 13;
            this.txtSalesPrice.Name = "txtSalesPrice";
            this.txtSalesPrice.Size = new System.Drawing.Size(114, 20);
            this.txtSalesPrice.TabIndex = 4;
            this.txtSalesPrice.TextChanged += new System.EventHandler(this.txtSalesPrice_TextChanged);
            this.txtSalesPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesPrice_KeyPress);
            // 
            // lblValueAverage
            // 
            this.lblValueAverage.AutoSize = true;
            this.lblValueAverage.Location = new System.Drawing.Point(21, 122);
            this.lblValueAverage.Name = "lblValueAverage";
            this.lblValueAverage.Size = new System.Drawing.Size(83, 13);
            this.lblValueAverage.TabIndex = 16;
            this.lblValueAverage.Text = "Harga Rata-rata";
            // 
            // txtValueAverage
            // 
            this.txtValueAverage.Location = new System.Drawing.Point(22, 139);
            this.txtValueAverage.MaxLength = 13;
            this.txtValueAverage.Name = "txtValueAverage";
            this.txtValueAverage.Size = new System.Drawing.Size(114, 20);
            this.txtValueAverage.TabIndex = 2;
            this.txtValueAverage.TextChanged += new System.EventHandler(this.txtValueAverage_TextChanged);
            this.txtValueAverage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueAverage_KeyPress);
            // 
            // lblValueEnd
            // 
            this.lblValueEnd.AutoSize = true;
            this.lblValueEnd.Location = new System.Drawing.Point(352, 135);
            this.lblValueEnd.Name = "lblValueEnd";
            this.lblValueEnd.Size = new System.Drawing.Size(42, 13);
            this.lblValueEnd.TabIndex = 17;
            this.lblValueEnd.Text = "QtyEnd";
            // 
            // lblValueMinusCorrection
            // 
            this.lblValueMinusCorrection.AutoSize = true;
            this.lblValueMinusCorrection.Location = new System.Drawing.Point(352, 213);
            this.lblValueMinusCorrection.Name = "lblValueMinusCorrection";
            this.lblValueMinusCorrection.Size = new System.Drawing.Size(110, 13);
            this.lblValueMinusCorrection.TabIndex = 18;
            this.lblValueMinusCorrection.Text = "ValueMinusCorrection";
            // 
            // lblQtyPlusCorrection
            // 
            this.lblQtyPlusCorrection.AutoSize = true;
            this.lblQtyPlusCorrection.Location = new System.Drawing.Point(352, 174);
            this.lblQtyPlusCorrection.Name = "lblQtyPlusCorrection";
            this.lblQtyPlusCorrection.Size = new System.Drawing.Size(91, 13);
            this.lblQtyPlusCorrection.TabIndex = 19;
            this.lblQtyPlusCorrection.Text = "QtyPlusCorrection";
            // 
            // lblQtyMinusCorrection
            // 
            this.lblQtyMinusCorrection.AutoSize = true;
            this.lblQtyMinusCorrection.Location = new System.Drawing.Point(352, 187);
            this.lblQtyMinusCorrection.Name = "lblQtyMinusCorrection";
            this.lblQtyMinusCorrection.Size = new System.Drawing.Size(99, 13);
            this.lblQtyMinusCorrection.TabIndex = 20;
            this.lblQtyMinusCorrection.Text = "QtyMinusCorrection";
            // 
            // lblValuePlusCorrection
            // 
            this.lblValuePlusCorrection.AutoSize = true;
            this.lblValuePlusCorrection.Location = new System.Drawing.Point(352, 200);
            this.lblValuePlusCorrection.Name = "lblValuePlusCorrection";
            this.lblValuePlusCorrection.Size = new System.Drawing.Size(102, 13);
            this.lblValuePlusCorrection.TabIndex = 21;
            this.lblValuePlusCorrection.Text = "ValuePlusCorrection";
            // 
            // lblQtyAvailable
            // 
            this.lblQtyAvailable.AutoSize = true;
            this.lblQtyAvailable.Location = new System.Drawing.Point(434, 96);
            this.lblQtyAvailable.Name = "lblQtyAvailable";
            this.lblQtyAvailable.Size = new System.Drawing.Size(66, 13);
            this.lblQtyAvailable.TabIndex = 22;
            this.lblQtyAvailable.Text = "QtyAvailable";
            // 
            // lblValueAvailable
            // 
            this.lblValueAvailable.AutoSize = true;
            this.lblValueAvailable.Location = new System.Drawing.Point(434, 109);
            this.lblValueAvailable.Name = "lblValueAvailable";
            this.lblValueAvailable.Size = new System.Drawing.Size(77, 13);
            this.lblValueAvailable.TabIndex = 23;
            this.lblValueAvailable.Text = "ValueAvailable";
            // 
            // ProductQtyUpdateUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 182);
            this.Controls.Add(this.lblValueAvailable);
            this.Controls.Add(this.lblQtyAvailable);
            this.Controls.Add(this.lblValuePlusCorrection);
            this.Controls.Add(this.lblQtyMinusCorrection);
            this.Controls.Add(this.lblQtyPlusCorrection);
            this.Controls.Add(this.lblValueMinusCorrection);
            this.Controls.Add(this.lblValueEnd);
            this.Controls.Add(this.lblValueAverage);
            this.Controls.Add(this.txtValueAverage);
            this.Controls.Add(this.lblSalesPrice);
            this.Controls.Add(this.txtSalesPrice);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.lblValueBegin);
            this.Controls.Add(this.txtValueBegin);
            this.Controls.Add(this.lblQtyOut);
            this.Controls.Add(this.lblQtyIn);
            this.Controls.Add(this.lblQtyEnd);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtQtyBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductQtyUpdateUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Qty";
            this.Load += new System.EventHandler(this.ProductQtyUpdateUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQtyBegin;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblQtyEnd;
        private System.Windows.Forms.Label lblQtyIn;
        private System.Windows.Forms.Label lblQtyOut;
        private System.Windows.Forms.Label lblValueBegin;
        private System.Windows.Forms.TextBox txtValueBegin;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Label lblSalesPrice;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.Label lblValueAverage;
        private System.Windows.Forms.TextBox txtValueAverage;
        private System.Windows.Forms.Label lblValueEnd;
        private System.Windows.Forms.Label lblValueMinusCorrection;
        private System.Windows.Forms.Label lblQtyPlusCorrection;
        private System.Windows.Forms.Label lblQtyMinusCorrection;
        private System.Windows.Forms.Label lblValuePlusCorrection;
        private System.Windows.Forms.Label lblQtyAvailable;
        private System.Windows.Forms.Label lblValueAvailable;
    }
}