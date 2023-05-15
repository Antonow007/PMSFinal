using Krypton.Toolkit;
using PMSFinal;
using PMSLibrary;
using System;
using System.Windows.Forms;

namespace PMS_Final
{
    public partial class Finder : KryptonForm
    {



        



        public Finder()
        {
            InitializeComponent();
        }









        private void Chooser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SelectData selectedData;
            DbManager dm = new DbManager();

            dm.SelectDatas(SearchBox.Text, out selectedData);
            NameResult.Text = selectedData.CustomerName;
            CarResult.Text = selectedData.BrandName;
            ModelResult.Text = selectedData.ModelName;
            LocationResult.Text = selectedData.ParkingName;
            ReservationEndResult.Text = selectedData.ReservationEnd;





        }

        private void Finder_Load(object sender, EventArgs e)
        {

        }
    }
}
