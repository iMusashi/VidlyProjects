using System.Linq;
using System.Web.Mvc;
using Vidly.Web.Models;
using Vidly.Web.ViewModels;

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
            //var customers = _context.Customers.Include("MembershipType").ToList();
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include("MembershipType").SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes,
            };
            return View("CustomerForm", viewModel);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var Customer = _context.Customers.Single(x => x.Id == customer.Id);
                Customer.Name = customer.Name;
                Customer.Birthdate = customer.Birthdate;
                Customer.MembershipTypeId = customer.MembershipTypeId;
                Customer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customer = _context.Customers.Single(x => x.Id == id);// Include("MembershipType").
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = customer
            };
            return View("CustomerForm", viewModel);
        }
     }
}