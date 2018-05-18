using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Web.Models;

namespace Vidly.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include("MembershipType").ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include("MembershipType").SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
     }
}