using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using static WebApplication1.Models.ContactsModel;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ContactsContext dbc = new ContactsContext();

        public IActionResult Index()
        {
            IEnumerable<Contacts> _viewModel;
            _viewModel = dbc.Contacts.AsEnumerable();
            return View(_viewModel);
        }

        public IActionResult Add()
        {
            IEnumerable<Contacts> _viewModel;
            _viewModel = dbc.Contacts.AsEnumerable();
            return View(_viewModel);
        }

        [HttpPost]
        public IActionResult Add(string fname, string lname, string num)
        {
            Contacts newContacts = new Contacts
            {
                Fname = fname,
                Lname = lname,
                Num = num,
            };
            dbc.Contacts.Add(newContacts);
            dbc.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
