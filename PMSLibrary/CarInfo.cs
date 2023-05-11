namespace PMSLibrary
{
    public class CarInfo
    {

        Car car = new Car();
        CarType carType = new CarType();
        Customer customer = new Customer();
        Parking parking = new Parking();

        public CarInfo()
        {

        }

        public string License { get => car.LicensePlate; set => car.LicensePlate = value; }
        public string Color { get => car.Color; set => car.Color = value; }
        public string Brand { get => carType.Brand; set => carType.Brand = value; }
        public string Model { get => carType.Model; set => carType.Model = value; }
        public string Name { get => customer.Name; set => customer.Name = value; }
        public string Phone { get => customer.Phone; set => customer.Phone = value; }
        public string Email { get => customer.Email; set => customer.Email = value; }
        public string Reservation_Start { get => parking.Reservation_start; set => parking.Reservation_start = value; }
        public string Reservation_End { get => parking.Reservation_end; set => parking.Reservation_end = value;}
    }
}
