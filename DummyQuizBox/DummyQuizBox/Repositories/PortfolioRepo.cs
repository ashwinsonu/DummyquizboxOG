using DummyQuizBox.Entities;
using DummyQuizBox.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DummyQuizBox.Repositories
{
    public class PortfolioRepo : IPortfolioRepo
    {
        private readonly IConfiguration config;

        public PortfolioRepo(IConfiguration _config)
        {
            this.config = _config;
        }

        public async Task<IEnumerable<Portfolio>> GetAll()
        {
           
            List<Portfolio> portfolios = new List<Portfolio>();
            try
            {
                using (SqlConnection con = new SqlConnection(config.GetConnectionString("cons")))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * from portfolio"))
                    {
                        cmd.Connection = con;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                portfolios.Add(new Portfolio
                                {
                                    ID = dr.GetGuid(dr.GetOrdinal("ID")),
                                    Name = Convert.ToString(dr["Name"]),
                                    isActive = Convert.ToBoolean(dr["isActive"]),
                                    isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                                    CreatedDate = Convert.ToDateTime(dr["CreatedDate"])
                                });


                            }
                        }
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            { }

            return portfolios;

        }


        public async Task<Portfolio> GetPortfolio(Guid id)
        {
            Portfolio portfolios = new Portfolio();
            string query = "Select * from portfolio where ID = '" + id + "'";
            using (SqlConnection con = new SqlConnection(config.GetConnectionString("cons")))
            {
                using SqlCommand cmd =new SqlCommand(query, con);
                {
                    cmd.Connection=con;
                    cmd.Parameters.AddWithValue("ID", id);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            portfolios = new Portfolio
                            {
                                ID = dr.GetGuid(dr.GetOrdinal("ID")),
                                Name = Convert.ToString(dr["Name"]),
                                isActive = Convert.ToBoolean(dr["isActive"]),
                                isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                                CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                            };
                        }
                    }
                    con.Close();

                }
                if (portfolios == null)
                { return null; }
                return portfolios;

            }


        }


        public async Task<bool> AddPortfolio(Portfolio portfolio)
        {
            using (SqlConnection con = new SqlConnection(config.GetConnectionString("cons")))
            {
                //how to get unique Guid and date how tyo autoinsert guid and date 
                string query = "insert into portfolio values(NEWID(),@name, @isActive, @isDeleted,@CreatedDate) ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ID", portfolio.ID);
                    cmd.Parameters.AddWithValue("@name", portfolio.Name);
                    cmd.Parameters.AddWithValue("@isActive", portfolio.isActive);
                    cmd.Parameters.AddWithValue("@isDeleted", portfolio.isDeleted);
                    cmd.Parameters.AddWithValue("@CreatedDate", portfolio.CreatedDate);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        return true;
                    }
                    con.Close();

                }
            }
            return false;


        }


        public async Task<bool> DeletePortfolio(Guid ID)
        {
            using (SqlConnection con = new SqlConnection(config.GetConnectionString("cons")))
            {
                string query = "Delete from portfolio where ID= '" + ID + "'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        return true;

                    }
                    con.Close();
                }

            }
            return false;

        }

        public async Task<bool> UpdatePortfolio(Guid ID, Portfolio portfolio)
            //how to update date and guid 
        {
            string query = "UPDATE  portfolio SET   name=@name, isActive= @isActive ,isDeleted=@isDeleted where id ='" + ID + "'";
            using (SqlConnection con = new SqlConnection(config.GetConnectionString("cons")))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@name", portfolio.Name);
                    cmd.Parameters.AddWithValue("@isActive", portfolio.isActive);
                    cmd.Parameters.AddWithValue("@isDeleted", portfolio.isDeleted);
                    con.Open(); 
                    int i =cmd.ExecuteNonQuery();
                    if (i > 0)
                    { return true; }
                    con.Close();    

                }
            }
            return false;

        }







    }
}


