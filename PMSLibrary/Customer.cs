namespace PMSLibrary
{
    public class Customer
    {

        private string name;
        private string phone;
        private string email;

        public Customer(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public Customer()
        {
            name = "";
            phone = "";
            email = "";
        }


        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}
