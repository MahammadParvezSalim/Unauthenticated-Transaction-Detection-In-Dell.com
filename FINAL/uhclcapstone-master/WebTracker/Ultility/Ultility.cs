using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTracker.Models;
using System.Data;
using System.Data.SqlClient;
namespace WebTracker.Ultility
{
    public static class Ultility
    {


        private const string webAPI = "webAPI";
        private const string LogPageInfoProcedureName = "dbo.InsertUpdateVisitedPage";
        private const string LogUserInfoProcedureName = "dbo.InsertUpdateUserInfo";
        public static void LogPageInfo(VisitedPage page)
        {
            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;


                using (SqlConnection conn = new SqlConnection(connString))
                {

                    using (SqlCommand cmd = new SqlCommand(LogPageInfoProcedureName, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;


                        //cmd.Parameters.Add("@arg_sessionID", SqlDbType.VarChar).Value = "this.sessionID";
                        //cmd.Parameters.Add("@arg_pathName", SqlDbType.VarChar).Value = "this.pathName";
                        //cmd.Parameters.Add("@arg_url", SqlDbType.VarChar).Value = "this.url";
                        //cmd.Parameters.Add("@arg_visitStartDateTime", SqlDbType.DateTime).Value = DateTime.UtcNow;
                        //cmd.Parameters.Add("@arg_visitEndDateTime", SqlDbType.DateTime).Value = DateTime.UtcNow;
                        cmd.Parameters.Add("@arg_MCMID", SqlDbType.VarChar).Value = page.MCMID;
                        cmd.Parameters.Add("@arg_sessionID", SqlDbType.VarChar).Value = page.sessionID;
                        cmd.Parameters.Add("@arg_pathName", SqlDbType.VarChar).Value = page.pathName;
                        cmd.Parameters.Add("@arg_url", SqlDbType.VarChar).Value = page.url;
                        cmd.Parameters.Add("@arg_referer", SqlDbType.VarChar).Value = page.referer;
                        cmd.Parameters.Add("@arg_visitStartDateTime", SqlDbType.DateTime).Value = page.startDateTime;
                        cmd.Parameters.Add("@arg_visitEndDateTime", SqlDbType.DateTime).Value = page.endDateTime;
                        cmd.Parameters.Add("@arg_lastModifiedUser", SqlDbType.VarChar).Value = webAPI;
                        cmd.Parameters.Add("@arg_lastModifiedDateTime", SqlDbType.DateTime).Value = DateTime.UtcNow;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                //TODO log application error here
            }

        }

        public static void LogUserInfo(UserInfo userInfo )
        {
            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;


                using (SqlConnection conn = new SqlConnection(connString))
                {

                    using (SqlCommand cmd = new SqlCommand(LogUserInfoProcedureName, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@arg_MCMID", SqlDbType.VarChar).Value = userInfo.MCMID;
                        cmd.Parameters.Add("@arg_sessionID", SqlDbType.VarChar).Value = userInfo.sessionID;
                        cmd.Parameters.Add("@arg_FirstName", SqlDbType.VarChar).Value = userInfo.FirstName;
                        cmd.Parameters.Add("@arg_LastName", SqlDbType.VarChar).Value = userInfo.LastName;
                        cmd.Parameters.Add("@arg_MiddleName", SqlDbType.VarChar).Value = userInfo.MiddleName;
                        cmd.Parameters.Add("@arg_StreetAddress", SqlDbType.VarChar).Value = userInfo.StreetAddress;
                        cmd.Parameters.Add("@arg_City", SqlDbType.VarChar).Value = userInfo.City;
                        cmd.Parameters.Add("@arg_State", SqlDbType.VarChar).Value = userInfo.State;
                        cmd.Parameters.Add("@arg_PostalCode", SqlDbType.VarChar).Value = userInfo.PostalCode;
                        cmd.Parameters.Add("@arg_EmailAddress", SqlDbType.VarChar).Value = userInfo.EmailAddress;
                        cmd.Parameters.Add("@arg_TimeStamp", SqlDbType.DateTime).Value = userInfo.TimeStamp;
                        cmd.Parameters.Add("@arg_lastModifiedUser", SqlDbType.VarChar).Value = webAPI;
                        cmd.Parameters.Add("@arg_lastModifiedDateTime", SqlDbType.DateTime).Value = DateTime.UtcNow;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                //TODO log application error here
            }

        }
    }
}