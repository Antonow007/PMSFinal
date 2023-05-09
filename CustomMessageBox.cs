using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using PMSLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
