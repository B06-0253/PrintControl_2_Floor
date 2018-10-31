namespace TPA_PrinterControll
{
    partial class frmComfirmPass
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
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.btnNext = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(82, 19);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(235, 23);
            this.txtNewPass.TabIndex = 25;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(20, 24);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(44, 13);
            this.btnNext.TabIndex = 24;
            this.btnNext.Text = "Mật khẩu";
            // 
            // btnSaveData
            // 
            this.btnSaveData.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveData.Location = new System.Drawing.Point(143, 57);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(78, 31);
            this.btnSaveData.TabIndex = 26;
            this.btnSaveData.Text = "Xác nhận";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // frmComfirmPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 100);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.btnNext);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComfirmPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận mật khẩu";
            this.Load += new System.EventHandler(this.frmComfirmPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewPass;
        private DevExpress.XtraEditors.LabelControl btnNext;
        private System.Windows.Forms.Button btnSaveData;
    }
}