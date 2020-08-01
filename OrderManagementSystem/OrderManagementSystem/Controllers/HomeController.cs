using DataRepository;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;

namespace OrderManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            //IRepository<Customer> repository = unitOfWork.Repository<Customer>();

            //var data = repository.GetAll().ToList();

            var sqlParameter = new List<SqlParameter> 
            {
                new SqlParameter
                {
                    ParameterName = "@CUSTID",
                    Direction = System.Data.ParameterDirection.Input,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = "CAA004"
                }
            };

            var sp = unitOfWork.ExecuteReader<CustomerOrders>("USP_GET_CUSTOMERORDERS", sqlParameter.ToArray());



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}