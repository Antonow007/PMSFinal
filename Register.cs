using Krypton.Toolkit;
using PMSLibrary;
using System;
using System.Windows.Forms;

namespace PMS_Final
{
    public partial class Register : KryptonForm
    {
        public Register()
        {
            InitializeComponent();
        }









        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        private void buttonClose_Click(object sender, EventArgs eventArgs)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void plateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(brandTextBox, true, true, true, true);
            }

        }

        private void brandTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(modelTextBox, true, true, true, true);
            }
        }

        private void modelTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(colorTextBox, true, true, true, true);
            }
        }

        private void colorTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(nameTextBox, true, true, true, true);
            }
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(phoneTextBox, true, true, true, true);
            }
        }

        private void phoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl(emailTextBox, true, true, true, true);
            }
        }




        private void nextButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(plateTextBox.Text) ||
        string.IsNullOrWhiteSpace(brandTextBox.Text) ||
        string.IsNullOrWhiteSpace(modelTextBox.Text) ||
        string.IsNullOrWhiteSpace(colorTextBox.Text) ||
        string.IsNullOrWhiteSpace(nameTextBox.Text) ||
        string.IsNullOrWhiteSpace(phoneTextBox.Text) ||
        string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                CustomMessageBox.Show("Please fill all fields.", "Error");
                return;
            }


            CarInfo info = new CarInfo();
            info.License = plateTextBox.Text;
            info.Brand = brandTextBox.Text;
            info.Model = modelTextBox.Text;
            info.Color = colorTextBox.Text;
            info.Name = nameTextBox.Text;
            info.Phone = phoneTextBox.Text;
            info.Email = emailTextBox.Text;
            Chooser chooser = new Chooser(info);

            chooser.Show();
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
