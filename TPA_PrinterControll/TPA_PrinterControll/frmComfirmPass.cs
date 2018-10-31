using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPA_PrinterControll
{
    public partial class frmComfirmPass : Form
    {
        bool _isOK = false;
        public frmComfirmPass()
        {
            InitializeComponent();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MyConfig._PassWord))
            {
                MessageBox.Show("Mật khẩu chưa được cài đặt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNewPass.Text.Trim() == "" || txtNewPass.Text.Trim() != this.DecryptPassword(MyConfig._PassWord))
            {
                MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _isOK = true;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// To Decrypt password
        /// </summary>
        /// <param name="encryptedPassword"></param>
        /// <returns>It returns plain password</returns>
        public string DecryptPassword(string encryptedPassword)
        {
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }

        private void frmComfirmPass_Load(object sender, EventArgs e)
        {
            MyConfig._Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            try
            {
                MyConfig.Read();
            }
            catch
            {
                MyConfig.Write();
            }
        }
    }
}
