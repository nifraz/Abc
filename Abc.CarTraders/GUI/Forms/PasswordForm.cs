using System;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();

            Password1 = null;
            Password2 = null;
        }

        #region Fields
        public string Password1
        {
            get
            {
                var str = txtPassword1.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPassword1.Text = value; }
        }

        public string Password2
        {
            get
            {
                var str = txtPassword2.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPassword2.Text = value; }
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInput()
        {
            if (Password1 == null)
            {
                txtPassword1.Focus();
                return false;
            }
            if (Password2 == null)
            {
                txtPassword2.Focus();
                return false;
            }
            if (Password1 != Password2)
            {
                MessageBox.Show("Passwords do not match.", "PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword2.Focus();
                return false;
            }
            return true;
        }
    }
}
