using PMSLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

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



        public void IsertIntoDatabase(CarInfo info, int parkID)
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
            "@pid," +
            "(SELECT Car.id FROM Car JOIN Car_Type ON Car.brand=Car_Type.id WHERE Car.license_plate=@Plate AND Car_Type.brand_name=@Brand AND Car_Type.model_name=@Model AND Car.color=@Color)" +
            ",@reservation_start,@reservation_end)", connection);
            cmd4.Parameters.AddWithValue("@pid", parkID);
            cmd4.Parameters.AddWithValue("@Plate", info.License);
            cmd4.Parameters.AddWithValue("@Brand", info.Brand);
            cmd4.Parameters.AddWithValue("@Model", info.Model);
            cmd4.Parameters.AddWithValue("@Color", info.Color);
            cmd4.Parameters.AddWithValue("@reservation_start", info.Reservation_Start);
            cmd4.Parameters.AddWithValue("@reservation_end", info.Reservation_End);

            try
            {

                cmd4.ExecuteNonQuery();
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





        public void SelectDatas(string SearchText, out SelectData selectedData)
        {
            selectedData = null;
           
            SqlCommand cmd5 = new SqlCommand("SELECT Customer.name_, Car_Type.brand_name, Car_Type.model_name, Parking.name_, Reservation.reservation_end " +
                "FROM Car" +
                " JOIN Customer ON Customer.id = Car.id_customer " +
                "JOIN Car_Type  ON Car_Type.id = Car.brand " +
                "JOIN Reservation ON Reservation.car_id = Car.id " +
                "JOIN Parking ON Parking.id = Reservation.parking_id " +
                "WHERE car.license_plate = @ParkingName", connection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd5);
            cmd5.Parameters.AddWithValue("@ParkingName", SearchText);
            using (SqlDataReader reader = cmd5.ExecuteReader())
            {
                
                if (reader.Read())
                {


                    selectedData = new SelectData();
                    selectedData.CustomerName = reader.GetString(0);
                    selectedData.BrandName = reader.GetString(1);
                    selectedData.ModelName = reader.GetString(2);
                    selectedData.ParkingName = reader.GetString(3);
                    selectedData.ReservationEnd = reader.GetString(4);
                    

                }

            }


        }

        public void DeleteCar(string SearchBoxText) 
        {


            SqlCommand cmd6 = new SqlCommand("DELETE FROM CAR WHERE license_plate = @SearchBoxText", connection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd6);
            cmd6.Parameters.AddWithValue("@SearchBoxText", SearchBoxText);
            try
            {

                cmd6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }




    }
}
