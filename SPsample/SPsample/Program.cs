using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SPsample
{
    class Program
    {
        static void Main(string[] args)
        {
            GetEmployees();
            Console.ReadKey();

        }

        public static void GetEmployees()
        {
            SqlConnection con = new SqlConnection("Data Source=KANINI-LTP-454\\SQLSERVER2019ASH;Initial Catalog=pubs;Trusted_Connection=True");
            List<EmpModel> e = new List<EmpModel>();
            //con.Open();
            SqlCommand cmd = new SqlCommand("usp_getemp",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];                   
            //da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmpModel emp = new EmpModel();
                emp.Employee_id = Convert.ToInt32(dr[0]);
                //Console.WriteLine(emp.Employee_id);
                emp.Name = Convert.ToString(dr[1]);
                //Console.WriteLine(emp.Name);
                emp.address = Convert.ToString(dr[2]);
                //Console.WriteLine(emp.address);
                emp.age = Convert.ToInt32(dr[3]);
                //Console.WriteLine(emp.age);
                Console.WriteLine(emp.Employee_id + " " + emp.Name + " " + emp.address + " " + emp.age);

                e.Add(emp);



            }





        }


    }


    }




    
