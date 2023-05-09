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
            CarInfo info = new CarInfo();
            info.License = plateTextBox.Text;
            info.Brand = brandTextBox.Text;
            info.Model = brandTextBox.Text;
            info.Color = brandTextBox.Text;
            info.Name = nameTextBox.Text;
            info.Phone = phoneTextBox.Text;
            info.Email = emailTextBox.Text;
            Chooser chooser = new Chooser(info);

            chooser.Show();
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }
    }
}
