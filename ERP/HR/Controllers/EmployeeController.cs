using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Models;

namespace HR.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEmployee(Employee objEmployee)
        {
            string employeeName = objEmployee.Name;
            string employeeEmail = objEmployee.Email;
            string connectionString = ConfigurationManager.ConnectionStrings["dbERPConnection"].ToString();
            var sql = @"INSERT INTO [Employee]
               ([Name], [EmployeeEmail]
        
		       )
                VALUES (" +
               "'" + employeeName + "'" +
                ",'" + employeeEmail + "'" +
               " );";
            
            SaveEmployee(connectionString, sql);
            return View();
        }

        private static void SaveEmployee(string connectionString, string sql)
        {
            try
            {
                var myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                new SqlCommand(sql, myConnection).ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception msgError)
            {

                throw msgError;
            }
        }

        public ActionResult ShowEmployee()
        {
            return View();
        }


    }
}