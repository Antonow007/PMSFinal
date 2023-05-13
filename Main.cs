using Krypton.Toolkit;
using PMSFinal;
using PMSLibrary;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PMS_Final
{
    public partial class Main : KryptonForm
    {





        public Main()
        {
            InitializeComponent();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        private void addButton_Click(object sender, EventArgs e)
        {

            Register register = new Register();
            register.Show();

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show("Comming Soon!","Message");
            return;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show("Comming Soon!", "Message");
            return;
        }
    }
}
