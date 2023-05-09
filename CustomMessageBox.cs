using Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace PMS_Final
{
    public partial class CustomMessageBox : KryptonForm
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public static DialogResult Show(string message, string caption)
        {
            CustomMessageBox box = new CustomMessageBox();
            box.messageLabel.Text = message;
            box.Text = caption;
            return box.ShowDialog();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
