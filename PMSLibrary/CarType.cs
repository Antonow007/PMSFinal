﻿namespace PMSLibrary
{
    public class CarType
    {
        private string brand;
        private string model;

        public CarType(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public CarType()
        {

            brand = "";
            model = "";
        }


        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
    }
}
