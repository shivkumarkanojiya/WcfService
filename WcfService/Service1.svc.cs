using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WcfService
{

    public class Service1 : IService1
    {
        string Con = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public string InsertUser(UserDetails user)
        {
            string msg = "";
            try
            {
                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand("InsUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a == 1)
                {
                    msg = "Record Added Successfully";
                }
                else
                {
                    msg = "Record Not Add";
                }
                con.Close();

                return msg;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //update
        public string UpdateUser(UserDetails user)
        {
            string msg = "";
            try
            {
                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand("UpdateUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                con.Open();
               int b= cmd.ExecuteNonQuery();
                if(b==1)
                {
                    msg = "Record Updated Successfully";
                }
                else
                {
                    msg = "Record Not Updated";
                }
                con.Close();

                return msg;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //Delete
        public string DeleteUser(UserDetails user)
        {
            string msg = "";
            try
            {
                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand("DeleteUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                con.Open();
                int re = cmd.ExecuteNonQuery();
                con.Close();
                if (re == 1)
                {
                    msg= "Record Deleted Successfully";
                }
                else
                {
                    msg= "Record Not Deleted";
                }
                return msg;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Get data
        public List<UserDetails> GetListData(UserDetails user)
        {
            SqlConnection con = new SqlConnection(Con);
            try
            {

                SqlCommand cmd = new SqlCommand("SelectUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<UserDetails> lstuser = new List<UserDetails>();
                while (sdr.Read())
                {

                    UserDetails us = new UserDetails();
                    us.UserID = Convert.ToInt32(sdr["UserID"]);
                    us.Name = sdr["Name"].ToString();
                    us.Email = sdr["Email"].ToString();

                    lstuser.Add(us);
                }

                return lstuser;


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
