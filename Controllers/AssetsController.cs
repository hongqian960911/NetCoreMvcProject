using IC.Common;
using IC.DataAccess;
using IC.EntityManager;
using Microsoft.AspNetCore.Mvc;
using MvcExample.Data;
using System;

namespace MvcExample.Controllers
{
    public class AssetsController : Controller
    {
        private readonly MvcExampleContext _context;

        public AssetsController(MvcExampleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getCustomersList")]
        public string getCustomersList()
        {
            TX tx = null;
            try
            {
                tx = new TX();
                customerET customerET = new customerET(tx.Connection, tx.myTrans);
                customerField customerField = customerET.SearchByCondition(new customerTerm() { });
                return DATAPROCESS.CreateJsonDataTables(customerField);
            }
            catch (Exception ex)
            {
                return "error:" + ex.Message;
            }
        }
    }
}
