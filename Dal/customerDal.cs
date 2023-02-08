using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EpfTechHub.Models;

namespace EpfTechHub.Dal
{
    public class customerDal
    {
        //Add the name from the web.config database name

        string conString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();
        //Get all customer
        public List<customer> GetAllFinancials()
        {
            List<customer> customerList = new List<customer>();

            //call the data from the database
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllFinancials";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtCustomer = new DataTable();

                connection.Open();
                sqlDA.Fill(dtCustomer);
                connection.Close();

                foreach (DataRow dr in dtCustomer.Rows)
                {
                    customerList.Add(new customer
                    {

                        firstName = dr["firstName"].ToString(),
                        lastName = dr["lastName"].ToString(),
                        DOB = Convert.ToDateTime(dr["DOB"]),


                    });
                }

            }
            return customerList;
            
            }
        //Insert Customer
        public bool InsertCustomer(customer Customer)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp__InsertCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstName", Customer.firstName);
                command.Parameters.AddWithValue("@lastName", Customer.lastName);
                command.Parameters.AddWithValue("@DOB", Customer.DOB);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}