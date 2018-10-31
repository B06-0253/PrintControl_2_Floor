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
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void frmChangePass_Load(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MyConfig._PassWord != null)
            {
                if (txtOldPass.Text.Trim() != this.DecryptPassword(MyConfig._PassWord))
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtNewPass.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu mới không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MyConfig._PassWord = this.EncryptPassword(txtNewPass.Text.Trim());
            MyConfig.Write();

            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        /// <summary>
        /// To encrypt the input password
        /// </summary>
        /// <param name="txtPassword"></param>
        /// <returns>It returns encrypted code</returns>
        public string EncryptPassword(string txtPassword)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword);
            string encryptPassword = Convert.ToBase64String(passBytes);
            return encryptPassword;
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

        
    }
}
