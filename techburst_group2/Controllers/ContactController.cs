using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL.Collections;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactCollection _contact;
        public ContactController(ContactCollection icollection)
        {
            _contact = icollection;
            
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var VVM = new ContactViewModel();
            return View(VVM);
        }

        [HttpPost]
        public ActionResult Create(ContactViewModel vehicle)
        {
            var convertedmodel = ContactViewModel.ConvertContactViewModelToModel(vehicle);
            _contact.Create(convertedmodel);
            TempData["Create"] = "The records has been added to the system!";
            return RedirectToAction("Index");
        }

    }
}
