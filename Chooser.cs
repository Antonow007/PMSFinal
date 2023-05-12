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
            CarInfo info = new CarInfo();         
            info.Reservation_Start = Startdate.Text;
            info.Reservation_End = Enddate.Text;



            DbManager dm = new DbManager();
            DataTable table = dm.DataBasetoComboBox();


            ParkingNames.DataSource = table;
            ParkingNames.DisplayMember = "name_";
            ParkingNames.ValueMember = "id";
            dm.Dispose();

           

        }
        public string GetSelectedParkingName()
        {
            return ParkingNames.SelectedText;
        }



        private void addButton_Click_1(object sender, EventArgs e)
        {

            CarInfo info = new CarInfo();
            info.Reservation_Start = Startdate.Text;
            info.Reservation_End = Enddate.Text;

            DbManager dm = new DbManager();
            dm.IsertIntoDatabase(info,int.Parse(ParkingNames.SelectedValue.ToString()));
            dm.UpdateParkingStatus(ParkingNames.Text);
            dm.Dispose();

          

        }

        private void Chooser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
