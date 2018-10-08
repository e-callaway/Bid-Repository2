namespace BidApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.txtOrgCity = new System.Windows.Forms.TextBox();
            this.txtOrgState = new System.Windows.Forms.TextBox();
            this.txtOrgZip = new System.Windows.Forms.TextBox();
            this.txtDestZip = new System.Windows.Forms.TextBox();
            this.txtDestState = new System.Windows.Forms.TextBox();
            this.txtDestCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdExport = new System.Windows.Forms.Button();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.lblNumLoads = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(16, 64);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(132, 22);
            this.txtCustomer.TabIndex = 1;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(1097, 39);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(105, 54);
            this.cmdSearch.TabIndex = 4;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(1211, 39);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(105, 54);
            this.cmdReset.TabIndex = 5;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Location = new System.Drawing.Point(1700, 15);
            this.cmdUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(151, 38);
            this.cmdUpdate.TabIndex = 17;
            this.cmdUpdate.Text = "Update Bids";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToAddRows = false;
            this.dataGridResults.AllowUserToDeleteRows = false;
            this.dataGridResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Location = new System.Drawing.Point(17, 194);
            this.dataGridResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridResults.MultiSelect = false;
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.Size = new System.Drawing.Size(1829, 410);
            this.dataGridResults.TabIndex = 21;
            this.dataGridResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResults_CellClick);
            // 
            // txtOrgCity
            // 
            this.txtOrgCity.Location = new System.Drawing.Point(116, 42);
            this.txtOrgCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrgCity.Name = "txtOrgCity";
            this.txtOrgCity.Size = new System.Drawing.Size(132, 22);
            this.txtOrgCity.TabIndex = 6;
            this.txtOrgCity.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // txtOrgState
            // 
            this.txtOrgState.Location = new System.Drawing.Point(265, 42);
            this.txtOrgState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrgState.Name = "txtOrgState";
            this.txtOrgState.Size = new System.Drawing.Size(132, 22);
            this.txtOrgState.TabIndex = 7;
            this.txtOrgState.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // txtOrgZip
            // 
            this.txtOrgZip.Location = new System.Drawing.Point(416, 42);
            this.txtOrgZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrgZip.Name = "txtOrgZip";
            this.txtOrgZip.Size = new System.Drawing.Size(132, 22);
            this.txtOrgZip.TabIndex = 8;
            this.txtOrgZip.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // txtDestZip
            // 
            this.txtDestZip.Location = new System.Drawing.Point(1023, 42);
            this.txtDestZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDestZip.Name = "txtDestZip";
            this.txtDestZip.Size = new System.Drawing.Size(132, 22);
            this.txtDestZip.TabIndex = 12;
            this.txtDestZip.TextChanged += new System.EventHandler(this.txtDestZip_TextChanged);
            // 
            // txtDestState
            // 
            this.txtDestState.Location = new System.Drawing.Point(872, 42);
            this.txtDestState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDestState.Name = "txtDestState";
            this.txtDestState.Size = new System.Drawing.Size(132, 22);
            this.txtDestState.TabIndex = 11;
            this.txtDestState.TextChanged += new System.EventHandler(this.txtDestState_TextChanged);
            // 
            // txtDestCity
            // 
            this.txtDestCity.Location = new System.Drawing.Point(723, 42);
            this.txtDestCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDestCity.Name = "txtDestCity";
            this.txtDestCity.Size = new System.Drawing.Size(132, 22);
            this.txtDestCity.TabIndex = 10;
            this.txtDestCity.TextChanged += new System.EventHandler(this.TextBox7_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Origin Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Zip";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1019, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "Zip";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(868, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "State";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(577, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Destination Filter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(719, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "City";
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(537, 60);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(243, 22);
            this.dateFrom.TabIndex = 14;
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(808, 60);
            this.dateTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(249, 22);
            this.dateTo.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(533, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 17);
            this.label12.TabIndex = 45;
            this.label12.Text = "Date From";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(804, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 46;
            this.label13.Text = "Date To";
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Location = new System.Drawing.Point(1727, 64);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(120, 31);
            this.cmdExport.TabIndex = 16;
            this.cmdExport.Text = "Export Results";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.Location = new System.Drawing.Point(884, 892);
            this.lblTotalProfit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(0, 29);
            this.lblTotalProfit.TabIndex = 54;
            // 
            // lblNumLoads
            // 
            this.lblNumLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumLoads.AutoSize = true;
            this.lblNumLoads.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLoads.Location = new System.Drawing.Point(237, 892);
            this.lblNumLoads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumLoads.Name = "lblNumLoads";
            this.lblNumLoads.Size = new System.Drawing.Size(0, 29);
            this.lblNumLoads.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtOrgCity);
            this.panel1.Controls.Add(this.txtOrgState);
            this.panel1.Controls.Add(this.txtOrgZip);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDestCity);
            this.panel1.Controls.Add(this.txtDestState);
            this.panel1.Controls.Add(this.txtDestZip);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(17, 101);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 86);
            this.panel1.TabIndex = 56;
            // 
            // fbd
            // 
            this.fbd.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 612);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1829, 322);
            this.dataGridView1.TabIndex = 57;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(182, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 58;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.cmdSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1864, 938);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNumLoads);
            this.Controls.Add(this.lblTotalProfit);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "BidApp";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.TextBox txtOrgCity;
        private System.Windows.Forms.TextBox txtOrgState;
        private System.Windows.Forms.TextBox txtOrgZip;
        private System.Windows.Forms.TextBox txtDestZip;
        private System.Windows.Forms.TextBox txtDestState;
        private System.Windows.Forms.TextBox txtDestCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label lblNumLoads;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

