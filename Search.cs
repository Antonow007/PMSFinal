using Krypton.Toolkit;
using PMSLibrary;
using System;
using System.Windows.Forms;

namespace PMS_Final
{
    public partial class Search : KryptonForm
    {
        public Search()
        {
            InitializeComponent();
        }









        
        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
