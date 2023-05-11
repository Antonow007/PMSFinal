using PMSLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PMSFinal
{
    public class DbManager

    {

        private static DbManager instance = null;
        private string connectionString;
        private SqlConnection connection;
        public DbManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbManager();
                }
                return instance;
            }
        }

        public DbManager()
        {
            try
            {
                connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\anton\\source\\repos\\PMS Final\\Parking.mdf\";Integrated Security=True;Connect Timeout=30";
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Dispose()
        {
            connection.Close();
            instance = null;
        }



        public void IsertIntoDatabase(CarInfo info)
        {

            SqlCommand cmd1 = new SqlCommand("INSERT INTO Car_Type (brand_name,model_name) VALUES (@Brand,@Model)", connection);

            cmd1.Parameters.AddWithValue("@Brand", info.Brand);
            cmd1.Parameters.AddWithValue("@Model", info.Model);
            try
            {


                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Customer (name_,phone,email) VALUES (@Name,@Phone,@Email)", connection);

            cmd2.Parameters.AddWithValue("@Name", info.Name);
            cmd2.Parameters.AddWithValue("@Phone", info.Phone);
            cmd2.Parameters.AddWithValue("@Email", info.Email);
            try
            {

                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
            SqlCommand cmd3 = new SqlCommand("INSERT INTO Car (id_customer,license_plate,brand,color) VALUES (" +
                "(SELECT id FROM Customer WHERE name_=@Name AND phone=@Phone AND email=@Email)," +
                "@Plate,(SELECT id FROM Car_Type WHERE brand_name=@Brand AND model_name=@Model),@Color)", connection);
            cmd3.Parameters.AddWithValue("@Name", info.Name);
            cmd3.Parameters.AddWithValue("@Phone", info.Phone);
            cmd3.Parameters.AddWithValue("@Email", info.Email);
            cmd3.Parameters.AddWithValue("@Plate", info.License);
            cmd3.Parameters.AddWithValue("@Brand", info.Brand);
            cmd3.Parameters.AddWithValue("@Model", info.Model);
            cmd3.Parameters.AddWithValue("@Color", info.Color);

            try
            {

                cmd3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            SqlCommand cmd4 = new SqlCommand("INSERT INTO Reservation (parking_id,car_id,reservation_start,reservation_end) VALUES (" +
                "(SELECT id FROM Parking WHERE name_=@Name AND phone=@Phone AND email=@Email)," +
                "@Plate,(SELECT id FROM Car_Type WHERE brand_name=@Brand AND model_name=@Model),@Color)", connection);
            cmd3.Parameters.AddWithValue("@Name", info.Name);
            cmd3.Parameters.AddWithValue("@Phone", info.Phone);
            cmd3.Parameters.AddWithValue("@Email", info.Email);
            cmd3.Parameters.AddWithValue("@Plate", info.License);
            cmd3.Parameters.AddWithValue("@Brand", info.Brand);
            cmd3.Parameters.AddWithValue("@Model", info.Model);
            cmd3.Parameters.AddWithValue("@Color", info.Color);

            try
            {

                cmd3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        public DataTable DataBasetoComboBox()
        {
            SqlCommand cmd = new SqlCommand("SELECT id,name_ FROM Parking WHERE status_ = 'f'", connection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adpt.Fill(table);
            adpt.Dispose();
            return table;
        }




        public void UpdateParkingStatus(string parkingNames)
        {

            SqlCommand cmd2 = new SqlCommand("UPDATE Parking SET status_ = 't' WHERE name_ = @ParkingName", connection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd2);
            cmd2.Parameters.AddWithValue("@ParkingName", parkingNames);
            try
            {

                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

    }
}
