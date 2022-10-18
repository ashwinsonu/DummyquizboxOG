using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    class Scholarship
    {
        public int Marks { get; set; }
        public float Fees { get; set; }
        
        public void Merit()
        {
            float SAmt =0;

            Console.WriteLine("Enter Marks,Fees Charged");
            Marks = Convert.ToInt32(Console.ReadLine());
            Fees = float.Parse(Console.ReadLine());
            {   if (Marks >= 70 && Marks < 80)
                {
                    SAmt = Fees * (20 / 100);
                    Console.WriteLine("the scholarship is :" + SAmt);
                }
                else if (Marks >= 80 && Marks < 90)
                {
                    SAmt = Fees * (30 / 100);
                    Console.WriteLine("the scholarship is :" + SAmt);
                }
                else if (Marks > 90)
                {
                    SAmt = Fees * (50 / 100);
                    Console.WriteLine("the scholarship is :" + SAmt);
                }

                else Console.WriteLine("No Scholarship");
            }

            


        }
        public static void Main()
        {
            Scholarship S = new Scholarship();
            S.Merit();
            
        }

    }
}
