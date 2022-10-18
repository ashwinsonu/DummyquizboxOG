/*using System;

namespace Customer
{
    class Customer
    {
        public int CID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phoneno { get; set; }
        public string City { get; set; }

        public Customer()
        {
            CID = 1111;
            Name = "No name";
            Age = 18;
            Phoneno = "00000";
            City = "Delhi";

        }

        public Customer(int cid, string name , int a, string pno, string city )
        {
            CID = cid;
            Name = name;
            Age = a;
            Phoneno = pno;
            City = city;

        }

        ~Customer()
        {
            Console.WriteLine("Instance destroyed");
        }
        
        public void DisplayCustomer()
        {
            Console.WriteLine("ID of Customer: "+CID);
            Console.WriteLine("Name of customer: "+Name);
            Console.WriteLine("Age of Customer: "+Age);
            Console.WriteLine("Phone Number of Customer: "+Phoneno);
            Console.WriteLine("City: "+City);


        }


        


        static void Main(string[] args)
        {
            Customer C1 = new Customer();
            C1.DisplayCustomer();
            Customer C2= new Customer(12,"sunny",19,"4567832","London" );
                C2.DisplayCustomer();

                
        }
    }
}
*/