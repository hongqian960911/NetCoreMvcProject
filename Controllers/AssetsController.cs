using IC.Common;
using IC.DataAccess;
using IC.EntityManager;
using Microsoft.AspNetCore.Mvc;
using NetCoreMvcPeoject.Data;
using System;

namespace NetCoreMvcPeoject.Controllers
{
    public class AssetsController : Controller
    {
        private readonly NetCoreMvcPeojectContext _context;

        public AssetsController(NetCoreMvcPeojectContext context)
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
