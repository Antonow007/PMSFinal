using PMSLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PMSLibrary
{
    public class CarInfo
    {

        Car car = new Car();
        CarType carType = new CarType();
        Customer customer = new Customer();

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
    }
}
