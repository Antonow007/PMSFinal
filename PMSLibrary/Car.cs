﻿namespace PMSLibrary
{
    public class Car
    {

        private string licensePlate;
        private string color;

        public Car(string licensePlate, string color)
        {
            LicensePlate = licensePlate;
            Color = color;
        }

        public Car()
        {
            LicensePlate = "";
            Color = "";

        }



        public string LicensePlate { get => licensePlate; set => licensePlate = value; }
        public string Color { get => color; set => color = value; }
    }
}
