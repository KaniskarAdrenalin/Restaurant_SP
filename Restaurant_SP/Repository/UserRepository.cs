using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Restaurant_SP.DAL;
using System.Data;

namespace Restaurant_SP.Repository
{
    public class UserRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add User details
        public bool AddUser(User obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserID", obj.UserID);
            com.Parameters.AddWithValue("@Username", obj.Username);
            com.Parameters.AddWithValue("@Password", obj.Password);
            com.Parameters.AddWithValue("@Email", obj.Email);


            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        //To view User details with generic list 
        public List<User> GetAllUsers()
        {
            connection();
            List<User> UserList = new List<User>();
            SqlCommand com = new SqlCommand("GetAllUsers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind User generic list using LINQ 
            UserList = (from DataRow dr in dt.Rows

                        select new User()
                        {
                            UserID = Convert.ToInt32(dr["UserID"]),
                            Username = Convert.ToString(dr["Username"]),
                            //Password = Convert.ToInt32(dr["Password"]),
                            Email = Convert.ToString(dr["Email"]),
                        }).ToList();


            return UserList;


        }
        //To Update User details
        public bool UpdateUser(User obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateUser", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserID", obj.UserID);
            com.Parameters.AddWithValue("@Username", obj.Username);
            com.Parameters.AddWithValue("@Password", obj.Password);
            com.Parameters.AddWithValue("@Email", obj.Email);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        //To delete User details
        public bool DeleteUser(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteUser", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserID", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
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