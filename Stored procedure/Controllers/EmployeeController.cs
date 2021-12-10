using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stored_procedure.Data;
using Stored_procedure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoredProc.Controllers
{
    public class EmployeeController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config { get; }
        public EmployeeController(StoredProcDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Employee> SearchResult()
        {
            var result = _context.Employee.FromSqlRaw<Employee>("spSearchEmployees").ToList();
            return result;
        }

        [HttpGet]
        public IActionResult DynamicSQL()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        /// <summary>
        /// SearchPageWithoutDynamicSQL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DynamicSQL(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (firstName != null)
                {
                    SqlParameter param_fn = new SqlParameter("@FirstName", firstName);
                    cmd.Parameters.Add(param_fn);
                }
                if (lastName != null)
                {
                    SqlParameter param_ln = new SqlParameter("@LastName", lastName);
                    cmd.Parameters.Add(param_ln);
                }
                if (gender != null)
                {
                    SqlParameter param_g = new SqlParameter("@Gender", gender);
                    cmd.Parameters.Add(param_g);
                }
                if (salary != 0)
                {
                    SqlParameter param_s = new SqlParameter("@Salary", salary);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SearchWithDynamic()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SearchWithDynamic(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                StringBuilder stringBuilder = new StringBuilder("Select * from Employees where 1 = 1");

                if (firstName != null)
                {
                    stringBuilder.Append(" AND FirstName=@FirstName");
                    SqlParameter param_fn = new SqlParameter("@FirstName", firstName);
                    cmd.Parameters.Add(param_fn);
                }
                if (lastName != null)
                {
                    SqlParameter param_ln = new SqlParameter(" AND LastName=@LastName", lastName);
                    cmd.Parameters.Add(param_ln);
                }
                if (gender != null)
                {
                    SqlParameter param_g = new SqlParameter(" AND Gender=@Gender", gender);
                    cmd.Parameters.Add(param_g);
                }
                if (salary != 0)
                {
                    SqlParameter param_s = new SqlParameter(" AND Salary=@Salary", salary);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult StoredInformation()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.Age = Convert.ToInt32(sdr["Age"]);
                    details.Criminal_Record = sdr["Criminal_Record"].ToString();
                    details.Address = sdr["Address"].ToString();
                    details.Phone_Number = sdr["Phone_Number"].ToString();
                    details.Opinion_On_Personality = sdr["Opinion_On_Personality"].ToString();
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult StoredInformation(int Age, string Criminal_Record, string Address, string Phone_Number, string Opinion_On_Personality)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                StringBuilder stringBuilder = new StringBuilder("Select * from Employees where 1 = 1");

                if (Criminal_Record != null)
                {
                    stringBuilder.Append(" AND Criminal_Record=@Criminal_Record");
                    SqlParameter param_fn = new SqlParameter("@Criminal_Record", Criminal_Record);
                    cmd.Parameters.Add(param_fn);
                }
                if (Address != null)
                {
                    SqlParameter param_ln = new SqlParameter(" AND Address=@Address", Address);
                    cmd.Parameters.Add(param_ln);
                }
                if (Phone_Number != null)
                {
                    SqlParameter param_g = new SqlParameter(" AND Phone_Number=@Phone_Number", Phone_Number);
                    cmd.Parameters.Add(param_g);
                }
                if (Opinion_On_Personality != null)
                {
                    SqlParameter param_g = new SqlParameter(" AND Opinion_On_Personality=@Opinion_On_Personality", Opinion_On_Personality);
                    cmd.Parameters.Add(param_g);
                }
                if (Age != 0)
                {
                    SqlParameter param_s = new SqlParameter(" AND Age=@Age", Age);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.Age = Convert.ToInt32(sdr["Age"]);
                    details.Criminal_Record = sdr["Criminal_Record"].ToString();
                    details.Address = sdr["Address"].ToString();
                    details.Phone_Number = sdr["Phone_Number"].ToString();
                    details.Opinion_On_Personality = sdr["Opinion_On_Personality"].ToString();
                    model.Add(details);
                }
                return View(model);
            }
        }

        // public int Age { get; set; }
        // public string Criminal_Record { get; set; }
        // public string Address { get; set; }
        // public DateTime Date_Of_Birth { get; set; }
        // public string Opinion_On_Personality { get; set; }
    }
}