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
using PMSFinal;
using PMSLibrary;

namespace PMS_Final
{
    public partial class Chooser : KryptonForm
    {



        CarInfo info = new CarInfo();

        public Chooser(CarInfo ci)
        {
            info = ci;
            InitializeComponent();
        }


        public Chooser()
        {
            InitializeComponent();
        }







       





        private void ButtonCloseForm_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Close();
        }


        private void ButtonClose_Click(object sender, EventArgs eventArgs)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }



        private void Chooser_Load(object sender, EventArgs e)
        {
            DbManager dm = new DbManager();
            DataTable table = dm.DataBasetoComboBox();


            ParkingNames.DataSource = table;
            ParkingNames.DisplayMember = "name_";
            ParkingNames.ValueMember = "id";
            dm.Dispose();
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            DbManager dm = new DbManager();
            dm.IsertIntoDatabase(info);

            dm.Dispose();
        }
    }
}
