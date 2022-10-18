using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saledDetails
{
    class saled
    {
        public int salesNo { get; set; }
        public int ProductNo { get; set; }
        public double Price { get; set; }
        public DateTime dateofsale { get; set; }
        public int Qty { get; set; }

        public saled()
        {
            salesNo = 1;
            ProductNo = 23;
            Price = 98765.23;
            dateofsale = Convert.ToDateTime("12 / 12 / 1234");
            Qty = 1;
        }
        public void getdetails()
        {
            Console.WriteLine("enter saled details(Salesno,  Productno,  Price, dateofsale, Qty)");
            salesNo = Convert.ToInt32(Console.ReadLine());
            ProductNo = Convert.ToInt32(Console.ReadLine());
            Price = Convert.ToInt64(Console.ReadLine());
            dateofsale = Convert.ToDateTime(Console.ReadLine());
            Qty = Convert.ToInt32(Console.ReadLine());

        }
        public void displayDetais()
        {
            Console.WriteLine("the saled details are");
            Console.WriteLine("salesNo :" + salesNo);
            Console.WriteLine(" ProductNo :" + ProductNo);
            Console.WriteLine("Price :" + Price);
            Console.WriteLine("dateofsale :" + dateofsale);
            Console.WriteLine(" Qty :" + Qty);
            Console.WriteLine("total price :" + (Qty * Price));
        }

        public static void Main()
        {
            saled detail = new saled();
            //detail.getdetails();
            detail.displayDetais();

        }
    }
}
