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
    public class BookingRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Booking details
        public bool AddBooking(Booking obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewBooking", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BookingID", obj.BookingID);
            com.Parameters.AddWithValue("@UserID", obj.UserID);
            com.Parameters.AddWithValue("@RoomID", obj.RoomID);
            com.Parameters.AddWithValue("@BookingDate", obj.BookingDate);
            com.Parameters.AddWithValue("@StartTime", obj.StartTime);
            com.Parameters.AddWithValue("@EndTime", obj.EndTime);
            com.Parameters.AddWithValue("@Purpose", obj.Purpose);
            com.Parameters.AddWithValue("@Status", obj.Status);

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
        //To view Booking details with generic list 
        public List<Booking> GetAllBookings()
        {
            connection();
            List<Booking> BookingList = new List<Booking>();
            SqlCommand com = new SqlCommand("GetAllBookings", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind Booking generic list using LINQ 
            BookingList = (from DataRow dr in dt.Rows

                        select new Booking()
                        {
                            BookingID = Convert.ToInt32(dr["BookingID"]),
                            UserID = Convert.ToInt32(dr["UserID"]),
                            RoomID = Convert.ToInt32(dr["RoomID"]),
                            BookingDate = Convert.ToDateTime(dr["BookingDate"]),
                            StartTime = Convert.ToDateTime(dr["StartTime"]),
                            EndTime = Convert.ToDateTime(dr["EndTime"]),
                            Purpose = Convert.ToString(dr["Purpose"]),
                            Status = Convert.ToString(dr["Status"])
                        }).ToList();

        
            return BookingList;


        }
        //To Update Booking details
        public bool UpdateBooking(Booking obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateBooking", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BookingID", obj.BookingID);
            com.Parameters.AddWithValue("@UserID", obj.UserID);
            com.Parameters.AddWithValue("@RoomID", obj.RoomID);
            com.Parameters.AddWithValue("@BookingDate", obj.BookingDate);
            com.Parameters.AddWithValue("@StartTime", obj.StartTime);
            com.Parameters.AddWithValue("@EndTime", obj.EndTime);
            com.Parameters.AddWithValue("@Purpose", obj.Purpose);
            com.Parameters.AddWithValue("@Status", obj.Status);
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
        //To delete Booking details
        public bool DeleteBooking(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteBooking", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BookingID", Id);

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