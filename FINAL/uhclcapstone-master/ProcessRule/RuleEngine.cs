using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
namespace ProcessRule
{
    public static class RuleEngine
    {


        /// <summary>
        /// This fuction runs between startTime and endTime.
        /// After each run, it sleeps for a specified seconds and repeats the process untill passing endtime
        /// </summary>
        public static void Run()
        {
            int startTime;
            int endTime;
            int sleepTime;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["startTime"].ToString(), out startTime);
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["endTime"].ToString(), out endTime);
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["SleepTimeSecond"].ToString(), out sleepTime);


            Dictionary<int, string> ruleList = new Dictionary<int, string>();
            try
            {


                sleepTime = sleepTime * 1000;
                Console.WriteLine("Start time: {0} - End time : {1}", startTime, endTime);


                ruleList = GetRules();
                while (DateTime.Now.Hour >= startTime & DateTime.Now.Hour <= endTime)
                {

                    foreach (KeyValuePair<int, string> rule in ruleList)
                    {
                        ExecuteRule(rule.Value);
                    }
                    System.Threading.Thread.Sleep(sleepTime);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Method: {0} - Error Message: {1}", MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }


        /// <summary>
        /// GetRules routine
        ///     1-  Executes procedure to retrieve a list of rule procedures from database.
        ///     2-  Returns rule ids and procedure name
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, string> GetRules()
        {
            Dictionary<int, string> ruleList = new Dictionary<int, string>();

            try
            {
                string procedureName = "[dbo].[GetProcessRule]";
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(procedureName, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (!ds.Tables[0].HasErrors)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ruleList.Add(int.Parse(row["RuleID"].ToString()), row["RuleProcedure"].ToString());
                            }
                        }

                        ds.Dispose();

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Method: {0} - Error Message: {1}", MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            return ruleList;

        }

        private static void ExecuteRule(string procedureName)
        {
            try
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(procedureName, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (!ds.Tables[0].HasErrors)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                Console.WriteLine(row["Message"].ToString());
                            }
                        }
                        ds.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Method: {0} - Error Message: {1}", MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }


    }
}
