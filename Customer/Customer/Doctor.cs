/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    class Doctor
    {
        public int RegNo { get; set; }
        public String Name { get; set; }
        public float Fees { get; set; }

        public void AcceptDetails()
        {
            Console.WriteLine("Enter Registration No., Name ,Fees Charged");

            RegNo = Convert.ToInt32(Console.ReadLine());
            Name = Console.ReadLine();
            
            
            Fees = float.Parse(Console.ReadLine());




        }

        public void DisplayDetails()
        {
            Console.WriteLine("The Details are: ");
            Console.WriteLine("Registration No: " + RegNo);
            Console.WriteLine("Name: "+ Name);
            Console.WriteLine("Fees Charged: " + Fees);


        }

        static void Main()
        {
            Doctor D = new Doctor();
            D.AcceptDetails();
            D.DisplayDetails();
        }
    }
}
*/