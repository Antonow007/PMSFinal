using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSLibrary
{
    public class Parking
    {

        private string reservation_start;
        private string reservation_end;

        public Parking(string reservation_start, string reservation_end)
        {
            this.reservation_start = reservation_start;
            this.reservation_end = reservation_end;
        }

        public Parking() 
        {

            reservation_start = "";
            reservation_end = "";

        }

        public string Reservation_start { get => reservation_start; set => reservation_start = value; }
        public string Reservation_end { get => reservation_end; set => reservation_end = value; }
    }
}
