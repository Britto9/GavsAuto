using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleWebApp1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/todos");
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();

            GetAPIData();

            GetSqlData();

            GetDBData();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            GetAPIData();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            GetSqlData();

            return View();
        }

        private void GetAPIData()
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("http://10.0.14.204:2027/api/Billing/PaymentGatewayAPI");
            request1.Method = "GET";
            request1.ContentType = "application/json";
            WebResponse response1 = request1.GetResponse();
        }


        private void GetDBData()
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("http://10.0.14.100:2020/api/Billing/PaymentGatewayAPI");
            request1.Method = "GET";
            request1.ContentType = "application/json";
            WebResponse response1 = request1.GetResponse();
        }

        private void GetSqlData()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=10.0.14.114;Initial Catalog=OperationsManager;uid=sa; Password=gavs_123;");
                string qryString = "SELECT * FROM LICENSE WHERE LICENSEID=1";
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                string name = "";

                cmd.CommandText = qryString;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        name = reader.GetString(5);
                        break;
                    }
                }
                else
                {
                    // Console.WriteLine("No rows found.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}