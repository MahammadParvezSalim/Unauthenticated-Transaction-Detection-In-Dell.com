using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTracker.Models;
using System.Data;
using System.Data.SqlClient;
namespace WebTracker.Ultility

{
    public static class UtilityCheckOutPage
    {


        private const string webAPI = "webAPI";
        private const string procedureName = "dbo.InsertUpdateCheckOutPage";
        public static void LogCheckOutPageInfo(CheckoutPage page)
        {
            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;


                using (SqlConnection conn = new SqlConnection(connString))
                {

                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add("@arg_MCMID", SqlDbType.VarChar).Value = page.MCMID;
                        cmd.Parameters.Add("@arg_sessionID", SqlDbType.VarChar).Value = page.sessionID;
                        cmd.Parameters.Add("@arg_CreditNumber", SqlDbType.VarChar).Value = page.CreditNumber;
                        cmd.Parameters.Add("@arg_ExpiryMonth", SqlDbType.Int).Value = page.ExpiryMonth;
                        cmd.Parameters.Add("@arg_ExpiryYear", SqlDbType.Int).Value = page.ExpiryYear;
                        cmd.Parameters.Add("@arg_SecurityCode", SqlDbType.VarChar).Value = page.SecurityCode;
                        cmd.Parameters.Add("@arg_TimeStamp", SqlDbType.DateTime).Value = page.TimeStamp;
                        cmd.Parameters.Add("@arg_lastModifiedUser", SqlDbType.VarChar).Value = webAPI;
                        cmd.Parameters.Add("@arg_lastModifiedDateTime", SqlDbType.DateTime).Value = DateTime.UtcNow;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}