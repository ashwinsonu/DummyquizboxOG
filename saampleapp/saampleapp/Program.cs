using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace saampleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            //RetrieveData();
            // UpdateEmployee();
            //AddEmployee();
            //RemoveEmpolyee();
            RetrieveDataSP();

            Console.ReadKey();
        }

        public static void RetrieveDataSP()
        {
            SqlConnection con = new SqlConnection("Data Source=KANINI-LTP-454\\SQLSERVER2019ASH;Initial Catalog=pubs;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_getemp1");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr[i] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void RetrieveData()
        {
            SqlConnection con = new SqlConnection("Data Source=KANINI-LTP-454\\SQLSERVER2019ASH;Initial Catalog=pubs;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Emp");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            

            
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr[i] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void AddEmployee()
        {

            Console.WriteLine("enter id,name,address,age");
            int Employee_id = Convert.ToInt32(Console.ReadLine());
            string Name = Console.ReadLine();
            string Address = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(InsertData(Employee_id, Name, Address, age));
        }

        public static string InsertData(int eid, string name, string addr, int a)
        {
            SqlConnection con = new SqlConnection("Data Source=KANINI-LTP-454\\SQLSERVER2019ASH;Initial Catalog=pubs;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Emp Values(@Employee_id,@Name,@address,@age)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Employee_id", eid);
            cmd.Parameters.AddWithValue("Name", name);
            cmd.Parameters.AddWithValue("address", addr);
            cmd.Parameters.AddWithValue("age", a);
            cmd.ExecuteNonQuery();
            return "record added";

        }

        public  static void UpdateEmployee()
        {
                Console.WriteLine("enter id,name,address,age to update");
                int Employee_id = Convert.ToInt32(Console.ReadLine());
                string Name = Console.ReadLine();
                string Address = Console.ReadLine();
                int age = Convert.ToInt32(Console.ReadLine());
                string msg = UpdateData(Employee_id, Name, Address, age);
                Console.WriteLine(msg);
        }

        public static string UpdateData(int eid, string name, string addr, int a)
        {
                SqlConnection con = new SqlConnection("Data Source=KANINI-LTP-454\\SQLSERVER2019ASH;Initial Catalog=pubs;Trusted_Connection=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Emp set Name=@Name,Address=@address,age=@age where Employee_id=@Employee_id");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("Employee_id", eid);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("address", addr);
                cmd.Parameters.AddWithValue("age", a);
                cmd.ExecuteNonQuery();
                return "record updated";
        }

        public static void RemoveEmpolyee()
        {
            Console.WriteLine("Enter the employee id");
            int empid = Convert.ToInt32(Console.ReadLine());
            string i = DeleteData(empid);
          
                Console.WriteLine(i +" "+ "Record Deleted");
            


        }

        public static string DeleteData(int eid)
         
       {
             SqlConnection con = new SqlConnection("Data Source=KANINI-LTP-454\\SQLSERVER2019ASH;Initial Catalog=pubs;Trusted_Connection=True");
                con.Open();
            bool b = CheckData(eid);
            if (b == true)
            {
                SqlCommand cmd = new SqlCommand("Delete from Emp where Employee_id =@eid");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@eid", eid);
                string msg = cmd.ExecuteNonQuery().ToString();
                return msg;
            }
            else
                return "Employee Id doesn't exist";

        }


        public static bool CheckData(int eid)
        {
            SqlConnection con = new SqlConnection("Data Source=KANINI-LTP-454\\SQLSERVER2019ASH;Initial Catalog=pubs;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Emp");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

         
            

                
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr[0]) == eid)
                    {
                        return true;
                    }
                }
                    
              dr.Close();
            
            return false;
        }




    }
    
}
