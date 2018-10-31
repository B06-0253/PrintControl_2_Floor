namespace TPA_PrinterControll
{
    partial class frmPrintMatrixNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintMatrixNew));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtManual = new System.Windows.Forms.RadioButton();
            this.rbtAuto = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.labelPrinter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtMatrixData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCountryOfProduction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerialNumberNG = new System.Windows.Forms.TextBox();
            this.txtSerialNumberOK = new System.Windows.Forms.TextBox();
            this.txtFosterPartNo = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtChangeIndexNo = new System.Windows.Forms.TextBox();
            this.txtCustomerPartNo = new System.Windows.Forms.TextBox();
            this.txtPlantCode = new System.Windows.Forms.TextBox();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.panelMatrixTem = new System.Windows.Forms.Panel();
            this.lblMatrix = new System.Windows.Forms.Label();
            this.lblCountryOfProduct1 = new System.Windows.Forms.Label();
            this.lblFosterPart1 = new System.Windows.Forms.Label();
            this.lblSupplierCode1 = new System.Windows.Forms.Label();
            this.lblCustomerPart1 = new System.Windows.Forms.Label();
            this.lblSerialNumber1 = new System.Windows.Forms.Label();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.pnTem = new System.Windows.Forms.Panel();
            this.lblCountryOfProduct = new System.Windows.Forms.Label();
            this.lblFosterPart = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblCustomerPart = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timerAutoPrint = new System.Windows.Forms.Timer(this.components);
            this.timerTurnPinOut = new System.Windows.Forms.Timer(this.components);
            this.btnChangePass = new System.Windows.Forms.Button();
            this.GroupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.panelMatrixTem.SuspendLayout();
            this.pnTem.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.rbtManual);
            this.GroupBox3.Controls.Add(this.rbtAuto);
            this.GroupBox3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(27, 11);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(393, 63);
            this.GroupBox3.TabIndex = 13;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Printing Mode";
            // 
            // rbtManual
            // 
            this.rbtManual.AutoSize = true;
            this.rbtManual.Checked = true;
            this.rbtManual.Location = new System.Drawing.Point(197, 26);
            this.rbtManual.Name = "rbtManual";
            this.rbtManual.Size = new System.Drawing.Size(67, 20);
            this.rbtManual.TabIndex = 12;
            this.rbtManual.TabStop = true;
            this.rbtManual.Text = "Manual";
            this.rbtManual.UseVisualStyleBackColor = true;
            this.rbtManual.CheckedChanged += new System.EventHandler(this.rbtAuto_CheckedChanged);
            // 
            // rbtAuto
            // 
            this.rbtAuto.AutoSize = true;
            this.rbtAuto.Location = new System.Drawing.Point(116, 26);
            this.rbtAuto.Name = "rbtAuto";
            this.rbtAuto.Size = new System.Drawing.Size(53, 20);
            this.rbtAuto.TabIndex = 12;
            this.rbtAuto.Text = "Auto";
            this.rbtAuto.UseVisualStyleBackColor = true;
            this.rbtAuto.CheckedChanged += new System.EventHandler(this.rbtAuto_CheckedChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cboModel);
            this.GroupBox1.Controls.Add(this.btnSaveData);
            this.GroupBox1.Controls.Add(this.cboPrinter);
            this.GroupBox1.Controls.Add(this.btnPrint);
            this.GroupBox1.Controls.Add(this.labelPrinter);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.Label16);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.Label15);
            this.GroupBox1.Controls.Add(this.txtMatrixData);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.txtCountryOfProduction);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txtSerialNumberNG);
            this.GroupBox1.Controls.Add(this.txtSerialNumberOK);
            this.GroupBox1.Controls.Add(this.txtFosterPartNo);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.txtChangeIndexNo);
            this.GroupBox1.Controls.Add(this.txtCustomerPartNo);
            this.GroupBox1.Controls.Add(this.txtPlantCode);
            this.GroupBox1.Controls.Add(this.txtSupplierCode);
            this.GroupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(27, 80);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(393, 413);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Label content";
            // 
            // cboModel
            // 
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(153, 22);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(211, 23);
            this.cboModel.TabIndex = 19;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveData.Location = new System.Drawing.Point(294, 375);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(70, 31);
            this.btnSaveData.TabIndex = 18;
            this.btnSaveData.Text = "Save";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // cboPrinter
            // 
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Items.AddRange(new object[] {
            "OK",
            "NG"});
            this.cboPrinter.Location = new System.Drawing.Point(65, 341);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(223, 23);
            this.cboPrinter.TabIndex = 17;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(294, 341);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelPrinter
            // 
            this.labelPrinter.AutoSize = true;
            this.labelPrinter.Location = new System.Drawing.Point(13, 345);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(46, 16);
            this.labelPrinter.TabIndex = 9;
            this.labelPrinter.Text = "Printer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Serial number NG";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(38, 258);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(109, 16);
            this.Label17.TabIndex = 9;
            this.Label17.Text = "Serial number OK";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(104, 25);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(45, 17);
            this.Label12.TabIndex = 9;
            this.Label12.Text = "Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Plant Code";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(60, 114);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(87, 16);
            this.Label16.TabIndex = 9;
            this.Label16.Text = "Supplier Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Change Index No.";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(32, 54);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(115, 16);
            this.Label15.TabIndex = 9;
            this.Label15.Text = "Customer Part No.";
            // 
            // txtMatrixData
            // 
            this.txtMatrixData.Location = new System.Drawing.Point(153, 226);
            this.txtMatrixData.Name = "txtMatrixData";
            this.txtMatrixData.Size = new System.Drawing.Size(211, 23);
            this.txtMatrixData.TabIndex = 8;
            this.txtMatrixData.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Matrix Data ";
            // 
            // txtCountryOfProduction
            // 
            this.txtCountryOfProduction.Location = new System.Drawing.Point(153, 197);
            this.txtCountryOfProduction.Name = "txtCountryOfProduction";
            this.txtCountryOfProduction.Size = new System.Drawing.Size(211, 23);
            this.txtCountryOfProduction.TabIndex = 8;
            this.txtCountryOfProduction.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Country of production";
            // 
            // txtSerialNumberNG
            // 
            this.txtSerialNumberNG.Location = new System.Drawing.Point(153, 284);
            this.txtSerialNumberNG.Name = "txtSerialNumberNG";
            this.txtSerialNumberNG.Size = new System.Drawing.Size(211, 23);
            this.txtSerialNumberNG.TabIndex = 8;
            this.txtSerialNumberNG.Text = "0";
            this.txtSerialNumberNG.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // txtSerialNumberOK
            // 
            this.txtSerialNumberOK.Location = new System.Drawing.Point(153, 255);
            this.txtSerialNumberOK.Name = "txtSerialNumberOK";
            this.txtSerialNumberOK.Size = new System.Drawing.Size(211, 23);
            this.txtSerialNumberOK.TabIndex = 8;
            this.txtSerialNumberOK.Text = "0";
            this.txtSerialNumberOK.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // txtFosterPartNo
            // 
            this.txtFosterPartNo.Location = new System.Drawing.Point(153, 168);
            this.txtFosterPartNo.Name = "txtFosterPartNo";
            this.txtFosterPartNo.Size = new System.Drawing.Size(211, 23);
            this.txtFosterPartNo.TabIndex = 8;
            this.txtFosterPartNo.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(51, 171);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(96, 16);
            this.Label14.TabIndex = 9;
            this.Label14.Text = "Foster Part No.";
            // 
            // txtChangeIndexNo
            // 
            this.txtChangeIndexNo.Location = new System.Drawing.Point(153, 81);
            this.txtChangeIndexNo.Name = "txtChangeIndexNo";
            this.txtChangeIndexNo.Size = new System.Drawing.Size(211, 23);
            this.txtChangeIndexNo.TabIndex = 8;
            this.txtChangeIndexNo.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // txtCustomerPartNo
            // 
            this.txtCustomerPartNo.Location = new System.Drawing.Point(153, 51);
            this.txtCustomerPartNo.Name = "txtCustomerPartNo";
            this.txtCustomerPartNo.Size = new System.Drawing.Size(211, 23);
            this.txtCustomerPartNo.TabIndex = 8;
            this.txtCustomerPartNo.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // txtPlantCode
            // 
            this.txtPlantCode.Location = new System.Drawing.Point(153, 139);
            this.txtPlantCode.Name = "txtPlantCode";
            this.txtPlantCode.Size = new System.Drawing.Size(211, 23);
            this.txtPlantCode.TabIndex = 8;
            this.txtPlantCode.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(153, 110);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(211, 23);
            this.txtSupplierCode.TabIndex = 8;
            this.txtSupplierCode.TextChanged += new System.EventHandler(this.tbxSupplier_TextChanged);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetting.Location = new System.Drawing.Point(447, 449);
            this.buttonSetting.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(64, 31);
            this.buttonSetting.TabIndex = 16;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.AutoSize = true;
            this.GroupBox2.Controls.Add(this.panelMatrixTem);
            this.GroupBox2.Controls.Add(this.pnTem);
            this.GroupBox2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(447, 11);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.GroupBox2.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.GroupBox2.MinimumSize = new System.Drawing.Size(100, 100);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.GroupBox2.Size = new System.Drawing.Size(400, 413);
            this.GroupBox2.TabIndex = 15;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Preview";
            // 
            // panelMatrixTem
            // 
            this.panelMatrixTem.BackColor = System.Drawing.Color.Transparent;
            this.panelMatrixTem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMatrixTem.BackgroundImage")));
            this.panelMatrixTem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMatrixTem.Controls.Add(this.lblMatrix);
            this.panelMatrixTem.Controls.Add(this.lblCountryOfProduct1);
            this.panelMatrixTem.Controls.Add(this.lblFosterPart1);
            this.panelMatrixTem.Controls.Add(this.lblSupplierCode1);
            this.panelMatrixTem.Controls.Add(this.lblCustomerPart1);
            this.panelMatrixTem.Controls.Add(this.lblSerialNumber1);
            this.panelMatrixTem.Controls.Add(this.lblDate1);
            this.panelMatrixTem.Location = new System.Drawing.Point(22, 41);
            this.panelMatrixTem.Margin = new System.Windows.Forms.Padding(0);
            this.panelMatrixTem.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.panelMatrixTem.MinimumSize = new System.Drawing.Size(100, 100);
            this.panelMatrixTem.Name = "panelMatrixTem";
            this.panelMatrixTem.Size = new System.Drawing.Size(356, 356);
            this.panelMatrixTem.TabIndex = 5;
            // 
            // lblMatrix
            // 
            this.lblMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMatrix.BackColor = System.Drawing.Color.Transparent;
            this.lblMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatrix.Location = new System.Drawing.Point(123, 190);
            this.lblMatrix.Margin = new System.Windows.Forms.Padding(0);
            this.lblMatrix.Name = "lblMatrix";
            this.lblMatrix.Size = new System.Drawing.Size(121, 119);
            this.lblMatrix.TabIndex = 1;
            this.lblMatrix.Text = "C5262280001";
            this.lblMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountryOfProduct1
            // 
            this.lblCountryOfProduct1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountryOfProduct1.BackColor = System.Drawing.Color.Transparent;
            this.lblCountryOfProduct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryOfProduct1.Location = new System.Drawing.Point(17, 166);
            this.lblCountryOfProduct1.Margin = new System.Windows.Forms.Padding(0);
            this.lblCountryOfProduct1.Name = "lblCountryOfProduct1";
            this.lblCountryOfProduct1.Size = new System.Drawing.Size(101, 31);
            this.lblCountryOfProduct1.TabIndex = 1;
            this.lblCountryOfProduct1.Text = "VIETNAM";
            this.lblCountryOfProduct1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFosterPart1
            // 
            this.lblFosterPart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFosterPart1.BackColor = System.Drawing.Color.Transparent;
            this.lblFosterPart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFosterPart1.Location = new System.Drawing.Point(250, 167);
            this.lblFosterPart1.Margin = new System.Windows.Forms.Padding(0);
            this.lblFosterPart1.Name = "lblFosterPart1";
            this.lblFosterPart1.Size = new System.Drawing.Size(90, 33);
            this.lblFosterPart1.TabIndex = 1;
            this.lblFosterPart1.Text = "604306";
            this.lblFosterPart1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplierCode1
            // 
            this.lblSupplierCode1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplierCode1.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplierCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCode1.Location = new System.Drawing.Point(36, 92);
            this.lblSupplierCode1.Margin = new System.Windows.Forms.Padding(0);
            this.lblSupplierCode1.Name = "lblSupplierCode1";
            this.lblSupplierCode1.Size = new System.Drawing.Size(287, 31);
            this.lblSupplierCode1.TabIndex = 1;
            this.lblSupplierCode1.Text = "105795-10 FOSTER";
            this.lblSupplierCode1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCustomerPart1
            // 
            this.lblCustomerPart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerPart1.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerPart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPart1.Location = new System.Drawing.Point(37, 121);
            this.lblCustomerPart1.Margin = new System.Windows.Forms.Padding(0);
            this.lblCustomerPart1.Name = "lblCustomerPart1";
            this.lblCustomerPart1.Size = new System.Drawing.Size(287, 29);
            this.lblCustomerPart1.TabIndex = 1;
            this.lblCustomerPart1.Text = "9999 8715683-01";
            this.lblCustomerPart1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSerialNumber1
            // 
            this.lblSerialNumber1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerialNumber1.BackColor = System.Drawing.Color.Transparent;
            this.lblSerialNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber1.Location = new System.Drawing.Point(250, 203);
            this.lblSerialNumber1.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialNumber1.Name = "lblSerialNumber1";
            this.lblSerialNumber1.Size = new System.Drawing.Size(65, 27);
            this.lblSerialNumber1.TabIndex = 1;
            this.lblSerialNumber1.Text = "0001";
            this.lblSerialNumber1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate1
            // 
            this.lblDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate1.BackColor = System.Drawing.Color.Transparent;
            this.lblDate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate1.Location = new System.Drawing.Point(31, 195);
            this.lblDate1.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(87, 33);
            this.lblDate1.TabIndex = 1;
            this.lblDate1.Text = "180629";
            this.lblDate1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnTem
            // 
            this.pnTem.BackColor = System.Drawing.Color.Transparent;
            this.pnTem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnTem.BackgroundImage")));
            this.pnTem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnTem.Controls.Add(this.lblCountryOfProduct);
            this.pnTem.Controls.Add(this.lblFosterPart);
            this.pnTem.Controls.Add(this.lblSupplierCode);
            this.pnTem.Controls.Add(this.lblCustomerPart);
            this.pnTem.Controls.Add(this.lblSerialNumber);
            this.pnTem.Controls.Add(this.lblDate);
            this.pnTem.Location = new System.Drawing.Point(22, 41);
            this.pnTem.Margin = new System.Windows.Forms.Padding(0);
            this.pnTem.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.pnTem.MinimumSize = new System.Drawing.Size(100, 100);
            this.pnTem.Name = "pnTem";
            this.pnTem.Size = new System.Drawing.Size(356, 356);
            this.pnTem.TabIndex = 18;
            // 
            // lblCountryOfProduct
            // 
            this.lblCountryOfProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountryOfProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblCountryOfProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryOfProduct.Location = new System.Drawing.Point(107, 292);
            this.lblCountryOfProduct.Margin = new System.Windows.Forms.Padding(0);
            this.lblCountryOfProduct.Name = "lblCountryOfProduct";
            this.lblCountryOfProduct.Size = new System.Drawing.Size(130, 31);
            this.lblCountryOfProduct.TabIndex = 1;
            this.lblCountryOfProduct.Text = "VIETNAM";
            this.lblCountryOfProduct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFosterPart
            // 
            this.lblFosterPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFosterPart.BackColor = System.Drawing.Color.Transparent;
            this.lblFosterPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFosterPart.Location = new System.Drawing.Point(70, 252);
            this.lblFosterPart.Margin = new System.Windows.Forms.Padding(0);
            this.lblFosterPart.Name = "lblFosterPart";
            this.lblFosterPart.Size = new System.Drawing.Size(211, 33);
            this.lblFosterPart.TabIndex = 1;
            this.lblFosterPart.Text = "604306";
            this.lblFosterPart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplierCode.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCode.Location = new System.Drawing.Point(32, 213);
            this.lblSupplierCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(287, 31);
            this.lblSupplierCode.TabIndex = 1;
            this.lblSupplierCode.Text = "105795-10";
            this.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCustomerPart
            // 
            this.lblCustomerPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerPart.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPart.Location = new System.Drawing.Point(32, 174);
            this.lblCustomerPart.Margin = new System.Windows.Forms.Padding(0);
            this.lblCustomerPart.Name = "lblCustomerPart";
            this.lblCustomerPart.Size = new System.Drawing.Size(287, 29);
            this.lblCustomerPart.TabIndex = 1;
            this.lblCustomerPart.Text = "8715683-01";
            this.lblCustomerPart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerialNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNumber.Location = new System.Drawing.Point(22, 128);
            this.lblSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(305, 27);
            this.lblSerialNumber.TabIndex = 1;
            this.lblSerialNumber.Text = "0001";
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(21, 90);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(312, 46);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "09 APR 18";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerAutoPrint
            // 
            this.timerAutoPrint.Tick += new System.EventHandler(this.timerAutoPrint_Tick);
            // 
            // timerTurnPinOut
            // 
            this.timerTurnPinOut.Enabled = true;
            this.timerTurnPinOut.Tick += new System.EventHandler(this.timerTurnPinOut_Tick);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePass.Location = new System.Drawing.Point(520, 449);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(132, 31);
            this.btnChangePass.TabIndex = 17;
            this.btnChangePass.Text = "Change Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // frmPrintMatrixNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(865, 501);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.buttonSetting);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1504, 1632);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(804, 534);
            this.Name = "frmPrintMatrixNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printing Monitor ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.panelMatrixTem.ResumeLayout(false);
            this.pnTem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.RadioButton rbtManual;
        internal System.Windows.Forms.RadioButton rbtAuto;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox txtFosterPartNo;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtCustomerPartNo;
        internal System.Windows.Forms.TextBox txtSupplierCode;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Timer timerAutoPrint;
        internal System.Windows.Forms.Panel panelMatrixTem;
        internal System.Windows.Forms.Label lblCountryOfProduct1;
        internal System.Windows.Forms.Label lblFosterPart1;
        internal System.Windows.Forms.Label lblSupplierCode1;
        internal System.Windows.Forms.Label lblCustomerPart1;
        internal System.Windows.Forms.Label lblSerialNumber1;
        internal System.Windows.Forms.Label lblDate1;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Timer timerTurnPinOut;
        private System.Windows.Forms.ComboBox cboPrinter;
        internal System.Windows.Forms.Label labelPrinter;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.ComboBox cboModel;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCountryOfProduction;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtSerialNumberOK;
        internal System.Windows.Forms.TextBox txtChangeIndexNo;
        internal System.Windows.Forms.TextBox txtPlantCode;
        internal System.Windows.Forms.Label lblMatrix;
        internal System.Windows.Forms.TextBox txtMatrixData;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtSerialNumberNG;
        internal System.Windows.Forms.Panel pnTem;
        internal System.Windows.Forms.Label lblCountryOfProduct;
        internal System.Windows.Forms.Label lblFosterPart;
        internal System.Windows.Forms.Label lblSupplierCode;
        internal System.Windows.Forms.Label lblCustomerPart;
        internal System.Windows.Forms.Label lblSerialNumber;
        internal System.Windows.Forms.Label lblDate;
    }
}