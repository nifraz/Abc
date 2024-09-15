using System;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class QuantityForm : Form
    {
        public QuantityForm()
        {
            InitializeComponent();

            Quantity = 1;
        }

        #region Fields
        public int Quantity
        {
            get
            {
                return (int)nudQuantity.Value;
            }
            set { nudQuantity.Value = value; }
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (!ValidateInput()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInput()
        {
            //if (Quantity == null)
            //{
            //    txtPassword1.Focus();
            //    return false;
            //}
            //if (Password2 == null)
            //{
            //    txtPassword2.Focus();
            //    return false;
            //}
            //if (Quantity != Password2)
            //{
            //    MessageBox.Show("Passwords do not match.", "PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPassword2.Focus();
            //    return false;
            //}
            return true;
        }
    }
}
